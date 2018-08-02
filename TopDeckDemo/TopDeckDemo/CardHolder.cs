using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDeckDemo
{
    class CardHolder
    {
        private List<Card> cards;

        public CardHolder() { cards = new List<Card>(); }
        public CardHolder(List<Card> cards) { this.cards = cards; }

        // Get property: returns size of 'cards' list.
        public int Size { get { return cards.Count(); }}

        // Draws/returns the top card from 'cards' and rmeoves it from the list.
        Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        // Adds a card to 'cards' at an indescriminate position.
        internal void Add(Card card)
        {
            cards.Add(card);
        }

        // Adds a card to 'cards' at a specified position.
        internal void Add(Card card, int index)
        {
            cards.Insert(index, card);
        }

        // Shuffles the 'cards' by splitting the cards into 2 piles and combining them.
        // This can be done 'iter' times.
        internal void ShuffleTopBottom(int iter)
        {
            for (int i = 0; i < iter; i++)                      // repeat this loop segment for x iterations:
            {
                CardHolder pile1 = new CardHolder();            // are these CardHolders in the right spot in the loop?
                CardHolder pile2 = new CardHolder();
                for (int j = 0; j <= cards.Count(); j++)        // for every card in 'cards', put it into 2 piles, alternating.
                {
                    if (j % 2 == 0)
                    {
                        pile1.Add(cards[j]);
                    }
                    else
                    {
                        pile2.Add(cards[j]);
                    }
                }
                cards.Clear();                                  // confirm there are no duplicate entries in 'cards'.
                for(int k = 0; k < pile1.Size; k++)             // for every card in each pile, add them back to 'cards.'
                {
                    cards.Add(pile1.Draw());
                }
                for (int k = 0; k < pile2.Size; k++)
                {
                    cards.Add(pile2.Draw());
                }
            }

        }

        // Shuffles 'cards' bridge-style, taking 2 piles and combining them from the bottom up.
        // This can be done 'iter' times.
        internal void ShuffleBridge(int iter)
        {

        }

        // Prints a copy of the CardHolder and all its Card objects.
        // This is for debug and will be refactored into real gameplay.
        internal void PrintStack()
        {
            StringBuilder sb = new StringBuilder();
            int k = cards.Count();
            sb.AppendLine("holder contains " + k + " entities");
            for (int i = 0; i < k; i++)
            {
                sb.AppendLine("pos " + i + ": " + cards[i].Name);
            }
            Console.Write(sb);
        }
    }
}

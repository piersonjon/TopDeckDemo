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
        private Command c;

        public CardHolder() { cards = new List<Card>(); }
        public CardHolder(int size) { cards = new List<Card>(size); }

        // Get property: returns size of 'cards' list.
        public int Size { get { return cards.Count(); }}

        // Draws/returns the top card from 'cards' and rmeoves it from the list.
        internal Card Draw()
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

        // Checks if a card exists at a defined index.
        // Has a security against out-of-range indexes.
        // Null-checking the object position may not be a catch-all solution.
        // Test more on this later. 8/6/18
        internal bool CardAt(int index)
        {
            try
            {
                if (cards[index] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
        }

        // Shuffles the 'cards' by splitting the cards into 2 piles and combining them.
        // This can be done 'iter' times.

        // This style of shuffling seems to be considerably less "random" than we would hope, so using this
        // in the future may be a bad move. An interesting way to learn about Properties and their behavior. 8/5/18
        internal void ShuffleTopBottom(int iter)
        {
            for (int i = 0; i < iter; i++)                      // repeat this loop segment for x iterations:
            {
                CardHolder pile1 = new CardHolder();            // are these CardHolders in the right spot in the loop?
                CardHolder pile2 = new CardHolder();
                for (int j = 0; j < cards.Count; j++)        // for every card in 'cards', put it into 2 piles, alternating.
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
                int p1 = pile1.Size;
                int p2 = pile2.Size;
                for(int k = 0; k < p1; k++)             // for every card in each pile, add them back to 'cards.'
                {
                    cards.Add(pile1.Draw());
                }
                for (int k = 0; k < p2; k++)
                {
                    cards.Add(pile2.Draw());
                }
            }

        }

        // Shuffles 'cards' bridge-style, taking 2 piles and combining them from the bottom up.
        // This can be done 'iter' times.

        // not working for now
        internal void ShuffleBridge(int iter)
        {
            for (int i = 0; i < iter; i++)                      // repeat this loop segment for x iterations:
            {
                CardHolder pile1 = new CardHolder();            // are these CardHolders in the right spot in the loop?
                CardHolder pile2 = new CardHolder();
                for (int j = 0; j < cards.Count; j++)        // for every card in 'cards', put it into 2 piles, top-bottom.
                {
                    if (j < (cards.Count / 2))
                    {
                        pile1.Add(cards[j]);
                    }
                    else
                    {
                        pile2.Add(cards[j]);
                    }
                }
                cards.Clear();                                  // confirm there are no duplicate entries in 'cards'.
                int p1 = pile1.Size;
                int p2 = pile2.Size;
                for (int j = 0; j < cards.Count; j++)        // for every card in 'cards', put them back into 'cards', alternating.
                {
                    if (j % 2 == 0)
                    {
                        cards.Add(pile1.Draw());
                    }
                    else
                    {
                        cards.Add(pile2.Draw());
                    }
                }
            }
        }

        // randomly reorders all objects in the CardHolder.
        internal void Shuffle()
        {
            int x = cards.Count;
            Command c = new Command();
            List<Card> ch = new List<Card>(x);
            for (int i = x; i > 0; i--)
            {
                int r = c.Random(i);
                Card card = cards[r-1];
                ch.Add(card);
                cards.RemoveAt(r-1);
            }
            cards = ch;
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

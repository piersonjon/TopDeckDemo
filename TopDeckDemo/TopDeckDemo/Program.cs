using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDeckDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            Command c = new Command();

            CardHolder test = new CardHolder();
            Card c1 = new Card("Card 1");
            Card c2 = new Card("Card 2");
            Card c3 = new Card("Card 3");
            Card c4 = new Card("Card 4");
            Card c5 = new Card("Card 5");
            Card c6 = new Card("Card 6");
            Card c7 = new Card("Card 7");
            Card c8 = new Card("Card 8");
            Card c9 = new Card("Card 9");
            Card c10 = new Card("Card 10");
            test.Add(c1);
            test.Add(c2);
            test.Add(c3);
            test.Add(c4);
            test.Add(c5);
            test.Add(c6);
            test.Add(c7);
            test.Add(c8);
            test.Add(c9);
            test.Add(c10);

            test.PrintStack();
            test.Shuffle();
            test.PrintStack();
            
            sb.AppendLine("Compile OK. Press any key...");
            Console.Write(sb);
            Console.ReadLine();
        }
    }
}

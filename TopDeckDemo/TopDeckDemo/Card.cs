using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDeckDemo
{
    class Card
    {
        private string name;
        private string desc;

        public Card()
        {
            name = "";
            desc = "";
        }

        public Card(string name)
        {
            this.name = name;
            desc = "";
        }

        public Card(string name, string desc)
        {
            this.name = name;
            this.desc = desc;
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Desc
        {
            get { return desc; }
            set { this.desc = value; }
        }
    }
}

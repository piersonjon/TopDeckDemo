using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TopDeckDemo
{
    class Command
    {
        // Returns a random number between 1 and 'max', inclusive.
        // Uses an instantiated RNGCryptoServiceProvider to allow for more random number generation.
        // Thanks, Shivprasad Koirala! (stackoverflow.com/questions/2706500)
        public int Random(int max)
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[2];
                rg.GetBytes(rno);
                int randomvalue = (BitConverter.ToUInt16(rno, 0) % max) + 1;
                return randomvalue;
            }
        }
    }
}

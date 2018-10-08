using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class StringGenerator : IGenerator
    {
        private static string symbols = "1234567890-=!@#$%^&*()_+qwertyuiop[]asdfghjkl;'zxcvbnm,.QWERTYUIOP{}ASDFGHJKL:\"ZXCVBNM<>?";
        public Type TargetType { get; }

        public StringGenerator()
        {
            TargetType = typeof(string);
        }

        public object Generate()
        {
            string res = "";
            Random rand = new Random();
            int length = rand.Next(30);
            for (int i = 0; i < length; ++i)
                res += symbols[rand.Next(symbols.Length)];
            return res;
        }
    }
}

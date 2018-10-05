using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
        public class IntGenerator : IGenerator
        {
            public object Generate()
            {
                Random rand = new Random();
                int res = rand.Next();
                return res;
            }
        }

    public class LongGenerator : IGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            long res = rand.Next();
            return res;
        }
    }

    public class ByteGenerator : IGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            byte res = (byte)rand.Next();
            return res;
        }
    }
    public class ShortGenerator : IGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            short res = (short)rand.Next();
            return res;
        }
    }
    public class CharGenerator : IGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            char res =  (char)rand.Next();
            return res;
        }
    }
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            float res = (float)(rand.Next() + rand.NextDouble());
            return res;
        }
    }

    public class DoubleGenerator : IGenerator
        {
            public object Generate()
            {
                Random rand = new Random();
                double res = rand.Next() + rand.NextDouble();
                return res;
            }
        }
}

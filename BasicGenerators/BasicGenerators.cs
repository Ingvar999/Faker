using System;
using Interface;

namespace BasicGenerators
{
    public class IntGenerator : IGenerator
    {
        public Type TargetType { get; }

        public IntGenerator()
        {
            TargetType = typeof(int);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int res = rand.Next();
            return res;
        }
    }

    public class LongGenerator : IGenerator
    {
        public Type TargetType { get; }

        public LongGenerator()
        {
            TargetType = typeof(long);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            long res = rand.Next();
            return res;
        }
    }

    public class ByteGenerator : IGenerator
    {
        public Type TargetType { get; }

        public ByteGenerator()
        {
            TargetType = typeof(byte);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            byte res = (byte)rand.Next();
            return res;
        }
    }
    public class ShortGenerator : IGenerator
    {
        public Type TargetType { get; }

        public ShortGenerator()
        {
            TargetType = typeof(short);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            short res = (short)rand.Next();
            return res;
        }
    }
    public class CharGenerator : IGenerator
    {
        public Type TargetType { get; }

        public CharGenerator()
        {
            TargetType = typeof(char);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            char res = (char)rand.Next();
            return res;
        }
    }
    public class FloatGenerator : IGenerator
    {
        public Type TargetType { get; }

        public FloatGenerator()
        {
            TargetType = typeof(float);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            float res = (float)(rand.Next() + rand.NextDouble());
            return res;
        }
    }

    public class DoubleGenerator : IGenerator
    {
        public Type TargetType { get; }

        public DoubleGenerator()
        {
            TargetType = typeof(double);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            double res = rand.Next() + rand.NextDouble();
            return res;
        }
    }

    public class BoolGenerator : IGenerator
    {
        public Type TargetType { get; }

        public BoolGenerator()
        {
            TargetType = typeof(double);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            bool res = rand.Next(2) > 0;
            return res;
        }
    }
}

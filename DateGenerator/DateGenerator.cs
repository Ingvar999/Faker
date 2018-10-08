using System;
using Interface;

namespace FakerLib
{
    class DateGenerator : IGenerator
    {
        public Type TargetType { get; }

        public DateGenerator()
        {
            TargetType = typeof(DateTime);
        }

        public object Generate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            DateTime res = new DateTime((long)rand.Next() << 28);
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class DateGenerator : IGenerator
    {
        public object Generate()
        {
            Random rand = new Random();
            DateTime res = new DateTime((long)rand.Next() << 28);
            return res;
        }
    }
}

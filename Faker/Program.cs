using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib;
using DTOLib;

namespace FakerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker();
            DTO1 obj = faker.Create<DTO1>();
        }
    }
}

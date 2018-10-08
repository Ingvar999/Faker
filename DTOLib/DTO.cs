using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLib
{
    public abstract class DTO
    {
    }

    public class DTO1 : DTO
    {
        public int intField;
        public float floatField;
        public byte byteField;
        public char charField;
        protected int protectedField;
        public int Property { get; set; }
        public DateTime dat;
        public string str;
        public int[] array;
        public DTO1 dto;

        public DTO1() { }

        public DTO1(int a)
        {
            protectedField = a;
        }
    }
}

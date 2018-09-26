using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DTOLib;

namespace FakerLib
{
    public class Faker
    {
        public T Create<T>() where T: DTO, new()
        {
            T res = new T();
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();
            return res;
        }
    }
}

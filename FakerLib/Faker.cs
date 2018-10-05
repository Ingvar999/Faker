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
        private Dictionary<int, IGenerator> generatorsList;

        public Faker() {
            
        }

        public Faker(string pluginsPath)
        {
            generatorsList = new Dictionary<int, IGenerator>
            {
                { typeof(int).GetHashCode(), new IntGenerator() },
                { typeof(double).GetHashCode(), new DoubleGenerator() },
                { typeof(float).GetHashCode(), new FloatGenerator() },
                { typeof(long).GetHashCode(), new LongGenerator() },
                { typeof(byte).GetHashCode(), new ByteGenerator() },
                { typeof(short).GetHashCode(), new ShortGenerator() },
                { typeof(char).GetHashCode(), new CharGenerator() },
                { typeof(string).GetHashCode(), new StringGenerator() },
                { typeof(DateTime).GetHashCode(), new DateGenerator() }
            };
        }

        public T Create<T>() where T: DTO, new()
        {
            T res = new T();
            FieldInfo[] fields = typeof(T).GetFields();
            foreach (var field in fields) {
                int hash = field.FieldType.GetHashCode();
                if (generatorsList.TryGetValue(hash, out IGenerator generator))
                    field.SetValue(res, generator.Generate());
            }
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                int hash = property.PropertyType.GetHashCode();
                if (generatorsList.TryGetValue(hash, out IGenerator generator))
                    property.SetValue(res, generator.Generate());
            }
            return res;
        }
    }
}

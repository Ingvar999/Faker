using System;
using System.Reflection;
using DTOLib;

namespace FakerCoreLib
{
    public class Faker
    {
        public T Create<T>() where T : DTO, new()
        {
            T res = new T();
            FieldInfo[] fields = typeof(T).GetFields();
            foreach (var field in fields)
            {
                if (field.FieldType.IsPrimitive)
                {
                    object val = field.GetValue(res);
                    BitConverter.TryWriteBytes(new Span<byte>(), val);
                }
                field.SetValue(res, 5);
            }
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(res, 4);
            }
            return res;
        }
    }
}

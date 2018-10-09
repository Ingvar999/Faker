using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Interface;
using System.IO;
using System.Reflection;
using DTOLib;

namespace FakerLib
{
    public class Faker
    {
        private Dictionary<int, IGenerator> generatorsList;
        private Dictionary<int, int> creationsStack;

        public Faker()
            : this("D:\\git\\СПП\\Faker\\Generators")
        {
            
        }

        public Faker(string pluginsPath)
        {
            generatorsList = new Dictionary<int, IGenerator>();
            creationsStack = new Dictionary<int, int>();
            InitPlugins(pluginsPath);
        }

        private void InitPlugins(string pluginsPath)
        {
            string[] files = System.IO.Directory.GetFiles(pluginsPath, "*.dll");
            
            foreach (string file in files)
            {
                Assembly assembly = Assembly.Load(File.ReadAllBytes(file));
                foreach (Type type in assembly.GetTypes())
                {
                    Type iface = type.GetInterface("IGenerator");
                    if (iface != null)
                    {
                        IGenerator generator = (IGenerator)Activator.CreateInstance(type);
                        if (!generatorsList.ContainsKey(generator.TargetType.GetHashCode()))
                            generatorsList.Add(generator.TargetType.GetHashCode(), generator);
                    }
                }
            }
        }

        private object CreateByConstructor(Type T)
        {
            ConstructorInfo[] constructors = T.GetConstructors();
            ConstructorInfo constructor = constructors[0];
            for (int i = 1; i < constructors.Length; ++i)
                if (constructors[i].GetParameters().Length > constructor.GetParameters().Length)
                    constructor = constructors[i];
            ParameterInfo[] parameters = constructor.GetParameters();
            object[] args = new object[parameters.Length];
            for (int i = 0; i < args.Length; ++i)
                if (generatorsList.TryGetValue(parameters[i].ParameterType.GetHashCode(), out IGenerator generator))
                    args[i] = generator.Generate();
            return constructor.Invoke(args);
        }

        private object GenerateArray(Type T)
        {
            var arr = T.GetConstructor(new Type[] { typeof(int) }).Invoke(new object[] { 5 });
            var temp = Activator.CreateInstance(typeof(List<>).MakeGenericType(T.GetElementType()));
            int hash = T.GetElementType().GetHashCode();
            if (generatorsList.TryGetValue(hash, out IGenerator generator))
            {
                for (int i = 0; i < 5; ++i)
                    ((IList)temp).Add(generator.Generate());
                ((IList)temp).CopyTo((Array)arr, 0);
            }
            return arr;
        }

        private object GenerateDTO(Type T)
        {
            if (creationsStack.TryGetValue(T.GetHashCode(), out int value))
            {
                if (value >= 2)
                    return null;
                creationsStack[T.GetHashCode()] = value + 1;
            }
            else
                creationsStack.Add(T.GetHashCode(), 1);
            object res = CreateByConstructor(T);

            FieldInfo[] fields = T.GetFields();
            foreach (var field in fields)
            {
                if (field.FieldType.IsArray)
                {
                    field.SetValue(res, GenerateArray(field.FieldType));
                }
                else
                {
                    if (field.FieldType.IsSubclassOf(typeof(DTO)))
                    {
                        field.SetValue(res, GenerateDTO(field.FieldType));
                    }
                    else
                    {
                        int hash = field.FieldType.GetHashCode();
                        if (generatorsList.TryGetValue(hash, out IGenerator generator))
                            field.SetValue(res, generator.Generate());
                    }
                }
            }
            PropertyInfo[] properties = T.GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType.IsArray)
                {
                    property.SetValue(res, GenerateArray(property.PropertyType));
                }
                else
                {
                    if (property.PropertyType.IsSubclassOf(typeof(DTO)))
                    {
                        property.SetValue(res, GenerateDTO(property.PropertyType));
                    }
                    else
                    {
                        int hash = property.PropertyType.GetHashCode();
                        if (generatorsList.TryGetValue(hash, out IGenerator generator))
                            property.SetValue(res, generator.Generate());
                    }
                }
            }
            creationsStack[T.GetHashCode()]--;
            return res;
        }

        public T Create<T>() where T: DTO
        {
            return (T)GenerateDTO(typeof(T));
        }
    }
}

﻿using System;
using System.Reflection;
using System.IO;


namespace Lab_14
{
    interface ITrans
    {
        void Info(string str);
    }
    interface ITransport
    {
        string name { get; set; }
        string purpose { get; set; }
        string weight { get; set; }
        string wings { get; set; }
        string engine { get; set; }

        void Info();

    }

    [Serializable]

    public class Transport : ITrans, ITransport
    {
        public string name { get; set; }
        public string purpose { get; set; }
        public string weight { get; set; }
        public string wings { get; set; }
        public string engine { get; set; }

        public int yeahr { get; set; }

        public void Info()
        {
            if (yeahr < 20)
            {
                Console.WriteLine("Самолёт пригоден к эксплутации");
            }
            else
            {
                Console.WriteLine("Самолёт не пригоден к эксплутации");
            }
        }
        public void Info(string str)
        {
            Console.WriteLine(str);
        }

        public virtual void addInfo()
        {
            Console.WriteLine("название самолёта");
            name = Console.ReadLine();

            Console.WriteLine("задача данного самолёта");
            purpose = Console.ReadLine();

            Console.WriteLine("вес данного самолёта");
            weight = Console.ReadLine();

            Console.WriteLine("количество крыльев");
            wings = Console.ReadLine();

            Console.WriteLine("количество двигателей");
            engine = Console.ReadLine();

            Console.WriteLine("как долго находится в эксплутации?");
            yeahr = Int32.Parse(Console.ReadLine());

        }
        public virtual void Type()
        {
            Console.WriteLine("Транспорт");
        }

        public Transport()
        {
            
        }

    }


    [Serializable]
    class Aviation : Transport
    {
        string Form { get; set; }
        public override void Type()
        {
            Console.WriteLine("Транспорт - Авиация");
        }

    }

    [Serializable]
    class Cargo : Transport
    {
        public override void Type()
        {
            Console.WriteLine("Грузовой самолёт");
        }

    }
    [Serializable]
    class Military : Transport
    {
        public override void Type()
        {
            Console.WriteLine("Военный самолёт");
        }
    }
    class Pasanger : Transport
    {
        public override void Type()
        {
            Console.WriteLine("Пассажирский самолёт");
        }

    }

    sealed class Ty134 : Transport
    {
        public override void Type()
        {
            Console.WriteLine("Ty134");
        }
    }

    [Serializable]
    public class Boing : Transport
    {
        public override void Type()
        {
            Console.WriteLine("Boing");
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Transport transport = obj as Transport;
            if (transport as Transport == null)
            {
                return false;
            }
            return transport.name == this.name;
        }
    }

    class Reflector
    {
        public static void ShowInfo(object obj)
        {
            StreamWriter sw = new StreamWriter(@"InfoFile.txt");
            Type t = obj.GetType();
            sw.WriteLine("Информация о классе");
            sw.WriteLine("Full name = " + t.FullName);
            sw.WriteLine("Base type = " + t.BaseType);
            sw.WriteLine("Is Seled = " + t.IsSealed);
            sw.WriteLine("Is Class = " + t.IsClass);


            foreach (Type i in t.GetInterfaces())
            {
                sw.WriteLine(i.Name);
            }

            foreach(FieldInfo f in t.GetFields())
            {
                sw.WriteLine("Field = " + f.Name);
            }

            sw.Close();
        }

        public static void ShowMethod(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("\n");

            foreach (MethodInfo f in t.GetMethods())
            {
                Console.WriteLine("method = " + f);
            }
        }

        public static void ShowInterface(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("\n");

            foreach(Type i in t.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }

        public static void ShowField(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("\n");


            foreach(FieldInfo i in t.GetFields())
            {
                Console.WriteLine("Field = " + i.Name);
            }

            Console.WriteLine("\n");

            foreach(PropertyInfo i in t.GetProperties())
            {
                Console.WriteLine("Property = " + i);
            }
        }

    }

}
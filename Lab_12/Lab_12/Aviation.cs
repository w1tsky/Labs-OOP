using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Lab_12
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

    abstract class Transport : ITrans, ITransport
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
            name = "null";
            purpose = "null";
            weight = "null";
            wings = "null";
            engine = "null";
            yeahr = 0;
        }

        public override string ToString()
        {
            string k;
            if (yeahr < 20)
            {
                k = "Самолёт пригоден для палётов";
            }
            else
            {
                k = "Самолёт не пригоден для палётов";
            }
            return name + "\n" + purpose + "\n" + weight + "\n" + wings + "\n" + engine + "\n" + k;
        }

    }

    class Aviation : Transport
    {
        string Form { get; set; }
        public override void Type()
        {
            Console.WriteLine("транспорт");
        }
        public static void Method(string str)
        {
            Console.WriteLine("Параметры из файла: " + str);
        }
    }

    public class Reflector
    {
        //выводит всё содержимое класса в текстовый файл (принимает в качестве параметра имя класса);
        public static void OutInfoInToFile(object obj)
        {
            StreamWriter fstream = new StreamWriter(@"InfoFile.txt");
            Type t = obj.GetType();
            fstream.WriteLine("Class info: ");
            fstream.WriteLine("Full name: " + t.FullName);
            fstream.WriteLine("Base type: " + t.BaseType);
            fstream.WriteLine("Is sealed: " + t.IsSealed);
            fstream.WriteLine("Is public: " + t.IsPublic);
            fstream.WriteLine("Is class: " + t.IsClass);
            fstream.WriteLine("Is Interface: " + t.IsInterface);
            foreach (Type i in t.GetInterfaces())
            {
                fstream.WriteLine(i.Name);
            }
            foreach (FieldInfo fi in t.GetFields())
            {
                fstream.WriteLine("Field=" + fi.Name);
            }
            fstream.Close();
            Console.WriteLine("Информация о классе записана в файл info.txt");
        }

        //извлекает все общедоступные публичные методы класса (принимает в качестве параметра имя класса);
        public static void AllPublicMethod(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine(" все общедоступные публичные методы класса");
            foreach (MethodInfo m in t.GetMethods())
            {
                if (m.IsPublic)
                {
                    Console.WriteLine("method = " + m);
                }
            }
        }

        //получает информацию о полях и свойствах класса;
        public static void InfoFieldsAndProperties(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("информация о полях и свойствах класса");
            foreach (FieldInfo fi in t.GetFields())
            {
                Console.WriteLine("Field=" + fi.Name);
            }

            Console.WriteLine('\n');

            foreach (PropertyInfo pi in t.GetProperties())
            {
                Console.WriteLine("Property=" + pi.Name);
            }
        }

        //получает все реализованные классом интерфейсы;
        public static void AllInterface(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("все реализованные классом интерфейсы");
            foreach (Type i in t.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }

        }

        public static void ParametrMethof(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("имена методов,которые содержат заданный(пользователем) тип параметра");
            Console.WriteLine("Введите тип параметра:");
            string str = Console.ReadLine();
            foreach (MethodInfo m in t.GetMethods())
            {
              foreach(ParameterInfo parameter in m.GetParameters())
                {
                    if(parameter.Name.Contains(str))
                    {
                        Console.WriteLine("method = " + m.Name);
                    }
}

            }
                
          }

        //вызывает некоторый метод класса, при этом значения для его
        // параметров необходимо прочитать из текстового файла(имя
        // класса и имя метода передаются в качестве аргументов).

        public static void MethodCall(object obj, string NameMethod)
        {
            Type t = obj.GetType();
            StreamReader sr = new StreamReader("FileWithParams.txt");
            string param = sr.ReadLine();
            MethodInfo mt = t.GetMethod(NameMethod);
            object nw = Activator.CreateInstance(typeof(Aviation));
            mt.Invoke(nw, new object[] { param });
         }
    }
}
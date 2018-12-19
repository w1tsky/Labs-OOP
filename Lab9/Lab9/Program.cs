using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    public delegate void UserControl(string str);
    class Programmer
    {
        public delegate int YearOfBirth(int age);
        YearOfBirth year = (int age) => 2018 - age;

        public event UserControl Delete;
        public event UserControl Modification;

        public string name;
        public string Name { get; set; }
        public string surname;
        public string Surname { get; set; }
        public int age;
        public int Age { get; set; }

        public Programmer(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
        public void DeleteMethod(string name)
        {
            if (Delete != null)
            {
                name = name.Remove(0);
                Delete($"Имя удалено");
            }
            else
            {
                Console.WriteLine("Событие не подписано");
            }

        }
        public void ModificationMethod(string name, string surname)
        {
            // string s = surname;
            // surname = name;
            //  name = s;
            if (Modification != null)
            {
                Modification($"Модификация  {surname} {name} ");
            }
            else
            {
                Console.WriteLine("Событие не подписано");
            }
        }
        public void info()
        {
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"surname: {surname}");
            Console.WriteLine($"age: {age}");
            Console.WriteLine($"Year of Birth: {year(age)}");
            Console.WriteLine("\n");
        }

    }



    class Program
    {

        static public void Message(string message)
        {
            Console.WriteLine(message);
        }
        static public void ToUpperCase(string str)
        {
            str = str.ToUpper();
            Console.WriteLine(str);
        }

        static public void ToLowerCase(string str)
        {
            str = str.ToLower();
            Console.WriteLine(str);
        }

        static public void ReplaceLiter(string str)
        {
            str = str.Replace('!', ' ');
            Console.WriteLine(str);
        }

        static public void RemoveStr(string str)
        {
            str = str.Remove(7);
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            Programmer pr1 = new Programmer("Саша", "Ковалев", 20);
            Programmer pr2 = new Programmer("Арина", "Петрова", 23);
            Programmer pr3 = new Programmer("Катя", "Алексиенко", 18);

            pr1.Modification += Message;
            pr2.Modification += Message;
            pr3.Modification += Message;
            pr1.Delete += Message;
            pr2.Delete += Message;
            pr3.Delete += Message;

            pr1.info();
            pr1.ModificationMethod("Саша", "Ковалёв");
            pr1.DeleteMethod("Саша");
            Console.WriteLine();
            pr2.info();
            pr2.ModificationMethod("Арина", "Петрова");
            pr2.DeleteMethod("Арина");
            Console.WriteLine();
            pr3.info();
            pr3.ModificationMethod("Катя", "Алексиенко");
            pr3.DeleteMethod("Катя");
            Console.WriteLine();

            Action<string> action;
            string str = "пам парам пам пам !!!";
            action = ToUpperCase;
            action(str);

            action -= ToUpperCase;
            action += ToLowerCase;
            action(str);

            action -= ToLowerCase;
            action += ReplaceLiter;
            action(str);

            action += ToUpperCase;
            action += RemoveStr;
            action(str);
            
            Console.ReadKey();
        }
    }
}

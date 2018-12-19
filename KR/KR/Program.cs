using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Вариант_4
{

    class Tele
    {
        Random random = new Random();
        public bool zvon()
        {
            if (random.Next(2) == 1)
                return true;
            else
                return false;
        }
    }
    class User
    {
        public delegate void Poll(string message);
        public event Poll tru;
        public bool EVENT(bool b)
        {
            if (b == true && tru != null)
            {
                tru("Подняли трубку");

            }
            else
            {
                tru("Не подняли");
            }
            return b;
        }
    }
    class SuperStack<T> : Stack<T>
    {
        public static bool operator ==(SuperStack<T> ts, SuperStack<T> ts2)
        {
            if (ts.Count == 0 || ts2.Count == 0)
            {
                throw new InsufficientExecutionStackException();
            }
            if (ts.Equals(ts2) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(SuperStack<T> ts, SuperStack<T> ts2)
        {

            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SuperStack<int> vs1 = new SuperStack<int>();
            SuperStack<int> vs2 = new SuperStack<int>();
            Random random = new Random();
            Console.WriteLine("Размер 1 стека");
            int element;
            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                element = random.Next(5);
                vs1.Push(element);
            }
            Console.WriteLine("Размер 2 стека");
            size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                element = random.Next(5);
                vs2.Push(element);
            }
            bool result = vs1 == vs2;
            Console.WriteLine(" 1 стек");
            foreach (int i in vs1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(" 2 стек");
            foreach (int i in vs2)
            {
                Console.WriteLine(i);
            }
            string[] vs = new string[] { "Name", "Noname", "NULL", "NAN", "KEK", "NULL" };
            Console.WriteLine("Введите строку");
            string elem = Console.ReadLine();
            var TASKI = (
                from m in vs
                where m == elem
                select m
                         );
                Console.WriteLine("Ваши строки");
                foreach (var p in TASKI)
                    {
                Console.WriteLine(p);
            }

            User Dimon = new User();
            Tele Iphone = new Tele();
            Dimon.tru += Show_Message;
            Dimon.EVENT(Iphone.zvon());
            Dimon.EVENT(Iphone.zvon());


        }
        private static void Show_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
    }
}







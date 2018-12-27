using Lab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
        

            SortedList<int, string> tran = new SortedList<int, string>();
            tran.Add(0, "Pasanger");
            tran.Add(1, "Cargo");
            tran.Add(2, "Militarry");


            //Вывести коллекцию на консоль
            Console.WriteLine($"\nВывод коллекции на консоль:");
            foreach (KeyValuePair<int, string> kvp in tran)
            {
                Console.WriteLine("Key={0}, Value={1}", kvp.Key, kvp.Value);
            }

            //Удалите из коллекции n последовательных элементов 
            for (int s = 0; s < 2; s++)
            {
                tran.RemoveAt(0);
            }

            Console.WriteLine($"\nВывод коллекции на консоль после удаления последовательно 2 элементов:");
            foreach (KeyValuePair<int, string> kvp in tran)
            {
                Console.WriteLine("Key={0}, Value={1}", kvp.Key, kvp.Value);
            }

            //Добавьте  другие  элементы .
            tran.Add(13, "Aviation");
            tran.Add(51, "Ty134");
            tran.Add(52, "Boing");


            Console.WriteLine($"\nВывод коллекции на консоль после добавления новых  элементов:");
            foreach (KeyValuePair<int, string> kvp in tran)
            {
                Console.WriteLine("Key={0}, Value={1}", kvp.Key, kvp.Value);
            }

            //  Создайте вторую  коллекцию  (Stack<T>)  и  заполните ее  данными  из первой коллекции.
            Stack<string> tr = new Stack<string>();
            foreach (KeyValuePair<int, string> kvp in tran)
            {
                tr.Push(kvp.Value);
            }

            //Выведите  вторую  коллекцию  на  консоль.  В  случае  не  совпадения количества параметров
            Console.WriteLine($"\nВывод 2 коллекции на консоль :");
            foreach (string item in tr)
            {
                Console.WriteLine(item);
            }
            //Найдите во второй коллекции заданное значение 
            Console.WriteLine($"\nВведите элемент, который хотите найти во второй коллекции:");
            string str = Console.ReadLine();
            if (tr.Contains(str))
            {
                Console.WriteLine($"\nЭлемент с таким значением присутствует в коллекции");
            }
            else
            {
                Console.WriteLine($"\nТакого элемента нет в коллекции");
            }



            // работа с пользовательским типом данных
            SortedList<int, Transport> avia = new SortedList<int, Transport>();
            avia.Add(0, new Pasanger());
            avia.Add(1, new Cargo());
            avia.Add(2, new Military());


            foreach (KeyValuePair<int, Transport> kvp in avia)
            {
                Console.Write(kvp.Key + " - ");
                avia[kvp.Key].Type();
            }

            for (int s = 0; s < 2; s++)
            {
                avia.RemoveAt(0);
            }

            foreach (KeyValuePair<int, Transport> kvp in avia)
            {
                Console.Write(kvp.Key + " - ");
                avia[kvp.Key].Type();
            }
            //Добавьте  другие  элементы .
            avia.Add(13, new Aviation());
            avia.Add(51, new Ty134());
            avia.Add(70, new Boing());

            foreach (KeyValuePair<int, Transport> kvp in avia)
            {
                Console.Write(kvp.Key + " - ");
                avia[kvp.Key].Type();
            }

            Stack<Transport> avia1 = new Stack<Transport>();
            foreach (KeyValuePair<int, Transport> kvp in avia)
            {
                avia1.Push(kvp.Value);
            }

            Console.WriteLine($"\nВывод  коллекции на консоль :");
            foreach (Transport item in avia1)
            {
                item.Type();
            }


            if (avia1.Contains(avia[1]))
            {
                Console.WriteLine($"\nЭлемент с таким значением присутствует в коллекции");
            }
            else
            {
                Console.WriteLine($"\nТакого элемента нет в коллекции");
            }


            Console.ReadKey();
        }
    }
    class Student
    {
        string name;
        int course;
        public Student(string n, int c)
        {
            name = n;
            course = c;
        }
    }

}

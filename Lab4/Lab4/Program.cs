using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    public class Owner
    {
        public Owner(int Id)
        {
            int Identity = Id;
            string Name = "Daniil";
            var Org = "BSTU";
        }
    }

    public class Date
    {
        public Date() { }
    }

    class List
    {

        public List<string> link = new List<string>();

        public void AddElement(string links)
        {
            link.Add(links);
        }

        public void ShowList()
        {
            foreach (string p in link)
            {
                Console.WriteLine(p);
            }
        }

        public void ReverseList()
        {
            link.Reverse();
        }

        public void Summa(List list, List list2)
        {
            foreach (string p in list.link.Union<string>(list2.link))
            {
                Console.WriteLine(p);
            }
        }

        public bool Equal(List list, List list2)
        { 
            string[] str1 = new string[list.link.Count];
            string[] str2 = new string[list2.link.Count];
            int i = 0;
            foreach (string s in list.link)
            {
                str1[i] = s;
                i++;
            }
            i = 0;
            foreach (string s in list2.link)
            {
                str2[i] = s;
                i++;
            }

            if (str1.Length == str2.Length)
            {
                for(i = 0; i < str1.Length; i++)
                {
                    if(str1[i] != str2[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public static List operator !(List lolika)
        {
            lolika.ReverseList();

            return lolika;
        }

        public static List operator +(List listik, List listik2)
        {
            listik.Summa(listik, listik2);
            return listik;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ;
        }

        public static class MathOperation
        {
            public static string Max(List list)
            { 
                return list.link.Max<string>();
            }

            public static string Min(List list)
            {
               return list.link.Min<string>();
            }
            public static int Counter(List list)
            {
                return list.link.Count<string>();
            }
            
        }


        class Program
        {
            static void Main()
            { 
                // Создадим связный список
                List list = new List();
                List list2 = new List();


                Console.WriteLine("Введите количество элементов первого списка:");
                int Size = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите элементы списка");
                for (int i = 0; i < Size; i++)
                {
                    string Element = Console.ReadLine();
                    list.AddElement(Element);
                }

                Console.WriteLine();
                Console.WriteLine("Введите количество элементов второго списка:");
                int Size2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите элементы списка");
                for (int i = 0; i < Size2; i++)
                {
                    string Element = Console.ReadLine();
                    list2.AddElement(Element);
                }


                Console.WriteLine("Первый список:");
                list.ShowList();
                Console.WriteLine("Второй список:");
                list2.ShowList();

                Console.WriteLine();
                Console.WriteLine("Сравнение: ");

                if(list.Equal(list, list2))
                {
                    Console.WriteLine("Равны");
                }
                else Console.WriteLine("Не равны");


                Console.WriteLine();
                Console.WriteLine("Обратный список:");
                list = !list;
                list.ShowList();

                Console.WriteLine();
                Console.WriteLine("Объединенный список:");
                list = +list;





                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Math Operations");
                Console.WriteLine("Максимальный : " + MathOperation.Max(list));
                Console.WriteLine("Минимальный : " + MathOperation.Min(list));
                Console.WriteLine("Общее количество : " + MathOperation.Counter(list));

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11
{
    class Student
    {
        public string Name { get; set; }
        public string Uni { get; set; }
    }
    class Uni
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Задайте массив типа string, содержащий 12 месяцев(June, July, May,
            //December, January ….).
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            // Используя LINQ to Object напишите запрос выбирающий 
            //последовательность месяцев с длиной строки равной n, 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Введите строки какой длины вы хотите найти:");
            int n = int.Parse(Console.ReadLine());
            var selectedMonths = from m in month
                                 where m.Length == n
                                 select m;
            foreach (string s in selectedMonths)
            {
                Console.WriteLine(s);
            }
            //запрос возвращающий только летние и зимние месяцы, 

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Зимние месяца:");
            var wintermonth = from m in month
                              where m == "January" || m == "February" || m == "December"
                              select m;
            foreach (string s in wintermonth)
            {
                Console.WriteLine(s);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Летние месяца:");
            var summermonth = from m in month
                              where m == "June" || m == "July" || m == "August"
                              select m;
            foreach (string s in summermonth)
            {
                Console.WriteLine(s);
            }
            //запрос вывода месяцев в алфавитном порядке,
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Вывод месяцев в алфавитном порядке:");
            var sortmonth = from m in month
                            orderby m
                            select m;


            foreach (string s in sortmonth)
            {
                Console.WriteLine(s);
            }
            //запрос считающий месяцы содержащие букву «u» и c длиной имени не менее 4-х
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Количество месяцев, содержащих букву «u» и длиной имени не менее 4-х:");
            var countmonth = (from m in month
                              where m.Contains("u") && m.Length >= 4
                              select m).Count();
            Console.WriteLine(countmonth);

            // Создайте коллекцию List<T> и  параметризируйте ее типом (классом) 
            // из лабораторной №3(при необходимости реализуйте нужные интерфейсы).

            List<Book> collection = new List<Book>();

            var b1 = new Book("Преступление и наказание", "Фёдор Достоевский", 256, 1954, 10);
            var b2 = new Book("Евгений Онегин", "Александр Пушкин", 120, 1820, 8);
            var b3 = new Book("Герой нашего времени", "Михаил Лермантов", 142, 2000, 20);
            var b4 = new Book("Война и мир", "Лев Толстой", 3020, 1964, 345);
            var b5 = new Book("Финансист", "Теодор Драйзер", 338, 1920, 15);
            var b6 = new Book("Овод", "Евгения Войнич", 260, 1980, 9);
            var b7 = new Book("Униженные и оскарбленные", "Фёдор Достоевский", 350, 1979, 6);
            var b8 = new Book("Руслан и Людмила", "Александр Пушкин", 180, 1890, 7);
            var b9 = new Book("Мёртвые души", "Николай Гоголь", 244, 1968, 5);
            collection.Add(b1);
            collection.Add(b2);
            collection.Add(b3);
            collection.Add(b4);
            collection.Add(b5);
            collection.Add(b6);
            collection.Add(b7);
            collection.Add(b8);
            collection.Add(b9);

            //На основе  LINQ сформируйте  следующие запросы  по вариантам. 
            // При необходимости добавьте в класс T(тип параметра) свойства.
            //список книг заданного автора; 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Книги Пушкина:");
            var autors = from k in collection
                         where k.author == "Александр Пушкин"
                         select k;
            foreach (var s in autors)
            {
                s.Info();
                Console.WriteLine();
            }
            //список книг, выпущенных после заданного года
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Книги, выпущенные после 1957 года:");
            var yeard = from k in collection
                        where k.yehr > 1957
                        select k;
            foreach (Book s in yeard)
            {
                s.Info();
                Console.WriteLine();
            }
            //самую тонкую книгу
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Самая тонкая книга:");
            var quent = from k in collection
                        orderby k.quantity
                        select k;
            quent.First().Info();
            Console.WriteLine();

            //5 первых самых толстых книг
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("5 cамых толстых книг:");
            var quent2 = (from k in collection
                          orderby k.quantity descending
                          select k).Take(5);

            foreach (Book s in quent2)
            {
                s.Info();
                Console.WriteLine();
            }
            //Список книг отсортированных по цене
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Список книг отсортированных по цене:");
            var sort = from k in collection
                       orderby k.cost ascending
                       select k;
            foreach (Book s in sort)
            {
                s.Info();
                Console.WriteLine();
            }
            //3.Придумайте и напишите свой собственный запрос, в котором было 
            // бы не  менее  5  операторов из  разных категорий:  условия,  проекций, 
            //упорядочивания, группировки, агрегирования, кванторов и разиения.
            int[] number = { 2, 5, 6, 8, 4, 9, 10, -18, -30 };
            var zapr = ((from k in number
                         orderby k
                         where k > 0
                         select k).Take(6)).Sum();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Собственный запрос:{zapr}");

            //4.Придумайте запрос с оператором Join 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Использование join:");
            List<Student> stud = new List<Student>()
{
            new Student { Name = "Даниил",  Uni ="БГТУ" },
            new Student { Name = "Владимир", Uni ="МГУ" }
};
            List<Uni> uni = new List<Uni>()
{
            new Uni {Name="БГТУ", Country="Беларусь"},
            new Uni {Name="MГУ", Country="Россия"},

};
            var result = from p in uni
                         join t in stud on p.Name equals t.Uni
                         select new { Name = t.Name, Uni = t.Uni, Country = p.Country };

            foreach (var item in result)
                Console.WriteLine("{0} - {1} ({2})", item.Name, item.Uni, item.Country);



            Console.ReadKey();

        }
    }
}
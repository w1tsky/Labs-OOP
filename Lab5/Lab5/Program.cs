using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Задание 
//1)  Определить  иерархию  и  композицию  классов  (в  соответствии  с //вариантом),  реализовать  классы.  Если  необходимо  расширьте  по 
//своему усмотрению  иерархию для выполнения всех пунктов л.р.  //Каждый  класс  должен  иметь  отражающее  смысл  название  и 
//информативный  состав.        При  кодировании  должны  быть //использованы соглашения об оформлении кода code convention. 
//В  одном  из  классов  переопределите  все  методы, //унаследованные от Object. 
//2)  В  проекте  должны  быть  интерфейсы  и  абстрактный  класс(ы).//Использовать виртуальные методы и переопределение. 
//3)  Сделайте один из классов герметизированным  (бесплодным). 
//4)  Добавьте  в  интерфейсы  или  интерфейс  +  абстрактный  класс //одноименные  методы.  Дайте  в  наследуемом  классе  им  разную 
//реализацию и вызовите эти методы. 
//5)  Написать  демонстрационную  программу,  в  которой  создаются //объекты различных классов. Поработать с объектами через ссылки 
//на  абстрактные  классы  и  интерфейсы.  В  этом  случае  для //идентификации типов объектов использовать операторы is или as. 
//6)  Во  всех  классах  (иерархии)  переопределить  метод  ToString(),//который  выводит  информацию  о  типе  объекта  и  его  текущих 
//значениях. Создайте дополнительный класс Printer c полиморфным //методом  iAmPrinting(  SomeAbstractClassorInterface  someobj). 
//Формальным  параметром  метода  должна  быть  ссылка  на //абстрактный класс или наиболее общий интерфейс в вашей иерархии 
//классов.  В  методе  iAmPrinting  определите  тип  объекта  и вызовите //ToString().    В  демонстрационной  программе  создайте  массив, 
//содержащий  ссылки  на  разнотипные  объекты  ваших  классов  по //иерархии, а также объект класса Printer  и последовательно вызовите 
//его метод iAmPrinting  со всеми ссылками в качестве аргументов. //ВАариант 19. Транспорт, Авиация, Грузовой самолёт, Пассажирский , Военный , Boeing , Ty134

namespace Lab5
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

    }

    class Cargo : Aviation
    {
        public override void Type()
        {
            Console.WriteLine("грузовой самолёт");
        }

    }
    class Military : Aviation
    {
        public override void Type()
        {
            Console.WriteLine("военный самолёт");
        }
    }
    class Pasanger : Aviation
    {
        public override void Type()
        {
            Console.WriteLine("пассажирский самолёт");
        }

    }
    sealed class Ty134 : Pasanger
    {
        public override void Type()
        {
            Console.WriteLine("Ty134");
        }
    }
    sealed class Boing : Pasanger
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
    static class Printer
    {
        public static string iAmPrinting(Transport someobj)
        {
            return someobj.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Aviation aviation = new Aviation();
            Cargo cargo = new Cargo();
            Military military = new Military();
            Pasanger pasanger = new Pasanger();
            Ty134 ty134 = new Ty134();
            Boing boing = new Boing();

            cargo.addInfo();
            Console.WriteLine('\n');
            military.addInfo();
            Console.WriteLine('\n');
            pasanger.addInfo();
            Console.WriteLine('\n');

            Console.ForegroundColor = ConsoleColor.Magenta;
            aviation.Type();
            cargo.Type();
            military.Type();
            pasanger.Type();
            ty134.Type();
            boing.Type();
            Console.WriteLine('\n');

            Console.ForegroundColor = ConsoleColor.White;
            bool fly = pasanger is Aviation;
            if (fly)
            {
                Aviation confOne = (Aviation)pasanger;
                confOne.Type();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            ITransport confTwo = military as ITransport;

            if (confTwo != null)
            {
                confTwo.Info();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(cargo.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            Transport obj = pasanger as Transport;//можно ли преобразовать
            Console.WriteLine(obj.GetType());

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (military is Transport)//преднадлежит
            {
                Console.WriteLine(true + "\n");
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Transport[] mas = { cargo, military, pasanger };
            foreach (Transport x in mas)
            {
                Console.WriteLine(Printer.iAmPrinting(x));
            }

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab10
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
            
        }

       /* public override string ToString()
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
        }*/

    }



    class Aviation : Transport
    {
        string Form { get; set; }
        public override void Type()
        {
            Console.WriteLine("транспорт");
        }

    }

    class Cargo : Transport
    {
        public override void Type()
        {
            Console.WriteLine("грузовой самолёт");
        }

    }
    class Military : Transport
    {
        public override void Type()
        {
            Console.WriteLine("военный самолёт");
        }
    }
    class Pasanger : Transport
    {
        public override void Type()
        {
            Console.WriteLine("пассажирский самолёт");
        }

    }
    sealed class Ty134 : Transport
    {
        public override void Type()
        {
            Console.WriteLine("Ty134");
        }
    }
    sealed class Boing : Transport
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

}
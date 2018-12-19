using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    partial class Task
    {
        //поле - только для чтения 
        readonly int read_only;

        //поле- константy
        const int _const = 47;
        public static int stat;
        int privat;
        public string str;

        public override int GetHashCode()
        {
            return _const.GetHashCode();
        }

        static Task()
        {
            int stat = 0;
            Console.WriteLine("Вызвался статистический конструктор");
        }
        private Task(int privat)
        {
            privat = 5;
            Console.WriteLine("Вызвался закрытый конструктор");
        }

        public Task()//конструктор без параметров
        {
           string str = "Неизвестно";
           Console.WriteLine("Вызвался конструктор без параметров");
           Console.WriteLine();
        }
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                name = value;
            }
        }
        public string Name2 { get; set; }

        public static Task ConstructorC(int privat)
        {
            return new Task(privat);
        }

        public static Task ConstructorP()
        {
            return new Task();
        }


    }
    partial class Task
    {
        int k = 25;
    }
}

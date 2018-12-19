//Создать Авиакомпанию.Посчитать общую вместимость и
//грузоподъемность. Провести сортировку самолетов
//компании по дальности полета.Найти самолет в компании,
//соответствующий заданному диапазону параметров
//потребления горючего. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab6
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
    // перечисление
    enum Operation : byte
    {
        zero = 0,
        one = 1,
        two,
        three,
        ten = 10,
    }

    // структура
    struct Person
    {
        string name;
        int age;
        string uni;
        int group;

        public Person(string name, int age, string uni, int group)
        {
            this.name = name;
            this.age = age;
            this.uni = uni;
            this.group = group;
        }

        public void DisplayPerson()
        {
            Console.WriteLine($"\nИнформация из структуры:\n Имя:{name}\n Возраст:{age }\n Университет:{ uni}\n Группа:{ group}");
        }
    }

    public abstract partial class Transport : ITrans, ITransport
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
        public virtual void con()
        {
            Console.WriteLine(name);
            Console.WriteLine(purpose);
            Console.WriteLine(weight);
            Console.WriteLine(wings);
            Console.WriteLine(engine);

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

    class Cargo : Transport
    {

        public override void Type()
        {
            Console.WriteLine("грузовой самолёт");
        }
        public Cargo(string name, string purpose, string weight, string wings, string engine)
        {
            this.name = "cargor";
            this.purpose = "transport";
            this.weight = "545450";
            this.wings = "2";
            this.engine = "6";

        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(name))
            { return base.ToString(); }

            Console.WriteLine("\nИнформация об объекте:\t\t");
            return name + ", " + purpose + ", " + weight + " ," + wings + " ," + engine;
        }

    }
    class Military : Aviation
    {
        public override void Type()
        {
            Console.WriteLine("военный самолёт");
        }
        public Military(string name, string purpose, string weight, string wings, string engine)
        {
            this.name = "military";
            this.purpose = "transport";
            this.weight = "50000";
            this.wings = "3";
            this.engine = "4";

        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(name))
            { return base.ToString(); }

            Console.WriteLine("\nИнформация об объекте:\t\t");
            return name + ", " + purpose + ", " + weight + " ," + wings + " ," + engine;
        }
    }
    class Pasanger : Transport
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
        public Ty134(string name, string purpose, string weight, string wings, string engine)
        {
            this.name = "pasanger";
            this.purpose = "transport";
            this.weight = "3000";
            this.wings = "1";
            this.engine = "4";

        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(name))
            { return base.ToString(); }
            Console.WriteLine("\nИнформация об объекте:\t\t");
            return name + ", " + purpose + ", " + weight + " ," + wings + " ," + engine;
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

    partial class Maize
    {
        public string GetName()
        {
            return "Bisy";
        }
    }

    //-----------------------------------
    public class Avialine : IAvialine
    {
        public string Name { get; set; }
        public double Capasity { get; set; }
        public double Loadcapacity { get; set; }
        public double Range { get; set; }
        public double Fuelconsumption { get; set; }


        public Avialine() { }

        public Transport[] array = new Transport[0];

        public Transport ArrAdd
        {
            get
            {
                return ArrAdd;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("\nМассив объектов некорректен");
                }

                else
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = value;
                }
            }
        }

        public Transport ArrDelete
        {
            get
            {
                return ArrDelete;
            }
            set
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nВедите удаляемый элемент массива:");
                int x = Convert.ToInt32(Console.ReadLine());
                for (int i = x; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Array.Resize(ref array, array.Length - 1);
            }
        }

        public Transport ArrPrint
        {
            get
            {
                return ArrPrint;
            }
            set
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine($"\n\n\tИнформация о {i}-ом объекте массива");
                    Console.WriteLine(array[i]);
                }
            }
        }

        public Avialine(string Name, double Capacity, double Loadcapacity, double Range, double Fuelconsumption)
        {
            this.Name = Name;
            this.Capasity = Capacity;
            this.Loadcapacity = Loadcapacity;
            this.Range = Range;
            this.Fuelconsumption = Fuelconsumption;
        }
    }


    public class Controler : Avialine
    {
        string Name { get; set; }
        double Capasity { get; set; }
        double Loadcapacity { get; set; }
        double Range { get; set; }
        double Fuelconsumption { get; set; }

        Avialine[] array = new Avialine[3];

        public void AvialineArray()
        {

            for (int i = 0; i < 3; i++)
            {
                array[i] = new Avialine("Боинг", 40, 3000, 1000000, 450);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nВведите название самолёта");
                array[i].Name = Console.ReadLine();

                Console.WriteLine("\n\nВведите вместимость самолёта:");
                array[i].Capasity = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\n\nВведите грузоподъемность самолёта: ");
                array[i].Loadcapacity = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\n\nВведите дальность полёта самолёта:");
                array[i].Range = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\n\nВведите потребление горючего: ");
                array[i].Fuelconsumption = Convert.ToDouble(Console.ReadLine());
            }
        }

        public void AvialineInfoArray()
        {

            Console.WriteLine("\n\n\nДанные :");//вывод заполненного массива
            for (int j = 0; j < 3; j++)
            {
                // Console.WriteLine(array[j].Punkt); нет доступа по get
                Console.WriteLine($"\n №{j}");
                Console.WriteLine($"название самолёта:{array[j].Name}");
                Console.WriteLine($"вместимость самолёта:{array[j].Capasity}");
                Console.WriteLine($"грузоподъемность самолёта:{array[j].Loadcapacity}");
                Console.WriteLine($"дальность полёта самолёта:{array[j].Range}");
                Console.WriteLine($"потребление горючего:{array[j].Fuelconsumption}");
            }
        }

        public void Sum()
        {
            double temp = 0;
            double load = 0;

            for (int i = 0; i < array.Length; i++)
            {
                temp += array[i].Capasity;
                load += array[i].Loadcapacity;

            }

            Console.WriteLine("Общая вместимость(грузоподъемость):{0}", temp);
            Console.WriteLine("Общая грузоподъемость:{0}", load);

        }

        public void AvialineSortMassArray()
        {
            double temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].Range > array[j].Range)
                    {
                        temp = array[i].Range;
                        array[i].Range = array[j].Range;
                        array[j].Range = temp;
                    }
                }
            }

            Console.WriteLine("Вывод отсортированного массива");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].Range);
            }



        }



        //-------поиск по заданному диапазону потребления горючего
        public void FlySearchArray()
        {

            Console.WriteLine("\n\nВведите диапазон потребления горючего:");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Fuelconsumption > a && array[i].Fuelconsumption < b)
                {
                    Console.WriteLine($"\n\nНайденные самолёты:\n{array[i].Name},\nПотребления горючего:{array[i].Fuelconsumption}");
                }
            }
        }


    }



    public interface IAvialine
    {
        string Name { get; set; }
        double Capasity { get; set; }
        double Loadcapacity { get; set; }
        double Range { get; set; }
        double Fuelconsumption { get; set; }
    }

    //лаба 7

    public class FlyException : Exception
    {
        public string Fly { get; set; }
        public void TransportTypeException()
        {
            Console.WriteLine("\n Введите тип транспорта:");
            this.Fly = Console.ReadLine();
            if (Fly != "самолёт")
            {
                Console.WriteLine("\n Ошибка. Введенный тип транспорта не является самолётом.");
            }
            else
            {
                Console.WriteLine("Введённый тип транспорта -самолёт");
            }
        }
    }
    public class ArrayException : FlyException
    {
        public void ArrayExceptionFly()
        {
            string[] array = new string[4] { "pasanger", "Military", "Cargo", "Croapduster" };
            Console.WriteLine("\n Массив самолётов:");
            foreach (string x in array)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Введите номер массива для вывода(от 0 до 3):");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i > array.Length)
            {

                Console.WriteLine("\n Ошибка.Элемента с данным индексом нет в массиве");
            }
            else
            {
                Console.WriteLine("\n Вывод заданного по номеру элемента массивая:{0}", array[i]);
            }
        }
    }



    public class TypeException : ArrayException
    {
        public int year { get; set; }
        public void TypeValueException()
        {

            Console.WriteLine("\n Год основания авиакомпании");
            this.year = Convert.ToInt32(Console.ReadLine());
            if (year < 1909 || year > 2018)
            {
                Console.WriteLine("\n Ошибка. Проверьте правильность введённой даты");
            }
            else
            {
                Console.WriteLine("\n Год основания авиакомпании:{0}", year);
            }
        }
    }



    public class EmployeeException : Exception
    {
        public EmployeeException(string message) : base(message) { }
    }




    public class Employee
    {
        public string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                {
                    throw new EmployeeException("Некорректно введённое имя сотрудника ");
                }
                else
                {
                    name = value;
                }
            }
        }
    }

    public class DivisionException : Exception
    {
        public DivisionException() { }
        public DivisionException(string message) : base(message) { }
        public DivisionException(string message, Exception ex) : base(message) { }
    }
    public class Division
    {
        public int Divis(int x, int y)
        {
            if (y == 0)
            {
                DivisionException exc = new DivisionException("Ошибка деления : На ноль делить нельзя");
                exc.HelpLink = "http:\\professorweb.ru";
                throw exc;
            }
            return x / y;
        }
    }
    public class Value
    {
        public void ValueMethod()
        {
            try
            {
                Console.WriteLine("\nВведите число:");
                string str = Console.ReadLine();
                int number = int.Parse(str);
                Console.WriteLine("Вы ввели число");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nОшибка.Введённые элемент не является числом." + ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            Console.WriteLine("Конец");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Иерархия классов собственных исключений");
            FlyException flyException = new FlyException();
            flyException.TransportTypeException();
            Console.WriteLine();

            ArrayException arrayException = new ArrayException();
            arrayException.ArrayExceptionFly();
            Console.WriteLine();

            TypeException typeException = new TypeException();
            typeException.TypeValueException();
            Console.WriteLine();

            Employee employee = new Employee();
            Console.WriteLine("Введите имя сотрудника:");
            try
            {
                employee.Name = Console.ReadLine();
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message + "\n\n");
                Console.WriteLine(ex.TargetSite + "\n\n");
                Console.WriteLine(ex.StackTrace + "\n\n");
                Console.WriteLine(ex.HelpLink + "\n\n");
            }

            Value value = new Value();
            value.ValueMethod();


            Division division = new Division();
            try
            {
                division.Divis(11, 0);
                throw new EmployeeException("Вызвалось исклечение");
                    
            }
            catch (DivisionException ex)
            {
                Console.WriteLine("\nОшибка.Знаменатель равен нулю");
                Console.WriteLine("Ошибка:" + ex.Message);
                Console.WriteLine("Метод:" + ex.TargetSite);
                Console.WriteLine("Имя объекта или сборки, которое вызвало исключение:" + ex.Source);
                Console.WriteLine("Строковое представление стека вызовов , которые привели к возникновению исключения :" + ex.StackTrace);

            }
            finally
            {
                Console.WriteLine("Блок Finally");
            }






            //работа  с макросам Assert
            int[] arr = null;
            Debug.Assert(arr != null, "Массив не может быть равен нулю");
            string str1 = null;
            Debug.Assert(str1 != null, "Cтрока не должна быть пустой");

            Console.ReadKey();
        }
    }
}
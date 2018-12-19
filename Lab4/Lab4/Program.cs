using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4
/*Класс - Марица. Дополнительно перегрузить следующие операции: == - сравнения  матриц; --     приведение  матрицы к 
единичному виду;  <- сравнение матриц по первому элементу; * –  инверсия всех элементов матрицы. 
Методы расширения: 
1)  Разность двух первых целых чисел строки  
2)  Сумма элементов матрицы 
*/
{
    public class Matrix
    {
        public double[,] arr = new double[3, 3];

        public void random()
        {
            Random rand = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = rand.Next(100);

                }
            }
        }


        public void rand()
        {
            Random rand = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = rand.Next(50);

                }
            }
        }

        public void show()
        {


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void zap()

        {
            arr[0, 0] = arr[0, 0] - 1;
            arr[1, 1] = arr[1, 1] - 1;
            arr[2, 2] = arr[2, 2] - 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
        }


        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (object.ReferenceEquals(m1, m2))
            {
                return m1.Equals(m2);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (m1.arr[i, j] != m2.arr[i, j])
                            return false;
                return true;
            }
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            if (object.ReferenceEquals(m1, m2))
            {
                return m1.Equals(m2);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if (m1.arr[i, j] == m2.arr[i, j])
                            return false;
                return true;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator <(Matrix m1, Matrix m2)
        {
            bool result = true;
            if (m1.arr[0, 0] > m2.arr[0, 0])
            {
                result = false;

            }
            if (m1.arr[0, 0] == m2.arr[0, 0])
            {
                result = false;

            }
            return result;
        }

        public static bool operator >(Matrix m1, Matrix m2)
        {
            bool result = true;

            if (m1.arr[0, 0] < m2.arr[0, 0])
            {
                result = false;
            }
            if (m1.arr[0, 0] == m2.arr[0, 0])
            {
                result = false;
            }

            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m3)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result.arr[i, j] = m1.arr[i, j] - m3.arr[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix ivners)
        {
            for (int i = 3 - 1; i >= 0; i--)
            {
                for (int j = 3 - 1; j >= 0; j--)
                {
                    ivners.arr[i, j] = ivners.arr[i, j];
                    Console.Write("{0}\t", ivners.arr[i, j]);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");


            return ivners;
        }

        public class Owner
        {
            static int id;
            int ID;
            string name;
            string organization;

            public Owner()
            {
                id++;
                ID = id;
            }

            public Owner(String name, String organization) : this()
            {
                this.name = name;
                this.organization = organization;
            }

            public void Info()
            {
                Console.WriteLine("id={0}", ID);
                Console.WriteLine("name={0}", name);
                Console.WriteLine("organization={0}", organization);
                Console.WriteLine();
            }
        }

        public class Date
        {
            public DateTime date = new DateTime();
            public Date()
            {
                date = DateTime.Now;
            }
        }


        public void info()
        {
            Console.WriteLine(date.date);
            owner.Info();
        }


        Owner owner = new Owner("Daniil Marchuk", "BSTU");
        Date date = new Date();



    }

    public static class MathOperation
    {
        public static double Max(this Matrix matr1)
        {
            double max = matr1.arr[0, 0];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matr1.arr[i, j] > max)
                    {
                        max = matr1.arr[i, j];
                    }
                }
            }

            return max;
        }

        public static double Min(this Matrix matr1)
        {
            double min = matr1.arr[0, 0];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matr1.arr[i, j] < min)
                    {
                        min = matr1.arr[i, j];
                    }
                }
            }
            return min;
        }

        public static int Count(this Matrix matr1)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    count++;
                }
            }
            return count;
        }

        public static double Sum(this Matrix matr1)
        {
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += matr1.arr[i, j];
                }
            }
            return sum;
        }

        public static int Razn(this string stroka)
        {
            int g = 0;
            int a = 0;
            int b = 0;
            int c = 0;

            for (int i = 0; i < stroka.Length; i++)
            {
                if ((stroka[i] == '0') || (stroka[i] == '1') || (stroka[i] == '2') || (stroka[i] == '3') || (stroka[i] == '4') || (stroka[i] == '5') || (stroka[i] == '6') || (stroka[i] == '7') || (stroka[i] == '8') || (stroka[i] == '9'))
                {
                    if (g < 2)
                    {
                        if ((g < 2) && (g > 0))
                        {
                            int a2 = (int)Char.GetNumericValue(stroka[i]);
                            b = a2;

                        }
                        else if (g < 1)
                        {

                            int a1 = (int)Char.GetNumericValue(stroka[i]);

                            c = a1;
                        }

                        g++;
                    }
                }
            }
            a = b - c;
            return a;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix();
            Console.ForegroundColor = ConsoleColor.Cyan;
            m1.info();
            Console.WriteLine();


            m1.random();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Первая матрица");
            Console.WriteLine();
            m1.show();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Matrix m2 = new Matrix();
            m2.rand();
            Console.WriteLine("Вторая матрица");
            Console.WriteLine();
            m2.show();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Matrix m3 = new Matrix();
            m3.random();
            Console.WriteLine("Третья матрица");
            Console.WriteLine();
            m3.zap();

            Console.ForegroundColor = ConsoleColor.Blue;
            Matrix result = new Matrix();
            Console.WriteLine("Перегрузка операции - -приведения матрицы к единичному виду: ");
            Console.WriteLine();
            result = m1 - m3;
            result.show();

            Console.ForegroundColor = ConsoleColor.Green;
            Matrix invers = new Matrix();
            Console.WriteLine("Перегрузка операции * -инверсия всех элементов матрицы: ");
            Console.WriteLine();
            invers = m2 * m2;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Перегрузка оператора == -сравнения матриц:{0}\t", m1 == m2);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Перегрузка оператора < -сравнения первого элемента матриц:{0}\t", m1 < m2);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Введите пожалуйста строку:");
            string str = Console.ReadLine();
            int func = str.Razn();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Разность первых 2 целых чисел в строке {0} равно {1}", str, func);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Минимальный элемент матрицы 1:{0}", m1.Min());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Максимальный элемент матрицы 1:{0}", m1.Max());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Количество элементов матрицы 1:{0}", m1.Count());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сумма элементов матрицы 1:{0}", m1.Sum());


            Console.ReadKey();

        }
    }
}

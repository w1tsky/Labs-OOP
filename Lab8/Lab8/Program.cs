using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab8

{
    interface IGeneric<T>
    {
        void Add(T obj);
        void Delete(int num);
        void Out();
    }
    

    public class Owner
    {
        public static int id;
        public int ID;
        public string name;
        public string organization;

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

    public class Matrix<T> : IGeneric<T> where T : struct
    {
        public double[,] arr = new double[3, 3];
        List<T> list = new List<T>();
        public void Out()
        {
            foreach (T x in list)
            {
                Console.WriteLine(x + "\t");
            }
            Console.WriteLine();
        }
        public void Add(T obj)
        {
            list.Add(obj);
        }
        public void Delete(int num)
        {
            num--;
            list.RemoveAt(num);
        }

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


        public static bool operator ==(Matrix<T> m1, Matrix<T> m2)
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
        public static bool operator !=(Matrix<T> m1, Matrix<T> m2)
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

        public static bool operator <(Matrix<T> m1, Matrix<T> m2)
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

        public static bool operator >(Matrix<T> m1, Matrix<T> m2)
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

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m3)
        {
            Matrix<T> result = new Matrix<T>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result.arr[i, j] = m1.arr[i, j] - m3.arr[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> ivners)
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

        Owner owner = new Owner("Yulya Buraya", "BSTU");
        Date date = new Date();
        public void Save()
        {
            string text = "\n\n\n" + date.date + "/nid=" + owner.ID + "/nname" + owner.name + "/norganization=" + owner.organization;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    text = "\t" + arr[i, j];
                }
                text += "\n";
            }
            text += "\n";

            foreach (T s in list)
            {
                text += s + "\t";
            }
            text += "\n\n\n";

            File.AppendAllText("file.txt", text);

        }
    }
    public static class MathOperation
    {
        public static double Max(this Matrix<int> matr1)
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

        public static double Min(this Matrix<int> matr1)
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

        public static int Count(this Matrix<int> matr1)
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

        public static double Sum(this Matrix<int> matr1)
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
            Matrix<int> m1 = new Matrix<int>();
            Console.ForegroundColor = ConsoleColor.Magenta;
            m1.info();
            Console.WriteLine();


            m1.random();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Первая матрица");
            Console.WriteLine();
            m1.show();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Matrix<int> m2 = new Matrix<int>();
            m2.rand();
            Console.WriteLine("Вторая матрица");
            Console.WriteLine();
            m2.show();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Matrix<int> m3 = new Matrix<int>();
            m3.random();
            Console.WriteLine("Третья матрица");
            Console.WriteLine();
            m3.zap();

            Console.ForegroundColor = ConsoleColor.Blue;
            Matrix<int> result = new Matrix<int>();
            Console.WriteLine("Перегрузка операции - -приведения матрицы к единичному виду:");
            Console.WriteLine();
            result = m1 - m3;
            result.show();

            Console.ForegroundColor = ConsoleColor.Green;
            Matrix<int> invers = new Matrix<int>();
            Console.WriteLine("Перегрузка операции * -инверсия всех элементов матрицы:");
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
            Console.ForegroundColor = ConsoleColor.White;
            int k = 0;
            do
            {
                Console.WriteLine("\n 1.Добавить элемент ");
                Console.WriteLine("\n 2.Вывести элемент ");
                Console.WriteLine("\n 3.Удалить элемент ");
                Console.WriteLine("\n 4.Сохранить объект ");
                Console.WriteLine("Выберите действие: ");
                k = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (k)
                {
                    case 1:
                        try
                        {

                            Console.Write("Введите число: ");
                            int x = int.Parse(Console.ReadLine());
                            m1.Add(x);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Операция завершена");
                        }
                        break;
                    case 2:
                        m1.Out();
                        break;
                    case 3:
                        try
                        {
                            Console.Write("Введите номер элемента который хотите удалить: ");
                            int i = int.Parse(Console.ReadLine());
                            m1.Delete(i);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Операция завершена");
                        }
                        break;
                    case 4:
                        m1.Save();
                        break;
                }
            } while (k != 0);

            Console.ReadKey();

        }
    }
}
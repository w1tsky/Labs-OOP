using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int[,] firstMartix = new int[5, 5];
            int[,] secondMartix = new int[5, 5];
            int[,] resultMatrix = new int[5, 5];
            firstMartix = AddMartix();
            secondMartix = AddMartix();
            Task task = new Task(() => {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        resultMatrix[i, j] = 0;
                        for (int k = 0; k < 5; k++)
                        {
                            resultMatrix[i, j] += firstMartix[i, k] * secondMartix[k, j];
                        }
                    }
                }
            });

            sw.Start();
            task.Start();
            sw.Stop();

            TimeSpan ts = sw.Elapsed;



            ShowMatrix(resultMatrix);

            Console.WriteLine($"Task {task.Id}: {task.Status}\n");
            Console.WriteLine("RunTime " + ts);
            Console.ReadKey();
            Console.Clear();


            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;


            Task task1 = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        resultMatrix[i, j] = 0;
                        for (int k = 0; k < 5; k++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Операция прервана");
                                return;
                            }
                            resultMatrix[i, j] += firstMartix[i, k] * secondMartix[k, j];
                        }
                    }
                }

            });

            Console.WriteLine("CancellationToken:\n\n");
            Console.WriteLine("Press enter to start.");
            Console.ReadLine();
            task1.Start();

            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s == "Y" || s == "y")
            {
                cancelTokenSource.Cancel();

            }
            Console.WriteLine(task1.Status);
            Console.ReadKey();
            Console.Clear();

            int z = 0;
            Func<int> func = () =>
            {

                return ++z;
            };

            Task<int> returnOne = new Task<int>(func);
            Task<int> returnTwo = new Task<int>(func);
            Task<int> returnThree = new Task<int>(func);

            returnOne.Start();
            returnTwo.Start();
            returnThree.Start();

            Func<int> Factorial = () =>
            {
                return returnOne.Result * returnTwo.Result * returnThree.Result;
            };

            Task<int> resultTask = new Task<int>(Factorial);

            resultTask.Start();

            Console.WriteLine("Result = " + resultTask.Result);
            Console.ReadKey();
            Console.Clear();

            Task taskContOne = new Task(() => {
                Console.WriteLine("Id задачи: {0}", Task.CurrentId);
            });

            Task taskContTwo = taskContOne.ContinueWith(Display);

            taskContOne.Start();

            taskContTwo.Wait();
            Console.WriteLine("Выполняется работа метода Main");
            Console.ReadKey();
            Console.Clear();

            Random rand = new Random();

            Task<int> what = Task.Run(() => rand.Next(10) * rand.Next(10));

            var awaiter = what.GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Result: " + awaiter.GetResult());
            });
            Console.ReadKey();
            Console.Clear();

            sw.Restart();
            Parallel.For(0, 5, CreateBigArr);
            sw.Stop();
            Console.WriteLine("Время при Parallel.For:  " + sw.Elapsed + '\n');

            sw.Restart();
            for (int j = 0; j < 5; j++)
            {
                int[] arr = new int[1000000];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(10);
                }
                Console.WriteLine("Выполнена задача номер " + j);
            }
            sw.Stop();
            Console.WriteLine("Время при For: " + sw.Elapsed + '\n');
            Console.WriteLine();

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

            sw.Restart();
            ParallelLoopResult result = Parallel.ForEach<int>(list, CreateBigArr);
            sw.Stop();
            Console.WriteLine("Время при Parallel.Foreach: " + sw.Elapsed + '\n');

            sw.Restart();
            foreach (int x in list)
            {
                int[] arr = new int[1000000];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(10);
                }
                Console.WriteLine("Выполнена задача номер " + x);
            }
            sw.Stop();
            Console.WriteLine("Время при Foreach: " + sw.Elapsed + '\n');
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Parallel.Invoke");
            Parallel.Invoke(() => CreateBigArr(1), () => Display(task), () => GetFactorial(5));
            Console.ReadKey();
            Console.Clear();

            FactorialAsync();   // вызов асинхронного метода

            Console.ReadKey();
            Console.Clear();
        }


        static void GetFactorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Выполняется задача {0}", Task.CurrentId);

            Console.WriteLine("Результат {0}", result);
        }

        static public void CreateBigArr(int x)
        {

            Random rand = new Random();
            int[] arr = new int[1000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(10);
            }
            Console.WriteLine("Выполнена задача номер " + x);
        }

        static void Display(Task t)
        {
            Console.WriteLine("Id задачи: {0}", Task.CurrentId);
            Console.WriteLine("Id предыдущей задачи: {0}", t.Id);

        }

        static public void ShowMatrix(int[,] matr)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("\t" + matr[i, j]);
                }
                Console.WriteLine();
            }
        }

        static public int[,] AddMartix()
        {
            int[,] matr = new int[5, 5];
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matr[i, j] = rand.Next(10);
                }
            }
            return matr;
        }

        static public int[,] Multiplay(int[,] firstMartix, int[,] secondMartix)
        {
            int[,] resultMatrix = new int[5, 5];

            return resultMatrix;
        }

        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync");
            await Task.Run(() => GetFactorial(1));
            Console.WriteLine("Конец метода FactorialAsync");
        }
    }
}
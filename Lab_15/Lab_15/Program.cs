using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Lab_15
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowProcess();
            CreateDomain();
            //NewThred();
            TwoThread();
            Console.ReadKey();
            TimerCallback tm = new TimerCallback(Function);
            Timer timer = new Timer(tm, null, 0, 1000);
        }

        static int q = 0;
        public static void Function(object obj)
        {
            Console.WriteLine("Прошло времени: " + q + " секунд");
            q++;
        }

        static public void ShowProcess()
        {
            Console.WriteLine("Process: ");
            foreach (Process process in Process.GetProcesses())
            {

                Console.WriteLine("ID: {0}  Name: {1}", process.Id, process.ProcessName);
            }
        }

        static public void CreateDomain()
        {
            Console.WriteLine("\nDamain:");
            AppDomain dm = AppDomain.CurrentDomain;
            Console.WriteLine("Name: " + dm.FriendlyName);
            Console.WriteLine("Base directory: " + dm.BaseDirectory + '\n');

            Console.WriteLine("Assemly");
            Assembly[] asseblies = dm.GetAssemblies();
            foreach (Assembly asm in asseblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }

            Console.WriteLine();

            AppDomain secondaryDomain = AppDomain.CreateDomain("Secondary domain");

            secondaryDomain.Load(new AssemblyName("mscorlib"));
            AppDomain.Unload(secondaryDomain);
        }

        static public void NewThred()
        {
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            Thread myThread = new Thread(new ParameterizedThreadStart(Count));

            myThread.Start(number);

            myThread.Suspend();

            Console.WriteLine("Thread Status: " + myThread.ThreadState);
            Console.WriteLine("Thred priority:" + myThread.Priority);
            Console.WriteLine("Thread Name: " + myThread.Name);
            myThread.Resume();


        }

        static public void Count(object x)
        {
            StreamWriter sw = new StreamWriter("SecondThread.txt");
            int n = (int)x;

            Console.WriteLine("Second Thred");
            for (int i = 0; i < n; i++)
            {
                Console.Write(i + " ");
                sw.Write(i + " ");
                Thread.Sleep(500);

            }

        }

        static object locker = new object();


        static public void TwoThread()
        {

            Thread FirstThread = new Thread(new ParameterizedThreadStart(EvenNumbers));
            Thread SecondThread = new Thread(new ParameterizedThreadStart(NotEvenNumbers));
            Console.Write("Введите число: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("/////////////////////////////");
            // SecondThread.Priority = ThreadPriority.Highest;

            //сначала четные потом нечетные
            /*FirstThread.Start(x);
            SecondThread.Start(x);
            */
            //поочерёдно
            FirstThread.Start(x);
            SecondThread.Start(x);


        }

        static public void EvenNumbers(object o)
        {

            int x = (int)o;

            lock (locker)
            {

                for (int i = 0; i < x; i += 2)
                {

                    Console.Write(i + " ");
                    Thread.Sleep(200);

                }
            }

        }

        static public void NotEvenNumbers(object o)
        {
            lock (locker)
            {
                int x = (int)o;
                Thread.Sleep(100);
                for (int i = 1; i < x; i += 2)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(200);
                }
            }
        }
    }


}
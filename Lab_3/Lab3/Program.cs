using System;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main()
        {
            void Method(out int i, ref int j)
            {
                i = 10;
                j = j + 10;

            }

            var anonimanonymousType = new
            {
                Make = "Pejout",
                Model = "223-123",
                Year = 2000,
                Color = "red",
                Price = 103232,
                RegistNumber = 1111
            };

            int val = 1;
            int znach;
            Method(out znach, ref val);
            Console.ForegroundColor = ConsoleColor.Cyan;
            var con = Task.ConstructorC(2);
            var con1 = Task.ConstructorP();
            Console.WriteLine("Введите количество массивов объектов:");
            int sizez = int.Parse(Console.ReadLine());
            OneDArray[] oneDArrays = new OneDArray[sizez];
            for (int i = 0; i < oneDArrays.Length; i++)
            {
                Console.Write("Задайте размер массива: ");
                int size = int.Parse(Console.ReadLine());
                oneDArrays[i] = new OneDArray(size);   // Инициализация одномерного массива
                oneDArrays[i].InputIntArray();                   // Ввод элементов массива с клавиатуры

            }
            
            for (int i = 0; i < oneDArrays.Length; i++)
            {
                Console.WriteLine("\nИсходный массив:");
                oneDArrays[i].ShowIntArray();                    // Вывод на экран исходных элементов массива

                oneDArrays[i].SortingArray();                    // Сортировка элементов массива в порядке возростания
                Console.WriteLine("\nОтсортированный в порядке возростания массив:");
                oneDArrays[i].ShowIntArray();                    // Вывод на экран отсортированных элементов массива

                Console.WriteLine(oneDArrays[i].Length);         // Информация о размерности массива
                Console.WriteLine("\nМассив, элементы которого умножены на скаляр (3):");
                oneDArrays[i].Scalar = 3;
                oneDArrays[i].ShowIntArray();                    // Элементы массива умноженные на скаляр

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nОбращение к элементам массива по индексу:");
                Console.ResetColor();
                Console.WriteLine(oneDArrays[i][-1]);            // Обращение к элементам массива по индексу
                Console.WriteLine(oneDArrays[i][0]);
                Console.WriteLine(oneDArrays[i][2]);
                Console.WriteLine(oneDArrays[i][7]);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nДемонстрация перегрузки операций");
                Console.ResetColor();
                Console.Write("Перегрузка операции ++: ");
                ++oneDArrays[i];                                 // Перегрузка операции ++
                oneDArrays[i].ShowIntArray();
                Console.Write("Перегрузка операции --: ");
                --oneDArrays[i];                                 // Перегрузка операции --
                oneDArrays[i].ShowIntArray();
                Console.Write("Перегрузка операции *5: ");
                oneDArrays[i] *= 5;                              // Перегрузка операции *
                oneDArrays[i].ShowIntArray();

                if (!oneDArrays[i])                              // Перегрузка операции !
                {
                    Console.WriteLine("Элементы массива НЕ упорядочены по возрастанию!");
                }
                else
                {
                    Console.WriteLine("Элементы массива упорядочены по возрастанию.");
                }
                oneDArrays[i].GetHashCode();
                
            }
            Console.ReadKey();
        }
    }
}
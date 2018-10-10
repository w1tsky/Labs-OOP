using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Задайте размер массива: ");
            int size = int.Parse(Console.ReadLine());

            OneDArray array = new OneDArray(size);   // Инициализация одномерного массива
            array.InputIntArray();                   // Ввод элементов массива с клавиатуры
            Console.WriteLine("\nИсходный массив:");
            array.ShowIntArray();                    // Вывод на экран исходных элементов массива

            array.SortingArray();                    // Сортировка элементов массива в порядке возростания
            Console.WriteLine("\nОтсортированный в порядке возростания массив:");
            array.ShowIntArray();                    // Вывод на экран отсортированных элементов массива

            Console.WriteLine(array.Length);         // Информация о размерности массива
            Console.WriteLine("\nМассив, элементы которого умножены на скаляр (3):");
            array.Scalar = 3;
            array.ShowIntArray();                    // Элементы массива умноженные на скаляр

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nОбращение к элементам массива по индексу:");
            Console.ResetColor();
            Console.WriteLine(array[-1]);            // Обращение к элементам массива по индексу
            Console.WriteLine(array[0]);
            Console.WriteLine(array[2]);
            Console.WriteLine(array[7]);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nДемонстрация перегрузки операций");
            Console.ResetColor();
            Console.Write("Перегрузка операции ++: ");
            ++array;                                 // Перегрузка операции ++
            array.ShowIntArray();
            Console.Write("Перегрузка операции --: ");
            --array;                                 // Перегрузка операции --
            array.ShowIntArray();
            Console.Write("Перегрузка операции *5: ");
            array *= 5;                              // Перегрузка операции *
            array.ShowIntArray();

            if (!array)                              // Перегрузка операции !
            {
                Console.WriteLine("Элементы массива НЕ упорядочены по возрастанию!");
            }
            else
            {
                Console.WriteLine("Элементы массива упорядочены по возрастанию.");
            }

            Console.ReadKey();
        }
    }
}
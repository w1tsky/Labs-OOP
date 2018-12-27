using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11
{
    public class Book
    {
        public static int tId = 0;
        int ID;
        public string name;
        public string author;
        public int quantity;
        public int yehr;
        public int cost;




        public Book(String name, String author, int quantity, int yehr, int cost) : this()
        {
            this.name = name;
            this.author = author;
            this.quantity = quantity;
            this.yehr = yehr;
            this.cost = cost;

        }

        public Book()
        {
            tId++;
            ID = tId * 228322;
        }



        public void Info()
        {
            Console.WriteLine($"Название книги: {name},\n автор:{author} ,\n количество страниц:{quantity},\n год выпуска:{yehr},\nстоимость: {cost },\n");
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_13
{
    class MDS_DirInfo
    {
        static string path = "D:\\Учеба\\Курс 2\\ООП\\Labs-OOP\\Lab_13";

        static DirectoryInfo drInf = new DirectoryInfo(path);
        static public void DirInfo()
        {
            Console.WriteLine("Количество файлов в папке : " + drInf.GetFiles().Length);
            Console.WriteLine("Время создания : " + drInf.CreationTime);
            Console.WriteLine("Количество подпапок : " + drInf.GetDirectories().Length);
            Console.WriteLine("Родительская папка : " + drInf.Parent);
            Console.WriteLine();

            MDS_Log.WriteLog("use DirInfo");
        }


    }
}
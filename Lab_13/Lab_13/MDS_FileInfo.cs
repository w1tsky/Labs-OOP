using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_13
{
    class MDS_FileInfo
    {
        static public void FileInfo()
        {
            string path = "D:\\package-lock.json";
            FileInfo flInf = new FileInfo(path);

            if (flInf.Exists)
            {
                Console.WriteLine("Имя файла: " + flInf.Name);
                Console.WriteLine("Время создания: " + flInf.CreationTime);
                Console.WriteLine("Расширение: " + flInf.Extension);
                Console.WriteLine("Размер: " + flInf.Length);
                Console.WriteLine("Полный путь: " + Path.GetFullPath(path));

            }
            Console.WriteLine();
            MDS_Log.WriteLog("use FileInfo");
        }

    }
}
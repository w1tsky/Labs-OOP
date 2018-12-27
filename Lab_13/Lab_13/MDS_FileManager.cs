using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_13
{
    class MDS_FileManager
    {
        static public void FirstManager(string path)
        {
            DirectoryInfo dr = new DirectoryInfo(path + "MDS_Inspect");
            DirectoryInfo dr2 = new DirectoryInfo(path);
            dr.Create();
            StreamWriter sw = new StreamWriter(path + "/MDS_Inspect/mds_dirinfo.txt");
            sw.WriteLine("Количество папок: " + dr2.GetDirectories().Length);
            sw.WriteLine("Количество файлов: " + dr2.GetFiles().Length);
            sw.Close();
            FileInfo file = new FileInfo(path + "/MDS_Inspect/MDS_dirinfo.txt");
            file.CopyTo(path + "/MDS_Inspect/MDS_seconddirinfo.txt", true);
            file.Delete();

            Console.WriteLine("Операция завершена");
            MDS_Log.WriteLog("use FirstManager");
        }

        static public void SecondManager(string path)
        {
            DirectoryInfo dr = new DirectoryInfo(path + "MDS_Files");
            dr.Create();
            DirectoryInfo dr2 = new DirectoryInfo("C:\\textFiles");
            foreach (FileInfo fl in dr2.GetFiles())
            {
                if (fl.Extension == ".txt")
                {
                    fl.CopyTo(path + "MDS_Files\\" + fl.Name);
                }
            }
            dr.MoveTo("C:\\MDS_Inspect\\MDS_Files");
            Console.WriteLine("Операция завершена");
            MDS_Log.WriteLog("use SecondManager");

        }
    }
}
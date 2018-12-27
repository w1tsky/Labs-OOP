using System;
using System.IO;

namespace Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            MDS_FileInfo.FileInfo();
            MDS_DirInfo.DirInfo();
            MDS_DiskInfo.GetDriveInfo();
            MDS_FileManager.FirstManager("C:\\");
            MDS_FileManager.SecondManager("C:\\");
            MDS_Log.ReadLog();
            Console.WriteLine(MDS_Log.FindLog("DirInfo"));
            MDS_Log.LongLog();
            MDS_Log.LogForTheLastHours();
            MDS_Log.ReadLog();
            MDS_Log.LongLog();

            Console.ReadKey();

        }
    }
}
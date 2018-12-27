using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_13
{
    class MDS_DiskInfo
    {
        static public void GetDriveInfo()
        {
            Console.WriteLine("Информация о диске");
            foreach (DriveInfo dr in DriveInfo.GetDrives())
            {
                if (dr.Name == "C:\\")
                {
                    Console.WriteLine("Имя диска: " + dr.Name);
                    Console.WriteLine("Размер диска: " + dr.TotalSize);
                    Console.WriteLine("Свободное место на диске: " + dr.TotalFreeSpace);
                    Console.WriteLine("Метка тома: " + dr.VolumeLabel);
                    Console.WriteLine("Имя файловой системы: " + dr.DriveFormat);
                    Console.WriteLine();
                }


            }

            MDS_Log.WriteLog("use DriverInfo");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_13
{
    class MDS_Log
    {
        static string path = "log.txt";



        static public void WriteLog(string text, bool bl = true)
        {
            StreamWriter sw = new StreamWriter(path, bl);
            sw.WriteLine(DateTime.Now + " : " + text);
            sw.Close();
        }

        static public void ReadLog()
        {
            StreamReader sr = new StreamReader(path);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }

        static public string FindLog(string date)
        {
            string str = " ";

            foreach (string s in File.ReadLines(path))
            {
                if (s.Contains(date))
                {
                    str += s + "\n";
                }
            }

            return str;
        }

        static public void LongLog()
        {
            int i = 0;
            foreach (string s in File.ReadLines(path))
            {
                i++;
            }
            Console.WriteLine("В файле записано " + i + " логов");
        }

        static public void LogForTheLastHours()
        {
            Console.WriteLine("lll");
            string date = DateTime.Now.ToString("dd.MM.yyy") + " " + DateTime.Now.Hour;
            Console.WriteLine("\n" + date);

            string LFTLH = FindLog(date);

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(LFTLH);
            sw.Close();

        }
    }
}

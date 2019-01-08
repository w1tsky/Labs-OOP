using System;
using System.IO;
using System.IO.Compression;

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

            string sourceFile = "D://test/book.pdf"; // исходный файл
            string compressedFile = "D://test/book.gz"; // сжатый файл
            string targetFile = "D://test/book_new.pdf"; // восстановленный файл

            // создание сжатого файла
            Compress(sourceFile, compressedFile);
            // чтение из сжатого файла
            Decompress(compressedFile, targetFile);

            Console.ReadLine();


        }
        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }
    }
}

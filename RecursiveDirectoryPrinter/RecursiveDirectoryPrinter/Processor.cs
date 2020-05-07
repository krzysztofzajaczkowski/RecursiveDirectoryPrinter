using System;
using System.IO;
using System.Linq;
using RecursiveDirectoryPrinter.ExtensionMethods;

namespace RecursiveDirectoryPrinter
{
    public class Processor
    {
        public bool RecursivePrint(string path, int depth)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach (var directoryPath in directories)
            {
                string padding = new String('\t', depth);
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
                int directoryChildrenCount = dirInfo.EnumerateDirectories().Count() + dirInfo.EnumerateFiles().Count();
                Console.WriteLine($"{padding}{dirInfo.Name} ({directoryChildrenCount}) {dirInfo.GetRahs()}");
                RecursivePrint(directoryPath, depth + 1);
            }

            foreach (var filePath in files)
            {
                PrintFile(filePath, depth + 1);
            }

            return true;
        }

        private void PrintFile(string path, int depth)
        {
            string padding = new String('\t', depth);
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine($"{padding}{fileInfo.Name} ({fileInfo.Length} bytes) {fileInfo.GetRahs()}");
        }

        public DateTime GetOldestFileInDirectory(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetOldestChildrenDate();
        }

    }
}
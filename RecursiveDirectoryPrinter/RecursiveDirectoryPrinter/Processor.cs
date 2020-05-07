using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using RecursiveDirectoryPrinter.ExtensionMethods;

namespace RecursiveDirectoryPrinter
{
    public class Processor
    {
        public bool RecursivePrint(string path, int depth)
        {
            string padding = new String('\t', depth);
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            int directoryChildrenCount = dirInfo.EnumerateDirectories().Count() + dirInfo.EnumerateFiles().Count();

            Console.WriteLine($"{padding}{dirInfo.Name} ({directoryChildrenCount}) {dirInfo.GetRahs()}");
            string[] directories;
            string[] files;

            try
            {
                directories = Directory.GetDirectories(path);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Invalid path! Error: {e}");
                return false;
            }

            try
            {
                files = Directory.GetFiles(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Invalid path! Error: {e}");
                return false;
            }

            foreach (var directoryPath in directories)
            {
                
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

        public SortedDictionary<string, int> GetSortedDirectChildren(string path)
        {
            SortedDictionary<string, int> directChildrenDict = new SortedDictionary<string, int>(new StringComparer());

            string[] directories;
            string[] files;

            try
            {
                directories = Directory.GetDirectories(path);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Invalid path! Error: {e}");
                return null;
            }

            try
            {
                files = Directory.GetFiles(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Invalid path! Error: {e}");
                return null;
            }
            foreach (var directoryPath in directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
                int directoryChildrenCount = dirInfo.EnumerateDirectories().Count() + dirInfo.EnumerateFiles().Count();
                directChildrenDict.Add(dirInfo.Name, directoryChildrenCount);
            }

            foreach (var filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                directChildrenDict.Add(fileInfo.Name, (int) fileInfo.Length);
            }

            return directChildrenDict;
        }
    }
}
using System;
using System.IO;

namespace RecursiveDirectoryPrinter.ExtensionMethods
{
    public static class DirectoryInfoExtension
    {
        public static DateTime GetOldestChildrenDate(this DirectoryInfo directory)
        {
            var oldestElementDate = DateTime.Now;

            foreach (var directoryInfo in directory.GetDirectories())
            {
                var directoryOldestElementDate = directoryInfo.GetOldestChildrenDate();
                if (directoryOldestElementDate < oldestElementDate)
                {
                    oldestElementDate = directoryOldestElementDate;
                }
            }

            foreach (var fileInfo in directory.GetFiles())
            {
                var fileCreationDate = fileInfo.CreationTime;
                if (fileCreationDate < oldestElementDate)
                {
                    oldestElementDate = fileCreationDate;
                }
            }

            return oldestElementDate;
        }
    }
}
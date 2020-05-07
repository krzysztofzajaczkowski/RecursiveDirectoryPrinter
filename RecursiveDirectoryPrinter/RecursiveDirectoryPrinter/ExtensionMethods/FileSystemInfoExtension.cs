using System;
using System.IO;

namespace RecursiveDirectoryPrinter.ExtensionMethods
{
    public static class FileSystemInfoExtension
    {
        public static string GetRahs(this FileSystemInfo fileSystemInfo)
        {
            char[] rahs = {'-', '-', '-', '-'};
            FileAttributes fileAttributes = fileSystemInfo.Attributes;
            if ((fileAttributes & FileAttributes.ReadOnly) != 0)
            {
                rahs[0] = 'r';
            }

            if ((fileAttributes & FileAttributes.Archive) != 0)
            {
                rahs[1] = 'a';
            }

            if ((fileAttributes & FileAttributes.Hidden) != 0)
            {
                rahs[2] = 'h';
            }

            if ((fileAttributes & FileAttributes.System) != 0)
            {
                rahs[3] = 's';
            }

            return string.Concat(rahs);
        }
    }
}
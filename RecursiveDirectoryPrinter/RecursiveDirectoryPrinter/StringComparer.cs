using System;
using System.Collections;
using System.Collections.Generic;

namespace RecursiveDirectoryPrinter
{
    [Serializable]
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }

            if (x.Length < y.Length)
            {
                return -1;
            }

            return String.Compare(x, y, StringComparison.CurrentCulture);
        }
    }
}
using System;

namespace RecursiveDirectoryPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new Processor();
            processor.RecursivePrint(args[0], 0);
        }
    }
}

using System;

namespace RecursiveDirectoryPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new Processor();
            processor.RecursivePrint(args[0], 0);
            Console.WriteLine($"Oldest file: {processor.GetOldestFileInDirectory(args[0])}");
            var sortedDict = processor.GetSortedDirectChildren(args[0]);
            var serializer = new Serializer();
            serializer.SerializeToFile(args[1], sortedDict);
            var deserializedDict = serializer.DeserializeFromFile(args[1]);
            foreach (var keyValuePair in deserializedDict)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}

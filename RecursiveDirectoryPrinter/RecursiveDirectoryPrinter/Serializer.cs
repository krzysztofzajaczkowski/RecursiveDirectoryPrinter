using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RecursiveDirectoryPrinter
{
    public class Serializer
    {
        public void SerializeToFile(string filePath, IDictionary<string, int> dictionary)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(fileStream, dictionary);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Serialization error: {e}");
            }
            fileStream.Close();
        }
    }
}
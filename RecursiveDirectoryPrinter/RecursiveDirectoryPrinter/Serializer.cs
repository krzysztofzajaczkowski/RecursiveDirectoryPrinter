using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public IDictionary<string, int> DeserializeFromFile(string filePath)
        {
            SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                sortedDictionary = (SortedDictionary<string, int>) binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Serialization error: {e}");
            }

            return sortedDictionary;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Utilities.SerializationMananger
{
    public class SerializationBase
    {
        public static void SerializeData<T>(string filePath, List<T> data)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (var writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, data); //serializes
                writer.Close(); //close writer
            }
        }


        public static List<T> DeserializeData<T>(string filePath)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (var reader = new StreamReader(filePath))
            {
                try
                {
                    var data = (List<T>)xmlSerializer.Deserialize(reader); //deserializes
                    return data;
                }
                catch (Exception ex)
                {
                    // Handle deserialization errors
                    Console.WriteLine($"Error during deserialization: {ex.Message}");
                    return new List<T>();
                }
            }
        }
    }
}

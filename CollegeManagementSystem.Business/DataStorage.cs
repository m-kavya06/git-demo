using CollegeManagementSystem.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CollegeManagementSystem.Business
{
    public class DataStorage
    {
        public static void SaveToFile<T>(List<T> data, string filePath)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
        public static List<T> LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}

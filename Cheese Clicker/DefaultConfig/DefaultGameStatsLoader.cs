using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Cheese_Clicker.DefaultConfig
{
    public class DefaultGameStatsLoader
    {
        private DefaultStats stats;

        public DefaultGameStatsLoader(string inFileName)
        {
            DeserializeJsonFile(inFileName);
        }

        public void DeserializeJsonFile(string fileName)
        {
            string defaultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DefaultConfig", "JsonFiles", fileName);

           if (File.Exists(defaultFilePath))
           {
                string jsonString = File.ReadAllText(defaultFilePath);
                Debug.WriteLine(jsonString);
                stats = JsonSerializer.Deserialize<DefaultStats>(jsonString)!;
                Debug.WriteLine(stats.defaultMasteryRank + " TEST");
           }
           else
           {
                Debug.WriteLine("Error, could not find file: " + defaultFilePath);
           }
        }

        public DefaultStats GetDefaultStats()
        {
            return stats;
        }
    }
}

using ForcePlatformData.Models;
using Microsoft.VisualBasic;
using System.Text;
using static ForcePlatformData.Constants;

namespace ForcePlatformData.Helpers
{
    public static class CsvProcessor
    {
        private static string path = Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath);

        public static string Save(int userId, int exerciseType, string param, CsvModel data, Constants.Units unit)
        {
            try
            {   
                string csvFilePath = $"platform_data_{userId}_{exerciseType}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";

                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter writer = new StreamWriter(Path.Join(path, csvFilePath), false, Encoding.UTF8))
                {
                    var firstLine = data.CsvItems.Dequeue();

                    var headline = "Time,";
                    var secondLine = $"{firstLine.Time.ToString(@"hh\:mm\:ss\.ffff")},";

                    foreach (var item in firstLine.AxisItems)
                    {
                        headline += $"p{item.Plate + 1}X,p{item.Plate + 1}Y,p{item.Plate + 1}Z({unit}),";
                        secondLine += $"{item.DiffX},{item.DiffY},{item.DiffZ},";
                    }

                    writer.WriteLine(headline);
                    writer.WriteLine(secondLine);

                    foreach(var line in data.CsvItems)
                    {
                        var raw = $"{line.Time.ToString(@"hh\:mm\:ss\.ffff")},";
                        foreach (var item in line.AxisItems)
                        {
                            raw += $"{item.DiffX},{item.DiffY},{item.DiffZ},";
                        }
                        writer.WriteLine(raw);
                    }
                }
                return csvFilePath;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static List<string[]> Read(string fileName)
        {
            string[] lines = File.ReadAllLines(Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath, fileName));
            var result = new List<string[]>();
            foreach (string line in lines)
            {
                // Split the line into an array of values
                string[] values = line.Split(',');
                result.Add(values);
            }
            return result;
        }

        public static string[] ReadLines(string fileName)
        {
            string[] lines=new string[0];
            try
            {
                string fullPath = Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath, fileName);
                if (File.Exists(fullPath))
                    lines = File.ReadAllLines(fullPath);
            }
            catch {  }
            
            return lines;
        }
    }
}

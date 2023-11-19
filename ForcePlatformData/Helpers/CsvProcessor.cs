using ForcePlatformData.Models;
using System.Text;

namespace ForcePlatformData.Helpers
{
    public static class CsvProcessor
    {
        private static string path = Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath);

        public static string Save(int userId, int exerciseType, string param, CsvModel data)
        {
            try
            {
                string csvFilePath = $"platform_data_{userId}_{exerciseType}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";

                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter writer = new StreamWriter(Path.Join(path, csvFilePath), false, Encoding.UTF8))
                {
                    var line = data.CsvItems.Dequeue();

                    var headline = "Time,";
                    var secondLine = $"{line.Time},";

                    foreach (var item in line.AxisItems)
                    {
                        headline += $"p{item.Plate + 1}X,p{item.Plate + 1}Y,p{item.Plate + 1}Z,";
                        secondLine += $"{item.DiffX},{item.DiffY},{item.DiffZ},";
                    }

                    //headline += "FilterType,FilterLength,ExserciseType";
                    //secondLine += $"{data.FilterMode},{data.FilterLength},{data.ExerciseType}";

                    writer.WriteLine(headline);
                    writer.WriteLine(secondLine);

                    while (data.CsvItems.Count > 0)
                    {
                        line = data.CsvItems.Dequeue();
                        var raw = $"{line.Time},";
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
    }
}

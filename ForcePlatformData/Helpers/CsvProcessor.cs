using ForcePlatformData.Models;
using System.Text;

namespace ForcePlatformData.Helpers
{
    public static class CsvProcessor
    {
        private static string path = Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath);

        public static string Save(int userId, CsvModel data, string param, List<int> openPlates)
        {
            try
            {
                string csvFilePath = $"platform_data_{userId}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";

                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter writer = new StreamWriter(Path.Join(path, csvFilePath), false, Encoding.UTF8))
                {
                    var line = data.CsvItems.Dequeue();  
                    
                    var headline = "Time,";
                    var secondLine = $"{line.Time.ToString(@"hh\:mm\:ss\.ffff")},";

                    foreach ( var item in line.AxisItems)
                    {
                        if (openPlates.Contains(item.Plate))
                        {
                            headline += $"p{item.Plate + 1}X,p{item.Plate + 1}Y,p{item.Plate + 1}Z,";
                            secondLine += $"{item.DiffX},{item.DiffY},{item.DiffZ},";
                        }
                    }
                    headline += "FilterType,FilterLength,ExserciseType";
                    secondLine += $"{data.FilterMode},{data.FilterLength},{data.ExerciseType}";

                    writer.WriteLine(headline);
                    writer.WriteLine(secondLine);

                    while (data.CsvItems.Count > 0)
                    {
                        line = data.CsvItems.Dequeue();
                        var raw = $"{line.Time.ToString(@"hh\:mm\:ss\.ffff")},";
                        foreach (var item in line.AxisItems)
                        {
                            if (openPlates.Contains(item.Plate))
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

    }

}

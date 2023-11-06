using ForcePlatformCore.Models;
using System.Reflection;

namespace ForcePlatformCore.Helpers
{
    public static class CsvProcessor
    {
        private static string path = "Data";

        public static void Save(Queue<CSVModel> data, string param)
        {
            try
            {
                string csvFilePath = $"platform_data_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";

                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter writer = new StreamWriter(Path.Join(path, csvFilePath)))
                {
                    var line = data.Dequeue();  
                    var headline = "Time,";
                    foreach( var item in line.PlateData)
                    {
                        headline += $"p{item.Plate}X,p{item.Plate}Y,p{item.Plate}Z,";
                    }
                    headline += "ADC" ;
                    writer.WriteLine(headline);

                    while (data.Count > 0)
                    {
                        line = data.Dequeue();
                        var raw = $"{line.Time},";//.ToString(@"hh\:mm\:ss\.ffff")},";
                        foreach (var item in line.PlateData)
                        {
                            raw += $"{item.DiffX},{item.DiffY},{item.DiffZ},";
                        }
                        raw += $"{line.CurrentADC}";
                        writer.WriteLine(raw);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }

}

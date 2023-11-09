using ForcePlatformCore.Models;
using System.Reflection;
using WindowsFormsApp1;

namespace ForcePlatformCore.Helpers
{
    public static class CsvProcessor
    {
        private static string path = Program.Config.ReportPath;

        public static string Save(int userId, Queue<CSVModel> data, string param, List<int> openPlates)
        {
            try
            {
                string csvFilePath = $"platform_data_{userId}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";

                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter writer = new StreamWriter(Path.Join(path, csvFilePath)))
                {
                    var line = data.Dequeue();  
                    var headline = "Time,";
                    foreach( var item in line.PlateData)
                    {
                        if(openPlates.Contains(item.Plate))
                            headline += $"p{item.Plate+1}X,p{item.Plate+1}Y,p{item.Plate+1}Z";
                    }
                    writer.WriteLine(headline);

                    while (data.Count > 0)
                    {
                        line = data.Dequeue();
                        var raw = $"{line.Time.ToString(@"hh\:mm\:ss\.ffff")},";
                        foreach (var item in line.PlateData)
                        {
                            if (openPlates.Contains(item.Plate))
                                raw += $"{item.DiffX},{item.DiffY},{item.DiffZ}";
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

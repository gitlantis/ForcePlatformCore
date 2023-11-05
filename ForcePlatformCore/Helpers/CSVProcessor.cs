using ForcePlatformCore.Models;
using System.Reflection;

namespace ForcePlatformCore.Helpers
{
    public static class CSVProcessor
    {
        private static string path = "Data";

        public static string Save(int plateNumber, List<CSVModel> model)
        {
            try
            {
                string csvFilePath = $"plate_{plateNumber}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";
                SaveDoubleListToCSV(model, csvFilePath);
                return Path.Join(path,csvFilePath);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        static void SaveDoubleListToCSV(List<CSVModel> data, string fileName)
        {
            try
            {
                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter writer = new StreamWriter(Path.Join(path, fileName)))
                {
                    writer.WriteLine("DiffX,DiffY,DiffZ");

                    foreach (var row in data)
                    {
                        string csvRow = $"{row.DiffX},{row.DiffY},{row.DiffZ}";
                        writer.WriteLine(csvRow);
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

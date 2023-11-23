using ForcePlatformData.DbModels;
using ForcePlatformData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Text;
using static ForcePlatformData.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ForcePlatformData.Helpers
{
    public static class CsvProcessor
    {
        private static string path = Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath);

        public static string Save(int userId, int exerciseType, CsvModel data, Constants.Units unit)
        {
            try
            {
                string csvFileName = $"platform_data_{userId}_{exerciseType}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";

                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter writer = new StreamWriter(Path.Join(path, csvFileName), false, Encoding.UTF8))
                {
                    var firstLine = data.CsvItems.Dequeue();

                    var headline = "Time(msec),";
                    var secondLine = $"{firstLine.Time},";

                    foreach (var item in firstLine.AxisItems)
                    {
                        headline += $"p{item.Plate + 1}X(%),p{item.Plate + 1}Y(%),p{item.Plate + 1}Z({unit}),";
                        secondLine += $"{item.DiffX},{item.DiffY},{item.DiffZ},";
                    }

                    writer.WriteLine($"{headline}UcTime");
                    writer.WriteLine($"{secondLine}{firstLine.UcTime}");

                    foreach (var line in data.CsvItems)
                    {
                        var raw = $"{line.Time},";
                        foreach (var item in line.AxisItems)
                        {
                            raw += $"{item.DiffX},{item.DiffY},{item.DiffZ},";
                        }
                        writer.WriteLine($"{raw}{line.UcTime}");
                    }
                }
                return csvFileName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string[]> Read(string fileName)
        {
            var result = new List<string[]>();

            try
            {
                string[] lines = File.ReadAllLines(Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath, fileName));
                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    result.Add(values);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static string[] ReadLines(string fileName)
        {
            string[] lines = new string[0];
            try
            {
                string fullPath = Path.Join(AppConfig.CommonPath, AppConfig.Config.ReportsPath, fileName);
                if (File.Exists(fullPath))
                    lines = File.ReadAllLines(fullPath);
            }
            catch { }

            return lines;
        }
        public static string Delete(string fileName)
        {
            try
            {
                File.Delete(Path.Join(path, fileName));
                return fileName;
            }
            catch { }
            return "";
        }
    }
}

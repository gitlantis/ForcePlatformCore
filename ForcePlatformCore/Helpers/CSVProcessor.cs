using ForcePlatformCore.Models;
using System.Reflection;

namespace ForcePlatformCore.Helpers
{
    public static class CSVProcessor
    {
        private static string path = "Data";

        public static void Save(int plateNumber, List<CSVModel> model)
        {

            try
            {
                string csvFilePath = $"plate_{plateNumber}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";
                SaveDoubleListToCSV(model, csvFilePath);

                string message = $"data saved in: {Path.Join(path, csvFilePath)} file";
                string caption = "Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

            }
            catch (Exception e)
            {
                string message = e.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
            }

        }

        public static void SaveAll(Dictionary<int, List<CSVModel>> plates)
        {
            try
            {
                foreach (var plate in plates)
                {
                    string csvFilePath = $"plate_{plate.Key}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";
                    SaveDoubleListToCSV(plate.Value, csvFilePath);
                }
                string message = $"data saved in: {path} folder";
                string caption = "Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
            }


            catch (Exception e)
            {
                string message = e.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
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
                    writer.WriteLine("Weight,DiffX,DiffY");

                    foreach (var row in data)
                    {
                        string csvRow = $"{row.Weight},{row.DiffX},{row.DiffY}";
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

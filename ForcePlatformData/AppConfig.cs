using ForcePlatformData.DbModels;
using ForcePlatformData.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ForcePlatformData
{
    public static class AppConfig
    {
        private static IConfiguration Configuration { get; set; }
        public static SqliteContext DbContext = new SqliteContext();
        public static User User { get; set; }
        
        public static AppsettingsModel? UpdateConfig
        {
            set
            {
                Update(value);
            }
        }

        public static AppsettingsModel Config => Get();

        public static string CommonPath = AppsettingsModel.CommonPath;
        public static string DbName = AppsettingsModel.DbName;

        private static AppsettingsModel Get()
        {
            if (!Directory.Exists(CommonPath))
                Directory.CreateDirectory(CommonPath);

            var commonFiles = new Dictionary<string, string>
            {
                { Path.Join(Environment.CurrentDirectory, AppsettingsModel.AppSettingsName), Path.Join(CommonPath, AppsettingsModel.AppSettingsName)},
                { Path.Join(Environment.CurrentDirectory, AppConfig.DbName), Path.Join(CommonPath, AppConfig.DbName)}
            };

            foreach (var file in commonFiles)
                if (!File.Exists(file.Value))
                    File.Copy(file.Key, file.Value);

            var builder = new ConfigurationBuilder().AddJsonFile(Path.Join(CommonPath, AppsettingsModel.AppSettingsName), optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            var result = Configuration.Get<AppsettingsModel>();

            var reportPath = Path.Join(CommonPath, result.ReportsPath);
            if (!Directory.Exists(reportPath))
                Directory.CreateDirectory(reportPath);

            var pdfReportPath = Path.Join(CommonPath, result.PdfReportPath);
            if (!Directory.Exists(pdfReportPath))
                Directory.CreateDirectory(pdfReportPath);

            return result;
        }

        public static void Update(AppsettingsModel model)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            File.WriteAllText(Path.Join(CommonPath, AppsettingsModel.AppSettingsName), JsonSerializer.Serialize(model, jsonOptions));
        }
    }




}

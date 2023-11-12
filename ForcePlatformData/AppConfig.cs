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

        private static string commonPath = AppsettingsModel.CommonPath;

        private static AppsettingsModel Get()
        {
            if (!Directory.Exists(commonPath))
                Directory.CreateDirectory(commonPath);

            var commonFiles = new Dictionary<string, string>
            {
                { Path.Join(Environment.CurrentDirectory, AppsettingsModel.AppSettingsName), Path.Join(commonPath, AppsettingsModel.AppSettingsName)},
                { Path.Join(Environment.CurrentDirectory, AppsettingsModel.DbName), Path.Join(commonPath, AppsettingsModel.DbName)}
            };

            foreach (var file in commonFiles)
                if (!File.Exists(file.Value))
                    File.Copy(file.Key, file.Value);

            var builder = new ConfigurationBuilder().AddJsonFile(Path.Join(commonPath, AppsettingsModel.AppSettingsName), optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            var result = Configuration.Get<AppsettingsModel>();
            return result;
        }

        public static void Update(AppsettingsModel model)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            File.WriteAllText(Path.Join(commonPath, AppsettingsModel.AppSettingsName), JsonSerializer.Serialize(model, jsonOptions));
        }
    }




}

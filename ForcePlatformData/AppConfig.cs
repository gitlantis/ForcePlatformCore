using ForcePlatformData.DbModels;
using ForcePlatformData.Models;
using Microsoft.Extensions.Configuration;

namespace ForcePlatformData
{
    public static class AppConfig
    {
        private static IConfiguration Configuration { get; set; }
        public static SqliteContext DbContext = new SqliteContext();
        public static User User { get; set; }
        public static AppsettingsModel Config => Get();

        private static AppsettingsModel Get()
        {
            var commonPath = AppsettingsModel.CommonPath;

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
            var config = Configuration.Get<AppsettingsModel>();
            return config;
        }
    }
}

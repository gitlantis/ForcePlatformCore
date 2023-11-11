using ForcePlatformData.DbModels;
using ForcePlatformData.Models;
using Microsoft.Extensions.Configuration;

namespace ForcePlatformData
{
    public static class AppConfig
    {
        private static IConfiguration Configuration { get; set; }
        public static SqliteContext? dbContext = new SqliteContext();
        public static User User { get; set; }
        public static AppsettingsModel Config => Get();

        private static AppsettingsModel Get()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            var config= Configuration.Get<AppsettingsModel>();
            return config;
        }
    }
}

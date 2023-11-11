using ForcePlatformCore;
using ForcePlatformCore.DbModels;
using Microsoft.Extensions.Configuration;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        private static IConfiguration Configuration { get; set; }
        public static AppsettingsModel Config { get; set; }
        public static SqliteContext? dbContext = new SqliteContext();
        public static User User {get;set;}
        public static MDIParent1 mdiParent;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config = Configuration.Get<AppsettingsModel>();
            
            mdiParent = new MDIParent1();

            Application.Run(mdiParent);
        }

        public static DialogResult Message(string caption, string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            return result;
        }
    }
}

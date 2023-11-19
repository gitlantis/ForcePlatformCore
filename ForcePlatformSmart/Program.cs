using ForcePlatformData;
using ForcePlatformData.DbModels;

namespace ForcePlatformSmart
{
    internal static class Program
    {
        public static User User = new User();
        public static MainMDI mdiParent;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
         
            AppConfig.DbContext.Database.EnsureCreated();

            Application.Run(new MainMDI());
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
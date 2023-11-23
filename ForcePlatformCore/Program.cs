using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformData;
using ForcePlatformData.DbModels;

namespace ForcePlatformCore
{
    internal static class Program
    {
        public static User User =new User();
        public static MainMDI mdiParent;
        public static ComPort ComPort;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mdiParent = new MainMDI();

            try
            {
                AppConfig.DbContext.Database.EnsureCreated();
                ComPort = new ComPort(AppConfig.Config.AutoSelectCom, AppConfig.Config.ComPort, AppConfig.Config.FilterLength);
                if (!AppConfig.Config.AutoSelectCom)
                {
                    var conf = AppConfig.Config;
                    conf.ComPort = ComPort.PortName;
                    AppConfig.UpdateConfig = conf;
                }
            }
            catch (Exception ex) {
                Message("Error", ex.Message);
            }

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

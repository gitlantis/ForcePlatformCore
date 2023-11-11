using ForcePlatformData.DbModels;

namespace ForcePlatformCore
{
    internal static class Program
    {
        public static User User {get;set;}
        public static MainMDI mdiParent;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            mdiParent = new MainMDI();

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

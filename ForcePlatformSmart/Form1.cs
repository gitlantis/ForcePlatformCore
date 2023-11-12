using ForcePlatformData.Helpers;

namespace ForcePlatformSmart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PdfProcessor.GeneratePdf();
        }
    }
}
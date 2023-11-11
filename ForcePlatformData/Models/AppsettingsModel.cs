namespace ForcePlatformData.Models
{
    public class AppsettingsModel
    {
        public bool AutoSelectCom { get; set; }
        public string ComPort { get; set; }
        public int FilterLength { get; set; }
        public double CalibrateZ { get; set; }
        public double FreeFallAcc { get; set; }
        public string ReportsPath { get; set; }
        public string ChromePath { get; set; }
        public string TemplatePath { get; set; }
        public string PdfReportPath { get; set; }

    }
}

using PuppeteerSharp.Media;
using PuppeteerSharp;

namespace ForcePlatformData.Helpers
{
    public static class PdfProcessor
    {
        private readonly static string chrome = Path.Join(Environment.CurrentDirectory, AppConfig.Config.ChromePath);
        private readonly static string pdfReportPath = Path.Join(Environment.CurrentDirectory, AppConfig.Config.PdfReportPath);

        public static void GeneratePdf()
        {
            if (AppConfig.User != null)
            {
                using (var browser = Puppeteer.LaunchAsync(new LaunchOptions
                {
                    ExecutablePath = chrome,
                    Headless = true
                }).Result)
                using (var page = browser.NewPageAsync().Result)
                {
                    var url = Path.Join(Environment.CurrentDirectory, AppConfig.Config.TemplatePath, "FirstPage.html");

                    var printOptions = new PdfOptions
                    {
                        Format = PaperFormat.A4,
                        Landscape = true,
                        PrintBackground = true,
                    };

                    page.GoToAsync(url, new NavigationOptions
                    {
                        WaitUntil = new[] { WaitUntilNavigation.Load }
                    }).Wait();

                    var pdfBytes = page.PdfDataAsync(printOptions).Result;

                    File.WriteAllBytes(Path.Join(pdfReportPath, $"report_{AppConfig.User.Id}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.pdf"), pdfBytes);
                }
            }
            else {
                //Program.Message("Warning", "User is not selected");
            }
        }
    }
}

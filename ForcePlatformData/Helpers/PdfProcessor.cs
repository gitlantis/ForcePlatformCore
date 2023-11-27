using PuppeteerSharp.Media;
using PuppeteerSharp;
using ForcePlatformData.DbModels;
using System.Diagnostics;

namespace ForcePlatformData.Helpers
{
    public static class PdfProcessor
    {
        private readonly static string chrome = Path.Join(AppConfig.CommonPath, AppConfig.Config.ChromePath);
        private readonly static string pdfReportPath = Path.Join(AppConfig.CommonPath, AppConfig.Config.PdfReportPath);

        public static string GeneratePdf(User user, Report userReport)
        {
            try
            {
                if (AppConfig.User == null)
                {
                    using (var browser = Puppeteer.LaunchAsync(new LaunchOptions
                    {
                        ExecutablePath = chrome,
                        Headless = true
                    }).Result)
                    using (var page = browser.NewPageAsync().Result)
                    {
                        var templateDir = Path.Join(Environment.CurrentDirectory, AppConfig.Config.TemplatePath);
                        File.Copy(Path.Join(templateDir, "GraphPage.html"), Path.Join(templateDir, "_GraphPage.html"), true);

                        var url = Path.Join(templateDir, "_GraphPage.html");

                        string[] lines = File.ReadAllLines(url);

                        for (int i = 0; i < lines.Length; i++)
                        {
                            lines[i] = lines[i].Replace(".Patient", $"{user.Name} {user.Surname} {user.MiddleName}");
                            lines[i] = lines[i].Replace(".BirthDate", $"{user.BirthDate.ToString("yyyy/MM/dd")}");
                            lines[i] = lines[i].Replace(".Weight", $"{user.UserParams.BodyWeight} kg");
                            lines[i] = lines[i].Replace(".Height", $"{user.UserParams.BodyHeight} sm");
                            lines[i] = lines[i].Replace(".Gender", $"{user.UserParams.Gender}");
                            lines[i] = lines[i].Replace(".Comment", $"{userReport.Comment}");
                        }

                        File.WriteAllLines(url, lines);

                        var originalHtmlContent = File.ReadAllText(url);

                        var printOptions = new PdfOptions
                        {
                            Format = PaperFormat.A4,
                            Landscape = true,
                            PrintBackground = true,
                            MarginOptions = new MarginOptions
                            {
                                Top = "10mm",
                                Bottom = "10mm",
                                Left = "10mm",
                                Right = "10mm",
                                
                            }
                        };

                        page.GoToAsync(url, new NavigationOptions
                        {
                            WaitUntil = new[] { WaitUntilNavigation.Load }
                        }).Wait();

                        var pdfBytes = page.PdfDataAsync(printOptions).Result;

                        var resultPath = Path.Join(pdfReportPath, $"report_{1}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.pdf");
                        File.WriteAllBytes(resultPath, pdfBytes);
                        Process.Start(Path.Join(AppConfig.CommonPath,AppConfig.Config.ChromePath), resultPath);

                        return resultPath;
                    }
                }
                else
                {
                    throw new Exception("User is not selected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using PuppeteerSharp.Media;
using PuppeteerSharp;
using ForcePlatformData.DbModels;
using System.Diagnostics;
using System.IO;

namespace ForcePlatformData.Helpers
{
    public static class VideoProcessor
    {
        private readonly static string videosPath = Path.Join(AppConfig.CommonPath, AppConfig.Config.VideosPath);

        public static void Play(string fileName)
        {
            try
            {
                var fullPath = Path.Join(AppConfig.CommonPath, AppConfig.Config.VideosPath, $"{fileName}.{Constants.FileTypes.mp4}");
                if (File.Exists(fullPath))
                {
                    Process.Start(Path.Join(AppConfig.CommonPath, AppConfig.Config.VlcPath), fullPath);
                }
                else
                {
                    throw new Exception("The video does not exist: " + fullPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Delete(string fileName)
        {
            try
            {
                File.Delete(Path.Join(videosPath, $"{fileName}.{Constants.FileTypes.mp4}"));
                return fileName;
            }
            catch { }
            return "";
        }
    }
}

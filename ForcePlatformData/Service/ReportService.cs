using ForcePlatformData.DbModels;

namespace ForcePlatformData.Service
{
    public class ReportService
    {
        public int AddReport(int userId, string path)
        {
            try
            {
                var report = new Report()
                {
                    UserId = userId,
                    Path = path,
                    CreatedDate = DateTime.Now
                };
                AppConfig.dbContext.Add(report);
                AppConfig.dbContext!.SaveChanges();
                return report.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Report> GetReports(int userId)
        {
            try
            {
                var reports = AppConfig.dbContext.Reports.Where(c=>c.UserId==userId).ToList();
                return reports;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

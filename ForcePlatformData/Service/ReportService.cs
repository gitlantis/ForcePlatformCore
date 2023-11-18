using ForcePlatformData.DbModels;

namespace ForcePlatformData.Service
{
    public class ReportService
    {
        public int AddReport(int userId, string path, int exerciseTypeId)
        {
            try
            {
                var report = new Report()
                {
                    UserId = userId,
                    Path = path,
                    ExerciseTypeId = exerciseTypeId,
                    CreatedDate = DateTime.Now
                };
                AppConfig.DbContext.Add(report);
                AppConfig.DbContext!.SaveChanges();
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
                var reports = AppConfig.DbContext.Reports.Where(c=>c.UserId==userId).ToList();
                return reports;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

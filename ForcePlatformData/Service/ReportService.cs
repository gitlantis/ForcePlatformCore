using ForcePlatformData.DbModels;
using static ForcePlatformData.Constants;

namespace ForcePlatformData.Service
{
    public class ReportService
    {
        public int AddReport(int userId, string path, int exerciseTypeId, Units unit)
        {
            try
            {
                var report = new Report()
                {
                    UserId = userId,
                    Path = path,
                    Unit = unit.ToString(),
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
        public List<Report> GetReportsByUserId(int userId)
        {
            try
            {
                var reports = AppConfig.DbContext.Reports.Where(c => c.UserId == userId).OrderByDescending(c => c.CreatedDate).ToList();
                return reports;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Report GetReportById(int id)
        {
            try
            {
                var report = AppConfig.DbContext.Reports.Where(c => c.Id == id).FirstOrDefault();
                return report;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

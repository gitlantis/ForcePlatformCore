using ForcePlatformCore.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using ForcePlatformCore;

namespace ForcePlatformCore.Service
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
                Program.dbContext.Add(report);
                Program.dbContext!.SaveChanges();
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
                var reports = Program.dbContext.Reports.Where(c=>c.UserId==userId).ToList();
                return reports;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace ForcePlatformData.DbModels
{
    public class Report
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Path { get; set; }
        public string Unit { get; set; }
        public string Comment { get; set; }
        public int FilterLength { get; set; }
        public int ExerciseTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User User { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public string FullDetail => String.Format("{0, -15}{1, -50}{2, 0}", CreatedDate.ToString("MM/dd/yyyy"), Path, Comment);
    }
}

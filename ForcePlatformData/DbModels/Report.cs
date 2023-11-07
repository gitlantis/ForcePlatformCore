using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForcePlatformData.DbModels
{
    public class Report
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public string Id { get; set; }
        public string Path { get; set; }
        public DateTime createdDate { get; set; }
        public virtual User User { get; set; }
    }
}

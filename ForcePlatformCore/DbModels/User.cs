using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForcePlatformCore.DbModels
{
    public class User
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public virtual UserParams UserParams { get; set; }
        public virtual IEnumerable<Report>? Reports { get; set; }

        public string FullName => $"{Name} {Surname} {MiddleName} - {Id}";
    }
}

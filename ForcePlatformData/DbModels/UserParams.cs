using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForcePlatformData.DbModels
{
    public class UserParams
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int LeftSole { get; set; }
        public int LeftShin { get; set; }
        public int LeftTigh { get; set; }
        public int RightSole { get; set; }
        public int RightShin { get; set; }
        public int RightTigh { get; set; }
        public int BodyHeight { get; set; }
        public string LengthMeasurement { get; set; }
        public int Wight { get; set; }
        public string WightMeasurement { get; set; }
        public virtual User User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForcePlatformData.DbModels
{
    public class UserParams
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Gender { get; set; }
        public double? LeftSole { get; set; }
        public double? LeftShin { get; set; }
        public double? LeftTigh { get; set; }
        public double? RightSole { get; set; }
        public double? RightShin { get; set; }
        public double? RightTigh { get; set; }
        public double? LeftHand{ get; set; }
        public double? LeftForearm { get; set; }
        public double? LeftUpperLimb { get; set; }
        public double? RightHand { get; set; }
        public double? RightForearm { get; set; }
        public double? RightUpperLimb { get; set; }
        public string LengthUnit { get; set; } = "sm";
        public double? BodyHeight { get; set; }
        public double? BodyWeight { get; set; }
        public virtual User User { get; set; }
    }
}

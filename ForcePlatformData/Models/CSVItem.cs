namespace ForcePlatformData.Models
{
    public class CsvItem
    {
        public int Time { get; set; }
        public int UcTime { get; set; }
        public List<AxisItem> AxisItems { get; set; }
    }
}

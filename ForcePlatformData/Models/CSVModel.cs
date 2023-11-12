namespace ForcePlatformData.Models
{
    public class CsvModel
    {
        public TimeSpan Time { get; set; }
        public List<CsvItem> PlateData { get; set; }
    }
}

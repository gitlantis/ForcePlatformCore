namespace ForcePlatformData.Models
{
    public class CsvModel
    {
        public string FilterMode { get; set; } = "";
        public int FilterLength { get; set; }
        public string ExerciseType { get; set; } = "";
        public Queue<CsvItem> CsvItems { get; set; }
    }
}

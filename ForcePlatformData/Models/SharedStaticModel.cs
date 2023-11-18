namespace ForcePlatformData.Models
{
    public class SharedStaticModel
    {
        public static int FilterTypeIndex { get; set; } = -1;
        public static string FilterType { get; set; } = "";
        public static int FilterLength { get; set; }
        public static string ExerciseType { get; set; } = "";
        public static int ExerciseTypeIndex { get; set; } = 0;
        public static double DiffX { get; set; } = 1;
        public static double DiffY { get; set; } = 1;
        public static double DiffZ { get; set; } = 1;
        public static double Weight { get; set; } = 1;
    }
}

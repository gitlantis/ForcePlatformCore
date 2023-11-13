namespace ForcePlatformData.Models
{
    public static class AdcBuffer
    {
        public static Dictionary<int, List<AdcBufferItem>> BufferItems = new Dictionary<int, List<AdcBufferItem>> {
            { 0,new List<AdcBufferItem>() },
            { 1,new List<AdcBufferItem>() },
            { 2,new List<AdcBufferItem>() },
            { 3,new List<AdcBufferItem>() }
        };
    }
    public class AdcBufferItem
    {
        public int Plate { get; set; }
        public TimeSpan Time { get; set; }
        public int DiffX { get; set; }
        public int DiffY { get; set; }
        public int DiffZ { get; set; }
        public int CurrentTimeMC { get; set; }
    }
}

using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace ForcePlatformData.Models
{
    public static class SmallAdcBuffer
    {
        public static Dictionary<int, List<AdcBufferItem>> BufferItems = new Dictionary<int, List<AdcBufferItem>> {
            { 0,new List<AdcBufferItem>() },
            { 1,new List<AdcBufferItem>() },
            { 2,new List<AdcBufferItem>() },
            { 3,new List<AdcBufferItem>() }
        };

        public static void PushNew(int indx, AdcBufferItem data)
        {
            BufferItems[indx].Add(data);
            if (BufferItems[indx].Count > 200) { BufferItems[indx].RemoveAt(0); };
        }
    }

    public class AdcBufferItem
    {
        public TimeSpan Time { get; set; }
        public double DiffX { get; set; }
        public double DiffY { get; set; }
        public double DiffZ { get; set; }
        public int CurrentTimeMC { get; set; }
    }
}

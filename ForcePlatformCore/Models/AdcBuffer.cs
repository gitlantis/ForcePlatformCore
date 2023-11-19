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

        public static void PushNew(int indx, AdcBufferItem data, bool isRecording)
        {
            BufferItems[indx].Add(data);
            if (BufferItems[indx].Count > 200 && !isRecording) { BufferItems[indx].RemoveAt(0); };
        }
    }

    public class AdcBufferItem
    {
        public TimeSpan Time { get; set; }
        public int DiffX { get; set; }
        public int DiffY { get; set; }
        public int DiffZ { get; set; }
        public int CurrentTimeMC { get; set; }
    }
}

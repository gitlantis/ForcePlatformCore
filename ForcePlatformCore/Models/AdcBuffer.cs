using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformCore.Models
{
    public static class AdcBuffer
    {
        public static List<AdcBufferItem> BufferItems = new List<AdcBufferItem>();
    }
    public class AdcBufferItem
    {
        public int Plate { get; set; }
        public string Time { get; set; }
        public int DiffX { get; set; }
        public int DiffY { get; set; }
        public int DiffZ { get; set; }
        public int CurrentTimeMC { get; set; }
    }
}

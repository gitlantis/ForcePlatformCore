using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformCore.Helpers.ComPort
{
    public class AdcSerialData
    {
        public int CurrentTimeMC { get; set; }
        public int FilterLength { get; set; }
        public int[] CurrentAdc { get; set; }
        public int[] OlderAdc { get; set; }
        public int[] ZeroAdc { get; set; }
        public int[] ZeroedAdc { get; set; }
        public int[,] FilterBuff { get; set; }
        public int[] FilteredAdc { get; set; }
        public int[] MiddledAdc { get; set; }
        public int[] AbsAdc { get; set; }

        public int[] DiffX { get; set; }
        public int[] DiffY { get; set; }
        public int[] DiffZ { get; set; }

        public void Init(int filterLength)
        {
            FilterLength = filterLength;
            CurrentAdc = new int[16];
            OlderAdc = new int[16];
            ZeroAdc = new int[16];
            ZeroedAdc = new int[16];
            FilterBuff = new int[16, filterLength];
            FilteredAdc = new int[16];
            MiddledAdc = new int[16];
            AbsAdc = new int[16];
            DiffZ = new int[4];
            DiffX = new int[4];
            DiffY = new int[4];
        }
    }
}






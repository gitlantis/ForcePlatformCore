using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatFormComPort
{
    public class AdcData
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
    }
}






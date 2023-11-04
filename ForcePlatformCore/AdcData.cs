using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace ForcePlatformCore
{
    public static class AdcData
    {
        public static int CurrentTimeMC { get; set; }
        public static int FilterLength { get; set; }
        public static int[] CurrentAdc { get; set; }
        public static int[] OlderAdc { get; set; }
        public static int[] ZeroAdc { get; set; }
        public static int[] ZeroedAdc { get; set; }
        public static int[,] FilterBuff { get; set; }
        public static int[] FilteredAdc { get; set; }
        public static int[] MiddledAdc { get; set; }
        public static int[] AbsAdc { get; set; }

        public static int[] DiffZ { get; set; }
        public static int[] DiffX { get; set; }
        public static int[] DiffY { get; set; }
    }
}






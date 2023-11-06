using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace ForcePlatformCore.Models
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

        public static void Init(int filterLength)
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

        public static void Set(dynamic data)
        {
            try
            {
                CurrentTimeMC = data.CurrentTimeMC;
                FilterLength = data.FilterLength;
                CurrentAdc = data.CurrentAdc;
                OlderAdc = data.OlderAdc;
                ZeroAdc = data.ZeroAdc;
                ZeroedAdc = data.ZeroedAdc;
                FilterBuff = data.FilterBuff;
                FilteredAdc = data.FilteredAdc;
                MiddledAdc = data.MiddledAdc;
                AbsAdc = data.AbsAdc;
                DiffX = data.DiffX;
                DiffY = data.DiffY;
                DiffZ = data.DiffZ;
            }catch(Exception ex) { }
        }
    }
}






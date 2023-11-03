using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
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

        public static int[] Weights { get; set; }
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
            Weights = new int[4];
            DiffX = new int[4];
            DiffY = new int[4];
        }

        public static void FilterData()
        {
            long[] sums = new long[16];
            int tmp;
            for (int j = 0; j < 16; j++)
            {
                for (int i = 1; i < FilterLength; i++)
                {
                    FilterBuff[j, i - 1] = FilterBuff[j, i];
                }
                FilterBuff[j, FilterLength-1] = ZeroedAdc[j];
            }

            for (int j = 0; j < 16; j++)
            {
                sums[j] = 0; tmp = 0;
                for (int i = 0; i < FilterLength; i++)
                {
                    tmp++;
                    sums[j] += FilterBuff[j, i] * tmp;
                }
                FilteredAdc[j] = (int)(sums[j] / tmp);
                AbsAdc[j] = Math.Abs(FilteredAdc[j]);
            }

            for (int j = 0; j < 4; j++) { Weights[j] = 0; for (int i = 0; i < 4; i++) Weights[j] += AbsAdc[i+j*4]; };
            
            for (int j = 0; j < 4; j++) 
            {
                DiffX[j] = (AbsAdc[j * 4 + 0] + AbsAdc[j * 4 + 3]) - (AbsAdc[j * 4 + 1] + AbsAdc[j * 4 + 2]);
                DiffY[j] = (AbsAdc[j * 4 + 0] + AbsAdc[j * 4 + 1]) - (AbsAdc[j * 4 + 2] + AbsAdc[j * 4 + 3]);
            };


        }
        public static void FreshData()
        { 
            for (int i = 0; i < CurrentAdc.Length; i++) { ZeroedAdc[i] = CurrentAdc[i] - ZeroAdc[i]; MiddledAdc[i] = (int)((FilterLength * MiddledAdc[i] + CurrentAdc[i]) / (FilterLength +1)); }
            
            FilterData();

            // write to storage here
        }


        public static void Zero()
        {
            for (int i = 0; i < CurrentAdc.Length; i++) { ZeroAdc[i] = MiddledAdc[i]; }
        }
    }
}






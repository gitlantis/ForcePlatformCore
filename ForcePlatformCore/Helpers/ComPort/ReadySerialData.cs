using ForcePlatformCore.Models;
using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformCore.Helpers.ComPort
{
    public class ReadySerialData //const
    {
        public int CurrentTimeMC { get; set; }
        public int FilterLength { get; set; }
        public int[] DiffX { get; set; }
        public int[] DiffY { get; set; }
        public int[] DiffZ { get; set; }

        public ReadySerialData() // new () да ишлайдиган ok
        {
            DiffZ = new int[4];
            DiffX = new int[4];
            DiffY = new int[4];
        }

        public void Set(int FilterLength, int CurrentTimeMC, int[] DiffX, int[] DiffY, int[] DiffZ)
        {
            // prisvaivanie qilish kerak
            this.FilterLength = FilterLength;
            this.CurrentTimeMC = CurrentTimeMC;
            for (int i = 0; i < DiffX.Length; i++)
            {
                this.DiffX[i] = DiffX[i];
                this.DiffY[i] = DiffY[i];
                this.DiffZ[i] = DiffZ[i];
            }
        }


    }
}






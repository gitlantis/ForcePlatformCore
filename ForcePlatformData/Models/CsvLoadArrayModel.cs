using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformData.Models
{
    public class CsvLoadArrayModel
    {
        public int[] data;

        public CsvLoadArrayModel()
        {
            data = new int[13];
        }

        public CsvLoadArrayModel(string[] strs) : this()
        {

            for (int i = 0; i < 13; i++)
                try
                {
                    data[i] = Int32.Parse(strs[i]);
                }
                catch { };

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformData.Models
{
    public class CsvLoadArrayModel
    {
        public double[] data;

        public CsvLoadArrayModel()
        {
            data = new double[14];
        }

        public CsvLoadArrayModel(string[] strs) : this()
        {

            for (int i = 0; i < 14; i++)
            {
                double.TryParse(strs[i], out double val);
                data[i] = val;
            };

        }
    }
}

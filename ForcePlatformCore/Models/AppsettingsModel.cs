using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class AppsettingsModel
    {
        public bool AutoSelectCom { get; set; }
        public string ComPort { get; set; }
        public int FilterLength { get; set; }
        public double CalibrateZ { get; set; }
        public double FreeFallAcc { get; set; }
        public string ReportPath { get; set; }
        
    }
}

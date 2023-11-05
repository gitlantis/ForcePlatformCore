using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class AppsettingsModel
    {
        public bool AutoSelectCom { get; set; }
        public string ComPort { get; set; }
        public int FilterLength { get; set; }
        public int CalibrateZ { get; set; }
    }
}

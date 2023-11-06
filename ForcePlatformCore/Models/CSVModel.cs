using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformCore.Models
{
    public class CSVModel
    {
        //public TimeSpan Time { get; set; }
        public string Time { get; set; }
        public List<CSVItem> PlateData { get; set; }
        public string CurrentADC { get; set; }
    }
}

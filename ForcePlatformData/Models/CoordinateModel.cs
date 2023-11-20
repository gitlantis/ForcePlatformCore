using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformData.Models
{
    public class CoordinateModel : IComparable<CoordinateModel>
    {
        public double X, Y;
        public CoordinateModel()
        {
            X = 0;
            Y = 0;
        }
        public CoordinateModel(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public int CompareTo(CoordinateModel other)
        {
            if (other.X > this.X) return -1;
            if (other.X < this.X) return 1;
            return 0;
        }
    }
}

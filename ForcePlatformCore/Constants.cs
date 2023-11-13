using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcePlatformCore
{
    public static class Constants
    {
        public static readonly string[] ExerciseTypes = {
            "Stability, 1st platform",
            "Jump, 2 platforms",
            "Gait, 4 platforms",
        };

        public static readonly string[] FilterTypes = {
            "Sliding exponential window",
            "Averaging"
        };
    }
}

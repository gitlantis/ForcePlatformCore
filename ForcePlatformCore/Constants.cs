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
            "Устойчивость, 1 платформа",
            "Прыжок, 2 платформы",
            "Походка, 4 платформы",
        };

        public static readonly string[] FilterTypes = {
            "Скользящее экспоненциальное окно",
            "Усреднение"
        };
    }
}

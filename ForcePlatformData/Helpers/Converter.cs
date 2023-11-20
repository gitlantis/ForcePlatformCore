namespace ForcePlatformData.Helpers
{
    public static class Converter
    {
        public static double ToUnit(double value, Constants.Units unit)
        {
            var temp = value / AppConfig.Config.CalibrateZ;
            if (unit == Constants.Units.N)
                temp = temp * AppConfig.Config.FreeFallAcc;
            return temp;
        }
    }
}

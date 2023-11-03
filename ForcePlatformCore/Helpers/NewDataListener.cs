//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ForcePlatformCore.Helpers
//{
//    public static class NewDataListener
//    {
//        private static int _time;
//        public static Action<NewDataListener, int> OnTimeChanged;
//        public static int Time
//        {
//            get { return _time; }
//            set
//            {
//                _time = value;
//                this?.OnTimeChanged(this, _time);
//            }
//        }
//    }
//}

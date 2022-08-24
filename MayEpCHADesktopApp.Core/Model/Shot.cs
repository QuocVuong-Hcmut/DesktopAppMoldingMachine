using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model
{
    public class Shot
    {
        public Shot(DateTime timeStamp, double injectionTime, double openTime)
        {
            TimeStamp = timeStamp;
            InjectionTime = injectionTime;
            OpenTime = openTime;
        }

        private Shot()
        {

        }

        public DateTime TimeStamp { get; set; }
        public double InjectionTime { get; set; }
        public double OpenTime { get; set; }
    }
}

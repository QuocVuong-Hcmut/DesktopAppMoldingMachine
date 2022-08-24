using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.ModelMQTT
{
    //    public class EventMachine
    //    {

    //#pragma warning disable CS8618
    //        public DateTime DateTime { get; set; }
    //        public string NameEvent { get; set; }
    //        public int Status { get; set; }
    //        public string Cycle { get; set; }

    //#pragma warning restore
    //    }
    public class EventMachine
    {

#pragma warning disable CS8618
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string NameEvent { get; set; }
        public string MachineId { get; set; }
        public int Status { get; set; }
        public string CycleTime { set; get; }

#pragma warning restore

    }
}

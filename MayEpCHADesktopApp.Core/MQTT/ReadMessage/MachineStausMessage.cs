using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.MQTT.ReadMessage
{
    public class MachineStausMessage
    {
        public DateTime TimeStamp { get; set; }
        public int MachineStaus { get; set; }
    }
}

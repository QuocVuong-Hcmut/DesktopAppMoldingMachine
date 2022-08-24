using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.ModelDatabase
{
    public class EventMachine
    {

#pragma warning disable CS8618
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string NameEvent { get; set; }
        public string MachineId { get; set; }
        public int Status { get; set; }

#pragma warning restore

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.ModelDatabase
{

    public class Configuration
    {
#pragma warning disable CS8618
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string MachineId { get; set; }
        public string MoldId { get; set; }
        public DateTime DateTime { get; set; }
        public int Quantity { get; set; }
        public int Shift { get; set; }
        public double CycleInjection { get; set; }
        public int ConfigurationInShift { set; get; }
 

#pragma warning restore

    }
}

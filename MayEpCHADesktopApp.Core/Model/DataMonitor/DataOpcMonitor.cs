using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model.DataMonitor
{
    public class DataOpcMonitor
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        public DataOpcMonitor (string name,object value)
        {
            Name=name;
            Value=value;
        }
    }
}

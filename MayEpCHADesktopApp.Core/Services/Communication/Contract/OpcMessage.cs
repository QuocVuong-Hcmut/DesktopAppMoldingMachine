using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionMoldingMachineDataAcquisitionService.Communication.Messages
{
    public class OpcMessage
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        public OpcMessage (string name,object value)
        {
            Name=name;
            Value=value;
        }
    }
}

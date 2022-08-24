using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model
{
    public class Machine
    {
        public Machine(string id, EMachineType machineType, string model)
        {
            Id = id;
            MachineType = machineType;
            Model = model;
        }

        private Machine()
        {

        }

        public string Id { get; set; }
        public EMachineType MachineType { get; set; }
        public string Model { get; set; }
    }
}

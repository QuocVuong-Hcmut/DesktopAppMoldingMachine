using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model
{
    public class PreShiftReport
    {

        public DateTime date { get; set; }
        public int id { get; set; }
        public EShift shiftNumber { get; set; }
        public Employee employee { get; set; }
        public Machine machine { get; set; }
        public Product product { get; set; }
        public int injectionCycle { get; set; }
        public int cavity { get; set; }
        public int totalQuantity { get; set; }
        public string note { get; set; }

    }
}

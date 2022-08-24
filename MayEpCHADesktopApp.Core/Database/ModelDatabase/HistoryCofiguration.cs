using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.ModelDatabase
{
    public class HistoryCofiguration
    {
        public int Id { set; get; }
        public string Shift { set; get; }
        public DateTime DateTime { set; get; }
        public int Status { set; get; }
    }
}

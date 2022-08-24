using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model
{


    public class ShiftReports
    {
        [JsonProperty("items")]
        public List<ShiftReport> items { get; set; }
        [JsonProperty("totalItems")]
        public int totalItems { get; set; }
    }
}

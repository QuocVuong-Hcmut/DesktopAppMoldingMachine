using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model
{
    public class Mold
    {
        public Mold(string id, double standardInjectionCycle, double standardOpenTime, double injectionCycleTolerance, double openTimeTolerance, bool automatic, int productsPerShot)
        {
            Id = id;
            StandardInjectionCycle = standardInjectionCycle;
            StandardOpenTime = standardOpenTime;
            InjectionCycleTolerance = injectionCycleTolerance;
            OpenTimeTolerance = openTimeTolerance;
            Automatic = automatic;
            ProductsPerShot = productsPerShot;
        }

        public Mold()
        {

        }

        public string Id { get; set; }
        public string moldId { get; set; }
        public double StandardInjectionCycle { get; set; }
        public double StandardOpenTime { get; set; }
        public double InjectionCycleTolerance { get; set; }
        public double OpenTimeTolerance { get; set; }
        public bool Automatic { get; set; }
        public int ProductsPerShot { get; set; }
    }
}

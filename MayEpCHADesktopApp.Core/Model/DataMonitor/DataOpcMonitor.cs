using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model.DataMonitor
{
    public class DataOpcMonitor: ViewModels.BaseViewModels.BaseViewModel
    {
       
        public string Name { get; set; }
        private object _value;
        public object Value { get { return _value; }  set { _value=value;OnPropertyChanged( );  } }

        public DataOpcMonitor (string name,object value)
        {
            Name=name;
            Value=value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Store
{
    public class MQTTStore
    {
        private int _page;
        public int Page
        {
            get => _page;
            set
            {
                _page = value;
                OnCurrentPageChanged();
            }
        }

        public event Action CurrentPageChanged;

        private void OnCurrentPageChanged()
        {
            CurrentPageChanged?.Invoke();
        }
    }
}

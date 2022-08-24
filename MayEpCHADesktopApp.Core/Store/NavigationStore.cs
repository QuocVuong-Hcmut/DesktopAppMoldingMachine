using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Store
{
    public class NavigationStore
    {
        private int _selectButton;
        private ViewModels.BaseViewModels.BaseViewModel _currentViewModel;
        public ViewModels.BaseViewModels.BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public int SelectButton { get => _selectButton;
            set  { 
                  _selectButton = value;
                  OnCurrentButtonChanged();
            } 
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public event Action CurrentButtonChanged;

        private void OnCurrentButtonChanged()
        {
            CurrentButtonChanged?.Invoke();
        }
    }
}

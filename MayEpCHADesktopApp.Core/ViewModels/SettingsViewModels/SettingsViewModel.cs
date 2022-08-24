using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels
{
    public class SettingsViewModel:ViewModels.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public ICommand SettingsNew { get; set; }
        public ICommand SettingsPrevious { get; set; }
        public bool IsCurrentSettings { get => isCurrentSettings; set { isCurrentSettings = value; OnPropertyChanged(); } }
        private bool isCurrentSettings;
        public bool IsNewSettings { get => isNewSettings; set { isNewSettings = value; OnPropertyChanged(); } }
        private bool isNewSettings;
        public ViewModels.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public SettingsViewModel(NavigationStore navigationStore,
            INavigationService _SettingsNewViewModel,
            INavigationService _SettingsPreviousViewModel
            )
        {

            _navigationStore = navigationStore;
            SettingsNew = new NavigateCommand(_SettingsNewViewModel);
            SettingsPrevious = new NavigateCommand(_SettingsPreviousViewModel);

            IsNewSettings = false;
            IsCurrentSettings = false;
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
            _navigationStore.CurrentButtonChanged += _navigationStore_CurrentButtonChanged;

        }

        private void _navigationStore_CurrentButtonChanged()
        {
            switch (_navigationStore.SelectButton)
            {
                case 11:
                    IsNewSettings = true;
                    IsNewSettings = true;
                    IsCurrentSettings = false;
                    break;
                case 12:
                    IsNewSettings = false;
                    IsCurrentSettings = true;
                    break;
                default:
                    break;
            }
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MayEpCHADesktopApp.Core.ViewModels
{
    public class MainViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public ViewModels.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand LoggingCommand { get; set; }

        public ICommand ObservateCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand AlertCommand { get; set; }
        public ICommand ManageCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public ICommand HelpCommand { get; set; }

        //
        public int SelectButton { get; set; }

        private bool isButtonLogin;
        public bool IsButtonLogin { get => isButtonLogin; set { isButtonLogin = value; OnPropertyChanged(); } }
        public bool IsButtonObservation { get => isButtonObservation; set { isButtonObservation = value; OnPropertyChanged(); } }
        private bool isButtonObservation;
        public bool IsButtonSettings { get => isButtonSettings; set { isButtonSettings = value; OnPropertyChanged(); } }
        private bool isButtonSettings;
        public bool IsButtonReport { get => isButtonReport; set { isButtonReport = value; OnPropertyChanged(); } }
        private bool isButtonReport;
        public bool IsButtonManage { get => isButtonManage; set { isButtonManage = value; OnPropertyChanged(); } }
        private bool isButtonManage;
        public bool IsButtonAlert { get => isButtonAlert; set { isButtonAlert = value; OnPropertyChanged(); } }
        private bool isButtonAlert;
        public bool IsButtonHistory { get => isButtonHistory; set { isButtonHistory = value; OnPropertyChanged(); } }
        private bool isButtonHistory;
        public bool IsButtonHelp { get => isButtonHelp; set { isButtonHelp= value; OnPropertyChanged(); } }
        private bool isButtonHelp;


        public MainViewModel(NavigationStore navigationStore,
                            INavigationService _LogingnavigationService,
                            INavigationService _ObservationViewModel,
                            INavigationService _SettingsViewModel,
                            INavigationService _AlertViewModel,
                            INavigationService _ManageViewModel,
                            INavigationService _ReportViewModel,
                            INavigationService _HistoryViewModel,
                            INavigationService _HelpViewModel
                            )
        {
            _navigationStore = navigationStore;
           // CurrentViewModel = new LoginViewModel();
            LoggingCommand = new NavigateCommand(_LogingnavigationService);
            ObservateCommand = new NavigateCommand(_ObservationViewModel);
            SettingsCommand = new NavigateCommand(_SettingsViewModel);
            AlertCommand = new NavigateCommand(_AlertViewModel);
            ManageCommand = new NavigateCommand(_ManageViewModel);
            ReportCommand = new NavigateCommand(_ReportViewModel);
            HistoryCommand = new NavigateCommand(_HistoryViewModel);
            HelpCommand = new NavigateCommand(_HelpViewModel);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationStore.CurrentButtonChanged += _navigationStore_CurrentButtonChanged;
            IsButtonLogin = false;
            IsButtonObservation = false;
            IsButtonSettings = false;
            IsButtonReport = false;
            IsButtonManage = false;
            IsButtonAlert = false;
            IsButtonHistory = false;
            isButtonHelp= false;

        }

        private void _navigationStore_CurrentButtonChanged()
        {
            SelectButton = _navigationStore.SelectButton;
            SwitchAnimationButton(SelectButton);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        public void SwitchAnimationButton(int selectButton)
        {
       //     CustomMessageBoxWindow cx = new CustomMessageBoxWindow("Đây là Messag Thông số cài đại là Cảnh báo","kkkk", MessageBoxButton.YesNo, MessageBoxImage.Error);
            //cx.ShowDialog();
            switch (selectButton)
            {
                case 1:
                    IsButtonLogin = true;
                    IsButtonObservation = false;
                    IsButtonSettings = false;
                    IsButtonReport = false;
                    IsButtonManage = false;
                    IsButtonAlert = false;
                    IsButtonHistory = false;
                    IsButtonHelp= false;
                    break;
                case 2:
                    IsButtonLogin = false;
                    IsButtonObservation = true;
                    IsButtonSettings = false;
                    IsButtonReport = false;
                    IsButtonManage = false;
                    IsButtonAlert = false;
                    IsButtonHistory = false;
                    IsButtonHelp= false;
                    break;
                case 3:
                    IsButtonLogin = false;
                    IsButtonObservation = false;
                    IsButtonSettings = true;
                    IsButtonReport = false;
                    IsButtonManage = false;
                    IsButtonAlert = false;
                    IsButtonHistory = false;
                    IsButtonHelp= false;
                    break;
                case 4:
                    IsButtonLogin = false;
                    IsButtonObservation = false;
                    IsButtonSettings = false;
                    IsButtonReport = true;
                    IsButtonManage = false;
                    IsButtonAlert = false;
                    IsButtonHistory = false;
                    IsButtonHelp= false;
                    break;
                case 5:
                    IsButtonLogin = false;
                    IsButtonObservation = false;
                    IsButtonSettings = false;
                    IsButtonReport = false;
                    IsButtonManage = true;
                    IsButtonAlert = false;
                    IsButtonHistory = false;
                    IsButtonHelp= false;
                    break;
                case 6:
                    IsButtonLogin = false;
                    IsButtonObservation = false;
                    IsButtonSettings = false;
                    IsButtonReport = false;
                    IsButtonManage = false;
                    IsButtonAlert = true;
                    IsButtonHistory = false;
                    IsButtonHelp= false;
                    break;
                case 7:
                    IsButtonLogin = false;
                    IsButtonObservation = false;
                    IsButtonSettings = false;
                    IsButtonReport = false;
                    IsButtonManage = false;
                    IsButtonAlert = false;
                    IsButtonHistory = true;
                    IsButtonHelp= false;
                    break;
                case 8:
                    IsButtonLogin = false;
                    IsButtonObservation = false;
                    IsButtonSettings = false;
                    IsButtonReport = false;
                    IsButtonManage = false;
                    IsButtonAlert = false;
                    IsButtonHistory = false;
                    IsButtonHelp= true;
                    break;
                default:
                    IsButtonLogin = false;
                    IsButtonObservation = false;
                    IsButtonSettings = false;
                    IsButtonReport = false;
                    IsButtonManage = false;
                    IsButtonAlert = false;
                    IsButtonHistory = false;
                    IsButtonHelp= false;
                    break;
            }
        }
    }
}

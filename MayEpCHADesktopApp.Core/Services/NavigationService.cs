using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MayEpCHADesktopApp.Core.Services
{
    public class NavigationService: ViewModels.BaseViewModels.BaseViewModel,INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly ViewModels.BaseViewModels.BaseViewModel _createViewModel;
        private MediaPlayer mediaPlayer;
        public NavigationService(NavigationStore navigationStore, ViewModels.BaseViewModels.BaseViewModel createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
             mediaPlayer = new MediaPlayer();
    }



        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel;
          

        }     
        public void SelectViewModel()
        {
            switch (_createViewModel)
            {
                case MayEpCHADesktopApp.Core.ViewModels.LoginViewModels.LoginViewModel:
                    _navigationStore.SelectButton = 1;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel.ObservationViewModel:
                    _navigationStore.SelectButton = 2;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels.SettingsViewModel:
                    _navigationStore.SelectButton = 3;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ReportViewModels.ReportViewModel:
                    _navigationStore.SelectButton = 4;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ManageViewModel.ManageViewModel:
                    _navigationStore.SelectButton = 5;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.AlertViewModel.AlertViewModel:
                    _navigationStore.SelectButton = 6;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.HistoryViewModel.HistoryViewModel:
                    _navigationStore.SelectButton=7;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.HelpViewModel.HelpViewModel:
                    _navigationStore.SelectButton=8;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel.ObservationMachineViewModel:
                    _navigationStore.SelectButton = 9;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel.ObservationDetailMachineViewModel:
                    _navigationStore.SelectButton = 10;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels.SettingsNewViewModel:
                    _navigationStore.SelectButton = 11;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels.SettingsPreviousViewModel:
                    _navigationStore.SelectButton = 12;
                    break;
                //settings
                case MayEpCHADesktopApp.Core.ViewModels.ReportViewModels.ReportShiftViewModel:
                    _navigationStore.SelectButton = 1;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ReportViewModels.ReportObservateViewModel:
                    _navigationStore.SelectButton = 2;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ReportViewModels.ReportExportExcelViewModel:
                    _navigationStore.SelectButton = 3;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ReportViewModels.ReportBillExportWareHouseViewModel:
                    _navigationStore.SelectButton = 4;
                    break;
              //Manage
                case MayEpCHADesktopApp.Core.ViewModels.ManageViewModel.EmployeeManageViewModel:
                    _navigationStore.SelectButton = 1;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ManageViewModel.MoldCodeViewModel:
                    _navigationStore.SelectButton = 2;
                    break;
                case MayEpCHADesktopApp.Core.ViewModels.ManageViewModel.ProductCodeViewModel:
                    _navigationStore.SelectButton = 3;
                    break;

                default:
                    _navigationStore.SelectButton = 0;
                    break;
            }
        }

        public void Sound()
        {
        
           // mediaPlayer.Open(new Uri(@".\ClickMouse.mp3"));
            //mediaPlayer.Play();
        }
    }
}

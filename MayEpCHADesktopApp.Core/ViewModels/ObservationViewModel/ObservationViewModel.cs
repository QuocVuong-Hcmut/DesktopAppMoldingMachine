using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private INavigationService _navigationService;

        public ICommand ObservationDetailMachineCommand { get; set; }
        public ICommand ObservationMachineCommand { get; set; }
        public bool IsMachine { get => isMachine; set { isMachine = value; OnPropertyChanged(); } }
        private bool isMachine;
        public bool IsDetailMachine { get => isDetailMachine; set { isDetailMachine = value; OnPropertyChanged(); } }
        private bool isDetailMachine;
        public ViewModels.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;



        public ObservationViewModel(NavigationStore navigationStore,
                                    INavigationService _ObservationDetailMachineService,
                                    INavigationService _ObservationMachineService,
                                    ObservationMachineViewModel observationMachineViewModel)
        {

            _navigationStore = navigationStore;
            _navigationService = _ObservationDetailMachineService;
            ObservationDetailMachineCommand = new NavigateCommand(_ObservationDetailMachineService);
            ObservationMachineCommand = new NavigateCommand(_ObservationMachineService);
            IsMachine = false;
            IsDetailMachine = false;
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
            _navigationStore.CurrentButtonChanged += _navigationStore_CurrentButtonChanged;
            observationMachineViewModel.SwitchPageDetail += ObservationMachineViewModel_SwitchPageDetail;
        }

        private void ObservationMachineViewModel_SwitchPageDetail()
        {
            _navigationService.Navigate();
            _navigationService.SelectViewModel();
            _navigationService.Sound();
        }

        private void _navigationStore_CurrentButtonChanged()
        {
            SwitchButton(_navigationStore.SelectButton);
        }
        public void SwitchButton(int selectButton)
        {
            switch (selectButton)
            {
                case 9:
                    IsMachine = true;
                    IsDetailMachine = false;
                    break;
                case 10:
                    IsMachine = false;
                    IsDetailMachine = true;
                    break;
                default:
                    IsMachine = false;
                    IsDetailMachine = false;
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

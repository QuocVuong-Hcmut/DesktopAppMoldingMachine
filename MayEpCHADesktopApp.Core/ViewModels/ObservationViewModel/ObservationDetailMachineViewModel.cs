using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationDetailMachineViewModel : ViewModels.BaseViewModels.BaseViewModel
    {

        private  INavigationService _navigationService;
        private readonly INavigationService _navigationServicePage1;
        private readonly INavigationService _navigationServicePage2;
        private readonly INavigationService _navigationServicePage3;
        private readonly INavigationService _navigationServicePage4;
        private readonly INavigationService _navigationServicePage5;
        private readonly INavigationService _navigationServicePage6;
        private readonly INavigationService _navigationServicePage7;
        private PageStore _store;
        private readonly NavigationStore _navigationStore;
        public ViewModels.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        private int page;
        private bool page1;
        public bool Page1 { get => page1; set { page1 = value; OnPropertyChanged(); } }
        public bool Page2 { get => page2; set { page2 = value; OnPropertyChanged(); } }
        private bool page2;
        public bool Page3 { get => page3; set { page3 = value; OnPropertyChanged(); } }
        private bool page3;
        public bool Page4 { get => page4; set { page4 = value; OnPropertyChanged(); } }
        private bool page4;
        public bool Page5 { get => page5; set { page5 = value; OnPropertyChanged(); } }
        private bool page5;
        public bool Page6 { get => page6; set { page6 = value; OnPropertyChanged(); } }
        private bool page6;
        public bool Page7 { get => page7; set { page7 = value; OnPropertyChanged(); } }
        private bool page7;
        //command
        public ICommand GoToUnitCommand { set; get; }
        public ICommand GoToDoubleUnitCommand { set; get; }
        public ICommand GoBackUnitCommand { set; get; }
        public ICommand GoBackDoubleUnitCommand { set; get; }
        public int Page { get => page; set { page = value; OnPropertyChanged(); } }


        public ObservationDetailMachineViewModel(PageStore _PageStore,
                                                 NavigationStore navigationStore,
                                                 INavigationService _ObservationPage1,
                                                 INavigationService _ObservationPage2,
                                                 INavigationService _ObservationPage3,
                                                 INavigationService _ObservationPage4,
                                                 INavigationService _ObservationPage5,
                                                 INavigationService _ObservationPage6,
                                                 INavigationService _ObservationPage7


            )
        {

            _navigationStore = navigationStore;
            _store = _PageStore;
            _store.CurrentPageChanged += _store_CurrentPageChanged;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationServicePage1 = _ObservationPage1;
            _navigationServicePage2= _ObservationPage2; 
            _navigationServicePage3= _ObservationPage3;
            _navigationServicePage4= _ObservationPage4;
            _navigationServicePage5= _ObservationPage5;
            _navigationServicePage6= _ObservationPage6;
            _navigationServicePage7= _ObservationPage7;
            GoToUnitCommand = new RelayCommand(async () => await GoToUnit());
            GoToDoubleUnitCommand = new RelayCommand(async () => await GoToDoubleUnit());
            GoBackUnitCommand = new RelayCommand(async () => await GoBackUnit());
            GoBackDoubleUnitCommand = new RelayCommand(async () => await GoBackDoubleUnit());
           
            _store.Page = 1;
            Page = 1;
            


        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private Task GoToUnit()
        {
            Page++;
            if (Page > 7)
            {
                Page = 1;
            }
            _store.Page = Page;
            

            return Task.CompletedTask;
        }
        private Task GoToDoubleUnit()
        {
            Page = Page + 2;
            if( Page > 7 )
            {
                Page = 1;
            }
            _store.Page = Page;
            
            
            return Task.CompletedTask;
        }
        private Task GoBackUnit()
        {
            Page--;
            if ( Page < 0)
            {
                Page = 7;
            }
            _store.Page = Page;
            

            return Task.CompletedTask;
        }
        private Task GoBackDoubleUnit()
        {
            Page = Page - 2;
            if (Page < 1)
            {
                Page = 7;
            }
            _store.Page = Page;
            

            return Task.CompletedTask;
        }
        private void _store_CurrentPageChanged()
        {
            Page = _store.Page;
            SwitchPage(_store.Page);
            Page = _store.Page;
        }

        public void SelectPage(int page)
        {
            switch (page)
            {
                case 1:
                    _navigationService = _navigationServicePage1;
                    break;
                case 2:
                    _navigationService = _navigationServicePage2;
                    break;
                case 3:
                    _navigationService = _navigationServicePage3;
                    break;
                case 4:
                    _navigationService = _navigationServicePage4;
                    break;
                case 5:
                    _navigationService = _navigationServicePage5;
                    break;
                case 6:
                    _navigationService = _navigationServicePage6;
                    break;
                case 7:
                    _navigationService = _navigationServicePage7;
                    break;
                default:
                    _navigationService = _navigationServicePage1;
                    break;
            }
            _navigationService.Navigate();
            _navigationService.Sound();
        }

       public void SwitchPage(int data)
        {
            if (data != null && data >0 && data < 8)
            {
                SelectPage(data);
            } else
            {
                SelectPage(1);
            }
        }
        
    }
}

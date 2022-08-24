using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MayEpCHADesktopApp.Core.ViewModels.ManageViewModel
{
    public class ManageViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public ViewModels.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand EmployeeCommand { get; set; }

        public ICommand ProductCommand { get; set; }
        public ICommand MoldCommand { get; set; }
        public bool IsProduct { get => isProduct; set { isProduct = value; OnPropertyChanged(); } }
        private bool isProduct;
        public bool IsEmployee { get => isEmployee; set { isEmployee = value; OnPropertyChanged(); } }
        private bool isEmployee;
        public bool IsMold { get => isMold; set { isMold = value; OnPropertyChanged(); } }
        private bool isMold;

        public ManageViewModel(NavigationStore navigationStore, INavigationService _EmployeeViewModel, INavigationService _ProductViewModel, INavigationService _MoldCode)
        {
            _navigationStore = navigationStore;
            // CurrentViewModel = new LoginViewModel();
            EmployeeCommand = new NavigateCommand(_EmployeeViewModel);
            ProductCommand = new NavigateCommand(_ProductViewModel);
            MoldCommand = new NavigateCommand(_MoldCode);
            _navigationStore.CurrentButtonChanged += _navigationStore_CurrentButtonChanged;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void _navigationStore_CurrentButtonChanged()
        {
            switch (_navigationStore.SelectButton)
            {

                case 1:
                    IsEmployee = true;
                    IsMold = false;
                    IsProduct = false;
                    break;
                case 2:
                    IsEmployee = false;
                    IsMold = true;
                    IsProduct = false;
                    break;
                case 3:
                    IsEmployee = false;
                    IsMold = false;
                    IsProduct = true;
                    break;
                default:
                    break;
            }
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        public override void Dispose()
        {
            base.Dispose();
        }

    }
}

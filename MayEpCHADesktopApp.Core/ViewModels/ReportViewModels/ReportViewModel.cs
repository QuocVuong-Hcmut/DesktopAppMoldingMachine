using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MayEpCHADesktopApp.Core.ViewModels.ReportViewModels
{
    public class ReportViewModel: ViewModels.BaseViewModels.BaseViewModel
    {
        #region Var
        private readonly NavigationStore _navigationStore;

        public ICommand ReportShiftCommand { get; set; }
        public ICommand ReportEmployeeCommand { get; set; }
        public ICommand ReportExcelCommand { get; set; }
        public ICommand ReportExportWareHouseCommand { get; set; }
        public bool IsShift { get => isShift; set { isShift=value; OnPropertyChanged( ); } }
        private bool isShift;
        public bool IsObservation { get => isObservation; set { isObservation=value; OnPropertyChanged( ); } }
        private bool isObservation;
        public bool IsExcel { get => isExcel; set { isExcel=value; OnPropertyChanged( ); } }
        private bool isExcel;
        public bool IsBillWareHouse { get => isBillWareHouse; set { isBillWareHouse=value; OnPropertyChanged( ); } }
        private bool isBillWareHouse;
        public ViewModels.BaseViewModels.BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        #endregion

        public ReportViewModel (NavigationStore navigationStore,
            INavigationService _ReportShiftService,
            INavigationService _ReportEmployeeService,
            INavigationService _ReportExcelService,
            INavigationService _ReportExportWareHouse

            )
        {
            _navigationStore=navigationStore;
            ReportShiftCommand=new NavigateCommand(_ReportShiftService);
            ReportEmployeeCommand=new NavigateCommand(_ReportEmployeeService);
            ReportExcelCommand=new NavigateCommand(_ReportExcelService);
            ReportExportWareHouseCommand=new NavigateCommand(_ReportExportWareHouse);
            IsShift=false;
            IsObservation=false;
            IsExcel=false;
            IsBillWareHouse=false;
            _navigationStore.CurrentViewModelChanged+=_navigationStore_CurrentViewModelChanged;
            _navigationStore.CurrentButtonChanged+=_navigationStore_CurrentButtonChanged;
        }

        private void _navigationStore_CurrentButtonChanged ( )
        {
            switch ( _navigationStore.SelectButton )
            {
                case 1:
                    IsShift=true;
                    IsObservation=false;
                    IsExcel=false;
                    IsBillWareHouse=false;
                    break;
                case 2:
                    IsShift=false;
                    IsObservation=true;
                    IsExcel=false;
                    IsBillWareHouse=false;
                    break;
                case 3:
                    IsShift=false;
                    IsObservation=false;
                    IsExcel=true;
                    IsBillWareHouse=false;
                    break;
                case 4:
                    IsShift=false;
                    IsObservation=false;
                    IsExcel=false;
                    IsBillWareHouse=true;
                    break;

                default:
                    break;
            }
        }

        private void _navigationStore_CurrentViewModelChanged ( )
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


        public override void Dispose ( )
        {
            base.Dispose( );
        }
    }
}

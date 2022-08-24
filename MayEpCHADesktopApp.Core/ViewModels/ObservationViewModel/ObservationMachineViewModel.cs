using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachineViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private MachineViewModel _m1;
        private MachineViewModel _m2;
        private MachineViewModel _m3;
        private MachineViewModel _m4;
        private MachineViewModel _m5;
        private MachineViewModel _m6;
        private MachineViewModel _m7;
        private MachineViewModel _m8;
        private MachineViewModel _m9;
        private MachineViewModel _m10;
        private MachineViewModel _m11;
        private MachineViewModel _m12;
        private MachineViewModel _m13;
        private MachineViewModel _m14;
        private MachineViewModel _m15;
        private MachineViewModel _m16;
        private MachineViewModel _m17;
        private MachineViewModel _m18;
        private MachineViewModel _m19;
        private MachineViewModel _m20;
        private MachineViewModel _m21;
        private MachineViewModel _m22;
        private MachineViewModel _m23;
        private MachineViewModel _m24;
        private MachineViewModel _m25;
        private MachineViewModel _m26;
        private MachineViewModel _m27;
        private MachineViewModel _m28;
        private MachineViewModel _mL1;
        private MachineViewModel _mL2;
        private MachineViewModel _mL3;
        private MachineViewModel _mL4;
        private MachineViewModel _mL5;
        private MachineViewModel _mL6;
        private MachineViewModel _mL7;
        private MachineViewModel _mL8;
        private MachineViewModel _mL9;
        private MachineViewModel _mL10;
        private MachineViewModel _mL11;
        private MachineViewModel _mL12;
        public MachineViewModel M1 { get => _m1; set { _m1 = value; OnPropertyChanged(); } }
        public MachineViewModel M2 { get => _m2; set { _m2 = value; OnPropertyChanged(); } }
        public MachineViewModel M3 { get => _m3; set { _m3 = value; OnPropertyChanged(); } }
        public MachineViewModel M4 { get => _m4; set { _m4 = value; OnPropertyChanged(); } }
        public MachineViewModel M5 { get => _m5; set { _m5 = value; OnPropertyChanged(); } }
        public MachineViewModel M6 { get => _m6; set { _m6 = value; OnPropertyChanged(); } }
        public MachineViewModel M7 { get => _m7; set { _m7 = value; OnPropertyChanged(); } }
        public MachineViewModel M8 { get => _m8; set { _m8 = value; OnPropertyChanged(); } }
        public MachineViewModel M9 { get => _m9; set { _m9 = value; OnPropertyChanged(); } }
        public MachineViewModel M10 { get => _m10; set { _m10 = value; OnPropertyChanged(); } }
        public MachineViewModel M11 { get => _m11; set { _m11 = value; OnPropertyChanged(); } }
        public MachineViewModel M12 { get => _m12; set { _m12 = value; OnPropertyChanged(); } }
        public MachineViewModel M13 { get => _m13; set { _m13 = value; OnPropertyChanged(); } }
        public MachineViewModel M14 { get => _m14; set { _m14 = value; OnPropertyChanged(); } }
        public MachineViewModel M15 { get => _m15; set { _m15 = value; OnPropertyChanged(); } }
        public MachineViewModel M16 { get => _m16; set { _m16 = value; OnPropertyChanged(); } }
        public MachineViewModel M17 { get => _m17; set { _m17 = value; OnPropertyChanged(); } }
        public MachineViewModel M18 { get => _m18; set { _m18 = value; OnPropertyChanged(); } }
        public MachineViewModel M19 { get => _m19; set { _m19 = value; OnPropertyChanged(); } }
        public MachineViewModel M20 { get => _m20; set { _m20 = value; OnPropertyChanged(); } }
        public MachineViewModel M21 { get => _m21; set { _m21 = value; OnPropertyChanged(); } }
        public MachineViewModel M22 { get => _m22; set { _m22 = value; OnPropertyChanged(); } }
        public MachineViewModel M23 { get => _m23; set { _m23 = value; OnPropertyChanged(); } }
        public MachineViewModel M24 { get => _m24; set { _m24 = value; OnPropertyChanged(); } }
        public MachineViewModel M25 { get => _m25; set { _m25 = value; OnPropertyChanged(); } }
        public MachineViewModel M26 { get => _m26; set { _m26 = value; OnPropertyChanged(); } }
        public MachineViewModel M27 { get => _m27; set { _m27 = value; OnPropertyChanged(); } }
        public MachineViewModel M28 { get => _m28; set { _m28 = value; OnPropertyChanged(); } }
        public MachineViewModel ML1 { get => _mL1; set { _mL1 = value; OnPropertyChanged(); } }
        public MachineViewModel ML2 { get => _mL2; set { _mL2 = value; OnPropertyChanged(); } }
        public MachineViewModel ML3 { get => _mL3; set { _mL3 = value; OnPropertyChanged(); } }
        public MachineViewModel ML4 { get => _mL4; set { _mL4 = value; OnPropertyChanged(); } }
        public MachineViewModel ML5 { get => _mL5; set { _mL5 = value; OnPropertyChanged(); } }
        public MachineViewModel ML6 { get => _mL6; set { _mL6 = value; OnPropertyChanged(); } }
        public MachineViewModel ML7 { get => _mL7; set { _mL7 = value; OnPropertyChanged(); } }
        public MachineViewModel ML8 { get => _mL8; set { _mL8 = value; OnPropertyChanged(); } }
        public MachineViewModel ML9 { get => _mL9; set { _mL9 = value; OnPropertyChanged(); } }
        public MachineViewModel ML10 { get => _mL10; set { _mL10 = value; OnPropertyChanged(); } }
        public MachineViewModel ML11 { get => _mL11; set { _mL11 = value; OnPropertyChanged(); } }
        public MachineViewModel ML12 { get => _mL12; set { _mL12 = value; OnPropertyChanged(); } }



        private PageStore _store;
       

        public ICommand SwitchPage1 { get; set; }
        public ICommand SwitchPage2 { get; set; }
        public ICommand SwitchPage3 { get; set; }
        public ICommand SwitchPage4 { get; set; }
        public ICommand SwitchPage5 { get; set; }
        public ICommand SwitchPage6 { get; set; }
        public ICommand SwitchPage7 { get; set; }



        public event Action SwitchPageDetail;
        public ObservationMachineViewModel(PageStore _PageStore)
        {
            _store = _PageStore;
            
            M1 = new MachineViewModel();
            M2 = new MachineViewModel();
            M3 = new MachineViewModel();
            M4 = new MachineViewModel();
            M5 = new MachineViewModel();
            M6 = new MachineViewModel();
            M7 = new MachineViewModel();
            M8 = new MachineViewModel();
            M9 = new MachineViewModel();
            M10 = new MachineViewModel();
            M11 = new MachineViewModel();
            M12 = new MachineViewModel();
            M13 = new MachineViewModel();
            M14 = new MachineViewModel();
            M15 = new MachineViewModel();
            M16 = new MachineViewModel();
            M17 = new MachineViewModel();
            M18 = new MachineViewModel();
            M19 = new MachineViewModel();
            M20 = new MachineViewModel();
            M21 = new MachineViewModel();
            M22 = new MachineViewModel();
            M23 = new MachineViewModel();
            M24 = new MachineViewModel();
            M25 = new MachineViewModel();
            M26 = new MachineViewModel();
            M27 = new MachineViewModel();
            M28 = new MachineViewModel();
            ML1 = new MachineViewModel();
            ML2 = new MachineViewModel();
            ML3 = new MachineViewModel();
            ML4 = new MachineViewModel();
            ML5 = new MachineViewModel();
            ML6 = new MachineViewModel();
            ML7 = new MachineViewModel();
            ML8 = new MachineViewModel();
            ML9 = new MachineViewModel();
            ML10 = new MachineViewModel();
            ML11 = new MachineViewModel();
            ML12 = new MachineViewModel();
            MachineMessageConsumer.M1 += M1.ReiceverAction;
            MachineMessageConsumer.M2 += M2.ReiceverAction;
            MachineMessageConsumer.M3 += M3.ReiceverAction;
            MachineMessageConsumer.M4 += M4.ReiceverAction;
            MachineMessageConsumer.M5 += M5.ReiceverAction;
            MachineMessageConsumer.M6 += M6.ReiceverAction;
            MachineMessageConsumer.M7 += M7.ReiceverAction;
            MachineMessageConsumer.M8 += M8.ReiceverAction;
            MachineMessageConsumer.M9 += M9.ReiceverAction;
            MachineMessageConsumer.M10 += M10.ReiceverAction;
            MachineMessageConsumer.M11 += M11.ReiceverAction;
            MachineMessageConsumer.M12 += M12.ReiceverAction;
            MachineMessageConsumer.M13 += M13.ReiceverAction;
            MachineMessageConsumer.M14 += M14.ReiceverAction;
            MachineMessageConsumer.M15 += M15.ReiceverAction;
            MachineMessageConsumer.M16 += M16.ReiceverAction;
            MachineMessageConsumer.M17 += M17.ReiceverAction;
            MachineMessageConsumer.M18 += M18.ReiceverAction;
            MachineMessageConsumer.M19 += M19.ReiceverAction;
            MachineMessageConsumer.M20 += M20.ReiceverAction;
            MachineMessageConsumer.M21 += M21.ReiceverAction;
            MachineMessageConsumer.M22 += M22.ReiceverAction;
            MachineMessageConsumer.M23 += M23.ReiceverAction;
            MachineMessageConsumer.M24 += M24.ReiceverAction;
            MachineMessageConsumer.M25 += M25.ReiceverAction;
            MachineMessageConsumer.M26 += M26.ReiceverAction;
            MachineMessageConsumer.M27 += M27.ReiceverAction;
            MachineMessageConsumer.M28 += M28.ReiceverAction;
            MachineMessageConsumer.M1 += M1.ReiceverAction;
            MachineMessageConsumer.ML1 += ML1.ReiceverAction;
            MachineMessageConsumer.ML2 += ML2.ReiceverAction;
            MachineMessageConsumer.ML3 += ML3.ReiceverAction;
            MachineMessageConsumer.ML4 += ML4.ReiceverAction;
            MachineMessageConsumer.ML5 += ML5.ReiceverAction;
            MachineMessageConsumer.ML6 += ML6.ReiceverAction;
            MachineMessageConsumer.ML7 += ML7.ReiceverAction;
            MachineMessageConsumer.ML8 += ML8.ReiceverAction;
            MachineMessageConsumer.ML9 += ML9.ReiceverAction;
            MachineMessageConsumer.ML10 += ML10.ReiceverAction;
            MachineMessageConsumer.ML11 += ML11.ReiceverAction;
            MachineMessageConsumer.ML12 += ML12.ReiceverAction;

            SwitchPage1 = new RelayCommand(async () => await GoToPage1());
            SwitchPage2 = new RelayCommand(async () => await GoToPage2());
            SwitchPage3 = new RelayCommand(async () => await GoToPage3());
            SwitchPage4 = new RelayCommand(async () => await GoToPage4());
            SwitchPage5 = new RelayCommand(async () => await GoToPage5());
            SwitchPage6 = new RelayCommand(async () => await GoToPage6());
            SwitchPage7 = new RelayCommand(async () => await GoToPage7());

        }
        

        private void OnCurrentPageChanged()
        {
            SwitchPageDetail?.Invoke();
        }
        private Task GoToPage1()
        {
            _store.Page = 1;
            OnCurrentPageChanged();
            return Task.CompletedTask;
        }
        private Task GoToPage2()
        {
            
            _store.Page = 2;
            OnCurrentPageChanged();
            return Task.CompletedTask;
        }
        private Task GoToPage3()
        {
            
            _store.Page = 3;
            OnCurrentPageChanged();
            return Task.CompletedTask;
        }
        private Task GoToPage4()
        {
            
            _store.Page = 4;
            OnCurrentPageChanged();
            return Task.CompletedTask;
        }
        private Task GoToPage5()
        {
            
            _store.Page = 5;
            OnCurrentPageChanged();
            return Task.CompletedTask;
        }
        private Task GoToPage6()
        {
           
            _store.Page = 6;
            OnCurrentPageChanged();
            return Task.CompletedTask;
        }
        private Task GoToPage7()
        {
           
            _store.Page = 7;
            OnCurrentPageChanged();
            return Task.CompletedTask;
        }

    }
}

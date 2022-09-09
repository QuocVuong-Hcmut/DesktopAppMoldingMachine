using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage6ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineViewModel _detailMachineViewModelL3;
        public DetailMachineViewModel DetailMachineViewModelL3 { get => _detailMachineViewModelL3; set { _detailMachineViewModelL3 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModelL4;
        public DetailMachineViewModel DetailMachineViewModelL4 { get => _detailMachineViewModelL4; set { _detailMachineViewModelL4 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModelL5;
        public DetailMachineViewModel DetailMachineViewModelL5 { get => _detailMachineViewModelL5; set { _detailMachineViewModelL5 = value; OnPropertyChanged(); } }
        private DetailMachineOpcViewModel _detailMachineViewModelL6;
        public DetailMachineOpcViewModel DetailMachineViewModelL6 { get => _detailMachineViewModelL6; set { _detailMachineViewModelL6 = value; OnPropertyChanged(); } }
        private DetailMachineOpcViewModel _detailMachineViewModelL7;
        public DetailMachineOpcViewModel DetailMachineViewModelL7 { get => _detailMachineViewModelL7; set { _detailMachineViewModelL7 = value; OnPropertyChanged(); } }
        private DetailMachineOpcViewModel _detailMachineViewModelL8;
        public DetailMachineOpcViewModel DetailMachineViewModelL8 { get => _detailMachineViewModelL8; set { _detailMachineViewModelL8 = value; OnPropertyChanged(); } }
        public ObservationMachinePage6ViewModel(DetailMachineViewModel detailMachineViewModel1,
                                                DetailMachineViewModel detailMachineViewModel2,
                                                DetailMachineViewModel detailMachineViewModel3,
                                                DetailMachineOpcViewModel detailMachineViewModel4,
                                                DetailMachineOpcViewModel detailMachineViewModel5,
                                                DetailMachineOpcViewModel detailMachineViewModel6
            )
        {
            DetailMachineViewModelL3 = detailMachineViewModel1;
            DetailMachineViewModelL4 = detailMachineViewModel2;
            DetailMachineViewModelL5 = detailMachineViewModel3;
            DetailMachineViewModelL6 = detailMachineViewModel4;
            DetailMachineViewModelL7 = detailMachineViewModel5;
            DetailMachineViewModelL8 = detailMachineViewModel6;
            CycleMessageConsumer.ML3 += DetailMachineViewModelL3.GetCycleMessage;
            CycleMessageConsumer.ML4 += DetailMachineViewModelL4.GetCycleMessage;
            CycleMessageConsumer.ML5 += DetailMachineViewModelL5.GetCycleMessage;

            MachineMessageConsumer.ML3 += DetailMachineViewModelL3.GetMachineStatus;
            MachineMessageConsumer.ML4 += DetailMachineViewModelL4.GetMachineStatus;
            MachineMessageConsumer.ML5 += DetailMachineViewModelL5.GetMachineStatus;
            CycleMessageConsumer.ML6+=DetailMachineViewModelL6.GetCycleMessage;
            MachineMessageConsumer.ML6+=DetailMachineViewModelL6.GetMachineStatus;
            CycleMessageConsumer.ML7+=DetailMachineViewModelL7.GetCycleMessage;
            MachineMessageConsumer.ML7+=DetailMachineViewModelL7.GetMachineStatus;
            DetailMachineViewModelL6.UpdateViewConfiguration("L6");
            DetailMachineViewModelL7.UpdateViewConfiguration("L7");
            DetailMachineViewModelL8.UpdateViewConfiguration("L8");

        }

    }
}

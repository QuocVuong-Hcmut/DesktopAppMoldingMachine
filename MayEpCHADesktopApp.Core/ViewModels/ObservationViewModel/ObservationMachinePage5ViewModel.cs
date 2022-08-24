using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage5ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineViewModel _detailMachineViewModel4;
        public DetailMachineViewModel DetailMachineViewModel4 { get => _detailMachineViewModel4; set { _detailMachineViewModel4 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel3;
        public DetailMachineViewModel DetailMachineViewModel3 { get => _detailMachineViewModel3; set { _detailMachineViewModel3 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel2;
        public DetailMachineViewModel DetailMachineViewModel2 { get => _detailMachineViewModel2; set { _detailMachineViewModel2 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel1;
        public DetailMachineViewModel DetailMachineViewModel1 { get => _detailMachineViewModel1; set { _detailMachineViewModel1 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModelL1;
        public DetailMachineViewModel DetailMachineViewModelL1 { get => _detailMachineViewModelL1; set { _detailMachineViewModelL1 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModelL2;
        public DetailMachineViewModel DetailMachineViewModelL2 { get => _detailMachineViewModelL2; set { _detailMachineViewModelL2 = value; OnPropertyChanged(); } }
        public ObservationMachinePage5ViewModel(DetailMachineViewModel detailMachineViewModel1,
                                                DetailMachineViewModel detailMachineViewModel2,
                                                DetailMachineViewModel detailMachineViewModel3,
                                                DetailMachineViewModel detailMachineViewModel4,
                                                DetailMachineViewModel detailMachineViewModel5,
                                                DetailMachineViewModel detailMachineViewModel6
            )
        {
            DetailMachineViewModel1 = detailMachineViewModel1;
            DetailMachineViewModel2 = detailMachineViewModel2;
            DetailMachineViewModel3 = detailMachineViewModel3;
            DetailMachineViewModel4 = detailMachineViewModel4;
            DetailMachineViewModelL1 = detailMachineViewModel5;
            DetailMachineViewModelL2 = detailMachineViewModel6;
            CycleMessageConsumer.M4 += DetailMachineViewModel4.GetCycleMessage;
            CycleMessageConsumer.M3 += DetailMachineViewModel3.GetCycleMessage;
            CycleMessageConsumer.M2 += DetailMachineViewModel2.GetCycleMessage;
            CycleMessageConsumer.M1 += DetailMachineViewModel1.GetCycleMessage;
            CycleMessageConsumer.ML1 += DetailMachineViewModelL1.GetCycleMessage;
            CycleMessageConsumer.ML2 += DetailMachineViewModelL2.GetCycleMessage;
            MachineMessageConsumer.M1 += DetailMachineViewModel1.GetMachineStatus;
            MachineMessageConsumer.M2 += DetailMachineViewModel2.GetMachineStatus;
            MachineMessageConsumer.M3 += DetailMachineViewModel3.GetMachineStatus;
            MachineMessageConsumer.M4 += DetailMachineViewModel4.GetMachineStatus;
            MachineMessageConsumer.ML1 += DetailMachineViewModelL1.GetMachineStatus;
            MachineMessageConsumer.ML2 += DetailMachineViewModelL2.GetMachineStatus;
            UaBooleanDataConsumer.ML2 += DetailMachineViewModelL2.ReiceverBoolUaAction;
            UaIntegerDataConsumer.ML2 += DetailMachineViewModelL2.ReiceverIntUaAction;
        }

    }
}

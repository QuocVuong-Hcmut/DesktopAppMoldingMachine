using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage7ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineViewModel _detailMachineViewModelL9;
        public DetailMachineViewModel DetailMachineViewModelL9 { get => _detailMachineViewModelL9; set { _detailMachineViewModelL9 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModelL10;
        public DetailMachineViewModel DetailMachineViewModelL10 { get => _detailMachineViewModelL10; set { _detailMachineViewModelL10 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModelL11;
        public DetailMachineViewModel DetailMachineViewModelL11 { get => _detailMachineViewModelL11; set { _detailMachineViewModelL11 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModelL12;
        public DetailMachineViewModel DetailMachineViewModelL12 { get => _detailMachineViewModelL12; set { _detailMachineViewModelL12 = value; OnPropertyChanged(); } }

        public ObservationMachinePage7ViewModel(DetailMachineViewModel detailMachineViewModel1,
                                                DetailMachineViewModel detailMachineViewModel2,
                                                DetailMachineViewModel detailMachineViewModel3,
                                                DetailMachineViewModel detailMachineViewModel4
                                         
            )
        {
            DetailMachineViewModelL9 = detailMachineViewModel1;
            DetailMachineViewModelL10 = detailMachineViewModel2;
            DetailMachineViewModelL11 = detailMachineViewModel3;
            DetailMachineViewModelL12 = detailMachineViewModel4;
            CycleMessageConsumer.ML9 += DetailMachineViewModelL9.GetCycleMessage;
            CycleMessageConsumer.ML10 += DetailMachineViewModelL10.GetCycleMessage;
            CycleMessageConsumer.ML11 += DetailMachineViewModelL11.GetCycleMessage;
            CycleMessageConsumer.ML12 += DetailMachineViewModelL12.GetCycleMessage;
            MachineMessageConsumer.ML9 += DetailMachineViewModelL9.GetMachineStatus;
            MachineMessageConsumer.ML10 += DetailMachineViewModelL10.GetMachineStatus;
            MachineMessageConsumer.ML11 += DetailMachineViewModelL11.GetMachineStatus;
            MachineMessageConsumer.ML12 += DetailMachineViewModelL12.GetMachineStatus;
            UaBooleanDataConsumer.ML12 += DetailMachineViewModelL12.ReiceverBoolUaAction;
            UaIntegerDataConsumer.ML12 += DetailMachineViewModelL12.ReiceverIntUaAction;

        }

    }
}

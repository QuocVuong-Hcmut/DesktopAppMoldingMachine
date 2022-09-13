using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.Model.DataMonitor;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage7ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineOpcViewModel _detailMachineViewModelL9;
        public DetailMachineOpcViewModel DetailMachineViewModelL9 { get => _detailMachineViewModelL9; set { _detailMachineViewModelL9 = value; OnPropertyChanged(); } }
        private DetailMachineOpcViewModel _detailMachineViewModelL10;
        public DetailMachineOpcViewModel DetailMachineViewModelL10 { get => _detailMachineViewModelL10; set { _detailMachineViewModelL10 = value; OnPropertyChanged(); } }
        private DetailMachineOpcViewModel _detailMachineViewModelL11;
        public DetailMachineOpcViewModel DetailMachineViewModelL11 { get => _detailMachineViewModelL11; set { _detailMachineViewModelL11 = value; OnPropertyChanged(); } }
        private DetailMachineOpcViewModel _detailMachineViewModelL12;
        public DetailMachineOpcViewModel DetailMachineViewModelL12 { get => _detailMachineViewModelL12; set { _detailMachineViewModelL12 = value; OnPropertyChanged(); } }

        public ObservationMachinePage7ViewModel (DetailMachineOpcViewModel detailMachineViewModel1,
                                                DetailMachineOpcViewModel detailMachineViewModel2,
                                                DetailMachineOpcViewModel detailMachineViewModel3,
                                                DetailMachineOpcViewModel detailMachineViewModel4
                                         
            )
        {
            DetailMachineViewModelL9 = detailMachineViewModel1;
            DetailMachineViewModelL10 = detailMachineViewModel2;
            DetailMachineViewModelL11 = detailMachineViewModel3;
            DetailMachineViewModelL12 = detailMachineViewModel4;
            CycleMessageConsumer.ML9+=DetailMachineViewModelL9.GetCycleMessage;
            MachineMessageConsumer.ML9+=DetailMachineViewModelL9.GetMachineStatus;

            CycleMessageConsumer.ML10+=DetailMachineViewModelL10.GetCycleMessage;
            MachineMessageConsumer.ML10+=DetailMachineViewModelL10.GetMachineStatus;
            CycleMessageConsumer.ML12 += DetailMachineViewModelL12.GetCycleMessage;
            MachineMessageConsumer.ML12 += DetailMachineViewModelL12.GetMachineStatus;
            OpcMessageConsumer.L12+=DetailMachineViewModelL12.UpdateDataOpc;
            DetailMachineViewModelL9.UpdateViewConfiguration("L9");
            DetailMachineViewModelL10.UpdateViewConfiguration("L10");
            DetailMachineViewModelL11.UpdateViewConfiguration("L11");
        }

    }
}

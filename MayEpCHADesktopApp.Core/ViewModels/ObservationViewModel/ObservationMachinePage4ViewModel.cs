using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage4ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineViewModel _detailMachineViewModel10;
        public DetailMachineViewModel DetailMachineViewModel10 { get => _detailMachineViewModel10; set { _detailMachineViewModel10 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel9;
        public DetailMachineViewModel DetailMachineViewModel9 { get => _detailMachineViewModel9; set { _detailMachineViewModel9 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel8;
        public DetailMachineViewModel DetailMachineViewModel8 { get => _detailMachineViewModel8; set { _detailMachineViewModel8 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel7;
        public DetailMachineViewModel DetailMachineViewModel7 { get => _detailMachineViewModel7; set { _detailMachineViewModel7 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel6;
        public DetailMachineViewModel DetailMachineViewModel6 { get => _detailMachineViewModel6; set { _detailMachineViewModel6 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel5;
        public DetailMachineViewModel DetailMachineViewModel5 { get => _detailMachineViewModel5; set { _detailMachineViewModel5 = value; OnPropertyChanged(); } }
        public ObservationMachinePage4ViewModel(DetailMachineViewModel detailMachineViewModel1,
                                                DetailMachineViewModel detailMachineViewModel2,
                                                DetailMachineViewModel detailMachineViewModel3,
                                                DetailMachineViewModel detailMachineViewModel4,
                                                DetailMachineViewModel detailMachineViewModel5,
                                                DetailMachineViewModel detailMachineViewModel6
            )
        {
            DetailMachineViewModel10 = detailMachineViewModel1;
            DetailMachineViewModel9 = detailMachineViewModel2;
            DetailMachineViewModel8 = detailMachineViewModel3;
            DetailMachineViewModel7 = detailMachineViewModel4;
            DetailMachineViewModel6 = detailMachineViewModel5;
            DetailMachineViewModel5 = detailMachineViewModel6;
            CycleMessageConsumer.M10 += DetailMachineViewModel10.GetCycleMessage;
            CycleMessageConsumer.M9 += DetailMachineViewModel9.GetCycleMessage;
            CycleMessageConsumer.M8 += DetailMachineViewModel8.GetCycleMessage;
            CycleMessageConsumer.M7 += DetailMachineViewModel7.GetCycleMessage;
            CycleMessageConsumer.M6 += DetailMachineViewModel6.GetCycleMessage;
            CycleMessageConsumer.M5 += DetailMachineViewModel5.GetCycleMessage;
            MachineMessageConsumer.M5 += DetailMachineViewModel5.GetMachineStatus;
            MachineMessageConsumer.M6 += DetailMachineViewModel6.GetMachineStatus;
            MachineMessageConsumer.M7 += DetailMachineViewModel7.GetMachineStatus;
            MachineMessageConsumer.M8 += DetailMachineViewModel8.GetMachineStatus;
            MachineMessageConsumer.M9 += DetailMachineViewModel9.GetMachineStatus;
            MachineMessageConsumer.M10 += DetailMachineViewModel10.GetMachineStatus;
        }

    }
}

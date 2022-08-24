using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage3ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineViewModel _detailMachineViewModel16;
        public DetailMachineViewModel DetailMachineViewModel16 { get => _detailMachineViewModel16; set { _detailMachineViewModel16 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel15;
        public DetailMachineViewModel DetailMachineViewModel15 { get => _detailMachineViewModel15; set { _detailMachineViewModel15 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel14;
        public DetailMachineViewModel DetailMachineViewModel14 { get => _detailMachineViewModel14; set { _detailMachineViewModel14 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel13;
        public DetailMachineViewModel DetailMachineViewModel13 { get => _detailMachineViewModel13; set { _detailMachineViewModel13 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel12;
        public DetailMachineViewModel DetailMachineViewModel12 { get => _detailMachineViewModel12; set { _detailMachineViewModel12 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel11;
        public DetailMachineViewModel DetailMachineViewModel11 { get => _detailMachineViewModel11; set { _detailMachineViewModel11 = value; OnPropertyChanged(); } }
        public ObservationMachinePage3ViewModel(DetailMachineViewModel detailMachineViewModel1,
                                                DetailMachineViewModel detailMachineViewModel2,
                                                DetailMachineViewModel detailMachineViewModel3,
                                                DetailMachineViewModel detailMachineViewModel4,
                                                DetailMachineViewModel detailMachineViewModel5,
                                                DetailMachineViewModel detailMachineViewModel6
            )
        {
            DetailMachineViewModel16 = detailMachineViewModel1;
            DetailMachineViewModel15 = detailMachineViewModel2;
            DetailMachineViewModel14 = detailMachineViewModel3;
            DetailMachineViewModel13 = detailMachineViewModel4;
            DetailMachineViewModel12 = detailMachineViewModel5;
            DetailMachineViewModel11 = detailMachineViewModel6;
            CycleMessageConsumer.M16 += DetailMachineViewModel16.GetCycleMessage;
            CycleMessageConsumer.M15 += DetailMachineViewModel15.GetCycleMessage;
            CycleMessageConsumer.M14 += DetailMachineViewModel14.GetCycleMessage;
            CycleMessageConsumer.M13 += DetailMachineViewModel13.GetCycleMessage;
            CycleMessageConsumer.M12 += DetailMachineViewModel12.GetCycleMessage;
            CycleMessageConsumer.M11 += DetailMachineViewModel11.GetCycleMessage;
            MachineMessageConsumer.M11 += DetailMachineViewModel11.GetMachineStatus;
            MachineMessageConsumer.M12 += DetailMachineViewModel12.GetMachineStatus;
            MachineMessageConsumer.M13 += DetailMachineViewModel13.GetMachineStatus;
            MachineMessageConsumer.M14 += DetailMachineViewModel14.GetMachineStatus;
            MachineMessageConsumer.M15 += DetailMachineViewModel15.GetMachineStatus;
            MachineMessageConsumer.M16 += DetailMachineViewModel16.GetMachineStatus;
        }

    }
}

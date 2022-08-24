using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage2ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineViewModel _detailMachineViewModel22;
        public DetailMachineViewModel DetailMachineViewModel22 { get => _detailMachineViewModel22; set { _detailMachineViewModel22 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel21;
        public DetailMachineViewModel DetailMachineViewModel21 { get => _detailMachineViewModel21; set { _detailMachineViewModel21 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel20;
        public DetailMachineViewModel DetailMachineViewModel20 { get => _detailMachineViewModel20; set { _detailMachineViewModel20 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel19;
        public DetailMachineViewModel DetailMachineViewModel19 { get => _detailMachineViewModel19; set { _detailMachineViewModel19 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel18;
        public DetailMachineViewModel DetailMachineViewModel18 { get => _detailMachineViewModel18; set { _detailMachineViewModel18 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel17;
        public DetailMachineViewModel DetailMachineViewModel17 { get => _detailMachineViewModel17; set { _detailMachineViewModel17 = value; OnPropertyChanged(); } }
        public ObservationMachinePage2ViewModel(DetailMachineViewModel detailMachineViewModel1,
                                                DetailMachineViewModel detailMachineViewModel2,
                                                DetailMachineViewModel detailMachineViewModel3,
                                                DetailMachineViewModel detailMachineViewModel4,
                                                DetailMachineViewModel detailMachineViewModel5,
                                                DetailMachineViewModel detailMachineViewModel6
            )
        {
            DetailMachineViewModel22 = detailMachineViewModel1;
            DetailMachineViewModel21 = detailMachineViewModel2;
            DetailMachineViewModel20 = detailMachineViewModel3;
            DetailMachineViewModel19 = detailMachineViewModel4;
            DetailMachineViewModel18 = detailMachineViewModel5;
            DetailMachineViewModel17 = detailMachineViewModel6;
            CycleMessageConsumer.M22 += DetailMachineViewModel22.GetCycleMessage;
            CycleMessageConsumer.M21 += DetailMachineViewModel21.GetCycleMessage;
            CycleMessageConsumer.M20 += DetailMachineViewModel20.GetCycleMessage;
            CycleMessageConsumer.M19 += DetailMachineViewModel19.GetCycleMessage;
            CycleMessageConsumer.M18 += DetailMachineViewModel18.GetCycleMessage;
            CycleMessageConsumer.M17 += DetailMachineViewModel17.GetCycleMessage;
            MachineMessageConsumer.M17 += DetailMachineViewModel17.GetMachineStatus;
            MachineMessageConsumer.M18 += DetailMachineViewModel18.GetMachineStatus;
            MachineMessageConsumer.M19 += DetailMachineViewModel19.GetMachineStatus;
            MachineMessageConsumer.M20 += DetailMachineViewModel20.GetMachineStatus;
            MachineMessageConsumer.M21 += DetailMachineViewModel21.GetMachineStatus;
            MachineMessageConsumer.M22 += DetailMachineViewModel22.GetMachineStatus;
        }

    }
}

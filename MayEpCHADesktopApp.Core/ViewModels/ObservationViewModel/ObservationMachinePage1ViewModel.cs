using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;

namespace MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel
{
    public class ObservationMachinePage1ViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private DetailMachineViewModel _detailMachineViewModel28;
        public DetailMachineViewModel DetailMachineViewModel28 { get => _detailMachineViewModel28; set { _detailMachineViewModel28 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel27;
        public DetailMachineViewModel DetailMachineViewModel27 { get => _detailMachineViewModel27; set { _detailMachineViewModel27 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel26;
        public DetailMachineViewModel DetailMachineViewModel26 { get => _detailMachineViewModel26; set { _detailMachineViewModel26 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel25;
        public DetailMachineViewModel DetailMachineViewModel25 { get => _detailMachineViewModel25; set { _detailMachineViewModel25 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel24;
        public DetailMachineViewModel DetailMachineViewModel24 { get => _detailMachineViewModel24; set { _detailMachineViewModel24 = value; OnPropertyChanged(); } }
        private DetailMachineViewModel _detailMachineViewModel23;
        public DetailMachineViewModel DetailMachineViewModel23 { get => _detailMachineViewModel23; set { _detailMachineViewModel23 = value; OnPropertyChanged(); } }
        public ObservationMachinePage1ViewModel(DetailMachineViewModel detailMachineViewModel1,
                                                DetailMachineViewModel detailMachineViewModel2,
                                                DetailMachineViewModel detailMachineViewModel3,
                                                DetailMachineViewModel detailMachineViewModel4,
                                                DetailMachineViewModel detailMachineViewModel5,
                                                DetailMachineViewModel detailMachineViewModel6
            )
        {
            DetailMachineViewModel28 = detailMachineViewModel1;
            DetailMachineViewModel27 = detailMachineViewModel2;
            DetailMachineViewModel26 = detailMachineViewModel3;
            DetailMachineViewModel24 = detailMachineViewModel4;
            DetailMachineViewModel23 = detailMachineViewModel5;
            DetailMachineViewModel25 = detailMachineViewModel6;
            CycleMessageConsumer.M28 += DetailMachineViewModel28.GetCycleMessage;
            CycleMessageConsumer.M27 += DetailMachineViewModel27.GetCycleMessage;
            CycleMessageConsumer.M26 += DetailMachineViewModel26.GetCycleMessage;
            CycleMessageConsumer.M25 += DetailMachineViewModel25.GetCycleMessage;
            CycleMessageConsumer.M24 += DetailMachineViewModel24.GetCycleMessage;
            CycleMessageConsumer.M23 += DetailMachineViewModel23.GetCycleMessage;
            MachineMessageConsumer.M23 += DetailMachineViewModel23.GetMachineStatus;
            MachineMessageConsumer.M24 += DetailMachineViewModel24.GetMachineStatus;
            MachineMessageConsumer.M25 += DetailMachineViewModel25.GetMachineStatus;
            MachineMessageConsumer.M26 += DetailMachineViewModel26.GetMachineStatus;
            MachineMessageConsumer.M27 += DetailMachineViewModel27.GetMachineStatus;
            MachineMessageConsumer.M28 += DetailMachineViewModel28.GetMachineStatus;
        }
        public void LoadConfigurationDetail ( ) { 
            
        }

        
    }
}

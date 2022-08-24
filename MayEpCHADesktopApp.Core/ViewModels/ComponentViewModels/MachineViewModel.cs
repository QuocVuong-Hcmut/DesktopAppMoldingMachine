using ImmServiceContainers;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels
{

    public class MachineViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        public string Status { get => status; set { status = value; OnPropertyChanged(); } }
        private string status { get; set; }
        public MachineViewModel()
        {
            Status = "3";
        }
        public void ReiceverAction(MachineMessage machineMessage)
        {
            switch (machineMessage.MachineStatus)
            {
                case EMachineStatus.PowerOff:
                    Status = "1";
                    break;
                case EMachineStatus.PowerOn:
                    Status = "2";
                    break;
                case EMachineStatus.Disconnect:
                    Status = "3";
                    break;
                case EMachineStatus.Connected:
                    Status = "4";
                    break;
                case EMachineStatus.OnProduction:
                    Status = "5";
                    break;
                case EMachineStatus.Idle:
                    Status = "6";
                    break;
                case EMachineStatus.ErrorOnGoing:
                    Status = "7";
                    break;
                case EMachineStatus.ErrorOutGoing:
                    Status = "8";
                    break;

            }
        }


    }
}

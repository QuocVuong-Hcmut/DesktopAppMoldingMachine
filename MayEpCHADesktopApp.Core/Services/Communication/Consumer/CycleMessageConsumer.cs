using InjectionMoldingMachineDataAcquisitionService.Communication.Consumers;
using MassTransit;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.Consumer
{
    public  class CycleMessageConsumer : IConsumer<CycleMessage>
    {
        public CycleMessageConsumer(MQTTStore mQTTstore)
        {

        }
        public static event Action<CycleMessage> M1;
        public static event Action<CycleMessage> M2;
        public static event Action<CycleMessage> M3;
        public static event Action<CycleMessage> M4;
        public static event Action<CycleMessage> M5;
        public static event Action<CycleMessage> M6;
        public static event Action<CycleMessage> M7;
        public static event Action<CycleMessage> M8;
        public static event Action<CycleMessage> M9;
        public static event Action<CycleMessage> M10;
        public static event Action<CycleMessage> M11;
        public static event Action<CycleMessage> M12;
        public static event Action<CycleMessage> M13;
        public static event Action<CycleMessage> M14;
        public static event Action<CycleMessage> M15;
        public static event Action<CycleMessage> M16;
        public static event Action<CycleMessage> M17;
        public static event Action<CycleMessage> M18;
        public static event Action<CycleMessage> M19;
        public static event Action<CycleMessage> M20;
        public static event Action<CycleMessage> M21;
        public static event Action<CycleMessage> M22;
        public static event Action<CycleMessage> M23;
        public static event Action<CycleMessage> M24;
        public static event Action<CycleMessage> M25;
        public static event Action<CycleMessage> M26;
        public static event Action<CycleMessage> M27;
        public static event Action<CycleMessage> M28;
        public static event Action<CycleMessage> ML1;
        public static event Action<CycleMessage> ML2;
        public static event Action<CycleMessage> ML3;
        public static event Action<CycleMessage> ML4;
        public static event Action<CycleMessage> ML5;
        public static event Action<CycleMessage> ML6;
        public static event Action<CycleMessage> ML7;
        public static event Action<CycleMessage> ML8;
        public static event Action<CycleMessage> ML9;
        public static event Action<CycleMessage> ML10;
        public static event Action<CycleMessage> ML11;
        public static event Action<CycleMessage> ML12;
        public async Task Consume(ConsumeContext<CycleMessage> context)
        {
            var message = context.Message;
            
            Display(message);

        }
        private void Display(CycleMessage Message)
        {
            switch (Message.MachineId)
            {
                case "M1":
                    M1?.Invoke(Message);
                    break;
                case "M2":
                    M2?.Invoke(Message);
                    break;
                case "M3":
                    M3?.Invoke(Message);
                    break;
                case "M4":
                    M4?.Invoke(Message);
                    break;
                case "M5":
                    M5?.Invoke(Message);
                    break;
                case "M6":
                    M6?.Invoke(Message);
                    break;
                case "M7":
                    M7?.Invoke(Message);
                    break;
                case "M8":
                    M8?.Invoke(Message);
                    break;
                case "M9":
                    M9?.Invoke(Message);
                    break;
                case "M10":
                    M10?.Invoke(Message);
                    break;
                case "M11":
                    M11?.Invoke(Message);
                    break;
                case "M12":
                    M12?.Invoke(Message);
                    break;
                case "M13":
                    M13?.Invoke(Message);
                    break;
                case "M14":
                    M14?.Invoke(Message);
                    break;
                case "M15":
                    M15?.Invoke(Message);
                    break;
                case "M16":
                    M16?.Invoke(Message);
                    break;
                case "M17":
                    M17?.Invoke(Message);

                    break;
                case "M18":
                    M1?.Invoke(Message);
                    break;
                case "M19":
                    M19?.Invoke(Message);
                    break;
                case "M20":
                    M20?.Invoke(Message);
                    break;
                case "M21":
                    M21?.Invoke(Message);
                    break;
                case "M22":
                    M22?.Invoke(Message);
                    break;
                case "M23":
                    M23?.Invoke(Message);
                    break;
                case "M24":
                    M24?.Invoke(Message);
                    break;
                case "M25":
                    M25?.Invoke(Message);
                    break;
                case "M26":
                    M26?.Invoke(Message);
                    break;
                case "M27":
                    M27?.Invoke(Message);
                    break;
                case "M28":
                    M28?.Invoke(Message);
                    break;
                case "L1":
                    ML1?.Invoke(Message);
                    break;
                case "L2":
                    ML1?.Invoke(Message);
                    break;
                case "L3":
                    ML3?.Invoke(Message);
                    break;
                case "L4":
                    ML4?.Invoke(Message);
                    break;
                case "L5":
                    ML5?.Invoke(Message);
                    break;
                case "L6":
                    ML6?.Invoke(Message);
                    break;
                case "L7":
                    ML7?.Invoke(Message);
                    break;
                case "L8":
                    ML8?.Invoke(Message);
                    break;
                case "L9":
                    ML9?.Invoke(Message);
                    break;
                case "L10":
                    ML10?.Invoke(Message);
                    break;
                case "L11":
                    ML11?.Invoke(Message);
                    break;
                case "L12":
                    ML12?.Invoke(Message);
                    break;
                default:
                    break;



            }
        }

    }
}

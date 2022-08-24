using ImmServiceContainers;
using MassTransit;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.Consumer
{
    public class MachineMessageConsumer : IConsumer<MachineMessage>
    {
        public static event Action<MachineMessage> M1;
        public static event Action<MachineMessage> M2;
        public static event Action<MachineMessage> M3;
        public static event Action<MachineMessage> M4;
        public static event Action<MachineMessage> M5;
        public static event Action<MachineMessage> M6;
        public static event Action<MachineMessage> M7;
        public static event Action<MachineMessage> M8;
        public static event Action<MachineMessage> M9;
        public static event Action<MachineMessage> M10;
        public static event Action<MachineMessage> M11;
        public static event Action<MachineMessage> M12;
        public static event Action<MachineMessage> M13;
        public static event Action<MachineMessage> M14;
        public static event Action<MachineMessage> M15;
        public static event Action<MachineMessage> M16;
        public static event Action<MachineMessage> M17;
        public static event Action<MachineMessage> M18;
        public static event Action<MachineMessage> M19;
        public static event Action<MachineMessage> M20;
        public static event Action<MachineMessage> M21;
        public static event Action<MachineMessage> M22;
        public static event Action<MachineMessage> M23;
        public static event Action<MachineMessage> M24;
        public static event Action<MachineMessage> M25;
        public static event Action<MachineMessage> M26;
        public static event Action<MachineMessage> M27;
        public static event Action<MachineMessage> M28;
        public static event Action<MachineMessage> ML1;
        public static event Action<MachineMessage> ML2;
        public static event Action<MachineMessage> ML3;
        public static event Action<MachineMessage> ML4;
        public static event Action<MachineMessage> ML5;
        public static event Action<MachineMessage> ML6;
        public static event Action<MachineMessage> ML7;
        public static event Action<MachineMessage> ML8;
        public static event Action<MachineMessage> ML9;
        public static event Action<MachineMessage> ML10;
        public static event Action<MachineMessage> ML11;
        public static event Action<MachineMessage> ML12;


        public async Task Consume(ConsumeContext<MachineMessage> context)
        {
            var message = context.Message;

            Display(message);
            

        //    Console.WriteLine("MachineMessage: MachineId: {0}, Timestamp: {1}, MachineStatus: {2}", message.MachineId, message.Timestamp, message.MachineStatus);

        }
        private void Display(MachineMessage Message)
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

using InjectionMoldingMachineDataAcquisitionService.Communication.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.Consumer
{
    public class OpcMessageConsumer: IConsumer<UaMessage>
    {
        public static event Action<UaMessage> M1;
        public static event Action<UaMessage> M2;
        public static event Action<UaMessage> M27;
        public static event Action<UaMessage> M28;
        public static event Action<UaMessage> L2;
        public static event Action<UaMessage> L5;
        public static event Action<UaMessage> L6;
        public static event Action<UaMessage> L7;
        public static event Action<UaMessage> L8;
        public static event Action<UaMessage> L9;
        public static event Action<UaMessage> L10;
        public static event Action<UaMessage> L11;
        public static event Action<UaMessage> L12;
        public async Task Consume (ConsumeContext<UaMessage> context)
        {
            var message = context.Message;
            UpdateData(message);
        }
        private void UpdateData (UaMessage opcMessage)
        {
            switch ( opcMessage .MachineId)
            {
                case "M1":
                    M1?.Invoke(opcMessage);
                    break;
                case "M2":
                    M2?.Invoke(opcMessage);
                    break;
                case "M27":
                    M27?.Invoke(opcMessage);
                    break;
                case "M28":
                    M28?.Invoke(opcMessage);
                    break;
                case "L2":
                    L2?.Invoke(opcMessage);
                    break;
                case "L6":
                    L6?.Invoke(opcMessage);
                    break;
                case "L7":
                    L7?.Invoke(opcMessage);
                    break;
                case "L8":
                    L8.Invoke(opcMessage);
                    break;
                case "L9":
                    L9?.Invoke(opcMessage);
                    break;
                case "L10":
                    L10?.Invoke(opcMessage);
                    break;
                case "L11":
                    L11?.Invoke(opcMessage);
                    break;
                case "L12":
                    L12?.Invoke(opcMessage);
                    break;

            }
        }
    }
}

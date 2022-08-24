using InjectionMoldingMachineDataAcquisitionService.Communication.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.Consumer
{
    public class DaMessageConsumer: IConsumer<DaMessage>
    {
        public async Task Consume (ConsumeContext<DaMessage> context)
        {
            var message = context.Message;
        }
    }
}

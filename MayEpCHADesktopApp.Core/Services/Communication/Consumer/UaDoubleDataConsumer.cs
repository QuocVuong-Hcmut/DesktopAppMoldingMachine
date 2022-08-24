using ImmServiceContainers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.Consumer
{
    public class UaDoubleDataConsumer : IConsumer<UaDoubleData>
    {
        public async Task Consume(ConsumeContext<UaDoubleData> context)
        {
            var message = context.Message;

       //     Console.WriteLine("Name: {0}, Value: {1}", message.Name, message.Value);
        }
    }
}

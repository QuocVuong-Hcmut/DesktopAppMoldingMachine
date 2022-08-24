using ImmServiceContainers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.Consumer
{
    public class UaIntegerDataConsumer : IConsumer<UaIntegerData>
    {
        public static event Action<UaIntegerData> ML2;
        public static event Action<UaIntegerData> ML5;
        public static event Action<UaIntegerData> ML12;
        public async Task Consume(ConsumeContext<UaIntegerData> context)
        {
            var message = context.Message;

            Console.WriteLine("Name: {0}, Value: {1}", message.Name, message.Value);
        }
        void Display(UaIntegerData uaIntegerData)
        {
            string[] Data = uaIntegerData.Name.Split('.');
            switch (Data[0])
            {
                case "L2":
                    ML2?.Invoke(uaIntegerData);
                    break;
                case "L5":
                    ML5?.Invoke(uaIntegerData);
                    break;
                case "L12":
                    ML12?.Invoke(uaIntegerData);
                    break;

            }
        }
    }
}

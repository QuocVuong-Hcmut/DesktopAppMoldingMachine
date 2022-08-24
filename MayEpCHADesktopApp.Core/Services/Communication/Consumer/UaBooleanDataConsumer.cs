using ImmServiceContainers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services.Communication.Consumer
{
    public class UaBooleanDataConsumer : IConsumer<UaBooleanData>
    {
        public static event Action<UaBooleanData> ML2;
        public static event Action<UaBooleanData> ML5;
        public static event Action<UaBooleanData> ML12;
        public  async Task Consume(ConsumeContext<UaBooleanData> context)
        {
            var message = context.Message;
            Display(message);
      //      Console.WriteLine("Name: {0}, Value: {1}", message.Name, message.Value);
        }
        void Display(UaBooleanData uaBooleanData)
        {
            string[] Data = uaBooleanData.Name.Split('.');
            switch (Data[0]) {
                case "L2":
                    ML2?.Invoke(uaBooleanData);
                    break;
                case "L5":
                    ML5?.Invoke(uaBooleanData);
                    break;
                case "L12":
                    ML12?.Invoke(uaBooleanData);
                    break;

            }
        }
    }
}

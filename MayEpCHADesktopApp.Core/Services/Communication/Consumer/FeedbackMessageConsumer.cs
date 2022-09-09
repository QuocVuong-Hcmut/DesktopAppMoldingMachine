using  InjectionMoldingMachineDataAcquisitionService.Communication.Messages;
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
    public class FeedbackMessageConsumer : IConsumer<FeedbackMessage>
    {
        public static event Action ReceiveSychTime;
        public static event Action ReceiveRTCfail;
        public static event Action ReceiveSDcardfail;
        public async Task Consume(ConsumeContext<FeedbackMessage> context)
        {
            var message = context.Message;
            switch (message.Mess)
            {
                case EFeedback.SychTime:
                    ReceiveSychTime?.Invoke();
                    break;
                case EFeedback.RTCfail:
                    ReceiveSychTime?.Invoke();
                    break;
                case EFeedback.SDcardfail:
                    ReceiveSychTime?.Invoke();
                    break;
            }
            
          //  Console.WriteLine("Feedback: {0}", message.Mess);
        }
       
            
        

    }
}

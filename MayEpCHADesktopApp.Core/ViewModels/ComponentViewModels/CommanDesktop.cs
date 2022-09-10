using InjectionMoldingMachineDataAcquisitionService.Communication.Messages;
using MassTransit;
using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels
{
    public class CommanDesktop
    {
        private static IBusControl _bus;
        public CommanDesktop(IBusControl bus)
        {
            _bus = bus;
            FeedbackMessageConsumer.ReceiveSychTime += FeedbackMessageConsumer_Receive;
            FeedbackMessageConsumer.ReceiveRTCfail += FeedbackMessageConsumer_ReceiveRTCfail;
            FeedbackMessageConsumer.ReceiveSDcardfail += FeedbackMessageConsumer_ReceiveSDcardfail;
            
        }

        private void FeedbackMessageConsumer_ReceiveSDcardfail()
        {
            CustomMessageBox.Show("Lỗi nhận được ở FeedBack");
        }

        private void FeedbackMessageConsumer_ReceiveRTCfail()
        {
            CustomMessageBox.Show("Lỗi nhận được ở FeedBack");
        }

        private async void FeedbackMessageConsumer_Receive()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("http://127.0.0.1:8181/send-config"));
            await endpoint.Send<SychronizeTimeMessage>(new SychronizeTimeMessage
            {
                MachineId = "L6",
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day,
                Hour = DateTime.Now.Hour,
                Min =  DateTime.Now.Minute,
                Sec = DateTime.Now.Second,

            }); ; ;
        }

        public async static void Command(CommandMessage commandMessage)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("http://127.0.0.1:8181/send-config"));
            await endpoint.Send<CommandMessage>(commandMessage);
        }
        public async static void ConfigCommand(ConfigurationMessage configMessage)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("http://127.0.0.1:8181/send-config"));
            await endpoint.Send<ConfigurationMessage>(configMessage);
        }
    }
}

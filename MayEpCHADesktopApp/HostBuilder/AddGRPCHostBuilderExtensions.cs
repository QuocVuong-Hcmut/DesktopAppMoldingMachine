using MassTransit;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.Store;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddGRPC
    {
        public static IHostBuilder AddGRPCRead(this IHostBuilder host)
        {
            host.ConfigureServices(services => {
                services.AddSingleton<MQTTStore>();

                var protocolProvider = services.BuildServiceProvider();

                services.AddSingleton<FeedbackMessageConsumer>();
               // services.AddSingleton<CycleMessageConsumer>((IServiceProvider serviceprovider) => { return new CycleMessageConsumer(serviceprovider.GetRequiredService<MQTTStore>()); });
                services.AddSingleton<IBusControl>((IServiceProvider serviceprovider) => { return Bus.Factory.CreateUsingGrpc(x =>
                {
                    x.Host(h =>
                    {
                        h.Host = "127.0.0.1";
                        h.Port = 8182;
                        h.AddServer(new Uri("http://127.0.0.1:8181"));
                    });
                    x.ReceiveEndpoint("event-listener", e =>
                    {
                        e.Consumer<CycleMessageConsumer>(() => new CycleMessageConsumer(
                            protocolProvider.GetRequiredService<MQTTStore>()
                            ));
                        e.Consumer<MachineMessageConsumer>();
                        e.Consumer<FeedbackMessageConsumer>();
                        e.Consumer<UaDoubleDataConsumer>();
                        e.Consumer<UaBooleanDataConsumer>();
                        e.Consumer<UaIntegerDataConsumer>();
                       // e.Consumer<DaMessageConsumer>( );
                        e.Consumer(( ) => new DaMessageConsumer( ));
                    });
                });
                });

            });

            return host;
        }
      
    }
}

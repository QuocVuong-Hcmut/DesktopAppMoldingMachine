using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.ViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel;
using MayEpCHADesktopApp.Resources.Components;
using MayEpCHADesktopApp.Views.ObservationView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
            services.AddSingleton<MainWindow>((IServiceProvider serviceprovider) => { return new MainWindow(serviceprovider.GetRequiredService<MainViewModel>()); });
             // services.AddTransient<MachineInformationDetail>();
                //services.AddSingleton<ObservateView>((IServiceProvider serviceprovider) => { return new ObservateView(serviceprovider.GetRequiredService<ObservationViewModel>());});
            });

            return host;
        }
    }
}

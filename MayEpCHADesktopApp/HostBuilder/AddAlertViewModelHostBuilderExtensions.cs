using MayEpCHADesktopApp.Core.ViewModels.AlertViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddAlertViewModelHostBuilderExtensions
    {
        public static IHostBuilder AddAlertViewModel(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<AlertViewModel>();
            });

            return host;
        }
    }
}

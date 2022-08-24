using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.Store;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddStoressHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddTransient<NavigationStore>();
                services.AddSingleton<PageStore>();

            });

            return host;
        }
    }
}

using MayEpCHADesktopApp.Core.Database.DBContext;
using MayEpCHADesktopApp.Core.Database.Repository;
using MayEpCHADesktopApp.Core.Database.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.HostBuilder
{

    public static class AddDBContextHostBuilderExtensions
    {
        public static IHostBuilder AddDBContext(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddDbContextFactory<ApplicationDbContext>();
                services.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
                services.AddSingleton<IEventMachineRepository, EventMachineRepository>();
                services.AddSingleton<IHicstoryConfigurationRepository, HicstoryConfigurationRepository>();

            });

            return host;
        }
    }
}

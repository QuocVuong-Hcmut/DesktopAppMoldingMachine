
using MayEpCHADesktopApp.Core.ViewModels.ManageViewModel;
using MayEpCHADesktopApp.Core.Services;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels;
using MayEpCHADesktopApp.Core.ViewModels.LoginViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddManageViewModelHostBuilderExtensions
    {
        public static IHostBuilder AddManageViewModel(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<MoldCodeViewModel>();
                services.AddSingleton<EmployeeManageViewModel>();
                services.AddSingleton<ProductCodeViewModel>();
                services.AddSingleton<ManageViewModel>((IServiceProvider serviceprovider) =>
                {
                    var Store = serviceprovider.GetRequiredService<NavigationStore>();
                    return new ManageViewModel(Store, CreateEmployeeManageViewModel(serviceprovider, Store), CreateProductCodeViewModell(serviceprovider, Store), CreateMoldCodeViewModel(serviceprovider, Store));
                });
        });
      
            return host;
        }
        private static INavigationService CreateEmployeeManageViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<EmployeeManageViewModel>());
        }
        private static INavigationService CreateProductCodeViewModell(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ProductCodeViewModel>());
        }
        private static INavigationService CreateMoldCodeViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<MoldCodeViewModel>());
        }

    }
}

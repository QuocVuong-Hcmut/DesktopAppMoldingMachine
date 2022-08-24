using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using MayEpCHADesktopApp.Core.Services;
using MayEpCHADesktopApp.Core.ViewModels;
using MayEpCHADesktopApp.Core.ViewModels.AlertViewModel;
using MayEpCHADesktopApp.Core.ViewModels.LoginViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ManageViewModel;
using MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel;
using MayEpCHADesktopApp.Core.ViewModels.ReportViewModels;
using MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels;
using NavigationService = MayEpCHADesktopApp.Core.Services.NavigationService;

namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddSettingsViewModelHostBuilderExtensions
    {
        public static IHostBuilder AddSettings(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<SettingsNewViewModel>();
                services.AddSingleton<SettingsPreviousViewModel>();
                
                services.AddSingleton<SettingsViewModel>((IServiceProvider serviceprovider) => {
                    var Store = serviceprovider.GetRequiredService<NavigationStore>();
                    return new SettingsViewModel(Store, CreateSettingsNewViewModel(serviceprovider, Store),
                                                    CreateSettingsPreviousViewModel(serviceprovider, Store)
                                                   
                                                    );
                });

            });

            return host;
        }

        private static INavigationService CreateSettingsPreviousViewModel(IServiceProvider serviceprovider, NavigationStore store)
        {
            return new NavigationService(store, serviceprovider.GetRequiredService<SettingsPreviousViewModel>());
        }

        private static INavigationService CreateSettingsNewViewModel(IServiceProvider serviceprovider, NavigationStore store)
        {
            return new NavigationService(store, serviceprovider.GetRequiredService<SettingsNewViewModel>());
        }
    }
}

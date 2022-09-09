using MayEpCHADesktopApp.Core.Services;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels;
using MayEpCHADesktopApp.Core.ViewModels.AlertViewModel;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using MayEpCHADesktopApp.Core.ViewModels.HelpViewModel;
using MayEpCHADesktopApp.Core.ViewModels.HistoryViewModel;
using MayEpCHADesktopApp.Core.ViewModels.LoginViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ManageViewModel;
using MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel;
using MayEpCHADesktopApp.Core.ViewModels.ReportViewModels;
using MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels (this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<LoginViewModel>( );
                services.AddSingleton<HistoryViewModel>( );
                services.AddSingleton<HelpViewModel>( );
                services.AddTransient<DetailMachineViewModel>( );
                services.AddTransient<DetailMachineOpcViewModel>( );
                services.AddSingleton<CommanDesktop>( );

                services.AddSingleton<MainViewModel>((IServiceProvider serviceprovider) =>
                {
                    var Store = serviceprovider.GetRequiredService<NavigationStore>( );
                    return new MainViewModel(Store,CreateLoginViewModel(serviceprovider,Store),
                                                    CreateObservationViewmodel(serviceprovider,Store),
                                                    CreateSettingsViewModel(serviceprovider,Store),
                                                    CreateAlertViewModel(serviceprovider,Store),
                                                    CreateManegeViewModel(serviceprovider,Store),
                                                    CreateReportViewModel(serviceprovider,Store),
                                                    CreateHistoryViewmodel(serviceprovider,Store),
                                                    CreateHelpViewmodel(serviceprovider,Store)
                                                    );
                });

            });

            return host;
        }
        private static INavigationService CreateReportViewModel (IServiceProvider serviceprovider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceprovider.GetRequiredService<ReportViewModel>( ));
        }
        private static INavigationService CreateManegeViewModel (IServiceProvider serviceprovider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceprovider.GetRequiredService<ManageViewModel>( ));
        }
        private static INavigationService CreateAlertViewModel (IServiceProvider serviceprovider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceprovider.GetRequiredService<AlertViewModel>( ));
        }

        private static INavigationService CreateSettingsViewModel (IServiceProvider serviceprovider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceprovider.GetRequiredService<SettingsViewModel>( ));
        }

        private static INavigationService CreateLoginViewModel (IServiceProvider serviceProvider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceProvider.GetRequiredService<LoginViewModel>( ));
        }
        private static INavigationService CreateObservationViewmodel (IServiceProvider serviceProvider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceProvider.GetRequiredService<ObservationViewModel>( ));
        }
        private static INavigationService CreateHistoryViewmodel (IServiceProvider serviceProvider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceProvider.GetRequiredService<HistoryViewModel>( ));
        }
        private static INavigationService CreateHelpViewmodel (IServiceProvider serviceProvider,NavigationStore Store)
        {
            return new NavigationService(Store,serviceProvider.GetRequiredService<HelpViewModel>( ));
        }
    }
}

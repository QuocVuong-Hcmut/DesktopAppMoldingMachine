using MayEpCHADesktopApp.Core.Services;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.Store;
using MayEpCHADesktopApp.Core.ViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using MayEpCHADesktopApp.Core.ViewModels.LoginViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ObservationViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddObservationViewModelHostBuildExtensions
    {
        public static IHostBuilder AddObservationViewModel(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<ObservationMachinePage1ViewModel>((IServiceProvider serviceProvider) => { return 
                new ObservationMachinePage1ViewModel(serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>()
                                                    
                                                    
                ); });
                services.AddSingleton<ObservationMachinePage2ViewModel>((IServiceProvider serviceProvider) => {
                    return
                    new ObservationMachinePage2ViewModel(serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>()

);
                });
                services.AddSingleton<ObservationMachinePage3ViewModel>((IServiceProvider serviceProvider) => {
                    return
                    new ObservationMachinePage3ViewModel(serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>()

);
                });
                services.AddSingleton<ObservationMachinePage4ViewModel>((IServiceProvider serviceProvider) => {
                    return
                    new ObservationMachinePage4ViewModel(serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>()

);
                });
                services.AddSingleton<ObservationMachinePage5ViewModel>((IServiceProvider serviceProvider) => {
                    return
                    new ObservationMachinePage5ViewModel(serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>()

);
                });
                services.AddSingleton<ObservationMachinePage6ViewModel>((IServiceProvider serviceProvider) => {
                    return
                    new ObservationMachinePage6ViewModel(serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineOpcViewModel>()

);
                });
                services.AddSingleton<ObservationMachinePage7ViewModel>((IServiceProvider serviceProvider) => {
                    return
                    new ObservationMachinePage7ViewModel(serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineOpcViewModel>(),
                                                    serviceProvider.GetRequiredService<DetailMachineViewModel>()
                                                 

);
                });


                services.AddSingleton<ObservationMachineViewModel>((IServiceProvider serviceprovider) =>
                {
                    return new ObservationMachineViewModel(serviceprovider.GetRequiredService<PageStore>());    
                });
                
                services.AddSingleton<ObservationDetailMachineViewModel>((IServiceProvider serviceprovider) =>
                {
                    var Store = serviceprovider.GetRequiredService<NavigationStore>();
                    return new ObservationDetailMachineViewModel(serviceprovider.GetRequiredService<PageStore>(),
                                                                 Store,
                                                                 CreateObservationPage1ViewModel(serviceprovider, Store ),
                                                                 CreateObservationPage2ViewModel(serviceprovider, Store),
                                                                 CreateObservationPage3ViewModel(serviceprovider, Store),
                                                                 CreateObservationPage4ViewModel(serviceprovider, Store),
                                                                 CreateObservationPage5ViewModel(serviceprovider, Store),
                                                                 CreateObservationPage6ViewModel(serviceprovider, Store),
                                                                 CreateObservationPage7ViewModel(serviceprovider, Store)


                        );
                });
                services.AddSingleton<ObservationViewModel>(( IServiceProvider serviceprovider) => 
                {
                    var Store = serviceprovider.GetRequiredService<NavigationStore>();
                    return new ObservationViewModel(Store,
                                                    CreateLargeMachineViewModel(serviceprovider, Store),
                                                    CreateSmallMachineViewModel(serviceprovider, Store),
                                                    serviceprovider.GetRequiredService<ObservationMachineViewModel>()
                                                    ); });


            });

            return host;
        }
        private static INavigationService CreateObservationPage1ViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachinePage1ViewModel>());
        }
        private static INavigationService CreateObservationPage2ViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachinePage2ViewModel>());
        }
        private static INavigationService CreateObservationPage3ViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachinePage3ViewModel>());
        }
        private static INavigationService CreateObservationPage4ViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachinePage4ViewModel>());
        }
        private static INavigationService CreateObservationPage5ViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachinePage5ViewModel>());
        }
        private static INavigationService CreateObservationPage6ViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachinePage6ViewModel>());
         
        }
        private static INavigationService CreateObservationPage7ViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachinePage7ViewModel>());
        }
        private static INavigationService CreateLargeMachineViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationDetailMachineViewModel>());
        }

        private static INavigationService CreateSmallMachineViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ObservationMachineViewModel>());
        }

    }
}

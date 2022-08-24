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
using System.Threading.Tasks;
using MayEpCHADesktopApp.Core.ViewModels.ReportViewModels;

namespace MayEpCHADesktopApp.HostBuilder
{
    public static class AddReportViewModelHostBuilderExtensions
    {
        public static IHostBuilder AddReportViewModel(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<ReportObservateViewModel>();
                services.AddSingleton<ReportExportExcelViewModel>();
                services.AddSingleton<ReportShiftViewModel>();
                services.AddSingleton<ReportBillExportWareHouseViewModel>();

                services.AddSingleton<ReportViewModel>((IServiceProvider serviceprovider) =>
                {
                    var Store = serviceprovider.GetRequiredService<NavigationStore>();
                      return new ReportViewModel(Store, CreateShiftViewModel(serviceprovider, Store),
                          CreateEmployeeViewModel(serviceprovider, Store), CreateExcelViewModel(serviceprovider, Store),
                          CreateExportWareHouseViewModel(serviceprovider, Store));
                });



            });

            return host;
        }
        private static INavigationService CreateShiftViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ReportShiftViewModel>());
        }
        private static INavigationService CreateEmployeeViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ReportObservateViewModel>());
        }
        private static INavigationService CreateExcelViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ReportExportExcelViewModel>());
        }
        private static INavigationService CreateExportWareHouseViewModel(IServiceProvider serviceprovider, NavigationStore Store)
        {
            return new NavigationService(Store, serviceprovider.GetRequiredService<ReportBillExportWareHouseViewModel>());
        }
    }
}

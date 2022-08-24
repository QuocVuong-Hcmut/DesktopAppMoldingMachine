using MassTransit;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.HostBuilder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MayEpCHADesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                        .AddServices()
                        .AddViewModels()
                        .AddViews()
                        .AddStores()
                        .AddSettings()
                        .AddAlertViewModel()
                        .AddManageViewModel()   
                        .AddReportViewModel()
                        .AddObservationViewModel()
                        .AddDBContext()
                        .AddGRPCRead();



        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
           

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await _host.Services.GetRequiredService<IBusControl>().StartAsync(source.Token);
            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}

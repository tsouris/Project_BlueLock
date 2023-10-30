using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_BlueLock.Interfaces;
using Project_BlueLock.Models;
using Project_BlueLock.ViewModels;
using System.Windows;

namespace Project_BlueLock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddTransient<IDataModel, DataModel>();
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm!.DataContext = new MainWindowVM(new DataModel { Data = "Placeholder" });
            startupForm!.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }

        public static IHost? AppHost { get; private set; }
    }
}
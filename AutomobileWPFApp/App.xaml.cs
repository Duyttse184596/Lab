using AutomobileLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System;
using System.Windows;

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddSingleton<MainWindow>();

        }

        private void OnStartup(object sender, EventArgs e)
        {
            try
            {
                var window = serviceProvider.GetService<MainWindow>();
                if (window == null)
                {
                    MessageBox.Show("MainWindow is null from DI");
                    return;
                }
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Startup Error");
            }
        }
    }

}

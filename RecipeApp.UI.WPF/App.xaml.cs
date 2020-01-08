using Autofac;
using RecipeApp.UI.WPF.Configurations;
using RecipeApp.UI.WPF.ViewModels;
using RecipeApp.UI.WPF.ViewModels.Main;
using RecipeApp.UI.WPF.Views.Main;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace RecipeApp.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;

        public App()
        {
            var culture = "nl-NL";
            var newCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Configure();

            var window = container.Resolve<MainView>();
            window.Show();
        }

        private void Configure()
        {
            var builder = new ContainerBuilder();
            AutofacConfig.Register(builder);
            container = builder.Build();
        }
    }
}

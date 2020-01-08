using Autofac;
using RecipeApp.Shared.Settings;
using RecipeApp.UI.Interfaces.ViewModels.Dashboard;
using RecipeApp.UI.WPF.Navigation;
using RecipeApp.UI.WPF.Services;
using RecipeApp.UI.WPF.ViewModels;
using RecipeApp.UI.WPF.ViewModels.Dashboard;
using RecipeApp.UI.WPF.ViewModels.Main;
using RecipeApp.UI.WPF.Views.Main;
using System.Windows.Controls;

namespace RecipeApp.UI.WPF.Configurations
{
    public static class AutofacConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            //builder.RegisterType<ExampleService>().As<IExampleService>().SingleInstance();

            builder.RegisterType<ViewModelLocator>().As<IViewModelLocator>().InstancePerDependency();

            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            builder.Register(_ =>  new Shared.Settings.Settings(System.Configuration.ConfigurationManager.AppSettings["ApplicationSettings"])).As<ISettings>().SingleInstance();
            builder.Register(c => new RecipeService(c.Resolve<IHttpClientService>(), c.Resolve<ISettings>()))
                .As<IRecipeService>().SingleInstance();

            builder.RegisterType<MainViewModel>().As<IMainViewModel>().SingleInstance();
            builder.RegisterType<DashboardViewModel>().As<IDashboardViewModel>().SingleInstance();

            builder.RegisterType<HttpClientAccessor>().As<IHttpClientAccessor>().SingleInstance();
            builder.Register(c => new HttpClientService(c.Resolve<IHttpClientAccessor>())).As<IHttpClientService>().SingleInstance();

            builder.RegisterType<MainView>().AsSelf();
            builder.RegisterAssemblyTypes(typeof(MainView).Assembly).Where(t => t.IsSubclassOf(typeof(Page)));
        }
    }
}

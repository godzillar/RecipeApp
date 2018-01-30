using Autofac;
using RecipeApp.UI.Interfaces.ViewModels.Dashboard;
using RecipeApp.UI.Navigation;
using RecipeApp.UI.Services;
using RecipeApp.UI.Settings;
using RecipeApp.UI.ViewModels.Dashboard;
using RecipeApp.UI.ViewModels.Main;

namespace RecipeApp.UI.Configurations
{
    public class AutofacConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            //builder.RegisterType<ExampleService>().As<IExampleService>().SingleInstance();
            
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            builder.RegisterType<Settings.Settings>().As<ISettings>().SingleInstance();
            builder.Register(c => new RecipeService(c.Resolve<IHttpClientService>(), c.Resolve<ISettings>()))
                .As<IRecipeService>().SingleInstance();

            builder.Register(c => new MainViewModel(c.Resolve<INavigationService>(), c.Resolve<ISettings>())).As<IMainViewModel>().SingleInstance();
            builder.Register(c => new DashboardViewModel(c.Resolve<IRecipeService>())).As<IDashboardViewModel>().SingleInstance();

            builder.RegisterType<HttpClientAccessor>().As<IHttpClientAccessor>().SingleInstance();
            builder.Register(c => new HttpClientService(c.Resolve<IHttpClientAccessor>())).As<IHttpClientService>().SingleInstance();

        }
    }
}

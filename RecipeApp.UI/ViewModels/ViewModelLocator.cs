using RecipeApp.UI.Interfaces.ViewModels.Dashboard;
using RecipeApp.UI.ViewModels.Recipe;

namespace RecipeApp.UI.ViewModels
{
    using Autofac;
    using Configurations;
    using Main;

    public class ViewModelLocator
    {
        private readonly IContainer _container;

        /// <summary>
        /// Creates a new instance of the <see cref="ViewModelLocator"/>.
        /// It creates a new autofac container for dependency injection
        /// </summary>
        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();
            AutofacConfig.Register(builder);
            _container = builder.Build();
        }

        /// <summary>
        /// Gets or sets an instance of the <see cref="IMainViewModel"/>
        /// </summary>
        public IMainViewModel MainViewModel => _container.Resolve<IMainViewModel>();


        /// <summary>
        /// Gets or sets an instance of the <see cref="IRecipeViewModel"/>
        /// </summary>
        public IRecipeViewModel RecipeViewModel => _container.Resolve<IRecipeViewModel>();

        /// <summary>
        /// Gets or sets an instance of the <see cref="IDashboardViewModel"/>
        /// </summary>
        public IDashboardViewModel DashboardViewModel => _container.Resolve<IDashboardViewModel>();
    }
}

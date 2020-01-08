using RecipeApp.UI.Interfaces.ViewModels.Dashboard;
using RecipeApp.UI.WPF.ViewModels.Recipe;

namespace RecipeApp.UI.WPF.ViewModels
{
    using Autofac;
    //using Configurations;
    //using Main;

    public class ViewModelLocator: IViewModelLocator
    {
        private readonly IComponentContext componentContext;


        /// <summary>
        /// Creates a new instance of the <see cref="ViewModelLocator"/>.
        /// It creates a new autofac container for dependency injection
        /// </summary>
        public ViewModelLocator(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        ///// <summary>
        ///// Gets or sets an instance of the <see cref="IMainViewModel"/>
        ///// </summary>
        //public IMainViewModel MainViewModel => _container.Resolve<IMainViewModel>();


        ///// <summary>
        ///// Gets or sets an instance of the <see cref="IRecipeViewModel"/>
        ///// </summary>
        //public IRecipeViewModel RecipeViewModel => _container.Resolve<IRecipeViewModel>();

        ///// <summary>
        ///// Gets or sets an instance of the <see cref="IDashboardViewModel"/>
        ///// </summary>
        //public IDashboardViewModel DashboardViewModel => _container.Resolve<IDashboardViewModel>();


        public TViewModel GetViewModel<TViewModel>()
        {
            return componentContext.Resolve<TViewModel>();
        }
    }
}

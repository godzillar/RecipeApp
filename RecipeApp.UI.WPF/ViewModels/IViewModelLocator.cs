namespace RecipeApp.UI.WPF.ViewModels
{
    public interface IViewModelLocator
    {
        TViewModel GetViewModel<TViewModel>();
    }
}

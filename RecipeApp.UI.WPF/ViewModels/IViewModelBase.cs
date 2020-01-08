using System.Windows.Input;

namespace RecipeApp.UI.WPF.ViewModels
{
    public interface IViewModelBase
    {
        ICommand NavigateToPage { get; }

        string CommandParameter { get; set; }
    }
}

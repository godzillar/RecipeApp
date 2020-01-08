using System.Windows.Controls;

namespace RecipeApp.UI.WPF.Navigation
{
    public interface INavigationService
    {
        void Navigate(string pageName);

        void Navigate(INavigationPage page);

        void Navigate(INavigationPage page, object parameter);

        void GoBack();
    }
}

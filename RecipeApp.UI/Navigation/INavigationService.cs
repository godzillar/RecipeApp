using System;

namespace RecipeApp.UI.Navigation
{
    public interface INavigationService
    {
        void Navigate(Uri page);

        void Navigate(INavigationPage page);

        void Navigate(INavigationPage page, object parameter);

        void GoBack();
    }
}

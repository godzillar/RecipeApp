using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeApp.UI.Navigation
{
    public class NavigationService : INavigationService
    {
        private Frame _mainFrame;

        private int CurrentPageIndex { get; set; }

        private List<Uri> NavigationHistory
        {
            get;
            set;
        }

        private Frame NavigationFrame => _mainFrame ?? (_mainFrame =
                                             GetDescendantFromName(Application.Current.MainWindow, "MainContent") as Frame);

        /// <summary>
        /// Naviagtes back to the previous page
        /// </summary>
        public void GoBack()
        {
            if (CurrentPageIndex > 0)
            {
                NavigationFrame.Source = NavigationHistory[CurrentPageIndex--];
                NavigationHistory.RemoveAt(NavigationHistory.Count - 1);
            }
        }

        /// <summary>
        /// Navigate to the given Uri
        /// </summary>
        /// <param name="uri">The uri to navigate to</param>
        public void Navigate(Uri uri)
        {
            SetCurrentPage(uri);
        }

        public void Navigate(INavigationPage page)
        {
            throw new NotImplementedException();
        }
    

        public void Navigate(INavigationPage page, object parameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the current page that will be navigated to and adds current page to the navigation history
        /// </summary>
        /// <param name="page">The current page to set</param>
        private void SetCurrentPage(Uri page)
        {
            if (NavigationFrame == null) return;

            NavigationFrame.Source = page;
            if (NavigationHistory == null)
            {
                NavigationHistory = new List<Uri>();
            }

            NavigationHistory.Add(page);
            CurrentPageIndex++;
        }

        /// <summary>  
        /// Gets the name of the descendant from.  
        /// </summary>  
        /// <param name="parent">The parent.</param>  
        /// <param name="name">The name.</param>  
        /// <returns>The FrameworkElement.</returns>  
        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }

            return null;
        }
    }
}

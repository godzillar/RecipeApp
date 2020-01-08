using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeApp.UI.WPF.Navigation
{
    public class NavigationService : INavigationService
    {
        private Frame _mainFrame;

        private int CurrentPageIndex { get; set; }

        private List<Page> NavigationHistory
        {
            get;
            set;
        }

        private List<Page> createdPages;
        private readonly IComponentContext componentContext;

        private Frame NavigationFrame => _mainFrame ?? (_mainFrame =
                                             GetDescendantFromName(Application.Current.MainWindow, "MainContent") as Frame);

        public NavigationService(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        /// <summary>
        /// Navigates back to the previous page
        /// </summary>
        public void GoBack()
        {
            if (CurrentPageIndex > 0)
            {
                NavigationFrame.Navigate(NavigationHistory[CurrentPageIndex--]);
                NavigationHistory.RemoveAt(NavigationHistory.Count - 1);
            }
        }

        /// <summary>
        /// Navigate to the given page.
        /// </summary>
        /// <param name="pageName">The name of the page to navigate to</param>
        public void Navigate(string pageName)
        {
            if (createdPages == null)
            {
                createdPages = new List<Page>();
            }

            var pageInstance = createdPages.Find(page => page.GetType().FullName == pageName);

            if (pageInstance == null)
            {
                // Initialize a new instance of the page.
                Type pageType = Type.GetType(pageName);
                //pageInstance = componentContext.Resolve(pageType) as Page;
                createdPages.Add(pageInstance);
            }

            SetCurrentPage(pageName);
        }

        public void Navigate(INavigationPage page)
        {
            throw new NotImplementedException();
        }

        public void Navigate(INavigationPage page, object parameter)
        {
            throw new NotImplementedException();
        }

        private void SetCurrentPage(string name)
        {
            var uri = new Uri(name);
            if (NavigationFrame == null) return;

            NavigationFrame.Navigate(uri);
            //if (NavigationHistory == null)
            //{
            //    NavigationHistory = new List<Page>();
            //}

            //NavigationHistory.Add(page);
            CurrentPageIndex++;
        }

        /// <summary>
        /// Sets the current page that will be navigated to and adds current page to the navigation history
        /// </summary>
        /// <param name="page">The current page to set</param>
        private void SetCurrentPage(Page page)
        {
            if (NavigationFrame == null) return;

            NavigationFrame.Navigate(page);
            if (NavigationHistory == null)
            {
                NavigationHistory = new List<Page>();
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

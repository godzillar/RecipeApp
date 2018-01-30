using System;
using System.Windows;

namespace RecipeApp.UI.Views.Main
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            //SetDefaultPage();
        }

        //private void SetDefaultPage()
        //{
        //    this.MainContent.Source = new Uri("/Views/Dashboard/DashboardView.xaml", UriKind.RelativeOrAbsolute);
        //}
    }
}

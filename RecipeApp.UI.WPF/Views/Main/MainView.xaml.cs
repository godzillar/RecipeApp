using RecipeApp.UI.WPF.ViewModels;
using RecipeApp.UI.WPF.ViewModels.Main;
using System;
using System.Windows;

namespace RecipeApp.UI.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(IMainViewModel mainViewModel)
        {
            InitializeComponent();

            DataContext = mainViewModel;
        }
    }
}

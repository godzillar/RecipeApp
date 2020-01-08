using RecipeApp.UI.WPF.ViewModels;
using RecipeApp.UI.WPF.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeApp.UI.WPF.Views.Recipe
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Page
    {
        public RecipeView(IRecipeViewModel recipeViewModel)
        {
            InitializeComponent();
            DataContext = recipeViewModel;
        }
    }
}

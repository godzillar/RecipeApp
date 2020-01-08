using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RecipeApp.UI.Interfaces.ViewModels.Dashboard;
using RecipeApp.UI.WPF.Services;
using RecipeApp.UI.WPF.Commands;
using RecipeApp.UI.WPF.Models;
using RecipeApp.Shared.Models;

namespace RecipeApp.UI.WPF.ViewModels.Dashboard
{
    public class DashboardViewModel: ViewModelBase<IRecipeService>, IDashboardViewModel
    {
        private ICollection<Shared.Models.Recipe> addedRecipes;
        private Shared.Models.Recipe selectedRecipe;

        /// <summary>
        /// Gets a list of added recipes
        /// </summary>
        public ICollection<Shared.Models.Recipe> AddedRecipes
        {
            get
            {
                return addedRecipes;
            }
            set
            {
                addedRecipes = value;
                NotifyPropertyChanged();
            }
        }

        public Shared.Models.Recipe SelectedRecipe
        {
            get
            {
                return selectedRecipe;
            }
            set
            {
                selectedRecipe = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DashboardViewModel"/>
        /// </summary>
        /// <param name="recipeService">An instance of the <see cref="RecipeService"/></param>
        public DashboardViewModel(IRecipeService recipeService): base(recipeService)
        {
        }

        protected sealed override void Initialize(IRecipeService recipe)
        {
            GetAsyncValue(recipe.GetLastAddedRecipesAsync(50), (result) => 
            {
                Console.WriteLine($"Result: {result}");
                AddedRecipes = result; 
            });
        }
    }
}

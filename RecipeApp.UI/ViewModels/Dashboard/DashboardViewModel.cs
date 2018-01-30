using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RecipeApp.UI.Interfaces.ViewModels.Dashboard;
using RecipeApp.UI.Services;
using RecipeApp.UI.Commands;
using RecipeApp.UI.Models;

namespace RecipeApp.UI.ViewModels.Dashboard
{
    public class DashboardViewModel: ViewModelBase, IDashboardViewModel
    {
        private readonly IRecipeService _recipeService;
        
        /// <summary>
        /// Gets a list of added recipes
        /// </summary>
        public ICollection<Shared.Models.Recipe> AddedRecipes { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="DashboardViewModel"/>
        /// </summary>
        /// <param name="recipeService">An instance of the <see cref="RecipeService"/></param>
        public DashboardViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;

            InitializeViewModel();
        }

        /// <summary>
        /// Method ic called to initialize all properties 
        /// </summary>
        public void InitializeViewModel()
        {
            // load all Added Recipes List
            Task.Run(() =>
            {
                InitializeAddedRecipesListAsync();
            });
        }

        /// <summary>
        /// Gets the 50 last added recipes (or as much as possible)
        /// </summary>
        private async void InitializeAddedRecipesListAsync()
        {
            AddedRecipes = await _recipeService.GetLastAddedRecipesAsync(50).ConfigureAwait(true);
        }
    }
}

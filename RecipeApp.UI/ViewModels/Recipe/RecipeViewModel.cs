using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RecipeApp.Service.Interfaces.Dispatchers;
using RecipeApp.Service.Queries.Recipes;

namespace RecipeApp.UI.ViewModels.Recipe
{
    public class RecipeViewModel: ViewModelBase, IRecipeViewModel
    {
        private readonly IQueryDispatcher _queryDispatcher;

        private List<Shared.Models.Recipe> _recipes;

        public RecipeViewModel(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public List<Shared.Models.Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                NotifyPropertyChanged(nameof(Recipes));
            }
        }

        public override void Initialize()
        {
            Task.Run(async () => await GetRecipesAsync().ConfigureAwait(false)).ConfigureAwait(false);
        }

        private async Task GetRecipesAsync()
        {
            var query = new GetRecipesQuery();
            var recipes = await _queryDispatcher.HandleAsync<GetRecipesQuery, IEnumerable<Shared.Models.Recipe>>(query, CancellationToken.None)
                .ConfigureAwait(false);

            Recipes = recipes.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RecipeApp.Repository.Interfaces;
using RecipeApp.Service.Interfaces.Queries;
using RecipeApp.Shared.Models;

namespace RecipeApp.Service.Queries.Recipes
{
    public class GetRecipesQueryHandler : IQueryHandler<GetRecipesQuery, IEnumerable<Recipe>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipesQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<Recipe>> HandleAsync(GetRecipesQuery query, CancellationToken cancellation)
        {
            return await _recipeRepository.GetRecipesAsync().ConfigureAwait(false);
        }
    }
}

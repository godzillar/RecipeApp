using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RecipeApp.Shared.Models;

namespace RecipeApp.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync();

        /// <summary>
        /// Adds a new recipe to the database
        /// </summary>
        /// <param name="recipe">The recipe to add</param>
        /// <param name="cancellationToken">A token to cancel the action</param>
        Task CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    }
}

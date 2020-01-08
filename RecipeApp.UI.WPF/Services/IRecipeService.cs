using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeApp.Shared.Models;

namespace RecipeApp.UI.WPF.Services
{
    /// <summary>
    /// The interface for <see cref="RecipeService"/>
    /// </summary>
    public interface IRecipeService
    {
        /// <summary>
        /// Gets a number of last added recipes. It will be sorted based on last added.
        /// </summary>
        /// <param name="count">The number of recipes to get</param>
        /// <returns>A list of <see cref="Recipe"/>s</returns>
        Task<ICollection<Recipe>> GetLastAddedRecipesAsync(int count);

        /// <summary>
        /// Gets a list of 50 best rated recipes of last 365 days or longer period
        /// if count has not been reached yet. If less then count recipes exist 
        /// all available recipes are returned.
        /// </summary>
        /// <param name="count">The number of recipes to return</param>
        /// <returns>A list of <see cref="Recipe"/>s.</returns>
        Task<ICollection<Recipe>> GetLatestTopRatedRecipesAsync(int count);

        /// <summary>
        /// Gets a list of 50 worst rated recipes of last 365 days or longer period
        /// if count has not been reached yet. If less then count recipes exist 
        /// all available recipes are returned.
        /// </summary>
        /// <param name="count">The number of recipes to return</param>
        /// <returns>A list of <see cref="Recipe"/>s</returns>
        Task<ICollection<Recipe>> GetLatestWorstRatedRecipesAsync(int count);

        /// <summary>
        /// Gets the list of top rated recipes of all times
        /// </summary>
        /// <param name="count">The number of recipes to return</param>
        /// <returns>A list of <see cref="Recipe"/>s.</returns>
        Task<ICollection<Recipe>> GetTopRatedRecipesAsync(int count);
    }
}

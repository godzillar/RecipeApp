using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Repository.Database;
using RecipeApp.Repository.Interfaces;
using RecipeApp.Repository.Models;
using RecipeApp.Shared.Models;

namespace RecipeApp.Repository.Respositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IRecipeListDbContext _dbContext;
        private readonly IMapper _mapper;

        public RecipeRepository(IRecipeListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all recipies
        /// </summary>
        /// <returns>A list of <see cref="Recipe"/>.</returns>
        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            var recipeEntities = await _dbContext.Recipies.ToListAsync().ConfigureAwait(false);

            return _mapper.Map<IEnumerable<Recipe>>(recipeEntities);
        }

        /// <summary>
        /// Adds a new recipe to the database
        /// </summary>
        /// <param name="recipe">The recipe to add</param>
        /// <param name="cancellationToken">A token to cancel the action</param>
        public async Task CreateRecipeAsync(Recipe recipe, CancellationToken cancellationToken)
        {
            var recipeEntity = _mapper.Map<RecipeEntity>(recipe);
            _dbContext.Recipies.Add(recipeEntity);
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}

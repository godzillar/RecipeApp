using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Repository.Models;

namespace RecipeApp.Repository.Database
{
    public interface IRecipeListDbContext
    {
        DbSet<RecipeEntity> Recipies { get; set; }

        DbSet<IngredientTypeEntity> IngredientTypes { get; set; }

        DbSet<IngredientEntity> Ingredients { get; set; }

        DbSet<RecipeImageEntity> RecipeImages { get; set; }

        /// <summary>
        /// Saves the changes made to the database
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}

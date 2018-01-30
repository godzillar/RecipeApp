using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Repository.Models;

namespace RecipeApp.Repository.Database
{
    public class RecipeListDbContext: DbContext, IRecipeListDbContext
    {
        public RecipeListDbContext(DbContextOptions<RecipeListDbContext> options): base(options) { }

        public virtual DbSet<RecipeEntity> Recipies { get; set; }

        public virtual DbSet<IngredientTypeEntity> IngredientTypes { get; set; }

        public virtual DbSet<IngredientEntity> Ingredients { get; set; }

        public virtual DbSet<RecipeImageEntity> RecipeImages { get; set; }
    }
}

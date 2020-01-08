using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>().HasData(new RecipeEntity()
            {
                Id = Guid.NewGuid(),
                Description = "A description about a nice recipe",
                Rating = 5
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

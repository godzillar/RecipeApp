using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RecipeApp.Backend.Models;
using RecipeApp.Shared.Models;

namespace RecipeApp.Backend.Configurations
{
    public class ApiMapperProfile: Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<Ingredient, IngredientViewModel>();

            CreateMap<CreateRecipeModel, Recipe>();
        }
    }
}

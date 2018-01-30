using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RecipeApp.Repository.Models;
using RecipeApp.Shared.Models;

namespace RecipeApp.Repository.Configurations
{
    public class RepositoryMapperProfile: Profile
    {
        public RepositoryMapperProfile()
        {
            CreateMap<RecipeEntity, Recipe>();

            CreateMap<Recipe, RecipeEntity>();
        }
    }
}

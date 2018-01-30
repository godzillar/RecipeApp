using System;
using System.Collections.Generic;
using System.Text;
using RecipeApp.Service.Interfaces.Commands;
using RecipeApp.Shared.Models;
using RecipeApp.Service.Interfaces;

namespace RecipeApp.Service.Commands.Recipes
{
    public class AddRecipeCommand: ICommand
    {
        public Recipe Recipe { get; set; }
    }
}

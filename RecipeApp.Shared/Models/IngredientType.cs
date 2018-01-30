using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Shared.Models
{
    public class IngredientType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

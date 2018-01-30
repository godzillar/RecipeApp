using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Shared.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }

        public virtual Recipe Recipe { get; set; }

        public IngredientType IngredientType { get; set; }

        public int Quantity { get; set; }

        public string QuantityUnit { get; set; }
    }
}

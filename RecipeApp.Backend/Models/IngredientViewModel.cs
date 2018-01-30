using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApp.Shared.Models;

namespace RecipeApp.Backend.Models
{
    public class IngredientViewModel
    {
        public Guid Id { get; set; }

        public IngredientType IngredientType { get; set; }

        public int Quantity { get; set; }

        public string QuantityUnit { get; set; }
    }
}

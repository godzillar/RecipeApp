using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Shared.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }

        public string Remarks { get; set; }

        public int Rating { get; set; }

        public string Source { get; set; }

        public virtual List<RecipeImage> Images { get; set; }
    }
}

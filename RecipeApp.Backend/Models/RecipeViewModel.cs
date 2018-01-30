using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Backend.Models
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; }

        public string Remarks { get; set; }

        public int Rating { get; set; }

        public string Source { get; set; }
    }
}

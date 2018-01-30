using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Repository.Models
{
    public class IngredientTypeEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

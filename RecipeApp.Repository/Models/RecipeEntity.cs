using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeApp.Repository.Models
{
    public class RecipeEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<IngredientEntity> Ingredients { get; set; }

        public string Remarks { get; set; }

        [Range(0,10)]
        public int Rating { get; set; }

        public string Source { get; set; }

        public virtual List<RecipeImageEntity> Images { get; set; }
    }
}

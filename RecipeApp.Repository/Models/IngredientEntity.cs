using System;
using System.ComponentModel.DataAnnotations;


namespace RecipeApp.Repository.Models
{
    public class IngredientEntity
    {
        [Key]
        public Guid Id { get; set; }

        public virtual RecipeEntity Recipe { get; set; }

        public IngredientTypeEntity IngredientType { get; set; }

        public int Quantity { get; set; }

        public string QuantityUnit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeApp.Repository.Models
{
    public class RecipeImageEntity
    {
        [Key]
        public Guid Id { get; set; }

        public RecipeEntity Recipe { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}

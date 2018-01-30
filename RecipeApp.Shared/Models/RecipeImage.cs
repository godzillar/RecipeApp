using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeApp.Shared.Models
{
    public class RecipeImage
    {
        public Guid Id { get; set; }

        public Recipe Recipe { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}

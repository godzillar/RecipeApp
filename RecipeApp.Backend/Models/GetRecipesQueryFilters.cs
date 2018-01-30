using Microsoft.AspNetCore.Mvc;
using System;
using RecipeApp.Backend.Enumerations;

namespace RecipeApp.Backend.Models
{
    /// <summary>
    /// The filters that can be applied to the GetRecipes query
    /// </summary>
    public class GetRecipesQueryFilters
    {
        /// <summary>
        /// Gets or sets the From datetime, start date from which to get recipes
        /// </summary>
        [FromQuery(Name = "From")]
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the To datetime, end date to which to get recipes
        /// </summary>
        [FromQuery(Name="To")]
        public DateTime? To { get; set; }

        /// <summary>
        /// The (max) amount of recipes to get
        /// </summary>
        [FromQuery(Name = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// The sort method of the returned list of recipes, e.g. Date, alphabetical, highest rating
        /// </summary>
        [FromQuery(Name = "Sort")]
        public SortMethod Sort { get; set; } = SortMethod.Alphabetical;

        /// <summary>
        /// Gets or sets the sort order, 1 is high to low, 0 is default or indeterminate and -1 is low to high
        /// </summary>
        [FromQuery(Name = "SortOrder")]
        public int Order { get; set; }
    }
}

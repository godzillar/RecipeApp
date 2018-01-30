using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.UI.Interfaces.ViewModels.Dashboard

{
    public interface IDashboardViewModel
    {
        /// <summary>
        /// Gets or sets the added recipes
        /// </summary>
        ICollection<Shared.Models.Recipe> AddedRecipes { get; set; }
    }
}

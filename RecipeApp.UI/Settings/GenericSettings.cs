using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.UI.Models;

namespace RecipeApp.UI.Settings
{
    public class GenericSettings
    {
        public string StartupPage { get; set; }

        public IList<MenuItem> MenuItems { get; set; }
    }
}

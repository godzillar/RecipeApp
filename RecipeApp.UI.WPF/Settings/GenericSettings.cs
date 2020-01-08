using System.Collections.Generic;
using RecipeApp.Shared.Settings;
using RecipeApp.UI.WPF.Models;

namespace RecipeApp.UI.WPF.Settings
{
    public class GenericSettings : SettingsObject
    {
        public string StartupPage { get; set; }

        public IList<MenuItem> MenuItems { get; set; }
    }
}

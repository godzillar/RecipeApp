using RecipeApp.Shared.Settings;

namespace RecipeApp.UI.WPF.Settings
{
    public class ApiSettings: SettingsObject
    {
        public string ServerUrl { get; set; }

        public string RecipeEndpoint { get; set; }
    }
}

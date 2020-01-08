using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.UI.WPF.Navigation
{
    public interface INavigationPage
    {
        string Name { get; set; }

        Type PageType { get; set; }
    }
}

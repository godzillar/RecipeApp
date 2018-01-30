using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeApp.UI.ViewModels
{
    public interface IViewModelBase
    {
        ICommand NavigateToPage { get; }

        string CommandParameter { get; set; }
    }
}

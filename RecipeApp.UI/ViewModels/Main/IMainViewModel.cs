using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RecipeApp.UI.ViewModels.Main
{
    public interface IMainViewModel: IViewModelBase
    {
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the state of the menu
        /// </summary>
        bool MenuOpened { get; set; }

        /// <summary>
        /// Gets or sets the selected menu item
        /// </summary>
        string SelectedMenuItem { get; set; }

        /// <summary>
        /// Gets the open menu command, toggling the menuopened property
        /// </summary>
        ICommand OpenMenuCommand { get; }
    }
}

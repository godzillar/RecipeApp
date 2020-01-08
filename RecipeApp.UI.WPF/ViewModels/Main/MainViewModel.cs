using System;
using System.Windows.Input;
using RecipeApp.Shared.Settings;
using RecipeApp.UI.WPF.Commands;
using RecipeApp.UI.WPF.Navigation;
using RecipeApp.UI.WPF.Settings;
using System.Reflection;
using System.Windows.Controls;

namespace RecipeApp.UI.WPF.ViewModels.Main
{
    public class MainViewModel: ViewModelBase, IMainViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly GenericSettings _settings;
        private bool _menuOpened;

        private ICommand _openMenuCommand;
        private string _selectedMenuItem;

        /// <summary>
        /// The username of the user logged in
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the menu state
        /// </summary>
        public bool MenuOpened
        {
            get => _menuOpened;
            set
            {
                _menuOpened = value;
                NotifyPropertyChanged();
            }
        }

        public string SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the open menu command
        /// </summary>
        public ICommand OpenMenuCommand
        {
            get
            {
                return _openMenuCommand ?? (_openMenuCommand =
                           new RelayCommand<object>(OpenMenuCommandAction, () => true));
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MainViewModel"/>
        /// </summary>
        /// <param name="navigationService">An instance of the <see cref="NavigationService"/>.</param>
        /// <param name="settings">An instance of the <see cref="Settings"/>.</param>
        public MainViewModel(INavigationService navigationService, ISettings settings)
        {
            _navigationService = navigationService;
            _settings = settings.GetSection<GenericSettings>("GenericSettings");
        }

        /// <summary>
        /// Method navigates to a page
        /// </summary>
        /// <param name="menuIndex">The index of menu item</param>
        public override void NavigationAction(object menuIndex)
        {
            // search the menu item selected
            var test = Convert.ToInt32(menuIndex);
            var menuItem = _settings.MenuItems[test];

            SelectedMenuItem = menuItem.Name;

            
            _navigationService.Navigate(menuItem.Page);
        }

        /// <summary>
        /// Sets the open menu property
        /// </summary>
        /// <param name="param"></param>
        private void OpenMenuCommandAction(object param)
        {
            MenuOpened = !MenuOpened;
        }
    }
}

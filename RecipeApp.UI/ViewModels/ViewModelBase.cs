using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RecipeApp.UI.Commands;

namespace RecipeApp.UI.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand NavigateToPage => new RelayCommand<object>(NavigationAction, CanExecuteAction);

        public string CommandParameter { get; set; }

        public virtual void NavigationAction(object param)
        {
        }

        public virtual  bool CanExecuteAction()
        {
            return true;
        }

        public virtual void Initialize() { }

        public virtual void OnLoaded() { }

        public virtual void OnUnloaded() { }
    }
}

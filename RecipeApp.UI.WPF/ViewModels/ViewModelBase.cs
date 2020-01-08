using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using RecipeApp.UI.WPF.Commands;

namespace RecipeApp.UI.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ViewModelBase()
        {
            Initialize();
            OnLoaded();
        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected static void GetAsyncValue<T>(Task<T> task, Action<T> result)
        {
            task.ContinueWith((t) => result(t.Result));
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

        protected virtual void Initialize() { }

        protected virtual void OnLoaded() { }

        protected virtual void OnUnloaded() { }
    }

    public abstract class ViewModelBase<T> : ViewModelBase
    {
        protected ViewModelBase(T injectedService) {
            Initialize(injectedService);
        }

        protected virtual void Initialize(T injectedService) { }
    }
}

using System;
using System.Windows.Input;

namespace RecipeApp.UI.WPF.Commands
{
    /// <summary>
    /// Used to execute a command
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Func<bool> _canExecuteEvaluator;

        /// <inheritdoc />
        /// <summary>
        /// Creates a new instance of the <see cref="RelayCommand{T}"/>
        /// </summary>
        /// <param name="action">The action to execute in the command</param>
        public RelayCommand(Action<T> action) : this(action, null) { }

        /// <summary>
        /// Creates a new instance of the <see cref="RelayCommand{T}"/>
        /// </summary>
        /// <param name="action">The action to execute in the command</param>
        /// <param name="canExecuteEvaluator">Indicator if the command can be executed</param>
        public RelayCommand(Action<T> action, Func<bool> canExecuteEvaluator)
        {
            _action = action;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        /// <inheritdoc />
        /// <summary>
        /// Checks if the command can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecuteEvaluator == null || _canExecuteEvaluator();
        }

        /// <inheritdoc />
        /// <summary>
        /// Method executes the command action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action((T)parameter);
        }

        /// <inheritdoc />
        /// <summary>
        /// EVent handler signalling the can execute flag has changed state
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}

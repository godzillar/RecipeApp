using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RecipeApp.Service.Interfaces.Commands;

namespace RecipeApp.Service.Interfaces.Dispatchers
{
    /// <summary>
    /// Interface for a class that helps to find the correct command handler for a certain command.
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Method tries to resolve the command handler type and calls its HandleAsync method
        /// to execute the command.
        /// </summary>
        /// <typeparam name="TCommand">The command to execute</typeparam>
        /// <param name="command">The command instance</param>
        Task HandleAsync<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeApp.Service.Interfaces.Commands
{
    /// <summary>
    /// Generic interface used for implementing a command handler.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command this handler will handle.</typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <param name="cancellationToken">A token to cancel the command</param>
        Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}

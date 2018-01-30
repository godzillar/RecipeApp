using System;
using System.Threading;
using System.Threading.Tasks;
using RecipeApp.Service.Interfaces.Commands;
using RecipeApp.Service.Interfaces.Dispatchers;

namespace RecipeApp.Service.Dispatchers
{
    /// <inheritdoc />
    /// <summary>
    /// Class that helps to find the correct command handler for a certain command.
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates a new instance of the <see cref="CommandDispatcher"/>.
        /// </summary>
        /// <param name="serviceProvider">An instance of the <see cref="IServiceProvider"/></param>
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Method tries to resolve the command handler type and calls its HandleAsync method
        /// to execute the command.
        /// </summary>
        /// <typeparam name="TCommand">The command to execute.</typeparam>
        /// <param name="command">The command instance.</param>
        /// <param name="cancellation">A token to cancel the command</param>
        public async Task HandleAsync<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            dynamic handler = _serviceProvider.GetService(handlerType);

            await handler.HandleAsync((dynamic)command, cancellation);
        }
    }
}

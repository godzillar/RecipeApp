using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RecipeApp.Repository.Interfaces;
using RecipeApp.Service.Interfaces.Commands;

namespace RecipeApp.Service.Commands.Recipes
{
    public class AddRecipeCommandHandler : ICommandHandler<AddRecipeCommand>
    {
        private readonly IRecipeRepository _recipeRepository;

        public AddRecipeCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task HandleAsync(AddRecipeCommand command, CancellationToken cancellationToken)
        {
            if (command.Recipe == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await _recipeRepository.CreateRecipeAsync(command.Recipe, cancellationToken).ConfigureAwait(false);
        }
    }
}

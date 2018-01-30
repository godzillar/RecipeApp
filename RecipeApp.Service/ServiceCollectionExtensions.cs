using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RecipeApp.Service.Commands.Recipes;
using RecipeApp.Service.Interfaces.Commands;
using RecipeApp.Service.Interfaces.Queries;
using RecipeApp.Service.Queries.Recipes;
using RecipeApp.Shared.Models;

namespace RecipeApp.Service
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extention method adds all query handlers to the service collection
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns>The appended service collection</returns>
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetRecipesQuery, IEnumerable<Recipe>>, GetRecipesQueryHandler>();
            return services;
        }

        /// <summary>
        /// Extention method adds all command handlers to the service collection
        /// </summary>
        /// <param name="services">The service colletion</param>
        /// <returns>The appended service collection</returns>
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<AddRecipeCommand>, AddRecipeCommandHandler>();
            return services;
        }
    }
}

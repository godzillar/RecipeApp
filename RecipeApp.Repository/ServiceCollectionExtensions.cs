using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeApp.Repository.Database;

namespace RecipeApp.Repository
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds repository entity framework core DB context and uses sqlite connection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="connectionString">The sqlite connection string e.g. Data Source=Database\\RecipeListDb.db</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection UseSqLiteConnection(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<RecipeListDbContext>(options => options.UseSqlite(connectionString));
        }

        /// <summary>
        /// Adds repository entity framework core DB context and uses sql server connection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="connectionString">The sqlite connection string e.g. Data Source=.\\SqlExpress;database=RecipeListDb;Integrated Security=True</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection UseSqlServerConnection(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<RecipeListDbContext>(options => options.UseSqlServer(connectionString));
        }

    }
}

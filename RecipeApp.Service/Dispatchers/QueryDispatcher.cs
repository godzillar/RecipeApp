using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using RecipeApp.Service.Interfaces.Dispatchers;
using RecipeApp.Service.Interfaces.Queries;
using RecipeApp.Service.Queries;

namespace RecipeApp.Service.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates a new instance of the <see cref="QueryDispatcher"/>
        /// </summary>
        /// <param name="serviceProvider">An instance of the <see cref="IServiceProvider"/></param>
        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Method tries to resolve the query handler type and calls its HandleAsync method
        /// to execute the query
        /// </summary>
        /// <typeparam name="TQuery">The query to execute</typeparam>
        /// <typeparam name="TResult">The result type of this query</typeparam>
        /// <param name="query">The query instance</param>
        /// <param name="cancellation">The cancellation token to signal cancellation of this task</param>
        /// <returns>The query result</returns>
        public async Task<TResult> HandleAsync<TQuery, TResult>(TQuery query, CancellationToken cancellation)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull - Doesn't make sence to change this check so ignore warning
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _serviceProvider.GetService(handlerType);

            return await handler.HandleAsync((dynamic)query, cancellation);
        }
    }
}

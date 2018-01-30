using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeApp.Service.Interfaces.Queries
{
    /// <summary>
    /// A generic interface definition for classes that need to get data from the data store,
    /// possibly using parameters to filter the data with. A query object of type <see cref="TQuery"/> and optionally containing filters,
    /// is used as an input parameter. A task is returned containing the results of the query as type TResult.
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        /// <summary>
        /// Executes the query by getting data from the data store and returning results.
        /// </summary>
        /// <param name="query">An instance of a query class with might have filter properties set</param>
        /// <param name="cancellation">The cancellation token used to cancel the async task</param>
        /// <returns>A task containing the query results.</returns>
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellation);
    }
}

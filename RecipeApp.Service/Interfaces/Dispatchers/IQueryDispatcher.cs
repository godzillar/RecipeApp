using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeApp.Service.Interfaces.Dispatchers
{
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Method tries to resolve the query handler type and calls its HandleAsync method
        /// to execute the query
        /// </summary>
        /// <typeparam name="TQuery">The query to execute</typeparam>
        /// <typeparam name="TResult">The result type of this query</typeparam>
        /// <param name="query">The query instance</param>
        /// <param name="cancellation">The cancellation token to signal cancellation of this task</param>
        /// <returns>The query result</returns>
        Task<TResult> HandleAsync<TQuery, TResult>(TQuery query, CancellationToken cancellation);
    }
}

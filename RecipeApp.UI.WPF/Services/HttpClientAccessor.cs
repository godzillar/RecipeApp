using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.UI.WPF.Services
{
    /// <summary>
    /// Accessor for an instance of the <see cref="HttpClient"/>
    /// </summary>
    public class HttpClientAccessor : IHttpClientAccessor
    {
        private HttpClient _client;

        /// <summary>
        /// Gets an instance of the <see cref="HttpClient"/>
        /// </summary>
        public HttpClient HttpClient => CreateHttpClient();

        /// <summary>
        /// Creates a new instance of <see cref="HttpClient"/> if needed else returns
        /// current instance.
        /// </summary>
        /// <returns>An instance of the <see cref="HttpClient"/>.</returns>
        private HttpClient CreateHttpClient()
        {
            return _client ?? (_client = new HttpClient());
        }
    }
}

using System.Net.Http;

namespace RecipeApp.UI.Services
{
    /// <summary>
    /// Interface for <see cref="HttpClientAccessor"/>
    /// </summary>
    public interface IHttpClientAccessor
    {
        /// <summary>
        /// Gets an insnatce of <see cref="HttpClient"/>
        /// </summary>
        HttpClient HttpClient { get; }
    }
}

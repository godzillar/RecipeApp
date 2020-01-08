using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RecipeApp.Shared.Models;
using RecipeApp.Shared.Settings;
using RecipeApp.UI.WPF.Models;
using RecipeApp.UI.WPF.Settings;

namespace RecipeApp.UI.WPF.Services
{
    public class RecipeService: IRecipeService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiSettings _settings;

        /// <summary>
        /// Creates a new instance of the <see cref="RecipeService"/>
        /// </summary>
        /// <param name="httpClientService"></param>
        /// <param name="settings"></param>
        public RecipeService(IHttpClientService httpClientService, ISettings settings)
        {
            _httpClientService = httpClientService;
            _settings = settings.GetSection<ApiSettings>("RestApi");
        }


        /// <inheritdoc />
        public async Task<ICollection<Recipe>> GetLastAddedRecipesAsync(int count)
        {
            var queryStrings = new List<QueryString>
            {
                new QueryString {QueryParameter = "Count", Value = count.ToString()},
                new QueryString {QueryParameter = "From", Value = DateTime.UtcNow.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss")},
                new QueryString {QueryParameter = "To", Value = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")},
                new QueryString {QueryParameter = "Sort", Value = "Date"},
                new QueryString {QueryParameter = "SortOrder", Value = "1"}
            };

            var request = new Request
            {
                RequestUrl = _settings.ServerUrl,
                Endpoint = _settings.RecipeEndpoint,
                QueryStrings = queryStrings
            };

            return await GetRecipesAsync(request).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<ICollection<Recipe>> GetLatestTopRatedRecipesAsync(int count)
        {
            var queryStrings = new List<QueryString>
            {
                new QueryString {QueryParameter = "Count", Value = count.ToString()},
                new QueryString {QueryParameter = "From", Value = DateTime.UtcNow.AddYears(-1).ToString("yyyy-MM-dd HH:mm:ss")},
                new QueryString {QueryParameter = "To", Value = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")},
                new QueryString {QueryParameter = "Sort", Value = "Rating"},
                new QueryString {QueryParameter = "SortOrder", Value = "1"}
            };

            var request = new Request
            {
                RequestUrl = _settings.ServerUrl,
                Endpoint = _settings.RecipeEndpoint,
                QueryStrings = queryStrings
            };

            return await GetRecipesAsync(request);
        }

        /// <inheritdoc />
        public async Task<ICollection<Recipe>> GetLatestWorstRatedRecipesAsync(int count)
        {
            var queryStrings = new List<QueryString>
            {
                new QueryString {QueryParameter = "Count", Value = count.ToString()},
                new QueryString {QueryParameter = "From", Value = DateTime.UtcNow.AddYears(-1).ToString("yyyy-MM-dd HH:mm:ss")},
                new QueryString {QueryParameter = "To", Value = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")},
                new QueryString {QueryParameter = "Sort", Value = "Rating"},
                new QueryString {QueryParameter = "SortOrder", Value = "-1"}
            };

            var request = new Request
            {
                RequestUrl = _settings.ServerUrl,
                Endpoint = _settings.RecipeEndpoint,
                QueryStrings = queryStrings
            };

            return await GetRecipesAsync(request);
        }

        /// <inheritdoc />
        public async Task<ICollection<Recipe>> GetTopRatedRecipesAsync(int count)
        {
            var queryStrings = new List<QueryString>
            {
                new QueryString {QueryParameter = "Count", Value = count.ToString()},
                new QueryString {QueryParameter = "Sort", Value = "Rating"},
                new QueryString {QueryParameter = "SortOrder", Value = "1"}
            };

            var request = new Request
            {
                RequestUrl = _settings.ServerUrl,
                Endpoint = _settings.RecipeEndpoint,
                QueryStrings = queryStrings
            };

            return await GetRecipesAsync(request);
        }

        /// <summary>
        /// Gets a list of recipes based on a specific request with query strings
        /// </summary>
        /// <param name="request">The request with query strings</param>
        /// <returns>A list of <see cref="Recipe"/>s or null if failure occurs.</returns>
        private async Task<ICollection<Recipe>> GetRecipesAsync(Request request)
        {
            try
            {
                var result = await _httpClientService.GetAsync<ICollection<Recipe>>(request).ConfigureAwait(false);
                return result;
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine(hre.Message);
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RecipeApp.UI.Models;

namespace RecipeApp.UI.Services
{
    /// <summary>
    /// Functionality exposed to handle http requests
    /// </summary>
    public class HttpClientService: IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(IHttpClientAccessor httpClientAccessor)
        {
            _httpClient = httpClientAccessor.HttpClient;
        }

        public Task Delete(Request request)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync<T>(Request request)
        {
            request.Method = HttpMethod.Get;
            return await SendAsync<T>(request);
        }

        public async Task Post(Request request)
        {
            await SendAsync<object>(request);
        }

        public Task Put(Request request)
        {
            throw new NotImplementedException();
        }

        private async Task<T> SendAsync<T>(Request request)
        {
            var returnValue = default(T);

            //var authorizationHeader = GetAuthenticationHeaders();
            var queryStrings = "";
            if (request.QueryStrings.Any())
            {
                queryStrings = request.QueryStrings.Aggregate("?", (current, queryString) => current + $"{queryString.QueryParameter}={queryString.Value}&");
            }

            var requestUri = new Uri($"{request.RequestUrl}{request.Endpoint}{queryStrings.TrimEnd('&')}");

            var httpRequest = new HttpRequestMessage {Method = request.Method, RequestUri = requestUri};

            if (request.Body != null)
            {
                httpRequest.Content = new StringContent(request.Body);
            } 

            var result = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

            if (!result.IsSuccessStatusCode)
            {
                var errorMessage = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new HttpRequestException($"The request to {request.RequestUrl}{request.Endpoint} returned {result.StatusCode} and message {errorMessage}");
            }

            if (request.Method == HttpMethod.Get )
            {
                var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                returnValue = JsonConvert.DeserializeObject<T>(content);
            }

            return returnValue;
        }

        //private (string AuthorizationHeader, string value) GetAuthenticationHeaders()
        //{
        //    return new (string AuthorizationHeader, string value) { "Authorization", "Bearer token")};
            
        //}
    }
}

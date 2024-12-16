using System.Text;
using ErcasPay.Base.Response;
using ErcasPay.Exceptions;
using ErcasPay.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ErcasPay.Infrastructure.Http
{
    /// <summary>
    /// HTTP Client for interacting with ErcasPay API
    /// </summary>
    public class ApiClient : IApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiClient(IConfiguration configuration,
                        IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        /// <inheritdoc/>
        public async Task<T> Send<T>(HttpMethod method, string endpoint, object? body = null) where T : IResponse
        {   
            HttpClient client = _httpClientFactory.CreateClient();
            HttpRequestMessage request = await BuildRequest(method, endpoint, body);            

            // Send http request
            HttpResponseMessage response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize json response into specified model
            T result = JsonConvert.DeserializeObject<T>(responseBody);
            result.HttpCode = (long)response.StatusCode;

            return result;
        }

        /// <summary>
        /// Builds HTTP request header and body
        /// </summary>
        /// <param name="method">HTTP method</param>
        /// <param name="endpoint">URI to be visited</param>
        /// <param name="body">HTTP request body</param>
        /// <returns>HTTP request</returns>
        /// <exception cref="ConfigurationException">Occurs if Base URL or Authorization key is missing from appsettings</exception>
        private async Task<HttpRequestMessage> BuildRequest(HttpMethod method, string endpoint, object? body)
        {
            // Load ercaspay base url from appsettings
            string baseUrl = _configuration.GetSection("ErcasPay:BaseUrl").Value.EndsWith("/") ?
                $"{_configuration.GetSection("ErcasPay:BaseUrl").Value}{endpoint}" :
                $"{_configuration.GetSection("ErcasPay:BaseUrl").Value}/{endpoint}";

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ConfigurationException("Base URL not found in configuration");
            }

            // Load authorization token from appsettings
            string authorizationKey = _configuration.GetSection("ErcasPay:Authorization").Value;
            if (string.IsNullOrEmpty(authorizationKey))
            {
                throw new ConfigurationException("Authorization key not found in configuration");
            }

            // Build HTTP request header and body
            HttpRequestMessage request = new HttpRequestMessage(method, new Uri(baseUrl));
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {authorizationKey}");

            if (body != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(body),
                    Encoding.UTF8, 
                    "application/json"
                );
            }

            return request;
        }
    }
}
using ErcasPay.Base.Response;

namespace ErcasPay.Infrastructure.Http
{
    /// <summary>
    /// HTTP Client interface for interacting with ErcasPay API
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Makes HTTP requests
        /// </summary>
        /// <typeparam name="T">HTTP response body format</typeparam>
        /// <param name="method">HTTP request method</param>
        /// <param name="endpoint">URI to be visited</param>
        /// <param name="body">HTTP request body</param>
        /// <returns>HTTP response body</returns>
        Task<T> Send<T>(HttpMethod method, string endpoint, object? body = null) where T : IResponse;
    }
}
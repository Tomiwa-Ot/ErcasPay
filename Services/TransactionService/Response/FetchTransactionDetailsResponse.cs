using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.TransactionService.Response
{
    /// <summary>
    /// Fetch transaction details API response
    /// </summary>
    public class FetchTransactionDetailsResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<FetchTransactionDetailsResponseBody>))]
        public FetchTransactionDetailsResponseBody ResponseBody { get; set; }
        
        /// <inheritdoc/>
        public long HttpCode { get; set; }

        /// <inheritdoc/>
        public bool RequestSuccessful { get; set; }

        /// <inheritdoc/>
        public string? ResponseMessage { get; set; }

        /// <inheritdoc/>
        public string ResponseCode { get; set; }

        /// <inheritdoc/>
        public string? ErrorMessage { get; set; }
    }

    /// <summary>
    /// Fetch transaction details API response body
    /// </summary>
    public class FetchTransactionDetailsResponseBody
    {
        /// <summary>
        /// Customer's name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer's email
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Business name
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// Business logo
        /// </summary>
        public string BusinessLogo { get; set; }
        
        /// <inheritdoc/>
        public WhiteLabel WhiteLabel { get; set; }

        /// <summary>
        /// Payment methods
        /// </summary>
        public IEnumerable<string> PaymentMethods { get; set; }
    }
}
using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.TransactionService.Response
{
    /// <summary>
    /// Initiate transaction API response
    /// </summary>
    public class InitiateTransactionResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<InitiateTransactionResponseBody>))]
        public InitiateTransactionResponseBody ResponseBody { get; set; }

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
    /// Initiate transaction API response body
    /// </summary>
    public class InitiateTransactionResponseBody
    {
        /// <summary>
        /// Merchant payment reference
        /// </summary>
        public string PaymentReference { get; set; }

        /// <summary>
        /// ErcasPay transaction reference
        /// </summary>
        public string TransactionReference { get; set; }

        /// <summary>
        /// Checkout url
        /// </summary>
        public string CheckoutUrl { get; set; }

        /// <summary>
        /// Whitelabel
        /// </summary>
        public WhiteLabel WhiteLabel { get; set; }
    }
}
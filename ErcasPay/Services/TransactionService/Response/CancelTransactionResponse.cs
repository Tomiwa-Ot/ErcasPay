using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.TransactionService.Response
{
    /// <summary>
    /// Cancel transaction API response
    /// </summary>
    public class CancelTransactionResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<CancelTransactionResponseBody>))]
        public CancelTransactionResponseBody ResponseBody { get; set; }
        
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
    /// Cancel transaction API response body
    /// </summary>
    public class CancelTransactionResponseBody
    {
        /// <summary>
        /// Callback url
        /// </summary>
        public string Callback_Url { get; set; }
    }
}
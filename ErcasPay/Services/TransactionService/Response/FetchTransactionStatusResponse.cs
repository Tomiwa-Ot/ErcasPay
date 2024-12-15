using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.TransactionService.Response
{
    /// <summary>
    /// Fetch transaction status API response
    /// </summary>
    public class FetchTransactionStatusResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<FetchTransactionStatusResponseBody>))]
        public FetchTransactionStatusResponseBody ResponseBody { get; set; }

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
    /// Fetch transaction status API response body
    /// </summary>
    public class FetchTransactionStatusResponseBody
    {
        /// <summary>
        /// Payment reference
        /// </summary>
        public string PaymentReference { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Callback url
        /// </summary>
        public string CallbackUrl { get; set; }
    }
}
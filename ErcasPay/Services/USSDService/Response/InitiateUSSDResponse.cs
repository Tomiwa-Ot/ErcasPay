using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.USSDService.Response
{
    /// <summary>
    /// Initiate USSD API response
    /// </summary>
    public class InitiateUSSDResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<USSDInitiateResponseBody>))]
        public USSDInitiateResponseBody? ResponseBody { get; set; }

        /// <inheritdoc/>
        public long HttpCode { get ; set ; }

        /// <inheritdoc/>
        public bool RequestSuccessful { get ; set ; }

        /// <inheritdoc/>
        public string? ResponseMessage { get ; set ; }

        /// <inheritdoc/>
        public string ResponseCode { get ; set ; }

        /// <inheritdoc/>
        public string? ErrorMessage { get ; set ; }
    }

    /// <summary>
    /// Initiate USSD API response body
    /// </summary>
    public class USSDInitiateResponseBody
    {
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gateway message
        /// </summary>
        public string GatewayMessage { get; set; }

        /// <summary>
        /// Transaction reference
        /// </summary>
        public string TransactionReference { get; set; }

        /// <summary>
        /// Gateway reference
        /// </summary>
        public string GatewayReference { get; set; }

        /// <summary>
        /// USSD code
        /// </summary>
        public string UssdCode { get; set; }

        /// <summary>
        /// Payment code
        /// </summary>
        public string PaymentCode { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }
    }
}
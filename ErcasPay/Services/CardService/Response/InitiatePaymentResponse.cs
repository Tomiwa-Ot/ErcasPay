using System.Text.Json.Serialization;
using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.CardService.Response
{
    /// <summary>
    /// Card payment initiation API response
    /// </summary>
    public class InitiatePaymentResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<InitiatePaymentResponseBody>))]
        public InitiatePaymentResponseBody ResponseBody { get; set; }

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
    /// Card payment initiation API response body
    /// </summary>
    public class InitiatePaymentResponseBody
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

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
        /// Payment reference
        /// </summary>
        public string PaymentReference { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Redirect url
        /// </summary>
        public string RedirectUrl { get; set; }
    }
}
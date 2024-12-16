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
        /// Eci flag
        /// </summary>
        public string? EciFlag { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        public string? TransactionId { get; set; }

        /// <summary>
        /// Transaction ref
        /// </summary>
        public string? TransactionRef { get; set; }

        /// <summary>
        /// Transaction auth
        /// </summary>
        public string? TransactionAuth { get; set; }

        /// <summary>
        /// Transaction auth link
        /// </summary>
        public string? TransactionAuthLink { get; set; }

        /// <summary>
        /// Gateway message
        /// </summary>
        public string? GatewayMessage { get; set; }

        /// <summary>
        /// Gateway reference
        /// </summary>
        public string? GatewayReference { get; set; }

        /// <summary>
        /// Support message
        /// </summary>
        public string? SupportMessage { get; set; }

        /// <summary>
        /// Transaction reference
        /// </summary>
        public string? TransactionReference { get; set; }

        /// <summary>
        /// Payment reference
        /// </summary>
        public string? PaymentReference { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Redirect url
        /// </summary>
        public string? RedirectUrl { get; set; }

        /// <summary>
        /// Callback Url
        /// </summary>
        public string? CallbackUrl { get; set; }
    }
}
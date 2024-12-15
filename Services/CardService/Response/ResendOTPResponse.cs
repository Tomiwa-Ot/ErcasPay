using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.CardService.Response
{
    /// <summary>
    /// Resend OTP API response
    /// </summary>
    public class ResendOTPResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<ResendOTPResponseBody>))]
        public ResendOTPResponseBody ResponseBody { get; set; }

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
    /// Resend OTP API response body
    /// </summary>
    public class ResendOTPResponseBody
    {
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set;}

        /// <summary>
        /// Gateway message
        /// </summary>
        public string GatewayMessage { get; set;}

        /// <summary>
        /// Transaction reference
        /// </summary>
        public string TransactionReference { get; set;}

        /// <summary>
        /// Payment reference
        /// </summary>
        public string PaymentReference { get; set;}
    }
}
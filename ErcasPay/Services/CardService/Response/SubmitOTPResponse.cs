using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.CardService.Response
{
    /// <summary>
    /// Submit OTP API response
    /// </summary>
    public class SubmitOTPResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<SubmitOTPResponseBody>))]
        public SubmitOTPResponseBody ResponseBody { get; set; }

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
    /// Submit OTP API response
    /// </summary>
    public class SubmitOTPResponseBody
    {
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
        /// Callback url
        /// </summary>
        public string CallbackUrl { get; set; }
    }
}
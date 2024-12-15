using ErcasPay.Base.Response;

namespace ErcasPay.Services.CardService.Response
{
    /// <summary>
    /// Verify card transaction API response
    /// </summary>
    public class VerifyCardTransactionResponse : IResponse
    {
        /// <inheritdoc/>
        public VerifyCardTransactionResponseBody ResponseBody { get; set; }

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
    /// Verify card transaction API response body
    /// </summary>
    public class VerifyCardTransactionResponseBody
    {
        /// <summary>
        /// Reference
        /// </summary>
        public string Reference { get; set; }
    }
}
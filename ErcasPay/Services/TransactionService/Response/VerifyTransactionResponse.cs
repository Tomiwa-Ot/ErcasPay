using ErcasPay.Base.Response;
using ErcasPay.Helpers;
using Newtonsoft.Json;

namespace ErcasPay.Services.TransactionService.Response
{
    /// <summary>
    /// Verify transaction API response
    /// </summary>
    public class VerifyTransactionResponse : IResponse
    {
        /// <inheritdoc/>
        [JsonProperty("ResponseBody")]
        [Newtonsoft.Json.JsonConverter(typeof(SafePropertyConverter<VerifyTransactionResponseBody>))]
        public VerifyTransactionResponseBody ResponseBody { get; set; }

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
    /// Verify transaction API response body
    /// </summary>
    public class VerifyTransactionResponseBody
    {
        /// <summary>
        /// Domain
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Ercs reference
        /// </summary>
        public string Ercs_Reference { get; set; }

        /// <summary>
        /// Tx reference
        /// </summary>
        public string Tx_Reference { get; set; }
        
        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Paid at
        /// </summary>
        public DateTime Paid_At { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        public DateTime Created_At { get; set; }

        /// <summary>
        /// Channel
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Fee
        /// </summary>
        public double Fee { get; set; }

        /// <summary>
        /// Fee bearer
        /// </summary>
        public string Fee_Bearer { get; set; }

        /// <summary>
        ///  Settled amount
        /// </summary>
        public double Settled_Amount { get; set; }

        /// <inheritdoc/>
        public Customer Customer { get; set; }
    }

    /// <summary>
    /// Customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone_Number { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        public string Reference { get; set; }
    }
}
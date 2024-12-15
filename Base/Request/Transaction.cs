namespace ErcasPay.Base.Request
{
    /// <summary>
    /// Transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Amount
        /// </summary>
        public double amount { get; set; }

        /// <summary>
        /// Merchant payment reference
        /// </summary>
        public string paymentReference { get; set; }

        /// <summary>
        /// Payment methods
        /// </summary>
        public string? paymentMethods { get; set; }

        /// <summary>
        /// Customer's name
        /// </summary>
        public string customerName { get; set; }

        /// <summary>
        /// Customer's email
        /// </summary>
        public string customerEmail { get; set; }

        /// <summary>
        /// Customer's phone number
        /// </summary>
        public string? customerPhoneNumber { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// Fee bearer
        /// </summary>
        public string? feeBearer { get; set; }

        /// <summary>
        /// Redirect url
        /// </summary>
        public string? redirectUrl { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string? description { get; set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public object? metadata { get; set; }
    }
}
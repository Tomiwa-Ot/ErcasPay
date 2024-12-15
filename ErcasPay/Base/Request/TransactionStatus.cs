namespace ErcasPay.Base.Request
{
    /// <summary>
    /// Transaction status
    /// </summary>
    public class TransactionStatus
    {
        /// <summary>
        /// Reference
        /// </summary>
        public string reference { get; set; }

        /// <summary>
        /// Payment methodw
        /// </summary>
        public string payment_method { get; set; }
    }
}
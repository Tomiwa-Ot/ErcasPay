namespace ErcasPay.Base.Request
{
    /// <summary>
    /// Card information
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Card CVV
        /// </summary>
        public string cvv { get; set; }

        /// <summary>
        /// Card PIN
        /// </summary>
        public string pin { get; set; }

        /// <summary>
        /// Card Expiry Date
        /// </summary>
        public string expiryDate { get; set; }

        /// <summary>
        /// Card PAN
        /// </summary>
        public string pan { get; set; }
    }
}
namespace ErcasPay.Base.Request
{
    /// <summary>
    /// OTP
    /// </summary>
    public class OTP
    {
        /// <summary>
        /// OTP code
        /// </summary>
        public string otp { get; set; }

        /// <summary>
        /// Gateway reference
        /// </summary>
        public string gatewayReference { get; set; }
    }
}
using Newtonsoft.Json;

namespace ErcasPay.Base.Request
{
    /// <summary>
    /// Device details
    /// </summary>
    public class DeviceDetails
    {
        /// <summary>
        /// Payer device dto
        /// </summary>
        public PayerDeviceDto payerDeviceDto { get; set; }
    }

    /// <summary>
    /// Payer device dto
    /// </summary>
    public class PayerDeviceDto
    {
        /// <summary>
        /// Device
        /// </summary>
        public Device device { get; set; }
    }

    /// <summary>
    /// Device
    /// </summary>
    public class Device
    {
        /// <summary>
        /// User agent
        /// </summary>
        public string browser { get; set; }

        /// <summary>
        /// Browser details
        /// </summary>
        public BrowserDetails browserDetails { get; set; }

        /// <summary>
        /// IP address
        /// </summary>
        public string? ipAddress { get; set; }
    }

    /// <summary>
    /// Browser details
    /// </summary>
    public class BrowserDetails
    {
        /// <summary>
        /// 3DSecureChallengeWindowSize
        /// </summary>
        [JsonProperty("3DSecureChallengeWindowSize")]
        public string SecureChallengeWindowSize { get; set; }

        /// <summary>
        /// Accept headers
        /// </summary>
        public string acceptHeaders { get; set; }

        /// <summary>
        /// Color depth
        /// </summary>
        public long colorDepth { get; set; }

        /// <summary>
        /// Java enabled
        /// </summary>
        public bool javaEnabled { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// Screen height
        /// </summary>
        public long screenHeight { get; set; }

        /// <summary>
        /// Screen width
        /// </summary>
        public long screenWidth { get; set; }

        /// <summary>
        /// Timezone
        /// </summary>
        public long timeZone { get; set; }
    }
}
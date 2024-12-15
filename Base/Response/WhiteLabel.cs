namespace ErcasPay.Base.Response
{
    /// <summary>
    /// Whitelable
    /// </summary>
    public class WhiteLabel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Logo url
        /// </summary>
        public string Logo_Url { get; set; }

        /// <summary>
        /// Primary color
        /// </summary>
        public string Primary_Color { get; set; }

        /// <summary>
        /// Accent color
        /// </summary>
        public string Accent_Color { get; set; }

        /// <summary>
        /// Font family
        /// </summary>
        public string Font_Family { get; set; }

        /// <summary>
        /// Font color
        /// </summary>
        public string Font_Color { get; set; }

        /// <summary>
        /// Has admin approved
        /// </summary>
        public bool Has_Admin_Approved { get; set; }
    }
}
namespace ErcasPay.Base.Response
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public long HttpCode { get; set; }
        
        /// <summary>
        /// Indicates if the request was successful or not
        /// </summary>
        public bool RequestSuccessful { get; set; }

        /// <summary>
        /// Any message attached to the transaction
        /// </summary>
        public string? ResponseMessage { get; set; }

        /// <summary>
        /// This can be 'success', 'failed' or 'pending
        /// </summary>
        public string ResponseCode { get; set; }

        /// <summary>
        /// Error messages
        /// </summary>
        public string? ErrorMessage  { get; set; }
    }
}
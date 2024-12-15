using ErcasPay.Base.Response;

namespace ErcasPay.Services.USSDService.Response
{
    /// <summary>
    /// Get USSD bank list API response
    /// </summary>
    public class GetUSSDBankListResponse : IResponse
    {
        /// <summary>
        /// Response body
        /// </summary>
        public IEnumerable<string>? ResponseBody { get; set; }

        /// <inheritdoc/>
        public long HttpCode { get ; set ; }

        /// <inheritdoc/>
        public bool RequestSuccessful { get ; set ; }

        /// <inheritdoc/>
        public string? ResponseMessage { get ; set ; }

        /// <inheritdoc/>
        public string ResponseCode { get ; set ; }

        /// <inheritdoc/>
        public string? ErrorMessage { get ; set ; }
    }
}
using ErcasPay.Base.Request;
using ErcasPay.Base.Response;
using ErcasPay.Services.USSDService.Response;

namespace ErcasPay.Services.USSDService
{
    /// <summary>
    /// Service interface for USSD payments
    /// </summary>
    public interface IUSSDService
    {
        /// <summary>
        /// Fetch all the supported banks for USSD transfer
        /// </summary>
        /// <returns>ErcasPay API response</returns>
        Task<GetUSSDBankListResponse> GetBankList();

        /// <summary>
        /// Initiates a USSD transaction
        /// </summary>
        /// <param name="transaction">Transaction details(amount, customer's name, etc)</param>
        /// <param name="bankName">Name of bank</param>
        /// <returns>ErcasPay API response</returns>
        Task<InitiateUSSDResponse> InitiateUSSDCode(Transaction transaction, string bankName);
    }
}
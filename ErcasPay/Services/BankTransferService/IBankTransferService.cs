using ErcasPay.Base.Request;
using ErcasPay.Base.Response;
using ErcasPay.Services.BankTransferService.Response;

namespace ErcasPay.Services.BankTransferService
{
    /// <summary>
    /// Service interface for bank transfer payments
    /// </summary>
    public interface IBankTransferService
    {
        /// <summary>
        /// Initialize a bank transfer request
        /// </summary>
        /// <param name="transaction">Transaction details(amount, customer's name, etc)</param>
        /// <returns>ErcasPay API response</returns>
        Task<InitializeBankTransferResponse> InitializeBankTransfer(Transaction transaction);
    }
}
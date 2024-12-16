using ErcasPay.Base.Request;
using ErcasPay.Base.Response;
using ErcasPay.Services.TransactionService.Response;

namespace ErcasPay.Services.TransactionService
{
    /// <summary>
    /// Service interface for interacting with transactions
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Retrieve detailed information about a specific transaction
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<FetchTransactionDetailsResponse> FetchTransactionDetails(string transactionRef);

        /// /// <summary>
        /// Confirm the actual status of a transaction
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<VerifyTransactionResponse> VerifyTransaction(string transactionRef);

        /// <summary>
        /// Retrieves the status of a transaction
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <param name="transactionStatus">Merchant reference and payment method</param>
        /// <returns>ErcasPay API response</returns>
        Task<FetchTransactionStatusResponse> FetchTransactionStatus(string transactionRef, TransactionStatus transactionStatus);

        /// <summary>
        /// Cancel a transaction that has not yet been marked as completed
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<CancelTransactionResponse> CancelTransaction(string transactionRef);
        
        /// <summary>
        /// Initiate a transaction
        /// </summary>
        /// <param name="transaction">Transaction details(amount, customer's name, etc)</param>
        /// <returns></returns>
        Task<InitiateTransactionResponse> InitiateTransaction(Transaction transaction);
    }
}
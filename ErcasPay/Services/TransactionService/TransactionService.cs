using ErcasPay.Infrastructure.Http;
using ErcasPay.Base.Response;
using ErcasPay.Services.TransactionService.Response;
using ErcasPay.Base.Request;

namespace ErcasPay.Services.TransactionService
{
    /// <summary>
    /// Service for interacting with transactions
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly IApiClient _apiClient;

        public TransactionService(IApiClient apiClient)
        {
            _apiClient = apiClient;    
        }

        /// <inheritdoc/>
        public async Task<CancelTransactionResponse> CancelTransaction(string transactionRef)
        {
            return await _apiClient.Send<CancelTransactionResponse>(
                HttpMethod.Get, $"payment/cancel/{transactionRef}");
        }

        /// <inheritdoc/>
        public async Task<FetchTransactionDetailsResponse> FetchTransactionDetails(string transactionRef)
        {
            return await _apiClient.Send<FetchTransactionDetailsResponse>(
                HttpMethod.Get, $"payment/details/{transactionRef}");
        }

        /// <inheritdoc/>
        public async Task<FetchTransactionStatusResponse> FetchTransactionStatus(string transactionRef, TransactionStatus transactionStatus)
        {
            return await _apiClient.Send<FetchTransactionStatusResponse>(
                HttpMethod.Post, $"payment/status/{transactionRef}", transactionStatus);
        }

        /// <inheritdoc/>
        public async Task<InitiateTransactionResponse> InitiateTransaction(Transaction transaction)
        {
            return await _apiClient.Send<InitiateTransactionResponse>(
                HttpMethod.Post, $"payment/initiate", transaction);
        }

        /// <inheritdoc/>
        public async Task<VerifyTransactionResponse> VerifyTransaction(string transactionRef)
        {
            return await _apiClient.Send<VerifyTransactionResponse>(
                HttpMethod.Get, $"payment/transaction/verify/{transactionRef}");
        }
    }
}
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
        public async Task<IResponse> CancelTransaction(string transactionRef)
        {
            return await _apiClient.Send<CancelTransactionResponse>(
                HttpMethod.Get, $"payment/cancel/{transactionRef}");
        }

        /// <inheritdoc/>
        public async Task<IResponse> FetchTransactionDetails(string transactionRef)
        {
            return await _apiClient.Send<FetchTransactionDetailsResponse>(
                HttpMethod.Get, $"payment/details/{transactionRef}");
        }

        /// <inheritdoc/>
        public async Task<IResponse> FetchTransactionStatus(string transactionRef, TransactionStatus transactionStatus)
        {
            return await _apiClient.Send<FetchTransactionStatusResponse>(
                HttpMethod.Post, $"payment/status/{transactionRef}", transactionStatus);
        }

        /// <inheritdoc/>
        public async Task<IResponse> InitiateTransaction(Transaction transaction)
        {
            return await _apiClient.Send<InitiateTransactionResponse>(
                HttpMethod.Post, $"payment/initiate", transaction);
        }

        /// <inheritdoc/>
        public async Task<IResponse> VerifyTransaction(string transactionRef)
        {
            return await _apiClient.Send<VerifyTransactionResponse>(
                HttpMethod.Get, $"payment/transaction/verify/{transactionRef}");
        }
    }
}
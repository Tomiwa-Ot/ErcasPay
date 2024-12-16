using ErcasPay.Infrastructure.Http;
using ErcasPay.Base.Response;
using ErcasPay.Services.BankTransferService.Response;
using ErcasPay.Base.Request;
using ErcasPay.Helpers;
using ErcasPay.Base;
using ErcasPay.Services.TransactionService;
using ErcasPay.Services.TransactionService.Response;
using System.Text.Json;
using Newtonsoft.Json;
using ErcasPay.Exceptions;

namespace ErcasPay.Services.BankTransferService
{
    /// <summary>
    /// Service for bank transfer payments
    /// </summary>
    public class BankTransferService : IBankTransferService
    {
        private readonly IApiClient _apiClient;
        private readonly ITransactionService _transactionService;

        public BankTransferService(IApiClient apiClient,
                        ITransactionService transactionService)
        {
            _apiClient = apiClient;
            _transactionService = transactionService;
        }

        /// <inheritdoc/>
        public async Task<InitializeBankTransferResponse> InitializeBankTransfer(Transaction transaction)
        {
            transaction.paymentMethods = TransactionHelper.GetPaymentMethod(PaymentMethod.bank_transfer);
            InitiateTransactionResponse initiatedTransaction = (InitiateTransactionResponse)await _transactionService.InitiateTransaction(transaction);
            
            if (!initiatedTransaction.RequestSuccessful)
            {
                throw new TransactionException(System.Text.Json.JsonSerializer.Serialize(initiatedTransaction));
            }
            
            return await _apiClient.Send<InitializeBankTransferResponse>(
                HttpMethod.Get, $"payment/bank-transfer/request-bank-account/{initiatedTransaction.ResponseBody.TransactionReference}");
        }
    }
}
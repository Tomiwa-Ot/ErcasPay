using ErcasPay.Infrastructure.Http;
using ErcasPay.Base.Response;
using ErcasPay.Services.USSDService.Response;
using ErcasPay.Services.TransactionService;
using ErcasPay.Base.Request;
using ErcasPay.Helpers;
using ErcasPay.Base;
using ErcasPay.Services.TransactionService.Response;

namespace ErcasPay.Services.USSDService
{
    /// <summary>
    /// Service for USSD payments
    /// </summary>
    public class USSDService : IUSSDService
    {
        private readonly IApiClient _apiClient;
        private readonly ITransactionService _transactionService;

        public USSDService(IApiClient apiClient,
                        ITransactionService transactionService)
        {
            _apiClient = apiClient;
            _transactionService = transactionService;
        }

        /// <inheritdoc/>
        public async Task<IResponse> GetBankList()
        {
            return await _apiClient.
                Send<GetUSSDBankListResponse>(
                    HttpMethod.Get, "payment/ussd/supported-banks");
        }

        /// <inheritdoc/>
        public async Task<IResponse> InitiateUSSDCode(Transaction transaction, string bankName)
        {
            transaction.paymentMethods = TransactionHelper.GetPaymentMethod(PaymentMethod.ussd);
            InitiateTransactionResponse initiatedTransaction = (InitiateTransactionResponse)await _transactionService.InitiateTransaction(transaction);
            if (!initiatedTransaction.RequestSuccessful)
            {
                return initiatedTransaction;
            }
            
            return await _apiClient.
                Send<InitiateUSSDResponse>(
                    HttpMethod.Post, $"payment/ussd/request-ussd-code/{initiatedTransaction.ResponseBody.TransactionReference}", new { bank_name = bankName});
        }
    }
}
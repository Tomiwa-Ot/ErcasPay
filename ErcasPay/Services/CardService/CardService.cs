using ErcasPay.Base;
using ErcasPay.Base.Request;
using ErcasPay.Base.Response;
using ErcasPay.Exceptions;
using ErcasPay.Helpers;
using ErcasPay.Infrastructure.Http;
using ErcasPay.Services.CardService.Response;
using ErcasPay.Services.TransactionService;
using ErcasPay.Services.TransactionService.Response;

namespace ErcasPay.Services.CardService
{
    /// <summary>
    /// Service for card payments
    /// </summary>
    public class CardService : ICardService
    {
        private readonly IApiClient _apiClient;
        private readonly ITransactionService _transactionService;

        public CardService(IApiClient apiClient,
                    ITransactionService transactionService)
        {
            _apiClient = apiClient;
            _transactionService = transactionService;
        }

        /// <inheritdoc/>
        public async Task<IResponse> CardDetails(string transactionRef)
        {
            return await _apiClient.Send<CardDetailsResponse>(
                HttpMethod.Get, $"payment/cards/details/{transactionRef}");
        }

        /// <inheritdoc/>
        public async Task<IResponse> InitiatePayment(Transaction transaction, Card card, DeviceDetails _deviceDetails, string publicKeyFilePath)
        {
            transaction.paymentMethods = TransactionHelper.GetPaymentMethod(PaymentMethod.card);
            InitiateTransactionResponse initiatedTransaction = (InitiateTransactionResponse)await _transactionService.InitiateTransaction(transaction);
            if (!initiatedTransaction.RequestSuccessful)
            {
                return initiatedTransaction;
            }

            string publicKey = File.ReadAllText(publicKeyFilePath);
            if (string.IsNullOrEmpty(publicKey))
            {
                throw new ConfigurationException("Public key not found in configuration");
            }

            return await _apiClient.Send<InitiatePaymentResponse>(
                HttpMethod.Post, $"payment/cards/initialize", new {
                    payload = RSA.EncryptCard(publicKey, card),
                    transactionReference = initiatedTransaction.ResponseBody.TransactionReference,
                    deviceDetails = _deviceDetails
                });
        }

        /// <inheritdoc/>
        public async Task<IResponse> ResendOTP(string transactionRef, string _gatewayReference)
        {
            return await _apiClient.Send<ResendOTPResponse>(
                HttpMethod.Post, $"payment/cards/otp/resend/{transactionRef}", new {
                    gatewayReference = _gatewayReference
                });
        }

        /// <inheritdoc/>
        public async Task<IResponse> SubmitOTP(string transactionRef, OTP otp)
        {
            return await _apiClient.Send<SubmitOTPResponse>(
                HttpMethod.Post, $"payment/cards/otp/submit/{transactionRef}", otp);
        }

        /// <inheritdoc/>
        public async Task<IResponse> VerifyCardTransaction(string transactionRef)
        {
            return await _apiClient.Send<VerifyCardTransactionResponse>(
                HttpMethod.Post, $"payment/cards/transaction/verify", new {
                    reference = transactionRef
                });
        }
    }
}
using ErcasPay.Base.Request;
using ErcasPay.Base.Response;
using ErcasPay.Services.BankTransferService;
using ErcasPay.Services.BankTransferService.Response;
using ErcasPay.Services.CardService;
using ErcasPay.Services.CardService.Response;
using ErcasPay.Services.TransactionService;
using ErcasPay.Services.TransactionService.Response;
using ErcasPay.Services.USSDService;
using ErcasPay.Services.USSDService.Response;

namespace ErcasPay.Base
{
    /// <summary>
    /// ErcasPay API Wrapper
    /// </summary>
    public class ErcasPay : IErcasPay
    {
        private readonly IBankTransferService _bankTransferService;
        private readonly ICardService _cardService;
        private readonly ITransactionService _transactionService;
        private readonly IUSSDService _ussdService;
        public ErcasPay(IBankTransferService bankTransferService,
                    ICardService cardService,
                    ITransactionService transactionService,
                    IUSSDService ussdService)
        {
            _bankTransferService = bankTransferService;
            _cardService = cardService;
            _transactionService = transactionService;
            _ussdService = ussdService;
        }

        /// <inheritdoc/>
        public async Task<CancelTransactionResponse> CancelTransaction(string transactionRef)
        {
            return await _transactionService.CancelTransaction(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<CardDetailsResponse> CardDetails(string transactionRef)
        {
            return await _cardService.CardDetails(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<FetchTransactionDetailsResponse> FetchTransactionDetails(string transactionRef)
        {
            return await _transactionService.FetchTransactionDetails(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<FetchTransactionStatusResponse> FetchTransactionStatus(string transactionRef, TransactionStatus transactionStatus)
        {
            return await _transactionService.FetchTransactionStatus(transactionRef, transactionStatus);
        }

        /// <inheritdoc/>
        public async Task<GetUSSDBankListResponse> GetUSSDBankList()
        {
            return await _ussdService.GetBankList();
        }

        /// <inheritdoc/>
        public async Task<InitializeBankTransferResponse> PayViaBankTranfer(Transaction transaction)
        {
            return await _bankTransferService.InitializeBankTransfer(transaction);
        }

        /// <inheritdoc/>
        public async Task<InitiatePaymentResponse> PayViaCard(Transaction transaction, Card card, DeviceDetails deviceDetails, string publicKeyFilePath)
        {
            return await _cardService.InitiatePayment(transaction, card, deviceDetails, publicKeyFilePath);
        }

        /// <inheritdoc/>
        public async Task<InitiateUSSDResponse> PayViaUSSD(Transaction transaction, string bankName)
        {
            return await _ussdService.InitiateUSSDCode(transaction, bankName);
        }

        /// <inheritdoc/>
        public async Task<ResendOTPResponse> ResendOTP(string transactionRef, string gatewayReference)
        {
            return await _cardService.ResendOTP(transactionRef, gatewayReference);
        }

        /// <inheritdoc/>
        public async Task<SubmitOTPResponse> SubmitOTP(string transactionRef, OTP otp)
        {
            return await _cardService.SubmitOTP(transactionRef, otp);
        }

        /// <inheritdoc/>
        public async Task<VerifyCardTransactionResponse> VerifyCardTransaction(string transactionRef)
        {
            return await _cardService.VerifyCardTransaction(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<VerifyTransactionResponse> VerifyTransaction(string transactionRef)
        {
            return await _transactionService.VerifyTransaction(transactionRef);
        }
    }   
}
using ErcasPay.Base.Request;
using ErcasPay.Base.Response;
using ErcasPay.Services.BankTransferService;
using ErcasPay.Services.CardService;
using ErcasPay.Services.TransactionService;
using ErcasPay.Services.USSDService;

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
        public async Task<IResponse> CancelTransaction(string transactionRef)
        {
            return await _transactionService.CancelTransaction(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<IResponse> CardDetails(string transactionRef)
        {
            return await _cardService.CardDetails(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<IResponse> FetchTransactionDetails(string transactionRef)
        {
            return await _transactionService.FetchTransactionDetails(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<IResponse> FetchTransactionStatus(string transactionRef, TransactionStatus transactionStatus)
        {
            return await _transactionService.FetchTransactionStatus(transactionRef, transactionStatus);
        }

        /// <inheritdoc/>
        public async Task<IResponse> GetUSSDBankList()
        {
            return await _ussdService.GetBankList();
        }

        /// <inheritdoc/>
        public async Task<IResponse> PayViaBankTranfer(Transaction transaction)
        {
            return await _bankTransferService.InitializeBankTransfer(transaction);
        }

        /// <inheritdoc/>
        public async Task<IResponse> PayViaCard(Transaction transaction, Card card, DeviceDetails deviceDetails, string publicKeyFilePath)
        {
            return await _cardService.InitiatePayment(transaction, card, deviceDetails, publicKeyFilePath);
        }

        /// <inheritdoc/>
        public async Task<IResponse> PayViaUSSD(Transaction transaction, string bankName)
        {
            return await _ussdService.InitiateUSSDCode(transaction, bankName);
        }

        /// <inheritdoc/>
        public async Task<IResponse> ResendOTP(string transactionRef, string gatewayReference)
        {
            return await _cardService.ResendOTP(transactionRef, gatewayReference);
        }

        /// <inheritdoc/>
        public async Task<IResponse> SubmitOTP(string transactionRef, OTP otp)
        {
            return await _cardService.SubmitOTP(transactionRef, otp);
        }

        /// <inheritdoc/>
        public async Task<IResponse> VerifyCardTransaction(string transactionRef)
        {
            return await _cardService.VerifyCardTransaction(transactionRef);
        }

        /// <inheritdoc/>
        public async Task<IResponse> VerifyTransaction(string transactionRef)
        {
            return await _transactionService.VerifyTransaction(transactionRef);
        }
    }   
}
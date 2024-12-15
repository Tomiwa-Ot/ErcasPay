using ErcasPay.Base.Request;
using ErcasPay.Base.Response;

namespace ErcasPay.Base
{
    /// <summary>
    /// ErcasPay API Wrapper Interface
    /// </summary>
    public interface IErcasPay
    {
        /// <summary>
        /// Fetch all the supported banks for USSD transfer
        /// </summary>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> GetUSSDBankList();

        /// <summary>
        /// Initiate a card transaction
        /// </summary>
        /// <param name="transaction">Transaction details(amount, customer's name, etc)</param>
        /// <param name="card">Card details</param>
        /// <param name="deviceDetails">Device details</param>
        /// <param name="publicKeyFilePath">RSA public key for encrypting card</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> PayViaCard(Transaction transaction, Card card, DeviceDetails deviceDetailsdeviceDetails, string publicKeyFilePath);

        /// <summary>
        /// Initialize a bank transfer request
        /// </summary>
        /// <param name="transaction">Transaction details(amount, customer's name, etc)</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> PayViaBankTranfer(Transaction transaction);

        /// <summary>
        /// Initiates a USSD transaction
        /// </summary>
        /// <param name="transaction">Transaction details(amount, customer's name, etc)</param>
        /// <param name="bankName">Name of bank</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> PayViaUSSD(Transaction transaction, string bankName);

        /// <summary>
        /// Receive OTP for card validation purposes
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <param name="otp">One time password and gateway reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> SubmitOTP(string transactionRef, OTP otp);

        /// <summary>
        /// Initiate the OTP resend
        /// /summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <param name="gatewayReference">Gateway reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> ResendOTP(string transactionRef, string gatewayReference);

        /// <summary>
        /// Retrieve detailed information about a specific transaction
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> FetchTransactionDetails(string transactionRef);

        /// <summary>
        /// Retrieves the status of a transaction
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <param name="transactionStatus">Merchant reference and payment method</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> FetchTransactionStatus(string transactionRef, TransactionStatus transactionStatus);

        /// /// <summary>
        /// Confirm the actual status of a transaction
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> VerifyTransaction(string transactionRef);

        /// <summary>
        /// Verifies a card transaction and confirms its validity
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> VerifyCardTransaction(string transactionRef);

        /// <summary>
        /// Cancel a transaction that has not yet been marked as completed
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> CancelTransaction(string transactionRef);

        /// <summary>
        /// Retrieve the details of a card transaction based on the provided transaction reference
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> CardDetails(string transactionRef);
    }
}
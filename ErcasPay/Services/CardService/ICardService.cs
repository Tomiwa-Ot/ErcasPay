using ErcasPay.Base.Request;
using ErcasPay.Base.Response;

namespace ErcasPay.Services.CardService
{
    /// <summary>
    /// Service interface for card payments
    /// </summary>
    public interface ICardService
    {
        /// <summary>
        /// Initiate a card transaction
        /// </summary>
        /// <param name="transaction">Transaction details(amount, customer's name, etc)</param>
        /// <param name="card">Card details</param>
        /// <param name="deviceDetails">Device details</param>
        /// <param name="publicKeyFilePath">RSA public key for encrypting card</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> InitiatePayment(Transaction transaction, Card card, DeviceDetails _deviceDetails, string publicKeyFilePath);

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
        Task<IResponse> ResendOTP(string transactionRef, string _gatewayReference);

        /// <summary>
        /// Retrieve the details of a card transaction based on the provided transaction reference
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns><ErcasPay API response/returns>
        Task<IResponse> CardDetails(string transactionRef);

        /// <summary>
        /// Verifies a card transaction and confirms its validity
        /// </summary>
        /// <param name="transactionRef">ErcasPay transaction reference</param>
        /// <returns>ErcasPay API response</returns>
        Task<IResponse> VerifyCardTransaction(string transactionRef);
    }
}
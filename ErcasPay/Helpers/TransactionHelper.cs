using ErcasPay.Base;
using ErcasPay.Exceptions;

namespace ErcasPay.Helpers
{
    /// <summary>
    /// Transaction helper
    /// </summary>
    public static class TransactionHelper
    {
        private static readonly Dictionary<PaymentMethod, string> PaymentMethods = new()
        {
            { PaymentMethod.bank_transfer, "bank-transfer"},
            { PaymentMethod.card, "card"},
            { PaymentMethod.qr_code, "qr-code"},
            { PaymentMethod.ussd, "ussd"}
        };

        /// <summary>
        /// Converts PaymentMethod enum to string
        /// </summary>
        /// <param name="paymentMethod">Selected payment method</param>
        /// <returns>String version of the PaymentMethod enum</returns>
        public static string GetPaymentMethod(PaymentMethod paymentMethod)
        {
            return PaymentMethods.TryGetValue(paymentMethod, out var result)
                ? result : throw new UnsupportedPaymentMethodException(
                    $"{Enum.GetName(typeof(PaymentMethod), paymentMethod)} is not suppoted");
        }
    }
}
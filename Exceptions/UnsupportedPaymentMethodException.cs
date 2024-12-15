namespace ErcasPay.Exceptions
{
    /// <summary>
    /// Unsupported payment method exception
    /// </summary>
    public class UnsupportedPaymentMethodException : Exception
    {
        public UnsupportedPaymentMethodException(string Message) : base(Message) {}
    }
}
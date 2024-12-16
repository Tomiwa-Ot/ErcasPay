namespace ErcasPay.Exceptions
{
    /// <summary>
    /// Failed transaction exception
    /// </summary>
    public class TransactionException : Exception
    {
        public TransactionException(string Message) : base(Message) {}
    }
}
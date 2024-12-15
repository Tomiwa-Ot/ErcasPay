namespace ErcasPay.Exceptions
{
    /// <summary>
    /// Missing configuration exception
    /// </summary>
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string Message) : base(Message) {}
    }
}
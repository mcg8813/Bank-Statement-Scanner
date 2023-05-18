using System.Runtime.Serialization;

namespace BankStatementScannerLibrary.Input
{
    [Serializable]
    internal class FormatNotFoundException : Exception
    {
        public FormatNotFoundException()
        {
        }

        public FormatNotFoundException(String message) : base(message)
        {
        }

        public FormatNotFoundException(String message, Exception innerException) : base(message, innerException)
        {
        }

        protected FormatNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
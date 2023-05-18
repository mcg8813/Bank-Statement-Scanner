namespace BankStatementScannerLibrary
{
    [Serializable]
    public class SortException : Exception
    {
        public string FormatName { get; }

        public SortException() { }

        public SortException(string message)
            : base(message) { }

        public SortException(string message, Exception inner)
            : base(message, inner) { }

        public SortException(string message, string formatName)
            : this(message)
        {
            FormatName = formatName;
        }
    }
}

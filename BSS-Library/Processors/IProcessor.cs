namespace BankStatementScannerLibrary.Processors
{
    public interface IProcessor
    {
        string ProcessPdfString(string[] raw);
        
        string ParseData(List<string> transactions, List<DateOnly>? dateRange = null);
    }

}
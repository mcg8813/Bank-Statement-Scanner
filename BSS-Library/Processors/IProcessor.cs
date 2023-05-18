namespace BankStatementScannerLibrary.Processors
{
    public interface IProcessor
    {
        String ProcessPDFString(string[] raw);
        
        String ParseData(List<String> transactions, List<DateOnly>? dateRange = null);
    }

}
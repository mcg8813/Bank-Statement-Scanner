namespace BankStatementScannerLibrary.Processors
{
    public interface IProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        string ProcessPdfString(string[] raw); // TODO - Convert list into string.
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactions"></param>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        string ParseData(List<string> transactions, List<DateOnly>? dateRange = null); // TODO - Return Sorted List<String> 
    }
}
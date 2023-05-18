using BankStatementScannerLibrary.Processors;

namespace BankStatementScannerLibrary.Input
{
    public class Sorter
    {
        public static string GetFormat(string[] raw)
        {
            IProcessor? processor = null;

            foreach (string str in raw)
            {
                if (str.Contains("Capital One"))
                {
                    processor = new CapitalOneProcessor();
                    break;
                }
                else if (str.Contains("Bank of America"))
                {
                    processor = new BoAProcessor();
                    break;
                }
                else if (str.Contains("Suncoast"))
                {
                    processor = new SuncoastProcessor();
                    break;
                }
            }

            if(processor != null)
            {
                return processor.ProcessPdfString(raw);
            } else
            {
                throw new FormatNotFoundException("Unable to determine format");
            }
        }
    }
}


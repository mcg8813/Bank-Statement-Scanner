using BankStatementScannerLibrary.Input;
using BankStatementScannerLibrary.Processors;

namespace BankStatementScannerLibrary.Sorter
{
    public class Sorter
    {
        /// <summary>
        /// Instantiates the correct processor implementation.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="raw"></param>
        /// <returns></returns>
        /// <exception cref="FormatNotFoundException"></exception>
        public static string GetFormat(string filePath, bool raw = false)
        {
            string rawString = PdfReader.ExtractPdf(filePath);

            if (raw) return rawString;
            string[] rawArray = rawString.Split('\n');

            IProcessor? processor = null;

            foreach (string str in rawArray)
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
                return processor.ProcessPdfString(rawArray);
            } else
            {
                throw new FormatNotFoundException("Unable to determine format");
            }
        }
    }
}
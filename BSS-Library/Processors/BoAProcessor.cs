using System.Text;
using System.Text.RegularExpressions;
using Input;

namespace BankStatementScannerLibrary.Processors
{
    public class BoAProcessor : IProcessor
    {

        /// <summary>
        /// Converts an String array from the PDF file containing 
        /// BoA BankStatement with transactions into csv format.
        /// </summary>
        /// <param name="raw">String array input from PDF text extraction.</param>
        /// <returns>Formatted string</returns>
        public string ProcessPdfString(string[] raw)
        {
            string[] startConditions = { "Year-to-Date" };
            string[] stopConditions = { "Purchases and Adjustments" };

            List<string> transactions = TextProcessor.GetTransactionData(raw, startConditions, stopConditions);
            List<DateOnly> dateRange = TextProcessor.FindBillingDate(raw, "Account #");

            if (dateRange.Count == 0)
            {
                return "No date range found";
            }

            transactions = TextProcessor.ConvertDateFormat(transactions, dateRange, "MM/dd"); // No need to convert, just add year.
            return ParseData(transactions, dateRange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactions"></param>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        public string ParseData(List<string> transactions, List<DateOnly>? dateRange = null)
        {
            List<string> transList = new() { "Trans Date,Description,Amount\n" };

            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Length <= 15 ||
                    !DateOnly.TryParseExact(transactions[i].Remove(10), "MM/dd/yyyy", out DateOnly tempDate)) continue;

                string newString = TextProcessor.FormatAmount(transactions[i]);
                int commaIndex = TextProcessor.SecondCommaIndex(newString);
                    
                if(commaIndex != 0)
                {
                    // Removes post date and account number.
                    newString = TextProcessor.RemoveUntilSpace(newString, commaIndex - 1, true, true, 2).Remove(11, 6); 
                }

                //Add to result.
                if (Regex.Matches(newString, @",").Count == 2 && Regex.Matches(newString, @"$").Count > 0)
                {
                    transList.Add(newString + '\n');
                }
            }

            transList.Sort(TextProcessor.DateComparable);
            string result = string.Join("", transList);
            return result;
        }
    }

}


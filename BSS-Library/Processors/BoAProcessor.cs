using BankStatementScannerLibrary.TextHelpers;
using System.Text;
using System.Text.RegularExpressions;

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
        public String ProcessPDFString(string[] raw)
        {
            String[] startConditions = { "Year-to-Date" };
            String[] stopConditions = { "Purchases and Adjustments" };
            List<String> transactions = TextProcessor.GetTransactionData(raw, startConditions, stopConditions);

            List<DateOnly> dateRange = TextProcessor.FindBillingDate(raw, "Account #");
            if (dateRange.Count == 0)
            {
                return "No date range found";
            }

            transactions = TextProcessor.ConvertDateFormat(transactions, dateRange, "MM/dd"); // No need to convert, just add year.

            return ParseData(transactions, dateRange);
        }

        public String ParseData(List<String> transactions, List<DateOnly>? dateRange = null) 
        {
            Boolean Header = false;
            StringBuilder sb = new();
            DateOnly tempDate = new();
            transactions.Sort(TextProcessor.DateComparable);

            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Length > 15 && DateOnly.TryParseExact(transactions[i].Remove(10), "MM/dd/yyyy", out tempDate))
                {
                    String newString = TextProcessor.FormatAmount(transactions[i]);
                    Int32 commaIndex = TextProcessor.SecondCommaIndex(newString);
                    
                    if(commaIndex != 0)
                    {
                        // TODO - Change to RemoveUntilSpace.
                        newString = newString.Remove(commaIndex - 10, 9).Remove(11, 6); // Removes post date and account number. 
                    }

                    //Add to result.
                    if (Regex.Matches(newString, @",").Count >= 2 && Regex.Matches(newString, @"$").Count > 0)
                    {
                        sb.Append(newString + '\n');
                    }
                } //Table Header/Seperator. 
                else if (transactions[i].Contains("Date Date Description Number Number Amount") && !Header)
                {
                    sb.Append("Trans Date,Description,Amount\n");
                    Header = true;
                }
            }

            String result = sb.ToString();
            return result;
        }
    }

}


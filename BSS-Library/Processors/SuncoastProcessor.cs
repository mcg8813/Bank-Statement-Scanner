using System.Text;
using System.Text.RegularExpressions;

namespace BankStatementScannerLibrary.Processors
{
    public class SuncoastProcessor : IProcessor
    {
        /// <summary>
        /// Converts an String array from the PDF file containing 
        /// Suncoast BankStatement with transactions into csv format.
        /// </summary>
        /// <param name="raw">String array input from PDF text extraction.</param>
        /// <returns>Formatted string</returns>
        public string ProcessPdfString(string[] raw)
        {
            string[] startConditions = { "Post Date Eff Date Transaction Description Amount New Balance" };
            string[] stopConditions = { "suncoastcreditunion.com", "Share Draft Summary" };
            string[] exceptions = { "Balance Forward", "Post Date Eff Date Transaction Description Amount New Balance" };
            List<string> transactions = TextProcessor.GetTransactionData(raw, startConditions, stopConditions, exceptions);
            // Already has date

            return ParseData(transactions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactions"></param>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        public string ParseData(List<string> transactions, List<DateOnly>? dateRange = null) 
        {
            // Format Amount & Second Comma add Description from next line before second comma, Fix Date Add First Comma, Remove any unnecessary info, then sort by date. 
            StringBuilder sb = new();
            sb.Append("Trans Date,Description,Amount\n");

            for (int listIndex = 0; listIndex < transactions.Count; listIndex++)
            {
                if (transactions[listIndex].Length > 15 && DateOnly.TryParseExact(transactions[listIndex].Remove(10), "MM/dd/yyyy", out DateOnly tempDate))
                {
                    transactions[listIndex] = transactions[listIndex].Insert(10, ","); // Insert First Comma
                    string effDateRemoved = TextProcessor.RemoveUntilSpace(transactions[listIndex], 11, true); // Remove second date
                    string newBalanceRemoved = TextProcessor.RemoveUntilSpace(effDateRemoved, effDateRemoved.Length - 1, true, true); // Remove New Balance
                    string newString = TextProcessor.FormatAmount(newBalanceRemoved); // Format Amount
                    int commaIndex = TextProcessor.SecondCommaIndex(newString); // Index of second Comma

                    if (commaIndex != 0)
                    {
                        int nextIndex = listIndex + 1;
                        while (nextIndex < transactions.Count && transactions[nextIndex].Length > 10 && !DateOnly.TryParseExact(transactions[nextIndex].Remove(10), "MM/dd/yyyy", out tempDate))
                        {
                            newString = newString.Insert(commaIndex, " " + transactions[nextIndex]);
                            commaIndex += transactions[nextIndex].Length + 1;
                            nextIndex++;
                            listIndex++;
                        }
                    }

                    //Add to result.
                    if (Regex.Matches(newString, @",").Count >= 2 && Regex.Matches(newString, @"$").Count > 0)
                    {
                        sb.Append(newString + '\n');
                    }
                } 
            }

            string result = sb.ToString();
            return result;
        }
    }
}
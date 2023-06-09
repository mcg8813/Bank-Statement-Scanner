﻿using System.Text;
using System.Text.RegularExpressions;
using Input;

namespace BankStatementScannerLibrary.Processors
{
    public class CapitalOneProcessor : IProcessor
    {
        /// <summary>
        /// Converts an String array from the PDF file containing 
        /// Capital One BankStatement with transactions into csv format.
        /// </summary>
        /// <param name="raw">String array input from PDF text extraction.</param>
        /// <returns>Formatted string</returns>
        public string ProcessPdfString(string[] raw)
        {
            string[] startConditions = { "Date Description Amount" };
            string[] stopConditions = { "Fees\r" };
            string[] exceptions = { "Billing Cycle" };

            List<string> transactions = TextProcessor.GetTransactionData(raw, startConditions, stopConditions, exceptions);
            List<DateOnly> dateRange = TextProcessor.FindBillingDate(raw, "days in Billing Cycle");

            if (dateRange.Count == 0)
            {
                return "Unable to determine date range";
            }

            transactions = TextProcessor.ConvertDateFormat(transactions, dateRange, "MMM dd");
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
            if (dateRange == null)
            {
                return "No date range";
            }

            switch (GetCapitalFormat(transactions))
            {
                case 1:
                    return ParseFirstFormat(transactions, dateRange);
                case 2:
                    return ParseSecondFormat(transactions, dateRange);
                default:
                    break;
            }
            return "Capital One format not recognized";
        }

        /// <summary>
        /// Determines the format of a Capital One Bank Statement.
        /// </summary>
        /// <param name="transactions">String array input from PDF text extraction.</param>
        /// <returns></returns>
        private static int GetCapitalFormat(List<string> transactions)
        {
            return transactions.Any(str => str.Contains("Trans Date Post Date")) ? 2 : 1;
        }

        /// <summary>
        /// Processes the first format of capital one transaction data.
        /// </summary>
        /// <param name="transactions">List of strings representing transaction data.</param>
        /// <param name="dateRange">Date Range of the transactions.</param>
        /// <returns>Output string.</returns>
        private static string ParseFirstFormat(List<string> transactions, List<DateOnly> dateRange)
        {
            List<string> transList = new() { "Trans Date,Description,Amount\n" };

            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Length <= 15 ||
                    !DateOnly.TryParseExact(transactions[i].Remove(10), "MM/dd/yyyy", out DateOnly tempDate)) continue;

                while (!transactions[i].Contains('$') && !transactions[i + 1].Contains("Transactions"))
                {
                    transactions[i] = transactions[i] + ' ' + transactions[i + 1];
                    transactions.RemoveAt(i + 1);
                }

                string newString = TextProcessor.FormatAmount(transactions[i]);

                //Add to result.
                if (Regex.Matches(newString, @",").Count >= 2 && Regex.Matches(newString, @"$").Count > 0)
                {
                    transList.Add(newString + '\n');
                }
            }

            transList.Sort(TextProcessor.DateComparable);
            string result = string.Join("", transList);
            return result;
        }

        /// <summary>
        /// Processes the second format of capital one transaction data.
        /// </summary>
        /// <param name="transactions">List of strings representing transaction data.</param>
        /// <param name="dateRange">Date Range of the transactions.</param>
        /// <returns>Output string.</returns>
        private static string ParseSecondFormat(List<string> transactions, List<DateOnly> dateRange) 
        {
            List<string> transList = new() { "Trans Date,Description,Amount\n" };

            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Length <= 15 ||
                    !DateOnly.TryParseExact(transactions[i].Remove(10), "MM/dd/yyyy", out DateOnly tempDate)) continue;

                string newString = TextProcessor.FormatAmount(transactions[i]);
                int commaIndex = TextProcessor.SecondCommaIndex(newString);

                if (commaIndex != 0 && newString.Length > 17)
                {
                    newString = newString.Remove(11, newString[17].Equals(' ') ? 7 : // Remove leading space in second column 
                        6); // No leading space.
                }

                //Add to result.
                if(Regex.Matches(newString, @",").Count >= 2 && Regex.Matches(newString, @"$").Count > 0)
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

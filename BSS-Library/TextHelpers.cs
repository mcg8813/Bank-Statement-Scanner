using System.Configuration;
using System.Text;

namespace BankStatementScannerLibrary
{
    public static class TextProcessor
    {
        /// <summary>
        /// Month Abbreviations for the start of the string. 
        /// Including values for converting to int.
        /// </summary>
        private static readonly IDictionary<string, int> Months = new Dictionary<string, int> {
            { "Jan", 1 },
            { "Feb", 2 },
            { "Mar", 3 },
            { "Apr", 4 },
            { "May", 5 },
            { "Jun", 6 },
            { "Jul", 7 },
            { "Aug", 8 },
            { "Sep", 9 },
            { "Oct", 10 },
            { "Nov", 11 },
            { "Dec", 12 },
        };

        /// <summary>
        /// Returns the full file path to the out folder.
        /// </summary>
        /// <param name="filename">Name of output file</param>
        /// <returns>Full File path. Example: "C:\data\BankStatementScanner\'filename'"</returns>
        public static string FullFilePath(this string filename)
        {
            // Default points to app location + \Output
            // C:\data\BankStatementScanner
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{filename}"; // TODO - Actual Config file, Default output file location
        }

        /// <summary>
        /// Removes commas, newline, and carriage return from all strings in list of transactions.
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns>"Cleaned" List of Transaction Strings</returns>
        private static List<string> RemoveCommaAndNewlines(List<string> transactions)
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                transactions[i] = transactions[i].Replace("\n", "").Replace("\r", "").Replace(",", "");
            }
            return transactions;
        }

        /// <summary>
        /// Finds the date range of the transactions.
        /// </summary>
        /// <param name="raw">String array input from PDF text extraction.</param>
        /// <returns>List of DateOnly objects representing the range.</returns>
        public static List<DateOnly> FindBillingDate(string[] raw, string key) 
        {
            List<DateOnly> result = new();

            string containsDate = "";

            for (int i = 0; i < raw.Length; i++)
            {

                if (raw[i].Contains(key))
                {
                    if (GetMonth(raw[i]) > 0)
                    {
                        containsDate = raw[i].Replace(key, "").Replace('.', '-').Replace(',', '-').Replace(' ', '-').Replace('!','-');
                        break;
                    }
                    else if (GetMonth(raw[i + 1]) > 0)
                    {
                        containsDate = raw[i + 1].Replace(',', '-').Replace(' ', '-');
                    }
                }
                if (!string.IsNullOrEmpty(containsDate))
                {
                    break;
                }
            }

            string dateRange = TrimHyphens(containsDate);
            int endDateIndex = FindLastDateIndex(dateRange, out DateOnly endDate);

            if (endDateIndex != -1)
            {
                string startDateRaw = dateRange.Remove(endDateIndex).Trim('-');
                int startDateIndex = FindLastDateIndex(startDateRaw, out DateOnly startDate);
                if (startDateIndex >= 0)
                {
                    result.Add(startDate);
                    result.Add(endDate);
                }
                else
                {
                    startDateRaw += "-" + endDate.Year;
                    startDateIndex = FindLastDateIndex(startDateRaw, out startDate);
                    if (startDateIndex >= 0)
                    {
                        result.Add(startDate);
                        result.Add(endDate);
                    }
                    else
                    {
                        return result;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Determines if a string starts with an abbreviated version of a month.
        /// Returns the int value of matching month or 0 if the string doesn't
        /// start with a valid month.
        /// </summary>
        /// <param name="str">String containg Month.</param>
        /// <returns>Int value of Month found in String. 0 if none are found.</returns>
        private static int GetMonth(string str)
        {
            foreach (string month in Months.Keys)
            {
                if (str.Contains(month))
                {
                    return Months[month];
                }
            }
            return 0;
        }

        /// <summary>
        /// Converts every date with 'MM dd' format to MM/dd and adds year. 
        /// </summary>
        /// <param name="transactions">List of strings containing dates to be converted.</param>
        /// <param name="dateRange">Date range for the transactions. Used to add year.</param>
        /// <returns>List of Strings representing Transactions</returns>
        public static List<string> ConvertDateFormat(List<string> transactions, List<DateOnly> dateRange, string oldDateFormat) 
        {
            string startyear = dateRange[0].Year.ToString();
            string endyear = dateRange[1].Year.ToString();

            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Length > oldDateFormat.Length)
                {
                    string tempFormat = oldDateFormat;
                    string oldDate = transactions[i].Remove(oldDateFormat.Length).Trim();
                    string remaining = transactions[i].Substring(oldDateFormat.Length).Trim(); 
                    if (oldDate.Length < oldDateFormat.Length)
                    {
                        tempFormat = oldDateFormat.Remove(oldDateFormat.Length - 1); 
                    }

                    StringBuilder newStringSb = new();

                    if (DateOnly.TryParseExact(oldDate, tempFormat, out DateOnly transDate)) // Parseable 
                    {
                        newStringSb.Append(transDate.ToString("MM/dd/")); // Add start of date.  

                        if (startyear.Equals(endyear)) // If start date and new date have same year.
                        {
                            newStringSb.Append(startyear + ","); // Add year 
                        }
                        else // Not same year
                        {
                            if (dateRange[0].Month <= transDate.Month && transDate.Month <= 12) // If trans month is within start month and the end of the year.
                            {
                                newStringSb.Append(startyear + ",");
                            }
                            else
                            {
                                newStringSb.Append(endyear + ",");
                            }
                        }
                        transactions[i] = newStringSb.Append(remaining).ToString();
                    }
                }
                else
                {
                    continue;
                }
            }

            return transactions;
        }

        /// <summary>
        /// Removes continuous repeated hyphen occurrences in string. 
        /// </summary>
        /// <param name="input">String to be trimmed</param>
        /// <returns>Trimmed String</returns>
        private static string TrimHyphens(string input)
        {
            char[] chars = input.ToCharArray();
            StringBuilder dateRangeSb = new();
            int maxIndex = chars.Length - 1;
            for (int i = 0; i <= maxIndex; i++)
            {
                if (chars[i] == '|')
                {
                    break;
                }

                if (chars[i] != '-') // Problem with hyphen at end of string
                {
                    dateRangeSb.Append(chars[i]);
                } else
                {
                    dateRangeSb.Append('-');
                    while (chars[i + 1] == '-')
                    {
                        i++;
                    }
                }
            }
            string result = dateRangeSb.ToString().Trim('-').Trim();

            return result;
        }

        /// <summary>
        /// Finds the index at which the end date starts. 
        /// </summary>
        /// <param name="dateRange">The string containing start date and end date.</param>
        /// <param name="endDate">The last valid DateOnly instance in string.</param>
        /// <returns>Returns the starting index of date if found. -1 Otherwise.</returns>
        private static int FindLastDateIndex(string dateRange, out DateOnly endDate)
        {
            int startIndex = dateRange.Length - 11;
            if(startIndex < 0)
            {
                return -1;
            }

            for (int i = startIndex; i >= 0; i--)
            {
                string temp = dateRange.Substring(i);
                if (DateOnly.TryParseExact(temp, "MMMM-dd-yyyy", out endDate) || DateOnly.TryParseExact(temp, "MMM-dd-yyyy", out endDate))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Formats the currency amount. Occurs at end of string therefore starts at end of string.
        /// </summary>
        /// <param name="str">String containing a transaction with date, description, and amount.</param>
        /// <returns>Returns the transaction with a comma placed before amount and dollar sign if needed.</returns>
        public static string FormatAmount(string str)
        {
            StringBuilder resultSb = new();
            for (int i = str.Length - 1; i > 1; i--)
            {
                if (48 <= (int)str[i] && (int)str[i] <= 57) // If number
                {
                    if (str[i - 1].Equals('-')) // Minus sign next char
                    {
                        resultSb.Insert(0, str[..i].Trim('-').Trim() + ",-$" + str[i]); // Add dollar sign and minus
                        return resultSb.ToString();
                    }
                    else if (str[i - 1].Equals(' ')) // Space next char
                    {
                        if (!str[i - 2].Equals('-')) // No minus found
                        {
                            resultSb.Insert(0, str[..i].Trim() + ",$" + str[i]);
                        }
                        else // Minus found
                        {
                            resultSb.Insert(0, str[..(i - 1)].Trim('-').Trim() + ",-$" + str[i]);
                        }
                        return resultSb.ToString();
                    }
                    else // Number current, not end of amount.
                    {
                        resultSb.Insert(0, str[i]);
                    }
                }
                else if (str[i].Equals('$')) // If dollar sign
                {
                    if (!str[i - 1].Equals('-') && !str[i - 2].Equals('-')) // No minus sign for next two chars
                    {
                        resultSb.Insert(0, str[..i].Trim() + ",$"); // Add comma
                        return resultSb.ToString();

                    }
                    else if (str[i - 1].Equals('-') || str[i - 2].Equals('-')) // At least one minus sign found in next two chars
                    {
                        resultSb.Insert(0, str[..(i - 1)].Trim('-').Trim() + ",-$"); // Add comma and minus sign
                        return resultSb.ToString();
                    }
                }
                else if (!str[i].Equals('-')) //Do not add Minus sign
                {
                    resultSb.Insert(0, str[i]);
                }
            }
            return resultSb.ToString();
        }

        /// <summary>
        /// Sorts all transaction by their date. Any strings without transactions go to start of the list.
        /// </summary>
        /// <param name="Transactions">List of transaction strings.</param>
        /// <returns>Sorted list of strings by date at start of each string.</returns>
        public static int DateComparable(string str1, string str2) 
        {
            if (str1.Length < 10 || !DateOnly.TryParse(str1.Remove(10), out DateOnly str1date)) str1date = DateOnly.MinValue;
            if (str2.Length < 10 || !DateOnly.TryParse(str2.Remove(10), out DateOnly str2date)) str2date = DateOnly.MinValue;

            if (str1date.Equals(str2date) && str1.Length > 9 && str2.Length > 9)
            {
                return str1[9..].CompareTo(str2[9..]);
            } else if (str1date.Equals(str2date))
            {
                return 0;
            }

            if (str1date.Year == str2date.Year)
            {
                if (str1date.Month == str2date.Month)
                {
                    return str1date.Day.CompareTo(str2date.Day);
                } else
                {
                    return str1date.Month.CompareTo(str2date.Month);
                }
            } else
            {
                return str1date.Year.CompareTo(str2date.Year); 
            }
        }

        /// <summary>
        /// Locates the index of the second comma in string. 
        /// </summary>
        /// <param name="input">Transaction string</param>
        /// <returns>Index of comma</returns>
        public static int SecondCommaIndex(string input)
        {
            short commaCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals(','))
                {
                    commaCount++;
                    if (commaCount == 2)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Add strings in string array after header of transaction table.
        /// </summary>
        /// <param name="raw">Raw extract containing transactions</param>
        /// <param name="startingConditions">String indicating when to start capturing</param>
        /// <param name="stoppingConditions">String indicating when to stop capturing</param>
        /// <param name="exclusions">Strings to be excluded during the capture</param>
        /// <returns></returns>
        public static List<string> GetTransactionData(string[] raw, string[] startingConditions, string[] stoppingConditions, params string[] exclusions) 
        {
            List<string> transactionData = new();
            bool capturing = false;
            foreach (string line in raw)
            {
                if (startingConditions.Any(condition => line.Contains(condition)))
                {
                    capturing = true;
                }
                else if (stoppingConditions.Any(condition => line.Contains(condition)))
                {
                    capturing = false;
                }
                if (capturing && !string.IsNullOrEmpty(line) && !IsException(line, exclusions))
                {
                    transactionData.Add(line);
                }
            }

            transactionData = RemoveCommaAndNewlines(transactionData);

            return transactionData;
        }

        /// <summary>
        /// Handling for exclusions
        /// </summary>
        /// <param name="line">Current line</param>
        /// <param name="exclusions">Strings that indicate if a line should be excluded</param>
        /// <returns></returns>
        private static bool IsException(string line, string[] exclusions)
        {
            return exclusions?.Any(line.Contains) ?? false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="decreasing"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string RemoveUntilSpace(string str, int startIndex, bool deleteSpace = false, bool decreasing = false)
        {
            char[] chars = str.ToCharArray();
            int maxIndex = str.Length - 1;
            int count = 1;
            
            int current;
            if (!decreasing) 
            {
                if (startIndex != maxIndex)
                {
                    current = startIndex + 1;
                } else
                {
                    return str.Remove(startIndex, 1);
                }
            } else
            {
                if(startIndex != 0)
                {
                    current = startIndex - 1;
                } else
                {
                    return str.Remove(startIndex, 1);
                }
            }

            while (current > 0 && current <= maxIndex && chars[current] != ' ')
            {
                count++; 
                if(!decreasing)
                {
                    current++;
                } else
                {
                    current--;
                }
            }

            if (deleteSpace && (count + current) <= maxIndex && current > 0)
            {
                count++;
                current--;
            }

            string result = !decreasing ? str.Remove(startIndex, count) : str.Remove(current + 1, count);
            return result;
        }
    }
}

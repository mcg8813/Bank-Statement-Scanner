using System.Configuration;

namespace BankStatementScannerLibrary.FormHelpers
{
    public static class FormHelpers
    {
        /// <summary>
        /// Returns the full file path to the out folder.
        /// </summary>
        /// <param name="filename">Name of output file</param>
        /// <returns>Full File path. Example: "C:\data\BankStatementScanner\'filename'"</returns>
        public static string FullFilePath(this string filename)
        {
            return $"{ConfigurationManager.AppSettings["OutputPath"]}\\{filename}";
        }

        /// <summary>
        /// Changes the "OutputFolder" attribute's value app settings. 
        /// </summary>
        /// <param name="newFolder">New directory's path</param>
        public static void UpdateOutputFolder(string newFolder)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["OutputPath"].Value = newFolder;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool ValidOutputPath()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string filepath = config.AppSettings.Settings["OutputPath"].Value;
            bool validChars = filepath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            bool pathExists = Directory.Exists(filepath);

            return validChars && pathExists;
        }
    }
}

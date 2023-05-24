using Squirrel;
using System.Configuration;

namespace Bank_Statement_Scanner
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Required for Squirrel. 
            SquirrelAwareApp.HandleEvents();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PdfInput());
        }
    }
}
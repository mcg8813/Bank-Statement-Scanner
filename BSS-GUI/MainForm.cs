using System.Diagnostics;
using System.IO;
using Squirrel.Sources;
using Squirrel;
using System.Configuration;
using System.Text;
using System.Data;
using BankStatementScannerLibrary.FormHelpers;
using BankStatementScannerLibrary.Sorter;

namespace Bank_Statement_Scanner
{
    public partial class MainForm : Form
    {
        public MainForm() // TODO - Add light/dark mode toggle.
        {
            InitializeComponent();
            AddVersionNumber();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            CheckForUpdates();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        /// <summary>
        /// Adds the version number to window title.
        /// </summary>
        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = typeof(MainForm).Assembly;
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text += $" v{versionInfo.FileVersion}";
        }

        /// <summary>
        /// Checks github releases page for newer version and updates if there is.
        /// </summary>
        /// <returns></returns>
        private static async Task CheckForUpdates()
        {
            using var mgr =
                new UpdateManager(new GithubSource(@"https://github.com/mcg8813/Bank-Statement-Scanner", "", false));
            var newVersion = await mgr.UpdateApp();
            if (newVersion != null) UpdateManager.RestartApp();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadButton_Click(object sender, EventArgs e)
        {
            DialogResult = UploadFileDialog.ShowDialog();
            if (DialogResult != DialogResult.OK) return;
            string fileName = UploadFileDialog.FileName;
            string webFilePath = "file:///" + fileName;
            PDFView.Source = new Uri(webFilePath);
            SelectFolderButton.Enabled = true;
            ExtractButton.Enabled = true;
            ConvertButton.Enabled = true;
            ConvertButton.FlatAppearance.BorderColor = Color.Blue;
            ExtractButton.Enabled = true;
            ExtractButton.FlatAppearance.BorderColor = Color.Blue;
            PDFView.Visible = true;
            // Update Input Path
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string useInputPath = config.AppSettings.Settings["UseInputPath"].Value;

            if (useInputPath.Equals("false")) return;
            string? fileDirectory = Path.GetDirectoryName(fileName);

            if (fileDirectory == null) return;
            FormHelpers.UpdateOutputFolder(fileDirectory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetOutputToInput_Click(object sender, EventArgs e)
        {
            string fileName = UploadFileDialog.FileName;
            string? fileDirectory = Path.GetDirectoryName(fileName);

            if (fileDirectory == null) return;
            SelectFolderButton.Enabled = true;
            SelectFolderButton.FlatAppearance.BorderColor = Color.DimGray;
            FormHelpers.UpdateOutputFolder(fileDirectory);
            SetOutputToInput.Enabled = false;
            SetOutputToInput.FlatAppearance.BorderColor = Color.Green;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["UseInputPath"].Value = "true";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult dr = SelectFolderDialog.ShowDialog();
            string folderPath = SelectFolderDialog.SelectedPath;

            if (dr != DialogResult.OK) return;
            SetOutputToInput.Enabled = true;
            SetOutputToInput.FlatAppearance.BorderColor = Color.DimGray;
            FormHelpers.UpdateOutputFolder(folderPath);
            SelectFolderButton.Enabled = false;
            SelectFolderButton.FlatAppearance.BorderColor = Color.Green;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["UseInputPath"].Value = "false";
        }

        private void UpdateTextBoxPath(string filePath) // TODO - Trim path.
        {
            OutputPathBox.Text = filePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractButton_Click(object sender, EventArgs e)
        {
            if (!FormHelpers.ValidOutputPath())
            {
                ErrorProvider.SetError(SelectFolderButton, "Invalid Save Location");
            }
            string? input = UploadFileDialog.FileName;

            if (!UploadFileDialog.CheckFileExists || input == null) return;
            string raw = Sorter.GetFormat(input, true);

            string outputName = Path.GetFileNameWithoutExtension(input) + " Raw_Output.csv";
            string filePath = outputName.FullFilePath();

            File.WriteAllText(filePath, raw);
            UpdateTextBoxPath(filePath);
            ExtractButton.FlatAppearance.BorderColor = Color.DimGray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertButton_Click(object sender, EventArgs e) // TODO - Implement test methods.
        {
            if (!FormHelpers.ValidOutputPath())
            {
                ErrorProvider.SetError(SelectFolderButton, "Invalid Save Location");
            }
            string? input = UploadFileDialog.FileName;

            if (!UploadFileDialog.CheckFileExists || input == null) return;
            string result = Sorter.GetFormat(input);

            string outputName = Path.GetFileNameWithoutExtension(input) + " Output.csv";
            string filePath = outputName.FullFilePath();

            File.WriteAllText(filePath, result);
            BindData(filePath);
            UpdateTextBoxPath(filePath);
            ConvertButton.FlatAppearance.BorderColor = Color.DimGray;
        }

        /// <summary>
        /// Reads output file data into @CSVFilerViewer (GridDataView).
        /// </summary>
        /// <param name="filePath">Output csv filepath.</param>
        private void BindData(string filePath)
        {
            DataTable dt = new();
            string[] lines = File.ReadAllLines(filePath);
            List<string> headerLabels = new() { "Trans Date", "Description", "Amount" };


            if (lines.Length > 0)
            {
                // First line to create header
                // string firstLine = lines[0];
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                //For Data
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        if (columnIndex >= dataWords.Length)
                        {
                            break;
                        }
                        else
                        {
                            dr[headerWord] = dataWords[columnIndex++];
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count <= 0) return;
            CSVTable.DataSource = dt;
            CSVTable.ForeColor = Color.Black;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!FormHelpers.ValidOutputPath())
            {
                ErrorProvider.SetError(SelectFolderButton, "Invalid Save Location");
            }

            if (UploadFileDialog.SafeFileName == null) return;
            string filename = UploadFileDialog.SafeFileName;

            int dotIndex = filename.IndexOf('.');
            string name = filename.Remove(dotIndex);
            string outputFile = name + "Output.csv";
            string filePath = outputFile.FullFilePath();

            StringBuilder sb = new();

            var headers = CSVTable.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in CSVTable.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            string result = sb.ToString();
            File.WriteAllText(filePath, result);
            SaveButton.Enabled = false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CSVTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveButton.Enabled = true;
        }
    }
}

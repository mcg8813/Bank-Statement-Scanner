using BankStatementScannerLibrary.Input;
using System.Configuration;
using System.Data;
using System.Text;
using BankStatementScannerLibrary;
using RestSharp.Extensions;

namespace Bank_Statement_Scanner
{
    public partial class PdfInput : Form
    {
        private static string defaultPath = Properties.Settings.Default.DefaultOutputFolderPath;
        /// <summary>
        /// Initalizes form.
        /// </summary>
        public PdfInput()
        {
            string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.Combine(executableDirectory, "Outputs");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            Properties.Settings.Default.DefaultOutputFolderPath = folderPath;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            InitializeComponent();
        }

        /// <summary>
        /// Enables user to select the PDF needed for extraction. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadButton_Click(object sender, EventArgs e)
        {
            DialogResult = UploadFileDialog.ShowDialog();
            if(DialogResult == DialogResult.OK)
            {
                string webFilePath = "file:///" + UploadFileDialog.FileName;
                webView.Source = new Uri(webFilePath);
                ExtractFormattedButton.Enabled = true;
                ExtractRawButton.Enabled = true;
                webView.Visible = true;
                SetOutputToInput.Enabled = true;
            }
        }

        /// <summary>
        /// Switches to Image input form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageSwitch_Click(object sender, EventArgs e)
        {
            // TODO - (If needed) Image Switch button. 
            ImageInput imageInput = new()
            {
                Location = this.Location
            };
            this.Hide();
            imageInput.Show();
        }

        /// <summary>
        /// Extracts the text data from the selected PDF.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractFormattedButton_Click(object sender, EventArgs e) // TODO - Add tests methods
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["UseDefaultPath"].Value == "false")
            {
                string filepath = config.AppSettings.Settings["OutputFolder"].Value;
                bool possiblePath = filepath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
                if (!possiblePath && string.IsNullOrEmpty(filepath))
                {
                    ErrorProvider.SetError(FolderSelect, "Invalid Save Location");
                    return;
                }
            }

            if (UploadFileDialog.SafeFileName == null) return;
            string filename = UploadFileDialog.SafeFileName;
            string input = UploadFileDialog.FileName;

            int dotIndex = filename.IndexOf('.');
            string name = filename.Remove(dotIndex);

            string outputFile = name + "Output.csv";
            string raw = PdfReader.ExtractPdf(input);
            string filePath = GetPath(outputFile);
            FilePathBox.Text = filePath;
            string[] result = raw.Split("\n");
            string csv = Sorter.GetFormat(result);

            File.WriteAllText(filePath, csv);
            BindData(filePath);
        }

        /// <summary>
        /// Reads output file data into @CSVFilerViewer (GridDataView).
        /// </summary>
        /// <param name="filePath">Output csv filepath.</param>
        private void BindData(string filePath)
        {
            DataTable dt = new();
            string[] lines = File.ReadAllLines(filePath);
            List<string> headerLabels = new(){ "Trans Date", "Description", "Amount" };


            if (lines.Length > 0)
            {
                //first line to create header
                //string firstLine = lines[0];
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
            if (dt.Rows.Count > 0)
            {
                CSVFileViewer.DataSource = dt;
            }

        }

        /// <summary>
        /// Allows user to select folder in which the output file will be placed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderSelect_Click(object sender, EventArgs e)
        {
            SetOutputToInput.Enabled = true;
            DialogResult dr = SelectFolderDialog.ShowDialog();
            string folderPath = SelectFolderDialog.SelectedPath;

            if (dr != DialogResult.OK) return;

            ChangeOutputFolder(folderPath);
            FolderSelect.BackColor = SystemColors.ActiveBorder;
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

            FolderSelect.Enabled = true;
            FolderSelect.BackColor = SystemColors.Control;
            ChangeOutputFolder(fileDirectory);
            SetOutputToInput.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (UploadFileDialog.FileName == null) return;
            string fileName = UploadFileDialog.FileName;
            string outputCsv = fileName + "Output.csv";
            StringBuilder sb = new();

            var headers = CSVFileViewer.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in CSVFileViewer.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            string result = sb.ToString();
            string filepath = GetPath(outputCsv);
            File.WriteAllText(filepath, result);
        }

        private void ExtractRawButton_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["UseDefaultPath"].Value == "false")
            {
                string filepath = config.AppSettings.Settings["OutputFolder"].Value;
                bool possiblePath = filepath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
                if (!possiblePath && string.IsNullOrEmpty(filepath))
                {
                    ErrorProvider.SetError(FolderSelect, "Invalid Save Location");
                    return;
                }
            }

            if (UploadFileDialog.SafeFileName == null) return;
            string filename = UploadFileDialog.SafeFileName;
            string input = UploadFileDialog.FileName;
            int dotIndex = filename.IndexOf('.');
            string name = filename.Remove(dotIndex);
            string rawOutputFile = name + "RawOutput.csv";
            string raw = PdfReader.ExtractPdf(input);
            string filePath = GetPath(rawOutputFile);
            FilePathBox.Text = filePath;
            File.WriteAllText(filePath, raw);
            Console.WriteLine("Extract Complete");
        }

        private static void ChangeOutputFolder(string newFolder)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["OutputFolder"].Value = newFolder;
            config.AppSettings.Settings["UseDefaultPath"].Value = "false";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private static string GetPath(string fileName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.AppSettings.Settings["UseDefaultPath"].Value == "true" ? defaultPath : fileName.FullFilePath();
        }
    }
}
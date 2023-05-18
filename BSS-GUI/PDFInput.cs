using BankStatementScannerLibrary.Input;
using BankStatementScannerLibrary.Input.PDFReader;
using BankStatementScannerLibrary.TextHelpers;
using System.Configuration;
using System.Data;
using System.Text;

namespace Bank_Statement_Scanner
{
    public partial class PDFInput : Form
    {
        /// <summary>
        /// Initalizes form.
        /// </summary>
        public PDFInput()
        {
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
                String webFilePath = "file:///" + UploadFileDialog.FileName;
                webView.Source = new Uri(webFilePath);
                ExtractFormattedButton.Enabled = true;
                ExtractRawButton.Enabled = true;
                webView.Visible = true;
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
            String filepath = config.AppSettings.Settings["filePath"].Value;

            Boolean possiblePath = filepath.IndexOfAny(Path.GetInvalidPathChars()) == -1;

            if (possiblePath && !String.IsNullOrEmpty(filepath))
            {
                String filename = UploadFileDialog.SafeFileName;
                String input = UploadFileDialog.FileName;

                int dotIndex = filename.IndexOf('.');
                String name = filename.Remove(dotIndex);

                String outputFile = name + "Output.csv";
                String raw = PDFReader.ExtractPDF(input);
                FilePathBox.Text = outputFile.FullFilePath();
                String[] Result = raw.Split("\n");
                String csv = Sorter.GetFormat(Result);

                File.WriteAllText(outputFile.FullFilePath(), csv);
                BindData(outputFile.FullFilePath());
            } else
            {
                ErrorProvider.SetError(FolderSelect, "Select Folder");
            }
        }

        /// <summary>
        /// Reads output file data into @CSVFilerViewer (GridDataView).
        /// </summary>
        /// <param name="filePath">Output csv filepath.</param>
        private void BindData(string filePath)
        {
            DataTable dt = new();
            string[] lines = File.ReadAllLines(filePath);
            
            List<String> headerLabels = new(){ "Trans Date", "Description", "Amount" };

            foreach (string line in lines)
            {
                if(line.Contains("Post Date"))
                {
                    headerLabels.Insert(1, "Post Date");
                    break;
                } 
            }

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
            DialogResult dr = SelectFolderDialog.ShowDialog();
            String folderPath = SelectFolderDialog.SelectedPath;
            if(dr == DialogResult.OK)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["filePath"].Value = folderPath;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                ErrorProvider.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        { 
            String filename = UploadFileDialog.SafeFileName;

            int dotIndex = filename.IndexOf('.');
            String Name = filename.Remove(dotIndex);

            String OutputFile = Name + "Output.csv";

            StringBuilder sb = new();

            var headers = CSVFileViewer.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in CSVFileViewer.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            String result = sb.ToString();
            File.WriteAllText(OutputFile.FullFilePath(), result);
        }

        private void ExtractRawButton_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String filepath = config.AppSettings.Settings["filePath"].Value;

            Boolean possiblePath = filepath.IndexOfAny(Path.GetInvalidPathChars()) == -1;

            if (possiblePath && !String.IsNullOrEmpty(filepath))
            {
                String filename = UploadFileDialog.SafeFileName;
                String input = UploadFileDialog.FileName;

                int dotIndex = filename.IndexOf('.');
                String name = filename.Remove(dotIndex);

                String rawOutputFile = name + "RawOutput.csv";
                String raw = PDFReader.ExtractPDF(input);
                FilePathBox.Text = rawOutputFile.FullFilePath();
                File.WriteAllText(rawOutputFile.FullFilePath(), raw);
                Console.WriteLine("Extract Complete");
            }
            else
            {
                ErrorProvider.SetError(FolderSelect, "Select Folder");
            }
        }
    }
}
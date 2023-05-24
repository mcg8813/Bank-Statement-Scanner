using System.IO;
using BankStatementScannerLibrary;
using BankStatementScannerLibrary.Input;

namespace Bank_Statement_Scanner
{
    public partial class ImageInput : Form
    {
        public ImageInput()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            UploadFileDialog.ShowDialog();
        }

        private void BeginScanButton_Click(object sender, EventArgs e)
        {
            string fileName = UploadFileDialog.SafeFileName;
            string input = UploadFileDialog.FileName;
            string name = "";
            foreach(char c in fileName)
            {
                if(!c.Equals('.'))
                {
                    name += c; 
                } else
                {
                    break;
                }
            }
            string outputFile = name + "Output.txt";
            string result = ImageScanner.ProcessImage(input);
            File.WriteAllText(outputFile.FullFilePath(), result);
        }

        private void PDFSwitch_Click(object sender, EventArgs e)
        {
            PdfInput pdfInput = new PdfInput();
            pdfInput.Location = this.Location;
            this.Hide();
            pdfInput.Show();
        }

        private void CSVFileViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

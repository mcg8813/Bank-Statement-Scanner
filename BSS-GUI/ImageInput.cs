using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankStatementScannerLibrary.Input.ImageScanner;
using BankStatementScannerLibrary.TextHelpers;

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
            String FileName = UploadFileDialog.SafeFileName;
            String Input = UploadFileDialog.FileName;
            String Name = "";
            foreach(char c in FileName)
            {
                if(!c.Equals('.'))
                {
                    Name += c; 
                } else
                {
                    break;
                }
            }
            String OutputFile = Name + "Output.txt";
            String Result = ImageScanner.ProcessImage(Input);
            File.WriteAllText(OutputFile.FullFilePath(), Result);
        }

        private void PDFSwitch_Click(object sender, EventArgs e)
        {
            PDFInput PDFInput = new PDFInput();
            PDFInput.Location = this.Location;
            this.Hide();
            PDFInput.Show();
        }

        private void CSVFileViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

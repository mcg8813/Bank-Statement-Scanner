namespace Bank_Statement_Scanner
{
    partial class ImageInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutputLabel = new System.Windows.Forms.Label();
            this.ImageInputLabel = new System.Windows.Forms.Label();
            this.ImageInputViewer = new System.Windows.Forms.PictureBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.ScanProgress = new System.Windows.Forms.ProgressBar();
            this.UploadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PDFSwitch = new System.Windows.Forms.Button();
            this.CSVFileViewer = new System.Windows.Forms.DataGridView();
            this.SaveCSVButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageInputViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSVFileViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OutputLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OutputLabel.Location = new System.Drawing.Point(410, 9);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(73, 24);
            this.OutputLabel.TabIndex = 4;
            this.OutputLabel.Text = "Output";
            // 
            // ImageInputLabel
            // 
            this.ImageInputLabel.AutoSize = true;
            this.ImageInputLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ImageInputLabel.Location = new System.Drawing.Point(10, 10);
            this.ImageInputLabel.Name = "ImageInputLabel";
            this.ImageInputLabel.Size = new System.Drawing.Size(118, 24);
            this.ImageInputLabel.TabIndex = 3;
            this.ImageInputLabel.Text = "Image Input";
            // 
            // ImageInputViewer
            // 
            this.ImageInputViewer.Location = new System.Drawing.Point(10, 40);
            this.ImageInputViewer.Name = "ImageInputViewer";
            this.ImageInputViewer.Size = new System.Drawing.Size(385, 385);
            this.ImageInputViewer.TabIndex = 5;
            this.ImageInputViewer.TabStop = false;
            // 
            // ScanButton
            // 
            this.ScanButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScanButton.Location = new System.Drawing.Point(10, 430);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(75, 25);
            this.ScanButton.TabIndex = 6;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.BeginScanButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.UploadButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UploadButton.Location = new System.Drawing.Point(320, 10);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 25);
            this.UploadButton.TabIndex = 7;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // ScanProgress
            // 
            this.ScanProgress.Location = new System.Drawing.Point(90, 440);
            this.ScanProgress.Name = "ScanProgress";
            this.ScanProgress.Size = new System.Drawing.Size(300, 10);
            this.ScanProgress.TabIndex = 8;
            // 
            // UploadFileDialog
            // 
            this.UploadFileDialog.FileName = "openFileDialog1";
            // 
            // PDFSwitch
            // 
            this.PDFSwitch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PDFSwitch.Location = new System.Drawing.Point(140, 10);
            this.PDFSwitch.Name = "PDFSwitch";
            this.PDFSwitch.Size = new System.Drawing.Size(90, 25);
            this.PDFSwitch.TabIndex = 9;
            this.PDFSwitch.Text = "PDF Input";
            this.PDFSwitch.UseVisualStyleBackColor = true;
            this.PDFSwitch.Click += new System.EventHandler(this.PDFSwitch_Click);
            // 
            // CSVFileViewer
            // 
            this.CSVFileViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CSVFileViewer.Location = new System.Drawing.Point(410, 40);
            this.CSVFileViewer.Name = "CSVFileViewer";
            this.CSVFileViewer.RowTemplate.Height = 25;
            this.CSVFileViewer.Size = new System.Drawing.Size(400, 400);
            this.CSVFileViewer.TabIndex = 10;
            this.CSVFileViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CSVFileViewer_CellContentClick);
            // 
            // SaveCSVButton
            // 
            this.SaveCSVButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveCSVButton.Location = new System.Drawing.Point(735, 10);
            this.SaveCSVButton.Name = "SaveCSVButton";
            this.SaveCSVButton.Size = new System.Drawing.Size(75, 25);
            this.SaveCSVButton.TabIndex = 11;
            this.SaveCSVButton.Text = "Save As...";
            this.SaveCSVButton.UseVisualStyleBackColor = true;
            // 
            // ImageInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(824, 461);
            this.Controls.Add(this.SaveCSVButton);
            this.Controls.Add(this.CSVFileViewer);
            this.Controls.Add(this.PDFSwitch);
            this.Controls.Add(this.ScanProgress);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.ImageInputViewer);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.ImageInputLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ImageInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bank Statement Scanner";
            ((System.ComponentModel.ISupportInitialize)(this.ImageInputViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSVFileViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label OutputLabel;
        private Label ImageInputLabel;
        private PictureBox ImageInputViewer;
        private Button ScanButton;
        private Button UploadButton;
        private ProgressBar ScanProgress;
        private OpenFileDialog UploadFileDialog;
        private Button PDFSwitch;
        private DataGridView CSVFileViewer;
        private Button SaveCSVButton;
    }
}
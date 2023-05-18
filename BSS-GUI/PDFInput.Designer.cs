namespace Bank_Statement_Scanner
{
    partial class PDFInput
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFInput));
            this.PDFInputLabel = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.ExtractFormattedButton = new System.Windows.Forms.Button();
            this.ImageSwitch = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.ScanProgress = new System.Windows.Forms.ProgressBar();
            this.CSVFileViewer = new System.Windows.Forms.DataGridView();
            this.FolderSelect = new System.Windows.Forms.Button();
            this.UploadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SelectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.PreviewsContainer = new System.Windows.Forms.SplitContainer();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.ExtractRawButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CSVFileViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewsContainer)).BeginInit();
            this.PreviewsContainer.Panel1.SuspendLayout();
            this.PreviewsContainer.Panel2.SuspendLayout();
            this.PreviewsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // PDFInputLabel
            // 
            this.PDFInputLabel.AutoSize = true;
            this.PDFInputLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PDFInputLabel.Location = new System.Drawing.Point(10, 10);
            this.PDFInputLabel.Name = "PDFInputLabel";
            this.PDFInputLabel.Size = new System.Drawing.Size(104, 24);
            this.PDFInputLabel.TabIndex = 0;
            this.PDFInputLabel.Text = "PDF Input";
            // 
            // OutputLabel
            // 
            this.OutputLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OutputLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OutputLabel.Location = new System.Drawing.Point(400, 10);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(73, 24);
            this.OutputLabel.TabIndex = 2;
            this.OutputLabel.Text = "Output";
            // 
            // ExtractFormattedButton
            // 
            this.ExtractFormattedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExtractFormattedButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExtractFormattedButton.Enabled = false;
            this.ExtractFormattedButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExtractFormattedButton.Location = new System.Drawing.Point(116, 430);
            this.ExtractFormattedButton.Name = "ExtractFormattedButton";
            this.ExtractFormattedButton.Size = new System.Drawing.Size(121, 25);
            this.ExtractFormattedButton.TabIndex = 7;
            this.ExtractFormattedButton.Text = "Extract Formatted";
            this.ExtractFormattedButton.UseVisualStyleBackColor = false;
            this.ExtractFormattedButton.Click += new System.EventHandler(this.ExtractFormattedButton_Click);
            // 
            // ImageSwitch
            // 
            this.ImageSwitch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ImageSwitch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImageSwitch.Location = new System.Drawing.Point(299, 9);
            this.ImageSwitch.Name = "ImageSwitch";
            this.ImageSwitch.Size = new System.Drawing.Size(90, 25);
            this.ImageSwitch.TabIndex = 8;
            this.ImageSwitch.Text = "Image Input";
            this.ImageSwitch.UseVisualStyleBackColor = false;
            this.ImageSwitch.Visible = false;
            this.ImageSwitch.Click += new System.EventHandler(this.ImageSwitch_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UploadButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.UploadButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UploadButton.Location = new System.Drawing.Point(120, 9);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 25);
            this.UploadButton.TabIndex = 9;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // ScanProgress
            // 
            this.ScanProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ScanProgress.Location = new System.Drawing.Point(243, 439);
            this.ScanProgress.Name = "ScanProgress";
            this.ScanProgress.Size = new System.Drawing.Size(146, 10);
            this.ScanProgress.TabIndex = 10;
            // 
            // CSVFileViewer
            // 
            this.CSVFileViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CSVFileViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CSVFileViewer.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.CSVFileViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CSVFileViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSVFileViewer.Location = new System.Drawing.Point(0, 0);
            this.CSVFileViewer.Name = "CSVFileViewer";
            this.CSVFileViewer.RowTemplate.Height = 25;
            this.CSVFileViewer.Size = new System.Drawing.Size(398, 387);
            this.CSVFileViewer.TabIndex = 11;
            // 
            // FolderSelect
            // 
            this.FolderSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderSelect.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FolderSelect.Location = new System.Drawing.Point(707, 9);
            this.FolderSelect.Name = "FolderSelect";
            this.FolderSelect.Size = new System.Drawing.Size(85, 25);
            this.FolderSelect.TabIndex = 12;
            this.FolderSelect.Text = "Select Folder";
            this.FolderSelect.UseVisualStyleBackColor = true;
            this.FolderSelect.Click += new System.EventHandler(this.FolderSelect_Click);
            // 
            // UploadFileDialog
            // 
            this.UploadFileDialog.Filter = "pdf files (*.pdf)|*.pdf";
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(380, 387);
            this.webView.Source = new System.Uri("https://microsoft.com", System.UriKind.Absolute);
            this.webView.TabIndex = 13;
            this.webView.Visible = false;
            this.webView.ZoomFactor = 1D;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(717, 430);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PreviewsContainer
            // 
            this.PreviewsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewsContainer.Location = new System.Drawing.Point(10, 37);
            this.PreviewsContainer.Name = "PreviewsContainer";
            // 
            // PreviewsContainer.Panel1
            // 
            this.PreviewsContainer.Panel1.Controls.Add(this.webView);
            // 
            // PreviewsContainer.Panel2
            // 
            this.PreviewsContainer.Panel2.Controls.Add(this.CSVFileViewer);
            this.PreviewsContainer.Size = new System.Drawing.Size(782, 387);
            this.PreviewsContainer.SplitterDistance = 380;
            this.PreviewsContainer.TabIndex = 15;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // FilePathBox
            // 
            this.FilePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePathBox.BackColor = System.Drawing.SystemColors.Window;
            this.FilePathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilePathBox.Location = new System.Drawing.Point(395, 433);
            this.FilePathBox.MinimumSize = new System.Drawing.Size(317, 16);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.ReadOnly = true;
            this.FilePathBox.Size = new System.Drawing.Size(317, 16);
            this.FilePathBox.TabIndex = 16;
            // 
            // ExtractRawButton
            // 
            this.ExtractRawButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExtractRawButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExtractRawButton.Enabled = false;
            this.ExtractRawButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExtractRawButton.Location = new System.Drawing.Point(10, 430);
            this.ExtractRawButton.Name = "ExtractRawButton";
            this.ExtractRawButton.Size = new System.Drawing.Size(100, 25);
            this.ExtractRawButton.TabIndex = 17;
            this.ExtractRawButton.Text = "Extract Raw";
            this.ExtractRawButton.UseVisualStyleBackColor = false;
            this.ExtractRawButton.Click += new System.EventHandler(this.ExtractRawButton_Click);
            // 
            // PDFInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.ExtractRawButton);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.PreviewsContainer);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.FolderSelect);
            this.Controls.Add(this.ScanProgress);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.ImageSwitch);
            this.Controls.Add(this.ExtractFormattedButton);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.PDFInputLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "PDFInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bank Statement Scanner";
            ((System.ComponentModel.ISupportInitialize)(this.CSVFileViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.PreviewsContainer.Panel1.ResumeLayout(false);
            this.PreviewsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewsContainer)).EndInit();
            this.PreviewsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label PDFInputLabel;
        private Label OutputLabel;
        private Button ExtractFormattedButton;
        private Button ImageSwitch;
        private Button UploadButton;
        private ProgressBar ScanProgress;
        private DataGridView CSVFileViewer;
        private Button FolderSelect;
        private OpenFileDialog UploadFileDialog;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Button SaveButton;
        private FolderBrowserDialog SelectFolderDialog;
        private SplitContainer PreviewsContainer;
        private ErrorProvider ErrorProvider;
        private TextBox FilePathBox;
        private Button ExtractRawButton;
    }
}
namespace Bank_Statement_Scanner
{
    partial class PdfInput
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfInput));
            PDFInputLabel = new Label();
            OutputLabel = new Label();
            ExtractFormattedButton = new Button();
            ImageSwitch = new Button();
            UploadButton = new Button();
            CSVFileViewer = new DataGridView();
            FolderSelect = new Button();
            UploadFileDialog = new OpenFileDialog();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            SaveButton = new Button();
            SelectFolderDialog = new FolderBrowserDialog();
            PreviewsContainer = new SplitContainer();
            ErrorProvider = new ErrorProvider(components);
            FilePathBox = new TextBox();
            ExtractRawButton = new Button();
            SetOutputToInput = new Button();
            ((System.ComponentModel.ISupportInitialize)CSVFileViewer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviewsContainer).BeginInit();
            PreviewsContainer.Panel1.SuspendLayout();
            PreviewsContainer.Panel2.SuspendLayout();
            PreviewsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // PDFInputLabel
            // 
            PDFInputLabel.AutoSize = true;
            PDFInputLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            PDFInputLabel.Location = new Point(10, 10);
            PDFInputLabel.Name = "PDFInputLabel";
            PDFInputLabel.Size = new Size(104, 24);
            PDFInputLabel.TabIndex = 0;
            PDFInputLabel.Text = "PDF Input";
            // 
            // OutputLabel
            // 
            OutputLabel.Anchor = AnchorStyles.Top;
            OutputLabel.AutoSize = true;
            OutputLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            OutputLabel.ForeColor = SystemColors.ControlText;
            OutputLabel.Location = new Point(400, 10);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(73, 24);
            OutputLabel.TabIndex = 2;
            OutputLabel.Text = "Output";
            // 
            // ExtractFormattedButton
            // 
            ExtractFormattedButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ExtractFormattedButton.BackColor = SystemColors.ControlLightLight;
            ExtractFormattedButton.Enabled = false;
            ExtractFormattedButton.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ExtractFormattedButton.Location = new Point(12, 430);
            ExtractFormattedButton.Name = "ExtractFormattedButton";
            ExtractFormattedButton.Size = new Size(144, 25);
            ExtractFormattedButton.TabIndex = 7;
            ExtractFormattedButton.Text = "Extract Formatted";
            ExtractFormattedButton.UseVisualStyleBackColor = false;
            ExtractFormattedButton.Click += ExtractFormattedButton_Click;
            // 
            // ImageSwitch
            // 
            ImageSwitch.BackColor = SystemColors.ControlLightLight;
            ImageSwitch.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ImageSwitch.Location = new Point(201, 9);
            ImageSwitch.Name = "ImageSwitch";
            ImageSwitch.Size = new Size(90, 25);
            ImageSwitch.TabIndex = 8;
            ImageSwitch.Text = "Image Input";
            ImageSwitch.UseVisualStyleBackColor = false;
            ImageSwitch.Visible = false;
            ImageSwitch.Click += ImageSwitch_Click;
            // 
            // UploadButton
            // 
            UploadButton.AutoSize = true;
            UploadButton.BackColor = SystemColors.ControlLightLight;
            UploadButton.DialogResult = DialogResult.No;
            UploadButton.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            UploadButton.Location = new Point(120, 9);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(75, 25);
            UploadButton.TabIndex = 9;
            UploadButton.Text = "Upload";
            UploadButton.UseVisualStyleBackColor = false;
            UploadButton.Click += UploadButton_Click;
            // 
            // CSVFileViewer
            // 
            CSVFileViewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            CSVFileViewer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            CSVFileViewer.BackgroundColor = SystemColors.ActiveBorder;
            CSVFileViewer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CSVFileViewer.Dock = DockStyle.Fill;
            CSVFileViewer.Location = new Point(0, 0);
            CSVFileViewer.Name = "CSVFileViewer";
            CSVFileViewer.RowTemplate.Height = 25;
            CSVFileViewer.Size = new Size(398, 387);
            CSVFileViewer.TabIndex = 11;
            // 
            // FolderSelect
            // 
            FolderSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FolderSelect.AutoSize = true;
            FolderSelect.BackColor = Color.White;
            FolderSelect.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FolderSelect.Location = new Point(694, 9);
            FolderSelect.Name = "FolderSelect";
            FolderSelect.Size = new Size(98, 25);
            FolderSelect.TabIndex = 12;
            FolderSelect.Text = "Select Folder";
            FolderSelect.UseVisualStyleBackColor = false;
            FolderSelect.Click += FolderSelect_Click;
            // 
            // UploadFileDialog
            // 
            UploadFileDialog.Filter = "pdf files (*.pdf)|*.pdf";
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Dock = DockStyle.Fill;
            webView.Location = new Point(0, 0);
            webView.Name = "webView";
            webView.Size = new Size(380, 387);
            webView.Source = new Uri("https://microsoft.com", UriKind.Absolute);
            webView.TabIndex = 13;
            webView.Visible = false;
            webView.ZoomFactor = 1D;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            SaveButton.Location = new Point(717, 430);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 14;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // PreviewsContainer
            // 
            PreviewsContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PreviewsContainer.Location = new Point(10, 37);
            PreviewsContainer.Name = "PreviewsContainer";
            // 
            // PreviewsContainer.Panel1
            // 
            PreviewsContainer.Panel1.Controls.Add(webView);
            // 
            // PreviewsContainer.Panel2
            // 
            PreviewsContainer.Panel2.Controls.Add(CSVFileViewer);
            PreviewsContainer.Size = new Size(782, 387);
            PreviewsContainer.SplitterDistance = 380;
            PreviewsContainer.TabIndex = 15;
            // 
            // ErrorProvider
            // 
            ErrorProvider.ContainerControl = this;
            // 
            // FilePathBox
            // 
            FilePathBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            FilePathBox.BackColor = SystemColors.Window;
            FilePathBox.BorderStyle = BorderStyle.None;
            FilePathBox.Location = new Point(395, 433);
            FilePathBox.MinimumSize = new Size(317, 16);
            FilePathBox.Name = "FilePathBox";
            FilePathBox.ReadOnly = true;
            FilePathBox.Size = new Size(317, 16);
            FilePathBox.TabIndex = 16;
            FilePathBox.TextAlign = HorizontalAlignment.Right;
            // 
            // ExtractRawButton
            // 
            ExtractRawButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ExtractRawButton.BackColor = SystemColors.ControlLightLight;
            ExtractRawButton.Enabled = false;
            ExtractRawButton.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ExtractRawButton.Location = new Point(162, 430);
            ExtractRawButton.Name = "ExtractRawButton";
            ExtractRawButton.Size = new Size(100, 25);
            ExtractRawButton.TabIndex = 17;
            ExtractRawButton.Text = "Extract Raw";
            ExtractRawButton.UseVisualStyleBackColor = false;
            ExtractRawButton.Visible = false;
            ExtractRawButton.Click += ExtractRawButton_Click;
            // 
            // SetOutputToInput
            // 
            SetOutputToInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SetOutputToInput.AutoSize = true;
            SetOutputToInput.Enabled = false;
            SetOutputToInput.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            SetOutputToInput.Location = new Point(598, 9);
            SetOutputToInput.Name = "SetOutputToInput";
            SetOutputToInput.Size = new Size(90, 25);
            SetOutputToInput.TabIndex = 18;
            SetOutputToInput.Text = "Set To Input";
            SetOutputToInput.UseVisualStyleBackColor = true;
            SetOutputToInput.Click += SetOutputToInput_Click;
            // 
            // PdfInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 461);
            Controls.Add(SetOutputToInput);
            Controls.Add(ExtractRawButton);
            Controls.Add(FilePathBox);
            Controls.Add(PreviewsContainer);
            Controls.Add(SaveButton);
            Controls.Add(FolderSelect);
            Controls.Add(UploadButton);
            Controls.Add(ImageSwitch);
            Controls.Add(ExtractFormattedButton);
            Controls.Add(OutputLabel);
            Controls.Add(PDFInputLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(820, 500);
            Name = "PdfInput";
            StartPosition = FormStartPosition.Manual;
            Text = "Bank Statement Scanner";
            ((System.ComponentModel.ISupportInitialize)CSVFileViewer).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            PreviewsContainer.Panel1.ResumeLayout(false);
            PreviewsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PreviewsContainer).EndInit();
            PreviewsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PDFInputLabel;
        private Label OutputLabel;
        private Button ExtractFormattedButton;
        private Button ImageSwitch;
        private Button UploadButton;
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
        private Button SetOutputToInput;
    }
}
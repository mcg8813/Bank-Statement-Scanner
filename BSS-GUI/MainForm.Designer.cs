namespace Bank_Statement_Scanner
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainSplitContainer = new SplitContainer();
            UploadButton = new Button();
            InputLabel = new Label();
            PDFView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ExtractButton = new Button();
            ConvertButton = new Button();
            SetOutputToInput = new Button();
            SelectFolderButton = new Button();
            SaveButton = new Button();
            OutputPathBox = new TextBox();
            CSVTable = new DataGridView();
            OutputLabel = new Label();
            UploadFileDialog = new OpenFileDialog();
            SelectFolderDialog = new FolderBrowserDialog();
            ErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PDFView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CSVTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.Location = new Point(0, 0);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(UploadButton);
            MainSplitContainer.Panel1.Controls.Add(InputLabel);
            MainSplitContainer.Panel1.Controls.Add(PDFView);
            MainSplitContainer.Panel1MinSize = 470;
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.Controls.Add(ExtractButton);
            MainSplitContainer.Panel2.Controls.Add(ConvertButton);
            MainSplitContainer.Panel2.Controls.Add(SetOutputToInput);
            MainSplitContainer.Panel2.Controls.Add(SelectFolderButton);
            MainSplitContainer.Panel2.Controls.Add(SaveButton);
            MainSplitContainer.Panel2.Controls.Add(OutputPathBox);
            MainSplitContainer.Panel2.Controls.Add(CSVTable);
            MainSplitContainer.Panel2.Controls.Add(OutputLabel);
            MainSplitContainer.Panel2MinSize = 470;
            MainSplitContainer.Size = new Size(944, 501);
            MainSplitContainer.SplitterDistance = 470;
            MainSplitContainer.TabIndex = 0;
            // 
            // UploadButton
            // 
            UploadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UploadButton.BackColor = Color.FromArgb(56, 56, 56);
            UploadButton.FlatAppearance.BorderColor = Color.DimGray;
            UploadButton.FlatStyle = FlatStyle.Flat;
            UploadButton.Location = new Point(392, 5);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(75, 25);
            UploadButton.TabIndex = 6;
            UploadButton.Text = "Upload";
            UploadButton.UseVisualStyleBackColor = false;
            UploadButton.Click += UploadButton_Click;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.World);
            InputLabel.ForeColor = Color.White;
            InputLabel.Location = new Point(5, 5);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(68, 26);
            InputLabel.TabIndex = 1;
            InputLabel.Text = "Input";
            // 
            // PDFView
            // 
            PDFView.AllowExternalDrop = true;
            PDFView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PDFView.CreationProperties = null;
            PDFView.DefaultBackgroundColor = Color.White;
            PDFView.Location = new Point(3, 36);
            PDFView.Name = "PDFView";
            PDFView.Size = new Size(464, 462);
            PDFView.TabIndex = 0;
            PDFView.Visible = false;
            PDFView.ZoomFactor = 1D;
            // 
            // ExtractButton
            // 
            ExtractButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExtractButton.BackColor = Color.FromArgb(56, 56, 56);
            ExtractButton.Enabled = false;
            ExtractButton.FlatAppearance.BorderColor = Color.DimGray;
            ExtractButton.FlatStyle = FlatStyle.Flat;
            ExtractButton.Location = new Point(322, 5);
            ExtractButton.Name = "ExtractButton";
            ExtractButton.Size = new Size(65, 25);
            ExtractButton.TabIndex = 7;
            ExtractButton.Text = "Extract";
            ExtractButton.UseVisualStyleBackColor = false;
            ExtractButton.Visible = false;
            ExtractButton.Click += ExtractButton_Click;
            // 
            // ConvertButton
            // 
            ConvertButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ConvertButton.BackColor = Color.FromArgb(56, 56, 56);
            ConvertButton.Enabled = false;
            ConvertButton.FlatAppearance.BorderColor = Color.DimGray;
            ConvertButton.FlatStyle = FlatStyle.Flat;
            ConvertButton.Location = new Point(393, 5);
            ConvertButton.Name = "ConvertButton";
            ConvertButton.Size = new Size(65, 25);
            ConvertButton.TabIndex = 6;
            ConvertButton.Text = "Convert";
            ConvertButton.UseVisualStyleBackColor = false;
            ConvertButton.Click += ConvertButton_Click;
            // 
            // SetOutputToInput
            // 
            SetOutputToInput.BackColor = Color.FromArgb(56, 56, 56);
            SetOutputToInput.Enabled = false;
            SetOutputToInput.FlatAppearance.BorderColor = Color.Green;
            SetOutputToInput.FlatStyle = FlatStyle.Flat;
            SetOutputToInput.Location = new Point(102, 5);
            SetOutputToInput.Name = "SetOutputToInput";
            SetOutputToInput.Size = new Size(80, 25);
            SetOutputToInput.TabIndex = 5;
            SetOutputToInput.Text = "Set to Input";
            SetOutputToInput.UseVisualStyleBackColor = false;
            SetOutputToInput.Click += SetOutputToInput_Click;
            // 
            // SelectFolderButton
            // 
            SelectFolderButton.BackColor = Color.FromArgb(56, 56, 56);
            SelectFolderButton.Enabled = false;
            SelectFolderButton.FlatAppearance.BorderColor = Color.DimGray;
            SelectFolderButton.FlatStyle = FlatStyle.Flat;
            SelectFolderButton.Location = new Point(188, 5);
            SelectFolderButton.Name = "SelectFolderButton";
            SelectFolderButton.Size = new Size(85, 25);
            SelectFolderButton.TabIndex = 4;
            SelectFolderButton.Text = "Select Folder";
            SelectFolderButton.UseVisualStyleBackColor = false;
            SelectFolderButton.Click += SelectFolder_Click;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SaveButton.BackColor = Color.FromArgb(56, 56, 56);
            SaveButton.Enabled = false;
            SaveButton.FlatAppearance.BorderColor = Color.DimGray;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.Location = new Point(393, 36);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(65, 25);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // OutputPathBox
            // 
            OutputPathBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            OutputPathBox.BackColor = Color.FromArgb(46, 46, 46);
            OutputPathBox.BorderStyle = BorderStyle.FixedSingle;
            OutputPathBox.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.World);
            OutputPathBox.ForeColor = Color.White;
            OutputPathBox.Location = new Point(5, 36);
            OutputPathBox.Name = "OutputPathBox";
            OutputPathBox.ReadOnly = true;
            OutputPathBox.Size = new Size(382, 25);
            OutputPathBox.TabIndex = 2;
            // 
            // CSVTable
            // 
            CSVTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CSVTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CSVTable.Location = new Point(5, 67);
            CSVTable.Name = "CSVTable";
            CSVTable.RowTemplate.Height = 25;
            CSVTable.Size = new Size(453, 431);
            CSVTable.TabIndex = 1;
            CSVTable.CellContentClick += CSVTable_CellContentClick;
            // 
            // OutputLabel
            // 
            OutputLabel.AutoSize = true;
            OutputLabel.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.World);
            OutputLabel.ForeColor = Color.White;
            OutputLabel.Location = new Point(5, 5);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(86, 26);
            OutputLabel.TabIndex = 0;
            OutputLabel.Text = "Output";
            // 
            // UploadFileDialog
            // 
            UploadFileDialog.FileName = "openFileDialog1";
            // 
            // ErrorProvider
            // 
            ErrorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(944, 501);
            Controls.Add(MainSplitContainer);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(960, 540);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bank Statement Scanner";
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel1.PerformLayout();
            MainSplitContainer.Panel2.ResumeLayout(false);
            MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PDFView).EndInit();
            ((System.ComponentModel.ISupportInitialize)CSVTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer MainSplitContainer;
        private Label InputLabel;
        private Label OutputLabel;
        private Microsoft.Web.WebView2.WinForms.WebView2 PDFView;
        private DataGridView CSVTable;
        private Button UploadButton;
        private Button SetOutputToInput;
        private Button SelectFolderButton;
        private Button ExtractButton;
        private Button ConvertButton;
        private Button SaveButton;
        private TextBox OutputPathBox;
        private OpenFileDialog UploadFileDialog;
        private FolderBrowserDialog SelectFolderDialog;
        private ErrorProvider ErrorProvider;
    }
}
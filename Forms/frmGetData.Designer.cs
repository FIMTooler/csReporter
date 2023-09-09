namespace csReporter
{
    partial class frmGetData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetData));
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.btnShowExamples = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbDataSelection = new System.Windows.Forms.GroupBox();
            this.cbSystem = new System.Windows.Forms.CheckBox();
            this.rbImportError = new System.Windows.Forms.RadioButton();
            this.rbExportError = new System.Windows.Forms.RadioButton();
            this.rbExport = new System.Windows.Forms.RadioButton();
            this.rbImport = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.cbbMAs = new System.Windows.Forms.ComboBox();
            this.lblMAname = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbGenerate = new System.Windows.Forms.RadioButton();
            this.ofdCSfile = new System.Windows.Forms.OpenFileDialog();
            this.sfdReport = new System.Windows.Forms.SaveFileDialog();
            this.gbSource.SuspendLayout();
            this.gbDataSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.btnShowExamples);
            this.gbSource.Controls.Add(this.btnGenerate);
            this.gbSource.Controls.Add(this.gbDataSelection);
            this.gbSource.Controls.Add(this.cbbMAs);
            this.gbSource.Controls.Add(this.lblMAname);
            this.gbSource.Controls.Add(this.tbFile);
            this.gbSource.Controls.Add(this.btnOpenFile);
            this.gbSource.Controls.Add(this.rbFile);
            this.gbSource.Controls.Add(this.rbGenerate);
            this.gbSource.Location = new System.Drawing.Point(18, 17);
            this.gbSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSource.Name = "gbSource";
            this.gbSource.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSource.Size = new System.Drawing.Size(992, 382);
            this.gbSource.TabIndex = 0;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Report Source";
            // 
            // btnShowExamples
            // 
            this.btnShowExamples.Location = new System.Drawing.Point(590, 309);
            this.btnShowExamples.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowExamples.Name = "btnShowExamples";
            this.btnShowExamples.Size = new System.Drawing.Size(112, 57);
            this.btnShowExamples.TabIndex = 9;
            this.btnShowExamples.Text = "csexport examples";
            this.btnShowExamples.UseVisualStyleBackColor = true;
            this.btnShowExamples.Click += new System.EventHandler(this.btnShowExamples_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(831, 83);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(136, 32);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate File";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // gbDataSelection
            // 
            this.gbDataSelection.Controls.Add(this.cbSystem);
            this.gbDataSelection.Controls.Add(this.rbImportError);
            this.gbDataSelection.Controls.Add(this.rbExportError);
            this.gbDataSelection.Controls.Add(this.rbExport);
            this.gbDataSelection.Controls.Add(this.rbImport);
            this.gbDataSelection.Controls.Add(this.rbAll);
            this.gbDataSelection.Enabled = false;
            this.gbDataSelection.Location = new System.Drawing.Point(614, 40);
            this.gbDataSelection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDataSelection.Name = "gbDataSelection";
            this.gbDataSelection.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDataSelection.Size = new System.Drawing.Size(195, 213);
            this.gbDataSelection.TabIndex = 7;
            this.gbDataSelection.TabStop = false;
            this.gbDataSelection.Text = "Data Selection";
            // 
            // cbSystem
            // 
            this.cbSystem.AutoSize = true;
            this.cbSystem.Location = new System.Drawing.Point(46, 179);
            this.cbSystem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSystem.Name = "cbSystem";
            this.cbSystem.Size = new System.Drawing.Size(112, 22);
            this.cbSystem.TabIndex = 6;
            this.cbSystem.Text = "System Data";
            this.cbSystem.UseVisualStyleBackColor = true;
            this.cbSystem.CheckedChanged += new System.EventHandler(this.cbSystem_CheckedChanged);
            // 
            // rbImportError
            // 
            this.rbImportError.AutoSize = true;
            this.rbImportError.Location = new System.Drawing.Point(45, 145);
            this.rbImportError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbImportError.Name = "rbImportError";
            this.rbImportError.Size = new System.Drawing.Size(114, 22);
            this.rbImportError.TabIndex = 5;
            this.rbImportError.TabStop = true;
            this.rbImportError.Text = "Import Errors";
            this.rbImportError.UseVisualStyleBackColor = true;
            // 
            // rbExportError
            // 
            this.rbExportError.AutoSize = true;
            this.rbExportError.Location = new System.Drawing.Point(45, 114);
            this.rbExportError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbExportError.Name = "rbExportError";
            this.rbExportError.Size = new System.Drawing.Size(115, 22);
            this.rbExportError.TabIndex = 4;
            this.rbExportError.TabStop = true;
            this.rbExportError.Text = "Export Errors";
            this.rbExportError.UseVisualStyleBackColor = true;
            // 
            // rbExport
            // 
            this.rbExport.AutoSize = true;
            this.rbExport.Location = new System.Drawing.Point(46, 82);
            this.rbExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbExport.Name = "rbExport";
            this.rbExport.Size = new System.Drawing.Size(69, 22);
            this.rbExport.TabIndex = 3;
            this.rbExport.TabStop = true;
            this.rbExport.Text = "Export";
            this.rbExport.UseVisualStyleBackColor = true;
            // 
            // rbImport
            // 
            this.rbImport.AutoSize = true;
            this.rbImport.Location = new System.Drawing.Point(46, 50);
            this.rbImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbImport.Name = "rbImport";
            this.rbImport.Size = new System.Drawing.Size(68, 22);
            this.rbImport.TabIndex = 2;
            this.rbImport.TabStop = true;
            this.rbImport.Text = "Import";
            this.rbImport.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(46, 19);
            this.rbAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(41, 22);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // cbbMAs
            // 
            this.cbbMAs.Enabled = false;
            this.cbbMAs.FormattingEnabled = true;
            this.cbbMAs.Location = new System.Drawing.Point(112, 86);
            this.cbbMAs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbMAs.Name = "cbbMAs";
            this.cbbMAs.Size = new System.Drawing.Size(307, 26);
            this.cbbMAs.TabIndex = 6;
            // 
            // lblMAname
            // 
            this.lblMAname.AutoSize = true;
            this.lblMAname.Location = new System.Drawing.Point(62, 91);
            this.lblMAname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMAname.Name = "lblMAname";
            this.lblMAname.Size = new System.Drawing.Size(38, 18);
            this.lblMAname.TabIndex = 5;
            this.lblMAname.Text = "MAs";
            // 
            // tbFile
            // 
            this.tbFile.Enabled = false;
            this.tbFile.Location = new System.Drawing.Point(66, 324);
            this.tbFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(354, 24);
            this.tbFile.TabIndex = 4;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Enabled = false;
            this.btnOpenFile.Location = new System.Drawing.Point(430, 320);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(112, 32);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Select File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(36, 285);
            this.rbFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(382, 22);
            this.rbFile.TabIndex = 0;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "Provide existing file  (made using one of the examples)";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // rbGenerate
            // 
            this.rbGenerate.AutoSize = true;
            this.rbGenerate.Location = new System.Drawing.Point(36, 40);
            this.rbGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbGenerate.Name = "rbGenerate";
            this.rbGenerate.Size = new System.Drawing.Size(514, 22);
            this.rbGenerate.TabIndex = 1;
            this.rbGenerate.TabStop = true;
            this.rbGenerate.Text = "Generate file  (must be running on MIM Sync or Azure AD Connect Server)";
            this.rbGenerate.UseVisualStyleBackColor = true;
            this.rbGenerate.CheckedChanged += new System.EventHandler(this.rbGenerate_CheckedChanged);
            // 
            // ofdCSfile
            // 
            this.ofdCSfile.DefaultExt = "xml";
            this.ofdCSfile.Filter = "XML Files (.xml)|*.xml";
            // 
            // sfdReport
            // 
            this.sfdReport.DefaultExt = "html";
            this.sfdReport.Filter = "xml files (*.xml)|*.xml";
            // 
            // frmGetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 415);
            this.Controls.Add(this.gbSource);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmGetData";
            this.Text = "Get Data";
            this.VisibleChanged += new System.EventHandler(this.frmGetData_VisibleChanged);
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.gbDataSelection.ResumeLayout(false);
            this.gbDataSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.RadioButton rbGenerate;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog ofdCSfile;
        private System.Windows.Forms.Label lblMAname;
        private System.Windows.Forms.ComboBox cbbMAs;
        private System.Windows.Forms.GroupBox gbDataSelection;
        private System.Windows.Forms.RadioButton rbExport;
        private System.Windows.Forms.RadioButton rbImport;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.SaveFileDialog sfdReport;
        private System.Windows.Forms.RadioButton rbImportError;
        private System.Windows.Forms.RadioButton rbExportError;
        private System.Windows.Forms.Button btnShowExamples;
        private System.Windows.Forms.CheckBox cbSystem;
    }
}
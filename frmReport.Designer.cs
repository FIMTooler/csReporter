namespace csReporter
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.lbAttribute = new System.Windows.Forms.ListBox();
            this.gbFormat = new System.Windows.Forms.GroupBox();
            this.rbCSV = new System.Windows.Forms.RadioButton();
            this.rbHTML = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbExcel = new System.Windows.Forms.RadioButton();
            this.gbFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbAttribute
            // 
            this.lbAttribute.FormattingEnabled = true;
            this.lbAttribute.ItemHeight = 16;
            this.lbAttribute.Location = new System.Drawing.Point(16, 15);
            this.lbAttribute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbAttribute.Name = "lbAttribute";
            this.lbAttribute.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAttribute.Size = new System.Drawing.Size(241, 388);
            this.lbAttribute.Sorted = true;
            this.lbAttribute.TabIndex = 5;
            // 
            // gbFormat
            // 
            this.gbFormat.Controls.Add(this.rbExcel);
            this.gbFormat.Controls.Add(this.rbCSV);
            this.gbFormat.Controls.Add(this.rbHTML);
            this.gbFormat.Location = new System.Drawing.Point(279, 15);
            this.gbFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFormat.Name = "gbFormat";
            this.gbFormat.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFormat.Size = new System.Drawing.Size(117, 149);
            this.gbFormat.TabIndex = 6;
            this.gbFormat.TabStop = false;
            this.gbFormat.Text = "Format";
            // 
            // rbCSV
            // 
            this.rbCSV.AutoSize = true;
            this.rbCSV.Location = new System.Drawing.Point(20, 76);
            this.rbCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCSV.Name = "rbCSV";
            this.rbCSV.Size = new System.Drawing.Size(56, 21);
            this.rbCSV.TabIndex = 1;
            this.rbCSV.TabStop = true;
            this.rbCSV.Text = "CSV";
            this.rbCSV.UseVisualStyleBackColor = true;
            // 
            // rbHTML
            // 
            this.rbHTML.AutoSize = true;
            this.rbHTML.Location = new System.Drawing.Point(20, 36);
            this.rbHTML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbHTML.Name = "rbHTML";
            this.rbHTML.Size = new System.Drawing.Size(67, 21);
            this.rbHTML.TabIndex = 0;
            this.rbHTML.TabStop = true;
            this.rbHTML.Text = "HTML";
            this.rbHTML.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(73, 428);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 31);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 428);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 31);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbExcel
            // 
            this.rbExcel.AutoSize = true;
            this.rbExcel.Location = new System.Drawing.Point(20, 120);
            this.rbExcel.Margin = new System.Windows.Forms.Padding(4);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(62, 21);
            this.rbExcel.TabIndex = 2;
            this.rbExcel.TabStop = true;
            this.rbExcel.Text = "Excel";
            this.rbExcel.UseVisualStyleBackColor = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 479);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbFormat);
            this.Controls.Add(this.lbAttribute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReport";
            this.Text = "Report Settings";
            this.gbFormat.ResumeLayout(false);
            this.gbFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbAttribute;
        private System.Windows.Forms.GroupBox gbFormat;
        private System.Windows.Forms.RadioButton rbCSV;
        private System.Windows.Forms.RadioButton rbHTML;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbExcel;
    }
}
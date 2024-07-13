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
            this.rbExcel = new System.Windows.Forms.RadioButton();
            this.rbCSV = new System.Windows.Forms.RadioButton();
            this.rbHTML = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbLayout = new System.Windows.Forms.GroupBox();
            this.rbVertical = new System.Windows.Forms.RadioButton();
            this.rbHorizontal = new System.Windows.Forms.RadioButton();
            this.lblSelectAttributes = new System.Windows.Forms.Label();
            this.gbFilterCriteria = new System.Windows.Forms.GroupBox();
            this.cbFilterCriteria = new System.Windows.Forms.CheckBox();
            this.gbFontSize = new System.Windows.Forms.GroupBox();
            this.cbbFontSize = new System.Windows.Forms.ComboBox();
            this.rbFullList = new System.Windows.Forms.RadioButton();
            this.rbNetChange = new System.Windows.Forms.RadioButton();
            this.gbMultiValue = new System.Windows.Forms.GroupBox();
            this.gbFormat.SuspendLayout();
            this.gbLayout.SuspendLayout();
            this.gbFilterCriteria.SuspendLayout();
            this.gbFontSize.SuspendLayout();
            this.gbMultiValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbAttribute
            // 
            this.lbAttribute.FormattingEnabled = true;
            this.lbAttribute.ItemHeight = 18;
            this.lbAttribute.Location = new System.Drawing.Point(18, 35);
            this.lbAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.lbAttribute.Name = "lbAttribute";
            this.lbAttribute.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAttribute.Size = new System.Drawing.Size(529, 418);
            this.lbAttribute.Sorted = true;
            this.lbAttribute.TabIndex = 5;
            // 
            // gbFormat
            // 
            this.gbFormat.Controls.Add(this.rbExcel);
            this.gbFormat.Controls.Add(this.rbCSV);
            this.gbFormat.Controls.Add(this.rbHTML);
            this.gbFormat.Location = new System.Drawing.Point(555, 135);
            this.gbFormat.Margin = new System.Windows.Forms.Padding(4);
            this.gbFormat.Name = "gbFormat";
            this.gbFormat.Padding = new System.Windows.Forms.Padding(4);
            this.gbFormat.Size = new System.Drawing.Size(132, 129);
            this.gbFormat.TabIndex = 6;
            this.gbFormat.TabStop = false;
            this.gbFormat.Text = "Format";
            // 
            // rbExcel
            // 
            this.rbExcel.AutoSize = true;
            this.rbExcel.Location = new System.Drawing.Point(9, 96);
            this.rbExcel.Margin = new System.Windows.Forms.Padding(4);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(62, 22);
            this.rbExcel.TabIndex = 2;
            this.rbExcel.TabStop = true;
            this.rbExcel.Text = "Excel";
            this.rbExcel.UseVisualStyleBackColor = true;
            this.rbExcel.CheckedChanged += new System.EventHandler(this.rbExcel_CheckedChanged);
            // 
            // rbCSV
            // 
            this.rbCSV.AutoSize = true;
            this.rbCSV.Location = new System.Drawing.Point(9, 64);
            this.rbCSV.Margin = new System.Windows.Forms.Padding(4);
            this.rbCSV.Name = "rbCSV";
            this.rbCSV.Size = new System.Drawing.Size(56, 22);
            this.rbCSV.TabIndex = 1;
            this.rbCSV.TabStop = true;
            this.rbCSV.Text = "CSV";
            this.rbCSV.UseVisualStyleBackColor = true;
            // 
            // rbHTML
            // 
            this.rbHTML.AutoSize = true;
            this.rbHTML.Location = new System.Drawing.Point(9, 30);
            this.rbHTML.Margin = new System.Windows.Forms.Padding(4);
            this.rbHTML.Name = "rbHTML";
            this.rbHTML.Size = new System.Drawing.Size(67, 22);
            this.rbHTML.TabIndex = 0;
            this.rbHTML.TabStop = true;
            this.rbHTML.Text = "HTML";
            this.rbHTML.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(82, 482);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 35);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(248, 482);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 35);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbLayout
            // 
            this.gbLayout.Controls.Add(this.rbVertical);
            this.gbLayout.Controls.Add(this.rbHorizontal);
            this.gbLayout.Location = new System.Drawing.Point(555, 335);
            this.gbLayout.Margin = new System.Windows.Forms.Padding(4);
            this.gbLayout.Name = "gbLayout";
            this.gbLayout.Padding = new System.Windows.Forms.Padding(4);
            this.gbLayout.Size = new System.Drawing.Size(132, 101);
            this.gbLayout.TabIndex = 7;
            this.gbLayout.TabStop = false;
            this.gbLayout.Text = "Layout";
            this.gbLayout.Visible = false;
            // 
            // rbVertical
            // 
            this.rbVertical.AutoSize = true;
            this.rbVertical.Location = new System.Drawing.Point(9, 64);
            this.rbVertical.Margin = new System.Windows.Forms.Padding(4);
            this.rbVertical.Name = "rbVertical";
            this.rbVertical.Size = new System.Drawing.Size(74, 22);
            this.rbVertical.TabIndex = 1;
            this.rbVertical.TabStop = true;
            this.rbVertical.Text = "Vertical";
            this.rbVertical.UseVisualStyleBackColor = true;
            // 
            // rbHorizontal
            // 
            this.rbHorizontal.AutoSize = true;
            this.rbHorizontal.Location = new System.Drawing.Point(9, 32);
            this.rbHorizontal.Margin = new System.Windows.Forms.Padding(4);
            this.rbHorizontal.Name = "rbHorizontal";
            this.rbHorizontal.Size = new System.Drawing.Size(94, 22);
            this.rbHorizontal.TabIndex = 0;
            this.rbHorizontal.TabStop = true;
            this.rbHorizontal.Text = "Horizontal";
            this.rbHorizontal.UseVisualStyleBackColor = true;
            // 
            // lblSelectAttributes
            // 
            this.lblSelectAttributes.AutoSize = true;
            this.lblSelectAttributes.Location = new System.Drawing.Point(18, 15);
            this.lblSelectAttributes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectAttributes.Name = "lblSelectAttributes";
            this.lblSelectAttributes.Size = new System.Drawing.Size(239, 18);
            this.lblSelectAttributes.TabIndex = 28;
            this.lblSelectAttributes.Text = "Select Attributes to include in report";
            // 
            // gbFilterCriteria
            // 
            this.gbFilterCriteria.Controls.Add(this.cbFilterCriteria);
            this.gbFilterCriteria.Location = new System.Drawing.Point(555, 272);
            this.gbFilterCriteria.Margin = new System.Windows.Forms.Padding(4);
            this.gbFilterCriteria.Name = "gbFilterCriteria";
            this.gbFilterCriteria.Padding = new System.Windows.Forms.Padding(4);
            this.gbFilterCriteria.Size = new System.Drawing.Size(132, 55);
            this.gbFilterCriteria.TabIndex = 8;
            this.gbFilterCriteria.TabStop = false;
            this.gbFilterCriteria.Text = "Filter Criteria";
            // 
            // cbFilterCriteria
            // 
            this.cbFilterCriteria.AutoSize = true;
            this.cbFilterCriteria.Location = new System.Drawing.Point(10, 24);
            this.cbFilterCriteria.Name = "cbFilterCriteria";
            this.cbFilterCriteria.Size = new System.Drawing.Size(73, 22);
            this.cbFilterCriteria.TabIndex = 29;
            this.cbFilterCriteria.Text = "Include";
            this.cbFilterCriteria.UseVisualStyleBackColor = true;
            // 
            // gbFontSize
            // 
            this.gbFontSize.Controls.Add(this.cbbFontSize);
            this.gbFontSize.Location = new System.Drawing.Point(555, 444);
            this.gbFontSize.Margin = new System.Windows.Forms.Padding(4);
            this.gbFontSize.Name = "gbFontSize";
            this.gbFontSize.Padding = new System.Windows.Forms.Padding(4);
            this.gbFontSize.Size = new System.Drawing.Size(132, 59);
            this.gbFontSize.TabIndex = 8;
            this.gbFontSize.TabStop = false;
            this.gbFontSize.Text = "Font Size";
            this.gbFontSize.Visible = false;
            // 
            // cbbFontSize
            // 
            this.cbbFontSize.FormattingEnabled = true;
            this.cbbFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.cbbFontSize.Location = new System.Drawing.Point(9, 24);
            this.cbbFontSize.Name = "cbbFontSize";
            this.cbbFontSize.Size = new System.Drawing.Size(67, 26);
            this.cbbFontSize.TabIndex = 29;
            // 
            // rbFullList
            // 
            this.rbFullList.AutoSize = true;
            this.rbFullList.Location = new System.Drawing.Point(9, 64);
            this.rbFullList.Margin = new System.Windows.Forms.Padding(4);
            this.rbFullList.Name = "rbFullList";
            this.rbFullList.Size = new System.Drawing.Size(76, 22);
            this.rbFullList.TabIndex = 1;
            this.rbFullList.TabStop = true;
            this.rbFullList.Text = "Full List";
            this.rbFullList.UseVisualStyleBackColor = true;
            // 
            // rbNetChange
            // 
            this.rbNetChange.AutoSize = true;
            this.rbNetChange.Location = new System.Drawing.Point(9, 32);
            this.rbNetChange.Margin = new System.Windows.Forms.Padding(4);
            this.rbNetChange.Name = "rbNetChange";
            this.rbNetChange.Size = new System.Drawing.Size(104, 22);
            this.rbNetChange.TabIndex = 0;
            this.rbNetChange.TabStop = true;
            this.rbNetChange.Text = "Net Change";
            this.rbNetChange.UseVisualStyleBackColor = true;
            // 
            // gbMultiValue
            // 
            this.gbMultiValue.Controls.Add(this.rbFullList);
            this.gbMultiValue.Controls.Add(this.rbNetChange);
            this.gbMultiValue.Location = new System.Drawing.Point(555, 26);
            this.gbMultiValue.Margin = new System.Windows.Forms.Padding(4);
            this.gbMultiValue.Name = "gbMultiValue";
            this.gbMultiValue.Padding = new System.Windows.Forms.Padding(4);
            this.gbMultiValue.Size = new System.Drawing.Size(132, 101);
            this.gbMultiValue.TabIndex = 29;
            this.gbMultiValue.TabStop = false;
            this.gbMultiValue.Text = "Multi-Value";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 539);
            this.Controls.Add(this.gbMultiValue);
            this.Controls.Add(this.gbFontSize);
            this.Controls.Add(this.gbFilterCriteria);
            this.Controls.Add(this.lblSelectAttributes);
            this.Controls.Add(this.gbLayout);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbFormat);
            this.Controls.Add(this.lbAttribute);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReport";
            this.Text = "Report Settings";
            this.gbFormat.ResumeLayout(false);
            this.gbFormat.PerformLayout();
            this.gbLayout.ResumeLayout(false);
            this.gbLayout.PerformLayout();
            this.gbFilterCriteria.ResumeLayout(false);
            this.gbFilterCriteria.PerformLayout();
            this.gbFontSize.ResumeLayout(false);
            this.gbMultiValue.ResumeLayout(false);
            this.gbMultiValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAttribute;
        private System.Windows.Forms.GroupBox gbFormat;
        private System.Windows.Forms.RadioButton rbCSV;
        private System.Windows.Forms.RadioButton rbHTML;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbExcel;
        private System.Windows.Forms.GroupBox gbLayout;
        private System.Windows.Forms.RadioButton rbVertical;
        private System.Windows.Forms.RadioButton rbHorizontal;
        private System.Windows.Forms.Label lblSelectAttributes;
        private System.Windows.Forms.GroupBox gbFilterCriteria;
        private System.Windows.Forms.CheckBox cbFilterCriteria;
        private System.Windows.Forms.GroupBox gbFontSize;
        private System.Windows.Forms.ComboBox cbbFontSize;
        private System.Windows.Forms.RadioButton rbFullList;
        private System.Windows.Forms.RadioButton rbNetChange;
        private System.Windows.Forms.GroupBox gbMultiValue;
    }
}
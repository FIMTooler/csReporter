namespace csReporter
{
    partial class frmCSExamples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSExamples));
            this.lblExportInfo = new System.Windows.Forms.Label();
            this.lblExampleHeader = new System.Windows.Forms.Label();
            this.rtbDocumentation = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblExportInfo
            // 
            this.lblExportInfo.AutoSize = true;
            this.lblExportInfo.Font = new System.Drawing.Font("Lucida Console", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportInfo.Location = new System.Drawing.Point(18, 83);
            this.lblExportInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExportInfo.Name = "lblExportInfo";
            this.lblExportInfo.Size = new System.Drawing.Size(998, 418);
            this.lblExportInfo.TabIndex = 2;
            this.lblExportInfo.Text = resources.GetString("lblExportInfo.Text");
            // 
            // lblExampleHeader
            // 
            this.lblExampleHeader.AutoSize = true;
            this.lblExampleHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExampleHeader.Location = new System.Drawing.Point(18, 35);
            this.lblExampleHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExampleHeader.Name = "lblExampleHeader";
            this.lblExampleHeader.Size = new System.Drawing.Size(211, 26);
            this.lblExampleHeader.TabIndex = 3;
            this.lblExampleHeader.Text = "csexport examples";
            // 
            // rtbDocumentation
            // 
            this.rtbDocumentation.BackColor = System.Drawing.SystemColors.Control;
            this.rtbDocumentation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDocumentation.Font = new System.Drawing.Font("Lucida Console", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDocumentation.Location = new System.Drawing.Point(22, 450);
            this.rtbDocumentation.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDocumentation.Multiline = false;
            this.rtbDocumentation.Name = "rtbDocumentation";
            this.rtbDocumentation.ReadOnly = true;
            this.rtbDocumentation.Size = new System.Drawing.Size(966, 33);
            this.rtbDocumentation.TabIndex = 4;
            this.rtbDocumentation.Text = "https://docs.microsoft.com/en-us/previous-versions/mim/jj590346(v=ws.10)";
            this.rtbDocumentation.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbDocumentation_LinkClicked);
            // 
            // frmCSExamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 500);
            this.Controls.Add(this.rtbDocumentation);
            this.Controls.Add(this.lblExampleHeader);
            this.Controls.Add(this.lblExportInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCSExamples";
            this.Text = "Examples";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExportInfo;
        private System.Windows.Forms.Label lblExampleHeader;
        private System.Windows.Forms.RichTextBox rtbDocumentation;
    }
}
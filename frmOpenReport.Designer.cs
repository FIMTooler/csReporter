namespace csReporter
{
    partial class frmOpenReport
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
            this.lblOpenReport = new System.Windows.Forms.Label();
            this.btnOpenReport = new System.Windows.Forms.Button();
            this.btnOpenReportFolder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOpenReport
            // 
            this.lblOpenReport.AutoSize = true;
            this.lblOpenReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblOpenReport.Location = new System.Drawing.Point(25, 18);
            this.lblOpenReport.Name = "lblOpenReport";
            this.lblOpenReport.Size = new System.Drawing.Size(364, 18);
            this.lblOpenReport.TabIndex = 0;
            this.lblOpenReport.Text = "Would you like to open the report or containing folder?";
            // 
            // btnOpenReport
            // 
            this.btnOpenReport.Location = new System.Drawing.Point(28, 52);
            this.btnOpenReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenReport.Name = "btnOpenReport";
            this.btnOpenReport.Size = new System.Drawing.Size(94, 35);
            this.btnOpenReport.TabIndex = 13;
            this.btnOpenReport.Text = "Open Report";
            this.btnOpenReport.UseVisualStyleBackColor = true;
            this.btnOpenReport.Click += new System.EventHandler(this.btnOpenReport_Click);
            // 
            // btnOpenReportFolder
            // 
            this.btnOpenReportFolder.Location = new System.Drawing.Point(159, 52);
            this.btnOpenReportFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenReportFolder.Name = "btnOpenReportFolder";
            this.btnOpenReportFolder.Size = new System.Drawing.Size(108, 35);
            this.btnOpenReportFolder.TabIndex = 14;
            this.btnOpenReportFolder.Text = "Open Report Folder";
            this.btnOpenReportFolder.UseVisualStyleBackColor = true;
            this.btnOpenReportFolder.Click += new System.EventHandler(this.btnOpenReportFolder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(316, 52);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 35);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmOpenReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 102);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenReportFolder);
            this.Controls.Add(this.btnOpenReport);
            this.Controls.Add(this.lblOpenReport);
            this.Name = "frmOpenReport";
            this.Text = "frmOpenReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOpenReport;
        private System.Windows.Forms.Button btnOpenReport;
        private System.Windows.Forms.Button btnOpenReportFolder;
        private System.Windows.Forms.Button btnCancel;
    }
}
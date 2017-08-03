using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csReporter
{
    public partial class frmReport : Form
    {

        public frmReport(List<string>availableAttributes)
        {
            InitializeComponent();
            lbAttribute.Items.AddRange(availableAttributes.ToArray());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rbCSV.Checked && !rbHTML.Checked)
                {
                    MessageBox.Show("You must choose a report format.", "Report format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                frmFilter parent = (frmFilter)this.Owner;
                if (lbAttribute.SelectedItems.Count == 0)
                {
                    parent.SetReportAttributes(lbAttribute.Items.Cast<string>().ToList());
                }
                else
                {
                    parent.SetReportAttributes(lbAttribute.SelectedItems.Cast<string>().ToList());
                }
                switch (rbCSV.Checked)
                {
                    case true:
                        parent.SetReportType(true);
                        break;
                    default:
                        parent.SetReportType(false);
                        break;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHandler.handleException(ex, "Error occurred while getting report details.");
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

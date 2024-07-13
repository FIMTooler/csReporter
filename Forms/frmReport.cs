﻿/*
MIT License

Copyright (c) 2017 David Cassady

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

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
                if (!rbCSV.Checked && !rbHTML.Checked && !rbExcel.Checked)
                {
                    MessageBox.Show("You must choose a report format.", "Report format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                frmFilter parent = (frmFilter)this.Owner;
                parent.SetReportIncludeFilter(cbFilterCriteria.Checked);
                if (lbAttribute.SelectedItems.Count == 0)
                {
                    parent.SetReportAttributes(lbAttribute.Items.Cast<string>().ToList());
                }
                else
                {
                    parent.SetReportAttributes(lbAttribute.SelectedItems.Cast<string>().ToList());
                }
                if (rbCSV.Checked)
                {
                    parent.SetReportType(reportType.CSV);
                }
                else if (rbHTML.Checked)
                {
                    parent.SetReportType(reportType.HTML);
                }
                else
                {
                    if (!rbHorizontal.Checked && !rbVertical.Checked)
                    {
                        MessageBox.Show("You must choose a report layout.", "Report layout", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    parent.SetReportType(reportType.Excel);
                    if (rbHorizontal.Checked)
                    {
                        parent.SetReportLayout(true);
                    }
                    else
                    {
                        parent.SetReportLayout(false);
                    }
                    if (cbbFontSize.SelectedItem == null)
                    {
                        MessageBox.Show("You must choose a font size.", "Font Size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    parent.SetReportFontSize(int.Parse(cbbFontSize.SelectedItem.ToString()));
                }
                if (!rbNetChange.Checked && !rbFullList.Checked)
                {
                    MessageBox.Show("You must choose how to display mutli-value attributes in the report.", "Multi-Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (rbNetChange.Checked)
                {
                    parent.SetMultivalueBehavior(false);
                }
                else
                {
                    parent.SetMultivalueBehavior(true);
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

        private void rbExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExcel.Checked)
            {
                gbLayout.Visible = true;
                gbFontSize.Visible = true;
            }
            else
            {
                gbLayout.Visible = false;
                gbFontSize.Visible = false;
            }
        }
    }
}

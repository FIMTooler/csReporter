using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace csReporter
{
    public partial class frmProgressBar : Form
    {

        //Graphics percentage;
        bool closing;

        public frmProgressBar()
        {
            InitializeComponent();

            //percentage = pbProcessing.CreateGraphics();
            closing = false;
        }
        
        public void updateBar(int val)
        {
            if (!closing)
            {
                pbProcessing.Value = val;
                lblProgress.Text = val.ToString() + "%";
            }
        }

        public void setLblText(string val)
        {
            lblAction.Text = val;
        }


        private void frmProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                frmFilter.stopProcessing = true;
            }
            closing = true;
        }
    }
}

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
    public partial class frmError : Form
    {
        public frmError(string errorBanner, string errorMessage)
        {
            InitializeComponent();
            errorBanner = errorBanner.Replace(".  ", ".\r\n");
            tbErrorBanner.Text = errorBanner;
            Size bannerSize = TextRenderer.MeasureText(tbErrorBanner.Text, tbErrorBanner.Font);
            if (bannerSize.Width < tbErrorBanner.ClientSize.Width)
            {
                bannerSize.Width = tbErrorBanner.ClientSize.Width;
            }
            tbErrorBanner.ClientSize = new Size(bannerSize.Width, bannerSize.Height);


            tbErrorInfo.Text = errorMessage;
            Size textSize = TextRenderer.MeasureText(tbErrorInfo.Text, tbErrorInfo.Font);
            tbErrorInfo.ClientSize = new Size(bannerSize.Width, textSize.Height);
            bool needSB = tbErrorInfo.ClientSize.Width < textSize.Width;
            if (needSB)
            {
                tbErrorInfo.ScrollBars = ScrollBars.Vertical;
            }
        }
    }
}

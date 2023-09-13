using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RZZReader
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public void setBar(int bar)
        {
            progressBarLoading.Maximum = bar;
        }

        public void setProgress(int n)
        {
            progressBarLoading.Value = n;
            this.Text = "Loading...   (" + n.ToString() + "/" + progressBarLoading.Maximum.ToString() + ")";
        }

        private void FormLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotifyIcon notifyIcon = this.Tag as NotifyIcon;
            notifyIcon.Visible = true;
        }
    }
}

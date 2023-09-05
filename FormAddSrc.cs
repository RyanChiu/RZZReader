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
    public partial class FormAddSrc : Form
    {
        public FormAddSrc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public string GetUrl()
        {
            return textBoxURL.Text;
        }

        public string GetPwd()
        {
            return textBoxURL.Text;
        }

        public void setPwdMode()
        {
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            textBoxURL.UseSystemPasswordChar = true;
            this.Text = "Pin, please...";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBoxURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

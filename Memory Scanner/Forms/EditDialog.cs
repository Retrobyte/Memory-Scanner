using Memory_Scanner.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Scanner.Forms
{
    public partial class EditDialog : Form
    {
        public EditDialog()
        {
            InitializeComponent();
        }

        private void valueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                okButton.PerformClick();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valueTextBox.Text))
            {
                MessageBox.Show("Input value cannot be empty.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.isIntDouble(valueTextBox.Text))
            {
                MessageBox.Show("Input value contains invalid characters.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        public string Value
        {
            get
            {
                return valueTextBox.Text;
            }
        }
    }
}

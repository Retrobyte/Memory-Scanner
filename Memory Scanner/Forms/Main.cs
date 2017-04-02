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
    public partial class Main : Form
    {
        private int _currentId;
        private MemorySearch _ms;

        public Main()
        {
            InitializeComponent();

            _currentId = -1;
            _ms = new MemorySearch();

            _ms.setProgressEvent(progressUpdate);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dataTypeComboBox.SelectedIndex = 0;
        }

        private void selectProcessButton_Click(object sender, EventArgs e)
        {
            using (ProcessDialog pd = new ProcessDialog(_currentId))
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    _currentId = pd.SelectedProcessID;
                    selectedProcessValueLabel.Text = pd.SelectedProcessName;

                    _ms.openProcess(_currentId);
                    firstScanButton.Enabled = true;
                }
            }
        }

        private void firstScanButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dataValueTextBox.Text))
            {
                MessageBox.Show("Input value cannot be empty.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.isIntDouble(dataValueTextBox.Text))
            {
                MessageBox.Show("Input value contains invalid characters.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] scanValue;

            switch (dataTypeComboBox.SelectedIndex)
            {
                case 0:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToInt16(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Int16.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 1:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToInt32(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Int32.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 2:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToInt64(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Int64.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 3:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToSingle(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be a Float.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 4:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToDouble(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Double.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                default:
                    MessageBox.Show("An unknown error occurred.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            nextScanButton.Enabled = true;
            _ms.firstScan(scanValue, completeScan);
        }

        private void nextScanButton_Click(object sender, EventArgs e)
        {
            searchProgressBar.Value = 0;

            if (string.IsNullOrEmpty(dataValueTextBox.Text))
            {

                MessageBox.Show("Input value cannot be empty.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.isIntDouble(dataValueTextBox.Text))
            {
                MessageBox.Show("Input value contains invalid characters.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] scanValue;

            switch (dataTypeComboBox.SelectedIndex)
            {
                case 0:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToInt16(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Int16.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 1:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToInt32(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Int32.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 2:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToInt64(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Int64.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 3:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToSingle(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be a Float.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case 4:
                    try
                    {
                        scanValue = BitConverter.GetBytes(Convert.ToDouble(dataValueTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Input value is too large or too small to be an Double.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                default:
                    MessageBox.Show("An unknown error occurred.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            _ms.nextScan(scanValue, completeScan);
        }

        private void resultsMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = resultsListView.SelectedItems.Count == 0;
        }

        private void editValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditDialog ed = new EditDialog())
            {
                if (ed.ShowDialog() == DialogResult.OK)
                {
                    byte[] setValue;

                    switch (dataTypeComboBox.SelectedIndex)
                    {
                        case 0:
                            try
                            {
                                setValue = BitConverter.GetBytes(Convert.ToInt16(ed.Value));
                            }
                            catch
                            {
                                MessageBox.Show("Input value is too large or too small to be an Int16.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        case 1:
                            try
                            {
                                setValue = BitConverter.GetBytes(Convert.ToInt32(ed.Value));
                            }
                            catch
                            {
                                MessageBox.Show("Input value is too large or too small to be an Int32.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        case 2:
                            try
                            {
                                setValue = BitConverter.GetBytes(Convert.ToInt64(ed.Value));
                            }
                            catch
                            {
                                MessageBox.Show("Input value is too large or too small to be an Int64.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        case 3:
                            try
                            {
                                setValue = BitConverter.GetBytes(Convert.ToSingle(ed.Value));
                            }
                            catch
                            {
                                MessageBox.Show("Input value is too large or too small to be a Float.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        case 4:
                            try
                            {
                                setValue = BitConverter.GetBytes(Convert.ToDouble(ed.Value));
                            }
                            catch
                            {
                                MessageBox.Show("Input value is too large or too small to be an Double.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        default:
                            MessageBox.Show("An unknown error occurred.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    foreach (ListViewItem l in resultsListView.SelectedItems)
                    {
                        SearchResult sr = ((SearchResult)l.Tag);

                        sr.Buffer = setValue;
                        _ms.writeMemory(sr.Address, setValue);
                        l.SubItems[1].Text = convertBuffer(setValue, dataTypeComboBox.SelectedIndex);
                    }
                }
            }
        }

        private void progressUpdate(int amount)
        {
            searchProgressBar.Value = amount;
        }

        private void completeScan()
        {
            resultsListView.Items.Clear();

            foreach (SearchResult sr in _ms.Results)
                resultsListView.Items.Add(new ListViewItem(new string[] { padAddress(sr.Address.ToString("X")), convertBuffer(sr.Buffer, dataTypeComboBox.SelectedIndex) }) { Tag = sr });
        }

        private string padAddress(string address)
        {
            if (address.Length == 8)
                return address;

            string ret = string.Empty;

            for (int i = address.Length; i < 8; i++)
                ret += "0";

            return ret + address;
        }

        private string convertBuffer(byte[] buff, int convert)
        {
            switch (convert)
            {
                case 0:
                    return BitConverter.ToInt16(buff, 0).ToString();
                case 1:
                    return BitConverter.ToInt32(buff, 0).ToString();
                case 2:
                    return BitConverter.ToInt64(buff, 0).ToString();
                case 3:
                    return BitConverter.ToSingle(buff, 0).ToString();
                case 4:
                    return BitConverter.ToDouble(buff, 0).ToString();
            }

            return string.Empty;
        }
    }
}

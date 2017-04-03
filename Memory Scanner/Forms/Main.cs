using Memory_Scanner.Classes;
using System;
using System.ComponentModel;
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
            //Is Search Box Empty and doesn't contain invalid characters?
            if (ValidateSearchInput(dataValueTextBox.Text))
            {
                return;
            }

            nextScanButton.Enabled = true;
            _ms.firstScan(GetInputBytes(dataValueTextBox.Text), completeScan);
        }

        private void nextScanButton_Click(object sender, EventArgs e)
        {
            searchProgressBar.Value = 0;

            //Is Search Box Empty and doesn't contain invalid characters?
            if (ValidateSearchInput(dataValueTextBox.Text))
            {
                return;
            }

            _ms.nextScan(GetInputBytes(dataValueTextBox.Text), completeScan);
        }

        private void resultsMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = resultsListView.SelectedItems.Count == 0;
        }

        private void editValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditDialog mEditDialog = new EditDialog())
            {
                if (mEditDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] setValue = GetInputBytes(mEditDialog.Value);

                    foreach (ListViewItem mListViewItem in resultsListView.SelectedItems)
                    {
                        SearchResult mSearchResult = ((SearchResult)mListViewItem.Tag);

                        mSearchResult.Buffer = setValue;
                        _ms.writeMemory(mSearchResult.Address, setValue);
                        mListViewItem.SubItems[1].Text = convertBuffer(setValue, dataTypeComboBox.SelectedIndex);
                    }
                }
            }
        }

        private void progressUpdate(int amount)
        {
            //todo Hack need to fix root cause of this error
            // error is Value is going above 100
            if (!((searchProgressBar.Value + amount) > 100))
                searchProgressBar.Value = amount;
            else
                searchProgressBar.Value = 100;
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


        private bool ValidateSearchInput(string value)
        {
            if (ContainsInvalidCharacters(value))
            {
                return true;
            }
            else if (SearchBoxIsEmpty(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ContainsInvalidCharacters(string value)
        {
            if (!Validator.isIntDouble(value))
            {
                MessageBox.Show("Input value contains invalid characters.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private bool SearchBoxIsEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Input value cannot be empty.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private byte[] GetInt16Bytes(string value)
        {
            try
            {
                return BitConverter.GetBytes(Convert.ToInt16(value));
            }
            catch
            {
                MessageBox.Show("Input value is too large or too small to be an Int16.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[0];
            }
        }

        private byte[] GetInt32Bytes(string value)
        {
            try
            {
                return BitConverter.GetBytes(Convert.ToInt32(value));
            }
            catch
            {
                MessageBox.Show("Input value is too large or too small to be an Int32.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[0];
            }
        }
        private byte[] GetInt64Bytes(string value)
        {
            try
            {
                return BitConverter.GetBytes(Convert.ToInt64(value));
            }
            catch
            {
                MessageBox.Show("Input value is too large or too small to be an Int64.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[0];
            }
        }
        private byte[] GetFloatBytes(string value)
        {
            try
            {
                return BitConverter.GetBytes(Convert.ToSingle(value));
            }
            catch
            {
                MessageBox.Show("Input value is too large or too small to be a Float.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[0];
            }
        }
        private byte[] GetDoubleBytes(string value)
        {
            try
            {
                return BitConverter.GetBytes(Convert.ToInt32(dataValueTextBox.Text));
            }
            catch
            {
                MessageBox.Show("Input value is too large or too small to be a Double.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[0];
            }
        }

        private byte[] GetInputBytes(string value)
        {
            Byte[] scanValue;

            switch (dataTypeComboBox.SelectedIndex)
            {
                case 0:
                    scanValue = GetInt16Bytes(value);
                    break;
                case 1:
                    scanValue = GetInt32Bytes(value);
                    break;
                case 2:
                    scanValue = GetInt64Bytes(value);
                    break;
                case 3:
                    scanValue = GetFloatBytes(value);
                    break;
                case 4:
                    scanValue = GetDoubleBytes(value);
                    break;
                default:
                    MessageBox.Show("An unknown error occurred.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new Byte[0];
            }

            return scanValue;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Scanner.Forms
{
    public partial class ProcessDialog : Form
    {
        public ProcessDialog(int currentId)
        {
            InitializeComponent();
            loadProcessList();

            if (currentId != -1 && processListView.Items.ContainsKey(currentId.ToString()))
                processListView.Items[currentId.ToString()].BackColor = Color.Yellow;
        }

        private void loadProcessList()
        {
            foreach (Process p in Process.GetProcesses())
                processListView.Items.Add(new ListViewItem(new string[] { p.ProcessName, p.Id.ToString() }) { Name = p.Id.ToString() });
        }

        private void processListView_DoubleClick(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count == 1 && processListView.SelectedItems[0].BackColor != Color.Yellow)
                DialogResult = DialogResult.OK;
        }

        public string SelectedProcessName
        {
            get
            {
                return processListView.SelectedItems[0].Text;
            }
        }

        public int SelectedProcessID
        {
            get
            {
                return Convert.ToInt32(processListView.SelectedItems[0].SubItems[1].Text);
            }
        }
    }
}

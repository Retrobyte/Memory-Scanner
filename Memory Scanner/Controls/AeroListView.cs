using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Scanner.Controls
{
    public class AeroListView : ListView
    {
        [DllImport("uxtheme", CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

        public AeroListView()
        {
            HandleCreated += AeroListView_HandleCreated;

            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DoubleBuffered = true;
            FullRowSelect = true;
            MultiSelect = true;
            View = System.Windows.Forms.View.Details;
        }

        private void AeroListView_HandleCreated(object sender, System.EventArgs e)
        {
            SetWindowTheme(this.Handle, "explorer", null);
        }
    }
}

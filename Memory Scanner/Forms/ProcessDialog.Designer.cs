namespace Memory_Scanner.Forms
{
    partial class ProcessDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processListView = new Memory_Scanner.Controls.AeroListView();
            this.processNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_FillLol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // processListView
            // 
            this.processListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processNameHeader,
            this.processIdHeader});
            this.processListView.FullRowSelect = true;
            this.processListView.HideSelection = false;
            this.processListView.Location = new System.Drawing.Point(12, 12);
            this.processListView.MultiSelect = false;
            this.processListView.Name = "processListView";
            this.processListView.Size = new System.Drawing.Size(412, 237);
            this.processListView.TabIndex = 0;
            this.processListView.UseCompatibleStateImageBehavior = false;
            this.processListView.View = System.Windows.Forms.View.Details;
            this.processListView.DoubleClick += new System.EventHandler(this.processListView_DoubleClick);
            // 
            // processNameHeader
            // 
            this.processNameHeader.Text = "Process Name";
            this.processNameHeader.Width = 206;
            // 
            // processIdHeader
            // 
            this.processIdHeader.Text = "Process ID";
            this.processIdHeader.Width = 172;
            // 
            // btn_FillLol
            // 
            this.btn_FillLol.Location = new System.Drawing.Point(12, 255);
            this.btn_FillLol.Name = "btn_FillLol";
            this.btn_FillLol.Size = new System.Drawing.Size(209, 23);
            this.btn_FillLol.TabIndex = 1;
            this.btn_FillLol.Text = "Fill League of Legends";
            this.btn_FillLol.UseVisualStyleBackColor = true;
            this.btn_FillLol.Click += new System.EventHandler(this.btn_FillLol_Click);
            // 
            // ProcessDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 329);
            this.Controls.Add(this.btn_FillLol);
            this.Controls.Add(this.processListView);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProcessDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AeroListView processListView;
        private System.Windows.Forms.ColumnHeader processNameHeader;
        private System.Windows.Forms.ColumnHeader processIdHeader;
        private System.Windows.Forms.Button btn_FillLol;
    }
}
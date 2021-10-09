namespace Memory_Scanner.Forms
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.selectProcessButton = new System.Windows.Forms.Button();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.searchProgressBar = new System.Windows.Forms.ProgressBar();
            this.nextScanButton = new System.Windows.Forms.Button();
            this.firstScanButton = new System.Windows.Forms.Button();
            this.dataValueTextBox = new System.Windows.Forms.TextBox();
            this.dataValueLabel = new System.Windows.Forms.Label();
            this.dataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dataTypeLabel = new System.Windows.Forms.Label();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.resultsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedProcessValueLabel = new System.Windows.Forms.Label();
            this.selectedProcessNameLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_min = new System.Windows.Forms.Button();
            this.btn_max = new System.Windows.Forms.Button();
            this.btn_changeCamera = new System.Windows.Forms.Button();
            this.btn_getProcessLOL = new System.Windows.Forms.Button();
            this.txt_valueCamera = new System.Windows.Forms.TextBox();
            this.resultsListView = new Memory_Scanner.Controls.AeroListView();
            this.addressHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchGroupBox.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            this.resultsMenuStrip.SuspendLayout();
            this.processGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectProcessButton
            // 
            this.selectProcessButton.Location = new System.Drawing.Point(249, 13);
            this.selectProcessButton.Name = "selectProcessButton";
            this.selectProcessButton.Size = new System.Drawing.Size(105, 23);
            this.selectProcessButton.TabIndex = 0;
            this.selectProcessButton.Text = "Select Process";
            this.selectProcessButton.UseVisualStyleBackColor = true;
            this.selectProcessButton.Click += new System.EventHandler(this.selectProcessButton_Click);
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.searchProgressBar);
            this.searchGroupBox.Controls.Add(this.nextScanButton);
            this.searchGroupBox.Controls.Add(this.firstScanButton);
            this.searchGroupBox.Controls.Add(this.dataValueTextBox);
            this.searchGroupBox.Controls.Add(this.dataValueLabel);
            this.searchGroupBox.Controls.Add(this.dataTypeComboBox);
            this.searchGroupBox.Controls.Add(this.dataTypeLabel);
            this.searchGroupBox.Location = new System.Drawing.Point(6, 54);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(360, 105);
            this.searchGroupBox.TabIndex = 1;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search";
            // 
            // searchProgressBar
            // 
            this.searchProgressBar.Location = new System.Drawing.Point(6, 76);
            this.searchProgressBar.Name = "searchProgressBar";
            this.searchProgressBar.Size = new System.Drawing.Size(186, 23);
            this.searchProgressBar.TabIndex = 4;
            // 
            // nextScanButton
            // 
            this.nextScanButton.Enabled = false;
            this.nextScanButton.Location = new System.Drawing.Point(279, 76);
            this.nextScanButton.Name = "nextScanButton";
            this.nextScanButton.Size = new System.Drawing.Size(75, 23);
            this.nextScanButton.TabIndex = 6;
            this.nextScanButton.Text = "Next Scan";
            this.nextScanButton.UseVisualStyleBackColor = true;
            this.nextScanButton.Click += new System.EventHandler(this.nextScanButton_Click);
            // 
            // firstScanButton
            // 
            this.firstScanButton.Enabled = false;
            this.firstScanButton.Location = new System.Drawing.Point(198, 76);
            this.firstScanButton.Name = "firstScanButton";
            this.firstScanButton.Size = new System.Drawing.Size(75, 23);
            this.firstScanButton.TabIndex = 5;
            this.firstScanButton.Text = "First Scan";
            this.firstScanButton.UseVisualStyleBackColor = true;
            this.firstScanButton.Click += new System.EventHandler(this.firstScanButton_Click);
            // 
            // dataValueTextBox
            // 
            this.dataValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataValueTextBox.Location = new System.Drawing.Point(78, 48);
            this.dataValueTextBox.Name = "dataValueTextBox";
            this.dataValueTextBox.Size = new System.Drawing.Size(276, 22);
            this.dataValueTextBox.TabIndex = 3;
            // 
            // dataValueLabel
            // 
            this.dataValueLabel.AutoSize = true;
            this.dataValueLabel.Location = new System.Drawing.Point(6, 51);
            this.dataValueLabel.Name = "dataValueLabel";
            this.dataValueLabel.Size = new System.Drawing.Size(65, 13);
            this.dataValueLabel.TabIndex = 2;
            this.dataValueLabel.Text = "Data Value:";
            // 
            // dataTypeComboBox
            // 
            this.dataTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataTypeComboBox.FormattingEnabled = true;
            this.dataTypeComboBox.Items.AddRange(new object[] {
            "Int16",
            "Int32",
            "Int64",
            "Float",
            "Double"});
            this.dataTypeComboBox.Location = new System.Drawing.Point(72, 21);
            this.dataTypeComboBox.Name = "dataTypeComboBox";
            this.dataTypeComboBox.Size = new System.Drawing.Size(282, 21);
            this.dataTypeComboBox.TabIndex = 1;
            // 
            // dataTypeLabel
            // 
            this.dataTypeLabel.AutoSize = true;
            this.dataTypeLabel.Location = new System.Drawing.Point(6, 24);
            this.dataTypeLabel.Name = "dataTypeLabel";
            this.dataTypeLabel.Size = new System.Drawing.Size(60, 13);
            this.dataTypeLabel.TabIndex = 0;
            this.dataTypeLabel.Text = "Data Type:";
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Controls.Add(this.resultsListView);
            this.resultsGroupBox.Location = new System.Drawing.Point(6, 165);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(360, 150);
            this.resultsGroupBox.TabIndex = 2;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Results";
            // 
            // resultsMenuStrip
            // 
            this.resultsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editValueToolStripMenuItem});
            this.resultsMenuStrip.Name = "resultsMenuStrip";
            this.resultsMenuStrip.Size = new System.Drawing.Size(126, 26);
            this.resultsMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.resultsMenuStrip_Opening);
            // 
            // editValueToolStripMenuItem
            // 
            this.editValueToolStripMenuItem.Name = "editValueToolStripMenuItem";
            this.editValueToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.editValueToolStripMenuItem.Text = "Edit Value";
            this.editValueToolStripMenuItem.Click += new System.EventHandler(this.editValueToolStripMenuItem_Click);
            // 
            // processGroupBox
            // 
            this.processGroupBox.Controls.Add(this.selectedProcessValueLabel);
            this.processGroupBox.Controls.Add(this.selectedProcessNameLabel);
            this.processGroupBox.Controls.Add(this.selectProcessButton);
            this.processGroupBox.Location = new System.Drawing.Point(6, 6);
            this.processGroupBox.Name = "processGroupBox";
            this.processGroupBox.Size = new System.Drawing.Size(360, 42);
            this.processGroupBox.TabIndex = 0;
            this.processGroupBox.TabStop = false;
            this.processGroupBox.Text = "Process";
            // 
            // selectedProcessValueLabel
            // 
            this.selectedProcessValueLabel.AutoSize = true;
            this.selectedProcessValueLabel.Location = new System.Drawing.Point(106, 18);
            this.selectedProcessValueLabel.Name = "selectedProcessValueLabel";
            this.selectedProcessValueLabel.Size = new System.Drawing.Size(35, 13);
            this.selectedProcessValueLabel.TabIndex = 1;
            this.selectedProcessValueLabel.Text = "None";
            // 
            // selectedProcessNameLabel
            // 
            this.selectedProcessNameLabel.AutoSize = true;
            this.selectedProcessNameLabel.Location = new System.Drawing.Point(6, 18);
            this.selectedProcessNameLabel.Name = "selectedProcessNameLabel";
            this.selectedProcessNameLabel.Size = new System.Drawing.Size(94, 13);
            this.selectedProcessNameLabel.TabIndex = 0;
            this.selectedProcessNameLabel.Text = "Selected Process:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 370);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.processGroupBox);
            this.tabPage1.Controls.Add(this.searchGroupBox);
            this.tabPage1.Controls.Add(this.resultsGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Default";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_valueCamera);
            this.tabPage2.Controls.Add(this.btn_getProcessLOL);
            this.tabPage2.Controls.Add(this.btn_changeCamera);
            this.tabPage2.Controls.Add(this.btn_max);
            this.tabPage2.Controls.Add(this.btn_min);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(441, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LOL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_min
            // 
            this.btn_min.Location = new System.Drawing.Point(6, 33);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(75, 23);
            this.btn_min.TabIndex = 0;
            this.btn_min.Text = "Min";
            this.btn_min.UseVisualStyleBackColor = true;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // btn_max
            // 
            this.btn_max.Location = new System.Drawing.Point(6, 62);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(75, 23);
            this.btn_max.TabIndex = 1;
            this.btn_max.Text = "Max";
            this.btn_max.UseVisualStyleBackColor = true;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // btn_changeCamera
            // 
            this.btn_changeCamera.Location = new System.Drawing.Point(6, 91);
            this.btn_changeCamera.Name = "btn_changeCamera";
            this.btn_changeCamera.Size = new System.Drawing.Size(156, 23);
            this.btn_changeCamera.TabIndex = 2;
            this.btn_changeCamera.Text = "Change camera";
            this.btn_changeCamera.UseVisualStyleBackColor = true;
            this.btn_changeCamera.Click += new System.EventHandler(this.btn_changeCamera_Click);
            // 
            // btn_getProcessLOL
            // 
            this.btn_getProcessLOL.Location = new System.Drawing.Point(6, 6);
            this.btn_getProcessLOL.Name = "btn_getProcessLOL";
            this.btn_getProcessLOL.Size = new System.Drawing.Size(75, 23);
            this.btn_getProcessLOL.TabIndex = 3;
            this.btn_getProcessLOL.Text = "Get Process";
            this.btn_getProcessLOL.UseVisualStyleBackColor = true;
            this.btn_getProcessLOL.Click += new System.EventHandler(this.btn_getProcessLOL_Click);
            // 
            // txt_valueCamera
            // 
            this.txt_valueCamera.Location = new System.Drawing.Point(169, 93);
            this.txt_valueCamera.Name = "txt_valueCamera";
            this.txt_valueCamera.Size = new System.Drawing.Size(136, 22);
            this.txt_valueCamera.TabIndex = 4;
            this.txt_valueCamera.Text = "3000";
            // 
            // resultsListView
            // 
            this.resultsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.addressHeader,
            this.valueHeader});
            this.resultsListView.ContextMenuStrip = this.resultsMenuStrip;
            this.resultsListView.FullRowSelect = true;
            this.resultsListView.HideSelection = false;
            this.resultsListView.Location = new System.Drawing.Point(6, 21);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(348, 123);
            this.resultsListView.TabIndex = 0;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.Details;
            // 
            // addressHeader
            // 
            this.addressHeader.Text = "Address";
            this.addressHeader.Width = 120;
            // 
            // valueHeader
            // 
            this.valueHeader.Text = "Value";
            this.valueHeader.Width = 209;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 411);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hieu Memory Scanner";
            this.Load += new System.EventHandler(this.Main_Load);
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.resultsGroupBox.ResumeLayout(false);
            this.resultsMenuStrip.ResumeLayout(false);
            this.processGroupBox.ResumeLayout(false);
            this.processGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectProcessButton;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.Button nextScanButton;
        private System.Windows.Forms.Button firstScanButton;
        private System.Windows.Forms.TextBox dataValueTextBox;
        private System.Windows.Forms.Label dataValueLabel;
        private System.Windows.Forms.ComboBox dataTypeComboBox;
        private System.Windows.Forms.Label dataTypeLabel;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private System.Windows.Forms.ProgressBar searchProgressBar;
        private System.Windows.Forms.GroupBox processGroupBox;
        private System.Windows.Forms.Label selectedProcessValueLabel;
        private System.Windows.Forms.Label selectedProcessNameLabel;
        private Controls.AeroListView resultsListView;
        private System.Windows.Forms.ColumnHeader addressHeader;
        private System.Windows.Forms.ColumnHeader valueHeader;
        private System.Windows.Forms.ContextMenuStrip resultsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editValueToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_max;
        private System.Windows.Forms.Button btn_min;
        private System.Windows.Forms.Button btn_changeCamera;
        private System.Windows.Forms.Button btn_getProcessLOL;
        private System.Windows.Forms.TextBox txt_valueCamera;
    }
}
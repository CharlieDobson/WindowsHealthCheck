namespace WindowsHealthCheck
{
    partial class WindowsHealthCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsHealthCheck));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueScreenViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMemoryDiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDriveStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.winDirStatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatRemovableDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPolicyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOutputToLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandsRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartButton = new System.Windows.Forms.Button();
            this.startToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.consoleWindowToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuLogWindow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.defragCheckBox = new System.Windows.Forms.CheckBox();
            this.clearCheckBox = new System.Windows.Forms.CheckBox();
            this.dismCheckBox = new System.Windows.Forms.CheckBox();
            this.sfcCheckBox = new System.Windows.Forms.CheckBox();
            this.DriveStatusBox2 = new System.Windows.Forms.PictureBox();
            this.DriveStatusBox1 = new System.Windows.Forms.PictureBox();
            this.sfcToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.wsusToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.defragToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dismToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DriveToolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.DriveToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.DriveBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.contextMenuLogWindow.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriveStatusBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveStatusBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(459, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueScreenViewToolStripMenuItem,
            this.windowsMemoryDiagnosticsToolStripMenuItem,
            this.getDriveStatisticsToolStripMenuItem,
            this.winDirStatToolStripMenuItem,
            this.formatRemovableDriveToolStripMenuItem,
            this.groupPolicyReportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // blueScreenViewToolStripMenuItem
            // 
            this.blueScreenViewToolStripMenuItem.Name = "blueScreenViewToolStripMenuItem";
            this.blueScreenViewToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.blueScreenViewToolStripMenuItem.Text = "Blue Screen View";
            this.blueScreenViewToolStripMenuItem.ToolTipText = "Launches BlueScreenView BSOD viewer";
            this.blueScreenViewToolStripMenuItem.Visible = false;
            this.blueScreenViewToolStripMenuItem.Click += new System.EventHandler(this.blueScreenViewToolStripMenuItem_Click);
            // 
            // windowsMemoryDiagnosticsToolStripMenuItem
            // 
            this.windowsMemoryDiagnosticsToolStripMenuItem.Name = "windowsMemoryDiagnosticsToolStripMenuItem";
            this.windowsMemoryDiagnosticsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.windowsMemoryDiagnosticsToolStripMenuItem.Text = "Windows Memory Diagnostics";
            this.windowsMemoryDiagnosticsToolStripMenuItem.ToolTipText = "Launches the integrated Windows Memory Diagnostics";
            this.windowsMemoryDiagnosticsToolStripMenuItem.Click += new System.EventHandler(this.windowsMemoryDiagnosticsToolStripMenuItem_Click);
            // 
            // getDriveStatisticsToolStripMenuItem
            // 
            this.getDriveStatisticsToolStripMenuItem.Name = "getDriveStatisticsToolStripMenuItem";
            this.getDriveStatisticsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.getDriveStatisticsToolStripMenuItem.Text = "Get Drive Statistics";
            this.getDriveStatisticsToolStripMenuItem.Click += new System.EventHandler(this.getDriveStatisticsToolStripMenuItem_Click);
            // 
            // winDirStatToolStripMenuItem
            // 
            this.winDirStatToolStripMenuItem.Name = "winDirStatToolStripMenuItem";
            this.winDirStatToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.winDirStatToolStripMenuItem.Text = "WinDirStat";
            this.winDirStatToolStripMenuItem.ToolTipText = "Launches Windows Directory Statistics";
            this.winDirStatToolStripMenuItem.Visible = false;
            this.winDirStatToolStripMenuItem.Click += new System.EventHandler(this.winDirStatToolStripMenuItem_Click);
            // 
            // formatRemovableDriveToolStripMenuItem
            // 
            this.formatRemovableDriveToolStripMenuItem.Name = "formatRemovableDriveToolStripMenuItem";
            this.formatRemovableDriveToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.formatRemovableDriveToolStripMenuItem.Text = "Format Removable Drive";
            this.formatRemovableDriveToolStripMenuItem.Click += new System.EventHandler(this.formatRemoveableDriveToolStripMenuItem_Click);
            // 
            // groupPolicyReportToolStripMenuItem
            // 
            this.groupPolicyReportToolStripMenuItem.Name = "groupPolicyReportToolStripMenuItem";
            this.groupPolicyReportToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.groupPolicyReportToolStripMenuItem.Text = "Generate Group Policy Report";
            this.groupPolicyReportToolStripMenuItem.Click += new System.EventHandler(this.groupPolicyReportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Exits Windows Health Check";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOutputToolStripMenuItem,
            this.saveOutputToLogToolStripMenuItem,
            this.autoUpdateToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showOutputToolStripMenuItem
            // 
            this.showOutputToolStripMenuItem.CheckOnClick = true;
            this.showOutputToolStripMenuItem.Name = "showOutputToolStripMenuItem";
            this.showOutputToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showOutputToolStripMenuItem.Text = "Show output";
            this.showOutputToolStripMenuItem.ToolTipText = "Displays program output in separate window.";
            // 
            // saveOutputToLogToolStripMenuItem
            // 
            this.saveOutputToLogToolStripMenuItem.CheckOnClick = true;
            this.saveOutputToLogToolStripMenuItem.Name = "saveOutputToLogToolStripMenuItem";
            this.saveOutputToLogToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveOutputToLogToolStripMenuItem.Text = "Save output to log";
            this.saveOutputToLogToolStripMenuItem.Click += new System.EventHandler(this.saveOutputToLogToolStripMenuItem_Click);
            // 
            // autoUpdateToolStripMenuItem
            // 
            this.autoUpdateToolStripMenuItem.CheckOnClick = true;
            this.autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            this.autoUpdateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.autoUpdateToolStripMenuItem.Text = "AutoUpdate";
            this.autoUpdateToolStripMenuItem.ToolTipText = "Update WindowsHealthCheck on startup";
            this.autoUpdateToolStripMenuItem.Click += new System.EventHandler(this.autoUpdateToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommandsRunToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // CommandsRunToolStripMenuItem
            // 
            this.CommandsRunToolStripMenuItem.Name = "CommandsRunToolStripMenuItem";
            this.CommandsRunToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.CommandsRunToolStripMenuItem.Text = "Commands Run";
            this.CommandsRunToolStripMenuItem.ToolTipText = "Displays information about what this application does.";
            this.CommandsRunToolStripMenuItem.Click += new System.EventHandler(this.CommandsRunToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.ToolTipText = "Checks for a newer version of Windows Health Check";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.ToolTipText = "About Windows Health Check";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(106, 245);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(240, 37);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.startToolTip.SetToolTip(this.StartButton, "Click here to start");
            this.StartButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // contextMenuLogWindow
            // 
            this.contextMenuLogWindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogWindowToolStripMenuItem});
            this.contextMenuLogWindow.Name = "contextMenuLogWindow";
            this.contextMenuLogWindow.Size = new System.Drawing.Size(167, 26);
            // 
            // clearLogWindowToolStripMenuItem
            // 
            this.clearLogWindowToolStripMenuItem.Name = "clearLogWindowToolStripMenuItem";
            this.clearLogWindowToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.clearLogWindowToolStripMenuItem.Text = "Clear log window";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.defragCheckBox);
            this.panel1.Controls.Add(this.clearCheckBox);
            this.panel1.Controls.Add(this.dismCheckBox);
            this.panel1.Controls.Add(this.sfcCheckBox);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(65, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 170);
            this.panel1.TabIndex = 6;
            // 
            // defragCheckBox
            // 
            this.defragCheckBox.AutoSize = true;
            this.defragCheckBox.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defragCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.defragCheckBox.Location = new System.Drawing.Point(21, 131);
            this.defragCheckBox.Name = "defragCheckBox";
            this.defragCheckBox.Size = new System.Drawing.Size(280, 37);
            this.defragCheckBox.TabIndex = 3;
            this.defragCheckBox.Text = "Optimize System Drive";
            this.defragToolTip.SetToolTip(this.defragCheckBox, "Optimizes hard drives by performing defragmentation (HDD) or garbage cleanup (SSD" +
        ")");
            this.defragCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearCheckBox
            // 
            this.clearCheckBox.AutoSize = true;
            this.clearCheckBox.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearCheckBox.Location = new System.Drawing.Point(22, 91);
            this.clearCheckBox.Name = "clearCheckBox";
            this.clearCheckBox.Size = new System.Drawing.Size(271, 37);
            this.clearCheckBox.TabIndex = 2;
            this.clearCheckBox.Text = "Clear Cached Updates";
            this.wsusToolTip.SetToolTip(this.clearCheckBox, "Removes the SoftwareDistribution folder under Windows and clears out superceded u" +
        "pdates");
            this.clearCheckBox.UseVisualStyleBackColor = true;
            // 
            // dismCheckBox
            // 
            this.dismCheckBox.AutoSize = true;
            this.dismCheckBox.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dismCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dismCheckBox.Location = new System.Drawing.Point(21, 51);
            this.dismCheckBox.Name = "dismCheckBox";
            this.dismCheckBox.Size = new System.Drawing.Size(304, 37);
            this.dismCheckBox.TabIndex = 1;
            this.dismCheckBox.Text = "Restore Windows Health";
            this.dismToolTip.SetToolTip(this.dismCheckBox, "Runs the Deployment Imaging Service Manager to restore health on all Windows Oper" +
        "ating System files");
            this.dismCheckBox.UseVisualStyleBackColor = true;
            // 
            // sfcCheckBox
            // 
            this.sfcCheckBox.AutoSize = true;
            this.sfcCheckBox.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfcCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sfcCheckBox.Location = new System.Drawing.Point(21, 11);
            this.sfcCheckBox.Name = "sfcCheckBox";
            this.sfcCheckBox.Size = new System.Drawing.Size(247, 37);
            this.sfcCheckBox.TabIndex = 0;
            this.sfcCheckBox.Text = "System File Checker";
            this.sfcToolTip.SetToolTip(this.sfcCheckBox, "Scans core Operating System files for version consistency and repairs any issues " +
        "found.");
            this.sfcCheckBox.UseVisualStyleBackColor = true;
            // 
            // DriveStatusBox2
            // 
            this.DriveStatusBox2.BackColor = System.Drawing.Color.Blue;
            this.DriveStatusBox2.Location = new System.Drawing.Point(100, 5);
            this.DriveStatusBox2.Name = "DriveStatusBox2";
            this.DriveStatusBox2.Size = new System.Drawing.Size(189, 24);
            this.DriveStatusBox2.TabIndex = 10;
            this.DriveStatusBox2.TabStop = false;
            this.DriveStatusBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SystemDriveStatusLabel_DoubleClick);
            // 
            // DriveStatusBox1
            // 
            this.DriveStatusBox1.BackColor = System.Drawing.Color.LightGray;
            this.DriveStatusBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DriveStatusBox1.Location = new System.Drawing.Point(100, 3);
            this.DriveStatusBox1.Name = "DriveStatusBox1";
            this.DriveStatusBox1.Size = new System.Drawing.Size(200, 34);
            this.DriveStatusBox1.TabIndex = 9;
            this.DriveStatusBox1.TabStop = false;
            this.DriveStatusBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SystemDriveStatusLabel_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.DriveStatusBox2);
            this.panel2.Controls.Add(this.DriveBox1);
            this.panel2.Controls.Add(this.DriveStatusBox1);
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(77, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 40);
            this.panel2.TabIndex = 7;
            // 
            // DriveBox1
            // 
            this.DriveBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriveBox1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveBox1.FormattingEnabled = true;
            this.DriveBox1.Location = new System.Drawing.Point(16, 3);
            this.DriveBox1.Name = "DriveBox1";
            this.DriveBox1.Size = new System.Drawing.Size(68, 34);
            this.DriveBox1.TabIndex = 11;
            this.DriveBox1.SelectedValueChanged += new System.EventHandler(this.DriveBox1_SelectedValueChanged);
            this.DriveBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SystemDriveStatusLabel_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 289);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(459, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(325, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WindowsHealthCheck
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(459, 311);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 350);
            this.MinimumSize = new System.Drawing.Size(475, 350);
            this.Name = "WindowsHealthCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Health Check";
            this.Load += new System.EventHandler(this.WindowsHealthCheck_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuLogWindow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriveStatusBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveStatusBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ToolTip startToolTip;
        private System.Windows.Forms.ToolTip consoleWindowToolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuLogWindow;
        private System.Windows.Forms.ToolStripMenuItem clearLogWindowToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox defragCheckBox;
        private System.Windows.Forms.CheckBox clearCheckBox;
        private System.Windows.Forms.CheckBox dismCheckBox;
        private System.Windows.Forms.CheckBox sfcCheckBox;
        private System.Windows.Forms.ToolTip defragToolTip;
        private System.Windows.Forms.ToolTip wsusToolTip;
        private System.Windows.Forms.ToolTip dismToolTip;
        private System.Windows.Forms.ToolTip sfcToolTip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMemoryDiagnosticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox DriveStatusBox2;
        private System.Windows.Forms.PictureBox DriveStatusBox1;
        private System.Windows.Forms.ToolTip DriveToolTip2;
        private System.Windows.Forms.ToolTip DriveToolTip1;
        private System.Windows.Forms.ToolStripMenuItem blueScreenViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem winDirStatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CommandsRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOutputToLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatRemovableDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupPolicyReportToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox DriveBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem getDriveStatisticsToolStripMenuItem;
    }
}


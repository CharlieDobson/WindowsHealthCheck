namespace WindowsHealthCheck
{
    partial class DriveStats
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAvgFileSize1 = new System.Windows.Forms.Label();
            this.lblAvgFileSize2 = new System.Windows.Forms.Label();
            this.lblLargestFile1 = new System.Windows.Forms.Label();
            this.lblLargestFile3 = new System.Windows.Forms.Label();
            this.lblSystemTempSize1 = new System.Windows.Forms.Label();
            this.lblSystemTempSize2 = new System.Windows.Forms.Label();
            this.lblLargestFile2 = new System.Windows.Forms.Label();
            this.FolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FolderSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(174, 232);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolderName,
            this.FolderSize,
            this.NoOfFiles});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(432, 289);
            this.dataGridView1.TabIndex = 2;
            // 
            // lblAvgFileSize1
            // 
            this.lblAvgFileSize1.AutoSize = true;
            this.lblAvgFileSize1.Location = new System.Drawing.Point(12, 307);
            this.lblAvgFileSize1.Name = "lblAvgFileSize1";
            this.lblAvgFileSize1.Size = new System.Drawing.Size(136, 20);
            this.lblAvgFileSize1.TabIndex = 3;
            this.lblAvgFileSize1.Text = "Average File Size:";
            // 
            // lblAvgFileSize2
            // 
            this.lblAvgFileSize2.AutoEllipsis = true;
            this.lblAvgFileSize2.Location = new System.Drawing.Point(276, 307);
            this.lblAvgFileSize2.Name = "lblAvgFileSize2";
            this.lblAvgFileSize2.Size = new System.Drawing.Size(146, 20);
            this.lblAvgFileSize2.TabIndex = 4;
            this.lblAvgFileSize2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLargestFile1
            // 
            this.lblLargestFile1.AutoSize = true;
            this.lblLargestFile1.Location = new System.Drawing.Point(12, 338);
            this.lblLargestFile1.Name = "lblLargestFile1";
            this.lblLargestFile1.Size = new System.Drawing.Size(96, 20);
            this.lblLargestFile1.TabIndex = 5;
            this.lblLargestFile1.Text = "Largest File:";
            // 
            // lblLargestFile3
            // 
            this.lblLargestFile3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargestFile3.Location = new System.Drawing.Point(16, 364);
            this.lblLargestFile3.Name = "lblLargestFile3";
            this.lblLargestFile3.Size = new System.Drawing.Size(406, 20);
            this.lblLargestFile3.TabIndex = 6;
            this.lblLargestFile3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSystemTempSize1
            // 
            this.lblSystemTempSize1.AutoSize = true;
            this.lblSystemTempSize1.Location = new System.Drawing.Point(12, 393);
            this.lblSystemTempSize1.Name = "lblSystemTempSize1";
            this.lblSystemTempSize1.Size = new System.Drawing.Size(145, 20);
            this.lblSystemTempSize1.TabIndex = 7;
            this.lblSystemTempSize1.Text = "System Temp Size:";
            // 
            // lblSystemTempSize2
            // 
            this.lblSystemTempSize2.Location = new System.Drawing.Point(280, 393);
            this.lblSystemTempSize2.Name = "lblSystemTempSize2";
            this.lblSystemTempSize2.Size = new System.Drawing.Size(142, 20);
            this.lblSystemTempSize2.TabIndex = 8;
            this.lblSystemTempSize2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLargestFile2
            // 
            this.lblLargestFile2.AutoEllipsis = true;
            this.lblLargestFile2.Location = new System.Drawing.Point(276, 338);
            this.lblLargestFile2.Name = "lblLargestFile2";
            this.lblLargestFile2.Size = new System.Drawing.Size(146, 20);
            this.lblLargestFile2.TabIndex = 9;
            this.lblLargestFile2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FolderName
            // 
            this.FolderName.FillWeight = 101F;
            this.FolderName.Frozen = true;
            this.FolderName.HeaderText = "Folder";
            this.FolderName.MaxInputLength = 258;
            this.FolderName.MinimumWidth = 100;
            this.FolderName.Name = "FolderName";
            this.FolderName.ReadOnly = true;
            this.FolderName.Width = 200;
            // 
            // FolderSize
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FolderSize.DefaultCellStyle = dataGridViewCellStyle1;
            this.FolderSize.Frozen = true;
            this.FolderSize.HeaderText = "Size";
            this.FolderSize.MaxInputLength = 15;
            this.FolderSize.MinimumWidth = 80;
            this.FolderSize.Name = "FolderSize";
            this.FolderSize.ReadOnly = true;
            this.FolderSize.Width = 80;
            // 
            // NoOfFiles
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NoOfFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.NoOfFiles.Frozen = true;
            this.NoOfFiles.HeaderText = "# of Files";
            this.NoOfFiles.MaxInputLength = 20;
            this.NoOfFiles.MinimumWidth = 90;
            this.NoOfFiles.Name = "NoOfFiles";
            this.NoOfFiles.ReadOnly = true;
            this.NoOfFiles.Width = 110;
            // 
            // DriveStats
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(434, 431);
            this.Controls.Add(this.lblLargestFile2);
            this.Controls.Add(this.lblSystemTempSize2);
            this.Controls.Add(this.lblSystemTempSize1);
            this.Controls.Add(this.lblLargestFile3);
            this.Controls.Add(this.lblLargestFile1);
            this.Controls.Add(this.lblAvgFileSize2);
            this.Controls.Add(this.lblAvgFileSize1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 470);
            this.MinimizeBox = false;
            this.Name = "DriveStats";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DriveStats";
            this.Load += new System.EventHandler(this.DriveStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAvgFileSize1;
        private System.Windows.Forms.Label lblAvgFileSize2;
        private System.Windows.Forms.Label lblLargestFile1;
        private System.Windows.Forms.Label lblLargestFile3;
        private System.Windows.Forms.Label lblSystemTempSize1;
        private System.Windows.Forms.Label lblSystemTempSize2;
        private System.Windows.Forms.Label lblLargestFile2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfFiles;
    }
}
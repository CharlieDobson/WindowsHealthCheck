namespace WindowsHealthCheck
{
    partial class FormatRemovableDrive
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
            this.SelectDriveComboBox = new System.Windows.Forms.ComboBox();
            this.copyISOCheckBox = new System.Windows.Forms.CheckBox();
            this.FormatUSBGroupBox = new System.Windows.Forms.GroupBox();
            this.ISOPathName = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.FileSystemLabel = new System.Windows.Forms.Label();
            this.ShowPropertiesButton = new System.Windows.Forms.Button();
            this.MarkBootableCheckBox = new System.Windows.Forms.CheckBox();
            this.PartitionTypeDropDown = new System.Windows.Forms.ComboBox();
            this.PartitionTypeLabel = new System.Windows.Forms.Label();
            this.DriveFormatComboBox = new System.Windows.Forms.ComboBox();
            this.DriveLabelTextBox = new System.Windows.Forms.TextBox();
            this.DriveLabelLabel = new System.Windows.Forms.Label();
            this.FormatUSBButton = new System.Windows.Forms.Button();
            this.SelectDriveLabel = new System.Windows.Forms.Label();
            this.RefreshDrivesToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RefreshDrivesButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.FormatUSBGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectDriveComboBox
            // 
            this.SelectDriveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectDriveComboBox.FormattingEnabled = true;
            this.SelectDriveComboBox.Location = new System.Drawing.Point(153, 34);
            this.SelectDriveComboBox.Name = "SelectDriveComboBox";
            this.SelectDriveComboBox.Size = new System.Drawing.Size(74, 33);
            this.SelectDriveComboBox.TabIndex = 0;
            this.SelectDriveComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectDriveComboBox_SelectedIndexChanged);
            // 
            // copyISOCheckBox
            // 
            this.copyISOCheckBox.AutoSize = true;
            this.copyISOCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyISOCheckBox.Location = new System.Drawing.Point(11, 253);
            this.copyISOCheckBox.Name = "copyISOCheckBox";
            this.copyISOCheckBox.Size = new System.Drawing.Size(122, 29);
            this.copyISOCheckBox.TabIndex = 2;
            this.copyISOCheckBox.Text = "Copy ISO";
            this.copyISOCheckBox.UseVisualStyleBackColor = true;
            this.copyISOCheckBox.CheckedChanged += new System.EventHandler(this.copyISOCheckBox_CheckedChanged);
            // 
            // FormatUSBGroupBox
            // 
            this.FormatUSBGroupBox.Controls.Add(this.StatusLabel);
            this.FormatUSBGroupBox.Controls.Add(this.ISOPathName);
            this.FormatUSBGroupBox.Controls.Add(this.progressBar);
            this.FormatUSBGroupBox.Controls.Add(this.copyISOCheckBox);
            this.FormatUSBGroupBox.Controls.Add(this.FileSystemLabel);
            this.FormatUSBGroupBox.Controls.Add(this.ShowPropertiesButton);
            this.FormatUSBGroupBox.Controls.Add(this.MarkBootableCheckBox);
            this.FormatUSBGroupBox.Controls.Add(this.PartitionTypeDropDown);
            this.FormatUSBGroupBox.Controls.Add(this.PartitionTypeLabel);
            this.FormatUSBGroupBox.Controls.Add(this.DriveFormatComboBox);
            this.FormatUSBGroupBox.Controls.Add(this.DriveLabelTextBox);
            this.FormatUSBGroupBox.Controls.Add(this.DriveLabelLabel);
            this.FormatUSBGroupBox.Controls.Add(this.RefreshDrivesButton);
            this.FormatUSBGroupBox.Controls.Add(this.FormatUSBButton);
            this.FormatUSBGroupBox.Controls.Add(this.SelectDriveLabel);
            this.FormatUSBGroupBox.Controls.Add(this.SelectDriveComboBox);
            this.FormatUSBGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatUSBGroupBox.Location = new System.Drawing.Point(13, 3);
            this.FormatUSBGroupBox.Name = "FormatUSBGroupBox";
            this.FormatUSBGroupBox.Size = new System.Drawing.Size(484, 364);
            this.FormatUSBGroupBox.TabIndex = 3;
            this.FormatUSBGroupBox.TabStop = false;
            this.FormatUSBGroupBox.Text = "Format USB";
            // 
            // ISOPathName
            // 
            this.ISOPathName.AllowDrop = true;
            this.ISOPathName.Location = new System.Drawing.Point(147, 251);
            this.ISOPathName.Name = "ISOPathName";
            this.ISOPathName.Size = new System.Drawing.Size(318, 31);
            this.ISOPathName.TabIndex = 10;
            this.ISOPathName.TextChanged += new System.EventHandler(this.ISOPathName_TextChanged);
            this.ISOPathName.DragDrop += new System.Windows.Forms.DragEventHandler(this.ISOPathName_DragDrop);
            this.ISOPathName.DragEnter += new System.Windows.Forms.DragEventHandler(this.ISOPathName_DragEnter);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(147, 304);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(318, 31);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 9;
            // 
            // FileSystemLabel
            // 
            this.FileSystemLabel.AutoSize = true;
            this.FileSystemLabel.Location = new System.Drawing.Point(6, 199);
            this.FileSystemLabel.Name = "FileSystemLabel";
            this.FileSystemLabel.Size = new System.Drawing.Size(124, 25);
            this.FileSystemLabel.TabIndex = 8;
            this.FileSystemLabel.Text = "File System";
            // 
            // ShowPropertiesButton
            // 
            this.ShowPropertiesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPropertiesButton.Location = new System.Drawing.Point(316, 34);
            this.ShowPropertiesButton.Name = "ShowPropertiesButton";
            this.ShowPropertiesButton.Size = new System.Drawing.Size(152, 33);
            this.ShowPropertiesButton.TabIndex = 7;
            this.ShowPropertiesButton.Text = "Properties";
            this.ShowPropertiesButton.UseVisualStyleBackColor = true;
            this.ShowPropertiesButton.Click += new System.EventHandler(this.ShowPropertiesButton_Click);
            // 
            // MarkBootableCheckBox
            // 
            this.MarkBootableCheckBox.AutoSize = true;
            this.MarkBootableCheckBox.Checked = true;
            this.MarkBootableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MarkBootableCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarkBootableCheckBox.Location = new System.Drawing.Point(276, 144);
            this.MarkBootableCheckBox.Name = "MarkBootableCheckBox";
            this.MarkBootableCheckBox.Size = new System.Drawing.Size(168, 29);
            this.MarkBootableCheckBox.TabIndex = 4;
            this.MarkBootableCheckBox.Text = "Mark bootable";
            this.MarkBootableCheckBox.UseVisualStyleBackColor = true;
            // 
            // PartitionTypeDropDown
            // 
            this.PartitionTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PartitionTypeDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartitionTypeDropDown.FormattingEnabled = true;
            this.PartitionTypeDropDown.Items.AddRange(new object[] {
            "MBR",
            "GPT"});
            this.PartitionTypeDropDown.Location = new System.Drawing.Point(147, 142);
            this.PartitionTypeDropDown.Name = "PartitionTypeDropDown";
            this.PartitionTypeDropDown.Size = new System.Drawing.Size(100, 33);
            this.PartitionTypeDropDown.TabIndex = 5;
            this.PartitionTypeDropDown.SelectedValueChanged += new System.EventHandler(this.PartitionTypeDropDown_SelectedValueChanged);
            // 
            // PartitionTypeLabel
            // 
            this.PartitionTypeLabel.AutoSize = true;
            this.PartitionTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartitionTypeLabel.Location = new System.Drawing.Point(6, 145);
            this.PartitionTypeLabel.Name = "PartitionTypeLabel";
            this.PartitionTypeLabel.Size = new System.Drawing.Size(138, 25);
            this.PartitionTypeLabel.TabIndex = 6;
            this.PartitionTypeLabel.Text = "Partition type";
            // 
            // DriveFormatComboBox
            // 
            this.DriveFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriveFormatComboBox.FormattingEnabled = true;
            this.DriveFormatComboBox.Location = new System.Drawing.Point(147, 196);
            this.DriveFormatComboBox.Name = "DriveFormatComboBox";
            this.DriveFormatComboBox.Size = new System.Drawing.Size(100, 33);
            this.DriveFormatComboBox.TabIndex = 6;
            this.DriveFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.DriveFormatComboBox_SelectedIndexChanged);
            // 
            // DriveLabelTextBox
            // 
            this.DriveLabelTextBox.Location = new System.Drawing.Point(147, 87);
            this.DriveLabelTextBox.MaxLength = 11;
            this.DriveLabelTextBox.Name = "DriveLabelTextBox";
            this.DriveLabelTextBox.Size = new System.Drawing.Size(318, 31);
            this.DriveLabelTextBox.TabIndex = 5;
            // 
            // DriveLabelLabel
            // 
            this.DriveLabelLabel.AutoSize = true;
            this.DriveLabelLabel.Location = new System.Drawing.Point(9, 90);
            this.DriveLabelLabel.Name = "DriveLabelLabel";
            this.DriveLabelLabel.Size = new System.Drawing.Size(121, 25);
            this.DriveLabelLabel.TabIndex = 4;
            this.DriveLabelLabel.Text = "Drive Label";
            // 
            // FormatUSBButton
            // 
            this.FormatUSBButton.Location = new System.Drawing.Point(14, 302);
            this.FormatUSBButton.Name = "FormatUSBButton";
            this.FormatUSBButton.Size = new System.Drawing.Size(102, 33);
            this.FormatUSBButton.TabIndex = 2;
            this.FormatUSBButton.Text = "Format";
            this.FormatUSBButton.UseVisualStyleBackColor = true;
            this.FormatUSBButton.Click += new System.EventHandler(this.FormatUSBButton_Click);
            // 
            // SelectDriveLabel
            // 
            this.SelectDriveLabel.AutoSize = true;
            this.SelectDriveLabel.Location = new System.Drawing.Point(9, 38);
            this.SelectDriveLabel.Name = "SelectDriveLabel";
            this.SelectDriveLabel.Size = new System.Drawing.Size(128, 25);
            this.SelectDriveLabel.TabIndex = 1;
            this.SelectDriveLabel.Text = "Select Drive";
            // 
            // RefreshDrivesButton
            // 
            this.RefreshDrivesButton.BackgroundImage = global::WindowsHealthCheck.Properties.Resources.refresh_icon_black_20x20;
            this.RefreshDrivesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RefreshDrivesButton.Location = new System.Drawing.Point(243, 32);
            this.RefreshDrivesButton.Name = "RefreshDrivesButton";
            this.RefreshDrivesButton.Size = new System.Drawing.Size(35, 34);
            this.RefreshDrivesButton.TabIndex = 3;
            this.RefreshDrivesToolTip.SetToolTip(this.RefreshDrivesButton, "Refresh drive listing");
            this.RefreshDrivesButton.UseVisualStyleBackColor = true;
            this.RefreshDrivesButton.Click += new System.EventHandler(this.RefreshDrivesButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(150, 339);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(310, 15);
            this.StatusLabel.TabIndex = 11;
            // 
            // FormatRemovableDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 379);
            this.Controls.Add(this.FormatUSBGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatRemovableDrive";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormatRemovableDrive_Load);
            this.FormatUSBGroupBox.ResumeLayout(false);
            this.FormatUSBGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectDriveComboBox;
        private System.Windows.Forms.CheckBox copyISOCheckBox;
        private System.Windows.Forms.GroupBox FormatUSBGroupBox;
        private System.Windows.Forms.Button FormatUSBButton;
        private System.Windows.Forms.Label SelectDriveLabel;
        private System.Windows.Forms.Button RefreshDrivesButton;
        private System.Windows.Forms.ToolTip RefreshDrivesToolTip;
        private System.Windows.Forms.ComboBox DriveFormatComboBox;
        private System.Windows.Forms.TextBox DriveLabelTextBox;
        private System.Windows.Forms.Label DriveLabelLabel;
        private System.Windows.Forms.CheckBox MarkBootableCheckBox;
        private System.Windows.Forms.ComboBox PartitionTypeDropDown;
        private System.Windows.Forms.Label PartitionTypeLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label FileSystemLabel;
        private System.Windows.Forms.Button ShowPropertiesButton;
        private System.Windows.Forms.TextBox ISOPathName;
        private System.Windows.Forms.Label StatusLabel;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsHealthCheck
{
    public partial class FormatRemovableDrive : Form
    {
        public FormatRemovableDrive(Color Background, Color Text)
        {
            InitializeComponent();

            this.BackColor = Background;
            FormatUSBGroupBox.ForeColor = Text;
            FormatUSBButton.ForeColor = Color.Black;
            copyISOCheckBox.ForeColor = Text;
            MarkBootableCheckBox.ForeColor = Text;
            PartitionTypeLabel.ForeColor = Text;
            PartitionTypeDropDown.SelectedIndex = 0;
            ShowPropertiesButton.ForeColor = Color.Black;
        }

        private void FormatRemovableDrive_Load(object sender, EventArgs e)
        {
            // ISO copy not available in Vista & 7
            if (Environment.OSVersion.Version <= Version.Parse("6.1"))
            {
                copyISOCheckBox.Enabled = false;
                ISOPathName.Enabled = false;
            }

            SelectDriveComboBox.DataSource = GetDrives();

            if (GetDrives().Count == 0)
            {
                FormatUSBButton.Enabled = false;
                copyISOCheckBox.Enabled = false;
                ISOPathName.Enabled = false;
                ShowPropertiesButton.Enabled = false;
                DriveLabelTextBox.Text = "";
            }
            else
            {
                DriveFormatComboBox.DataSource = GetDriveFormats();
                if (GetDriveFormats().Contains(GetCurrentDriveFormat()))
                    DriveFormatComboBox.SelectedItem = GetCurrentDriveFormat();
                DriveLabelTextBox.Text = GetDriveLabel();
            }
        }

        private List<string> GetDrives()
        {
            List<string> RemoveableDrives = new List<string>();

            foreach (System.IO.DriveInfo drive in System.IO.DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.DriveType == System.IO.DriveType.Removable)
                {
                    RemoveableDrives.Add(drive.Name);
                }
            }

            return RemoveableDrives;
        }

        private string GetDriveLabel()
        {
            System.IO.DriveInfo drive = new System.IO.DriveInfo(SelectDriveComboBox.SelectedValue.ToString());

            if (drive.IsReady)
            {
                if (drive.VolumeLabel.Length > 11)
                {
                    return drive.VolumeLabel.Substring(0, 10);
                }
                else
                {
                    return drive.VolumeLabel;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        private void RefreshDrivesButton_Click(object sender, EventArgs e)
        {
            SelectDriveComboBox.DataSource = GetDrives();

            if (GetDrives().Count == 0)
            {
                FormatUSBButton.Enabled = false;
                copyISOCheckBox.Enabled = false;
                ISOPathName.Enabled = false;
                ShowPropertiesButton.Enabled = false;
                DriveLabelTextBox.Text = "";
            }
            else
            {
                DriveFormatComboBox.DataSource = GetDriveFormats();
                if (GetDriveFormats().Contains(GetCurrentDriveFormat()))
                    DriveFormatComboBox.SelectedItem = GetCurrentDriveFormat();
                DriveLabelTextBox.Text = GetDriveLabel();
                SetPartitionBootOptions();
            }
        }

        private void SetPartitionBootOptions()
        {
            // Get drive information to determine available formats
            DriveFormatComboBox.DataSource = GetDriveFormats();
            if (GetDriveFormats().Contains(GetCurrentDriveFormat()))
                DriveFormatComboBox.SelectedItem = GetCurrentDriveFormat();
            DriveLabelTextBox.Text = GetDriveLabel();

            // detect if drive is over 2TB and only allow GPT if true
            if (new System.IO.DriveInfo(SelectDriveComboBox.SelectedValue.ToString()).TotalSize >= 2199023255552)
            {
                PartitionTypeDropDown.SelectedValue = "GPT";
                PartitionTypeDropDown.Enabled = false;
            }
            else
            {
                PartitionTypeDropDown.SelectedValue = "MBR";
                PartitionTypeDropDown.Enabled = true;
            }
        }

        private string GetCurrentDriveFormat()
        {
            return new System.IO.DriveInfo(SelectDriveComboBox.SelectedValue.ToString()).DriveFormat;
        }

        private List<string> GetDriveFormats()
        {
            Version operatingSystem = Environment.OSVersion.Version;
            List<string> DriveFormats = new List<string>();
            System.IO.DriveInfo drive = new System.IO.DriveInfo(SelectDriveComboBox.SelectedValue.ToString());

            if (drive.TotalSize > 34359738368) // greater than 32GB
            {
                DriveFormats.Add("NTFS");
                if (operatingSystem >= Version.Parse("6.0.6001"))
                    DriveFormats.Add("exFAT");
            }
            else if (drive.TotalSize <= 34359738368 && drive.TotalSize > 4294967296) // between 4GB and 32GB
            {
                DriveFormats.Add("NTFS");
                if (operatingSystem >= Version.Parse("6.0.6001"))
                    DriveFormats.Add("exFAT");
                DriveFormats.Add("FAT32");
            }
            else if (drive.TotalSize <= 4294967296) // 4GB and less
            {
                DriveFormats.Add("NTFS");
                if (operatingSystem >= Version.Parse("6.0.6001"))
                    DriveFormats.Add("exFAT");
                DriveFormats.Add("FAT32");
                DriveFormats.Add("FAT");
            }

            // set partition types for drive
            if (drive.TotalSize <= 134217728) // 128MB and less
            {
                PartitionTypeDropDown.SelectedItem = "MBR";
                PartitionTypeDropDown.Enabled = false;
            }
            else
            {
                PartitionTypeDropDown.Enabled = true;
            }

            return DriveFormats;
        }

        private void FormatUSBButton_Click(object sender, EventArgs e)
        {
            if (SelectDriveComboBox.SelectedValue.ToString() == "")
            {
                MessageBox.Show("No drive selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("This will erase all data on the selected drive " + SelectDriveComboBox.SelectedValue.ToString() + ".\n\nDo you want to continue?",
                "Erase drive?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            else if (result == DialogResult.Yes)
                Perform_Action();
        }

        private void copyISOCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (copyISOCheckBox.Checked && string.IsNullOrEmpty(ISOPathName.Text))
            {
                // prompt for ISO file using file dialog
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "ISO Image|*.iso";
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.AddExtension = true;
                    openFileDialog.DefaultExt = "iso";
                    openFileDialog.Multiselect = false;
                    openFileDialog.Title = "Select ISO to copy...";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ISOPathName.Text = openFileDialog.FileName;
                    }
                    else
                    {
                        copyISOCheckBox.Checked = false;
                        return;
                    }
                }
            }
            else if (!copyISOCheckBox.Checked && !string.IsNullOrEmpty(ISOPathName.Text))
            {
                ISOPathName.Text = string.Empty;
            }
        }

        private void ISOPathName_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ISOPathName_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (FileList.Length == 1)
            {
                ISOPathName.Text = FileList[0];
                copyISOCheckBox.Checked = true;
            }
            else
            {
                MessageBox.Show("Invalid input or input not allowed.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ISOPathName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ISOPathName.Text))
                copyISOCheckBox.Checked = false;
        }

        private void SelectDriveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPartitionBootOptions();
        }

        private Version GetPowerShellVersion()
        {
            return Version.Parse(Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\3\PowerShellEngine", "PowerShellVersion", null).ToString());
        }

        private void ShowPropertiesButton_Click(object sender, EventArgs e)
        {
            DobsonUtilities.ShowProperties.ShowDriveProperties(SelectDriveComboBox.SelectedValue.ToString());
        }

        private void PartitionTypeDropDown_SelectedValueChanged(object sender, EventArgs e)
        {
            if (DriveFormatComboBox.DataSource != null) // if no drive is inserted, DataSouce will be null
            {
                if (PartitionTypeDropDown.SelectedItem.ToString() == "MBR")
                {
                    if (!MarkBootableCheckBox.Enabled)
                        MarkBootableCheckBox.Enabled = true;
                }
                else if (PartitionTypeDropDown.SelectedItem.ToString() == "GPT" && (DriveFormatComboBox.SelectedItem.ToString() == "NTFS" || DriveFormatComboBox.SelectedItem.ToString() == "exFAT"))
                {
                    if (MarkBootableCheckBox.Enabled)
                    {
                        MarkBootableCheckBox.Checked = false;
                        MarkBootableCheckBox.Enabled = false;
                    }
                }
                else if (PartitionTypeDropDown.SelectedItem.ToString() == "GPT" && (DriveFormatComboBox.SelectedItem.ToString() == "FAT32" || DriveFormatComboBox.SelectedItem.ToString() == "FAT"))
                {
                    if (!MarkBootableCheckBox.Enabled)
                        MarkBootableCheckBox.Enabled = true;
                }
            }
        }

        private void DriveFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PartitionTypeDropDown.SelectedItem.ToString() == "MBR")
            {
                if (!MarkBootableCheckBox.Enabled)
                    MarkBootableCheckBox.Enabled = true;
            }
            else if (PartitionTypeDropDown.SelectedItem.ToString() == "GPT" && (DriveFormatComboBox.SelectedItem.ToString() == "NTFS" || DriveFormatComboBox.SelectedItem.ToString() == "exFAT"))
            {
                if (MarkBootableCheckBox.Enabled)
                {
                    MarkBootableCheckBox.Checked = false;
                    MarkBootableCheckBox.Enabled = false;
                }
            }
            else if (PartitionTypeDropDown.SelectedItem.ToString() == "GPT" && (DriveFormatComboBox.SelectedItem.ToString() == "FAT32" || DriveFormatComboBox.SelectedItem.ToString() == "FAT"))
            {
                if (!MarkBootableCheckBox.Enabled)
                    MarkBootableCheckBox.Enabled = true;
            }
        }

        private void Perform_Action()
        {
            // disable UI elements while executing
            FormatUSBGroupBox.Enabled = false;
            //set variables
            string DestinationPath = SelectDriveComboBox.SelectedValue.ToString(); // for storing file copy destination
            string SourcePath = string.Empty; // mounted drive variable
            string diskPartResult = string.Empty; //for storing diskpart exit code
            progressBar.Maximum = 10;

            // set progress bar values
            if (copyISOCheckBox.Checked && !string.IsNullOrEmpty(ISOPathName.Text.ToString()))
            {
                // get list of optical drives before mounting ISO
                List<string> CDDrives = new List<string>();
                foreach (System.IO.DriveInfo cdDrive in System.IO.DriveInfo.GetDrives())
                {
                    if (cdDrive.IsReady && cdDrive.DriveType == System.IO.DriveType.CDRom)
                    {
                        CDDrives.Add(cdDrive.Name);
                    }
                }

                // use powershell to mount iso
                StatusLabel.Text = "Mounting ISO";
                DobsonUtilities.RunProcess ps = new DobsonUtilities.RunProcess("PowerShell.exe");
                ps.Arguments = "-command Mount-DiskImage -ImagePath '" + ISOPathName.Text.ToString() + "'";
                string result = ps.Execute();

                // verify iso was mounted
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Failed to mount disk image", "Mount failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    copyISOCheckBox.Checked = false;
                    FormatUSBGroupBox.Enabled = true;
                    return;
                }

                // get list of optical drives after mounting ISO
                foreach (System.IO.DriveInfo cdDrive in System.IO.DriveInfo.GetDrives())
                {
                    if (cdDrive.IsReady && cdDrive.DriveType == System.IO.DriveType.CDRom)
                    {
                        if (!CDDrives.Contains(cdDrive.Name))
                            SourcePath = cdDrive.Name;
                    }
                }

                // check if drive letter was found
                if (string.IsNullOrEmpty(SourcePath))
                {
                    MessageBox.Show("Could not locate mounted disk image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    copyISOCheckBox.Checked = false;
                    FormatUSBGroupBox.Enabled = true;
                    return;
                }

                // Check if destination is large enough
                StatusLabel.Text = "Examining ISO";
                if (new System.IO.DriveInfo(DestinationPath).TotalSize <= new System.IO.DriveInfo(SourcePath).TotalSize)
                {
                    MessageBox.Show(SelectDriveComboBox.SelectedItem.ToString() + " is not large enough. Insert a larger drive\nor choose a different ISO.\n\n" +
                        "Source: " + DobsonUtilities.FormatBytes.Format(new System.IO.DriveInfo(SourcePath).TotalSize) + "\n" +
                        "Destination: " + DobsonUtilities.FormatBytes.Format(new System.IO.DriveInfo(DestinationPath).TotalSize),
                        "Destination too small", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    copyISOCheckBox.Checked = false;
                    FormatUSBGroupBox.Enabled = true;
                    ps.Arguments = "-command Dismount-DiskImage -ImagePath '" + ISOPathName.Text.ToString() + "'";
                    ps.Execute();
                    return;
                }

                // if destination format is FAT32 or FAT and source contains files over 4GB, fail copy
                if (new System.IO.DriveInfo(DestinationPath).DriveFormat == "FAT" || new System.IO.DriveInfo(DestinationPath).DriveFormat == "FAT32")
                {
                    foreach (string file in System.IO.Directory.GetFiles(SourcePath, "*.*", System.IO.SearchOption.AllDirectories))
                    {
                        if (new System.IO.FileInfo(file).Length >= 4294967296)
                        {
                            MessageBox.Show("Destination format does not accept files larger than 4GB.\nReformat destination with a file system that accepts larger files.", "File size error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            copyISOCheckBox.Checked = false;
                            FormatUSBGroupBox.Enabled = true;
                            ps.Arguments = "-command Dismount-DiskImage -ImagePath '" + ISOPathName.Text.ToString() + "'";
                            ps.Execute();
                            return;
                        }
                    }
                }

                // Check if destination drive is empty; 1 = root directory, > 1 = other files / drive not empty
                /*  WE ARE GOING TO FORMAT THE USB DRIVE BEFORE COPYING SO THIS STEP ISN'T NECESSARY
                while (System.IO.Directory.GetFileSystemEntries(SelectDriveComboBox.SelectedValue.ToString()).Length > 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Drive " + SelectDriveComboBox.SelectedValue.ToString() + " is not empty. Continuing will erase all contents from the drive.\n\nWould you like to continue?", "Drive not empty", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.No)
                    {
                        copyISOCheckBox.Checked = false;
                        FormatUSBGroupBox.Enabled = true;
                        ps.Arguments = "-command Dismount-DiskImage -ImagePath '" + ISOPathName.Text.ToString() + "'";
                        ps.Execute();
                        return;
                    }
                    else if (dialogResult == DialogResult.Yes)
                        break;
                }
                */

                // finally, tally total number of files to copy for progress bar
                progressBar.Maximum += System.IO.Directory.GetFiles(SourcePath, "*.*", System.IO.SearchOption.AllDirectories).Length;
            }

            //MessageBox.Show("Progress bar maximum: " + progressBar.Maximum.ToString());

            // build diskpart script
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Environment.ExpandEnvironmentVariables("%Temp%").ToString() + @"\WinHealthChk.txt"))
            {
                sw.WriteLine("select volume {0}", DestinationPath.Substring(0, 1));
                sw.WriteLine("clean");
                if (PartitionTypeDropDown.SelectedItem.ToString() == "MBR")
                {
                    sw.WriteLine("convert mbr noerr");
                    sw.WriteLine("create partition primary noerr");
                    if (MarkBootableCheckBox.Checked == true)
                        sw.WriteLine("active");
                    else if (MarkBootableCheckBox.Checked == false)
                        sw.WriteLine("inactive");
                }
                else if (PartitionTypeDropDown.SelectedItem.ToString() == "GPT")
                {
                    sw.WriteLine("convert gpt noerr");
                    if (MarkBootableCheckBox.Checked && (DriveFormatComboBox.SelectedItem.ToString() == "FAT32" || DriveFormatComboBox.SelectedItem.ToString() == "FAT"))
                        sw.WriteLine("active");
                    /*
                    if (MarkBootableCheckBox.Checked == true && DriveFormatComboBox.SelectedValue.ToString() == "NTFS")
                    {
                        sw.WriteLine("create partition efi size=1 noerr");
                        sw.WriteLine("format fs=fat unit=512 label=\"efi\" quick noerr");
                    }
                    */
                    sw.WriteLine("create partition primary noerr");
                }
                sw.WriteLine("format fs={0} Label=\"{1}\" quick noerr", DriveFormatComboBox.SelectedValue.ToString(), DriveLabelTextBox.Text.ToString());
                sw.WriteLine("exit");
            }

            StatusLabel.Text = "Formatting drive " + SelectDriveComboBox.SelectedItem.ToString();
            DobsonUtilities.RunProcess diskPart = new DobsonUtilities.RunProcess("diskpart.exe", "/s \"" + Environment.ExpandEnvironmentVariables("%Temp%").ToString() + "\\WinHealthchk.txt\"");

            // increment progress bar and perform action
            do
            {
                progressBar.PerformStep();
                //System.Threading.Thread.Sleep(50);
                Application.DoEvents();

                if (progressBar.Value == 6)
                {
                    diskPartResult = diskPart.Execute();
                    if (!string.IsNullOrEmpty(diskPartResult))
                        break;
                }
            } while (progressBar.Value < 10);

            // check if there was an error
            if (!string.IsNullOrEmpty(diskPartResult))
            {
                MessageBox.Show("Process returned " + diskPartResult, "Formatting error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (copyISOCheckBox.Checked)
                {
                    // unmount drive
                    DobsonUtilities.RunProcess ps = new DobsonUtilities.RunProcess("PowerShell.exe");
                    ps.Arguments = "-command Dismount-DiskImage -ImagePath '" + ISOPathName.Text.ToString() + "'";
                    ps.Execute();
                    copyISOCheckBox.Checked = false;
                }
                FormatUSBGroupBox.Enabled = true;
                progressBar.Value = 0;
                return;
            }

            // copy iso if checked
            if (copyISOCheckBox.Checked && !string.IsNullOrEmpty(SourcePath))
            {
                StatusLabel.Text = "Starting copy";
                XCopy(SourcePath, DestinationPath, progressBar, StatusLabel);

                // unmount drive
                DobsonUtilities.RunProcess ps = new DobsonUtilities.RunProcess("PowerShell.exe");
                ps.Arguments = "-command Dismount-DiskImage -ImagePath '" + ISOPathName.Text.ToString() + "'";
                ps.Execute();
                copyISOCheckBox.Checked = false;
                FormatUSBGroupBox.Enabled = true;
                progressBar.Value = 0;
            }

            // reset status bar
            StatusLabel.Text = "";

            // enable UI elements when complete
            FormatUSBGroupBox.Enabled = true;
            if (Environment.OSVersion.Version <= Version.Parse("6.1"))
                copyISOCheckBox.Enabled = false;

            // display success or failure message
            MessageBox.Show("Operation complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // remove temp file when done
            if (System.IO.File.Exists(Environment.ExpandEnvironmentVariables("%Temp%").ToString() + @"\WinHealthChk.txt"))
                System.IO.File.Delete(Environment.ExpandEnvironmentVariables("%Temp%").ToString() + @"\WinHealthChk.txt");
            // reset progress bar
            progressBar.Value = 0;
        }

        private void ProgressBarText()
        {
            int percent = (int)(((double)(progressBar.Value - progressBar.Minimum) / (double)(progressBar.Maximum - progressBar.Minimum)) * 100);

            using (Graphics gr = progressBar.CreateGraphics())
            {
                gr.DrawString(percent.ToString() + "%",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(progressBar.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F),
                    progressBar.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)));
            }
        }

        private static void XCopy(string SourcePath, string DestinationPath, ProgressBar progressBar, Label statusLabel)
        {
            Application.DoEvents();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(SourcePath);

            System.IO.DirectoryInfo[] directories = dir.GetDirectories();
            //if destination dir doens't exist, create it
            if (!System.IO.Directory.Exists(DestinationPath))
            {
                statusLabel.Text = "Creating directory " + DestinationPath;
                System.IO.Directory.CreateDirectory(DestinationPath);
                progressBar.PerformStep();
            }

            // Get the files in the directory and copy them to the new location
            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                Application.DoEvents();
                string TempPath = System.IO.Path.Combine(DestinationPath, file.Name);
                statusLabel.Text = "Copying " + file.FullName.Substring(3) + " (" + DobsonUtilities.FormatBytes.Format(file.Length) + ")";
                try
                {
                    file.CopyTo(TempPath, false);
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show("Error copying " + file + "\n" + ex.Message.ToString(), "I/O Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Security.SecurityException ex)
                {
                    MessageBox.Show("Error copying " + file + "\n" + ex.Message.ToString(), "Security Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Error copying " + file + "\n" + ex.Message.ToString(), "Unauthorized Access Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                progressBar.PerformStep();
            }

            // Copy subdirectories
            foreach (System.IO.DirectoryInfo subdir in dir.GetDirectories())
            {
                string TempPath = System.IO.Path.Combine(DestinationPath, subdir.Name);
                XCopy(subdir.FullName, TempPath, progressBar, statusLabel);
            }
        }
    }
}
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
    public partial class DriveStats : Form
    {
        //private string Drive;
        private System.IO.DriveInfo Drive;

        public DriveStats(string drive)
        {
            InitializeComponent();

            Drive = new System.IO.DriveInfo(drive);
        }

        public DriveStats(System.IO.DriveInfo drive)
        {
            InitializeComponent();

            Drive = drive;
        }

        private void DriveStats_Load(object sender, EventArgs e)
        {
            UInt64 fileSize = 0, fileCount = 0, SystemTempSize = 0;
            this.Text = $"Statistics for drive { Drive.Name }";
            System.IO.DirectoryInfo dirInfo = Drive.RootDirectory;
            FileStatistics largestFile = new FileStatistics();

            ProgressDialog progress = new ProgressDialog();
            progress.Maximum = dirInfo.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly).Count();
            //progress.Maximum = dirInfo.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly).Where(x => !(x.Attributes.HasFlag(System.IO.FileAttributes.Hidden))).Count();
            progress.Step = 1;
            progress.Show();

            foreach (System.IO.DirectoryInfo dir in dirInfo.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly).Where(x => !(x.Attributes.HasFlag(System.IO.FileAttributes.Hidden)
                && x.Attributes.HasFlag(System.IO.FileAttributes.System)))) // exclude root directories flagged as system and hidden
            {
                DirectoryStatistics directoryStatistics = new DirectoryStatistics();
                directoryStatistics.DirectoryName = dir.Name;
                directoryStatistics.FullPathName = dir.FullName;
                progress.Text = $"Scanning { dir.FullName }";

                foreach (System.IO.FileInfo file in GetDirectorySize(dir))
                {
                    if ((UInt64)file.Length > largestFile.FileSize)
                    {
                        largestFile.FileName = file.Name;
                        largestFile.FileSize = (UInt64)file.Length;
                    }
                    fileSize += (UInt64)file.Length;
                    directoryStatistics.DirectorySize += (UInt64)file.Length;
                    Application.DoEvents(); // to keep application responsive
                }

                fileCount += GetDirectoryFileCount(dir);
                directoryStatistics.NumberOfFiles += GetDirectoryFileCount(dir);

                dataGridView1.Rows.Add(dir.FullName, DobsonUtilities.FormatBytes.Format(directoryStatistics.DirectorySize), string.Format("{0:N0}", directoryStatistics.NumberOfFiles));
                progress.PerformStep();
            }

            if (System.IO.Directory.Exists(Environment.ExpandEnvironmentVariables("%windir%").ToString() + "\\Temp"))
            {
                foreach (System.IO.FileInfo file in new System.IO.DirectoryInfo(Environment.ExpandEnvironmentVariables("%windir%").ToString() + "\\Temp").EnumerateFiles("*.*", System.IO.SearchOption.AllDirectories))
                {
                    SystemTempSize += (UInt64)file.Length;
                    Application.DoEvents();
                }
            }

            UInt64 AvgFileSize = fileSize / fileCount;
            lblAvgFileSize2.Text = $"{ DobsonUtilities.FormatBytes.Format(AvgFileSize)}";
            lblLargestFile2.Text = $"{ DobsonUtilities.FormatBytes.Format(largestFile.FileSize)}";
            lblLargestFile3.Text = $"{ largestFile.FileName }";
            lblSystemTempSize2.Text = $"{ DobsonUtilities.FormatBytes.Format(SystemTempSize)}";

            progress.Close();
            progress.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // recursive directory search for file info
        public static List<System.IO.FileInfo> GetDirectorySize(System.IO.DirectoryInfo dirInfo, string FileSearchPattern = "*")
        {
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();

            foreach (System.IO.FileInfo file in dirInfo.EnumerateFiles(FileSearchPattern, System.IO.SearchOption.TopDirectoryOnly))
            {
                files.Add(file);
                Application.DoEvents();
            }
            foreach (System.IO.DirectoryInfo subfolder in dirInfo.EnumerateDirectories("*", System.IO.SearchOption.TopDirectoryOnly))
            {
                try
                {
                    files.AddRange(GetDirectorySize(subfolder, FileSearchPattern));
                }
                catch
                {
                    // do nothing
                }
            }

            return files;
        }

        public static UInt64 GetDirectoryFileCount(System.IO.DirectoryInfo dirInfo, string FileSearchPattern = "*")
        {
            UInt64 fileCount = (UInt64)dirInfo.EnumerateFiles("*", System.IO.SearchOption.TopDirectoryOnly).Count();

            foreach (System.IO.DirectoryInfo subdir in dirInfo.EnumerateDirectories(FileSearchPattern, System.IO.SearchOption.TopDirectoryOnly))
            {
                try
                {
                    fileCount += GetDirectoryFileCount(subdir, FileSearchPattern);
                    Application.DoEvents();
                }
                catch
                {
                    // do nothing
                }
            }

            return fileCount;
        }
    }
}

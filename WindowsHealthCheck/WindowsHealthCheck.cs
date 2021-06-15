using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;

namespace WindowsHealthCheck
{
    public partial class WindowsHealthCheck : Form
    {
        // Set global vars
        private static bool exitWhenDone = false;

        public WindowsHealthCheck()
        {
            InitializeComponent();
        }

        public WindowsHealthCheck(bool clear, bool defrag, bool restore, bool sfc, bool silent)
        {
            InitializeComponent();

            // supported OS check
            CheckOSVersion();

            // set program options per command line
            sfcCheckBox.Checked = sfc;
            dismCheckBox.Checked = restore;
            clearCheckBox.Checked = clear;
            defragCheckBox.Checked = defrag;
            exitWhenDone = silent;

            // ?
            showOutputToolStripMenuItem.Checked = true;

            // Start application as a new thread
            Thread thread = new Thread(new ThreadStart(WorkerThread));
            thread.Start();
        }

        private void WindowsHealthCheck_Load(object sender, EventArgs e)
        {
            // supported OS check
            CheckOSVersion();

            // Check for pending reboots
            CheckPendingReboots();

            // Check for and move legacy registry path
            MoveLegacyRegistrySettings();

            // Check for WinDirStat
            CheckWinDirStat();

            // Set drive timer to refresh drive statistics
            System.Timers.Timer driveStatusTimer = new System.Timers.Timer(1000); // 1,000 = 1 sec
            driveStatusTimer.AutoReset = true;
            driveStatusTimer.Enabled = true;
            driveStatusTimer.Elapsed += new System.Timers.ElapsedEventHandler(TriggeredUpdateDriveStatus);
            driveStatusTimer.Start();

            // Set RAM timer to refresh RAM statistics
            System.Timers.Timer memoryStatusTimer = new System.Timers.Timer(2000);
            memoryStatusTimer.AutoReset = true;
            memoryStatusTimer.Enabled = false;
            memoryStatusTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateMemoryStatus);
            memoryStatusTimer.Start();

            string SystemDrive = Environment.ExpandEnvironmentVariables("%SystemDrive%").ToString() + @"\";
            UpdateDriveStatus(SystemDrive);
            //UpdateMemoryStatus();

            // Get list of fixed disks
            PopulateDrives();

            LoadPrefs();

            if (exitWhenDone)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void CheckPendingReboots()
        {
            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\RebootRequired", false) != null)
            {
                using (Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\RebootRequired", false))
                {
                    if (regkey.GetValueNames().ToList().Count > 0 && !exitWhenDone)
                    {
                        DialogResult result = MessageBox.Show("There are pending system updates. Please reboot the system before running WindowsHealthCheck.\n\nContinue anyway?", "Pending Updates", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Some features will be disabled until all pending updates have been installed.", "Please reboot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sfcCheckBox.Checked = false; //disable SFC
                            sfcCheckBox.Enabled = false;
                            clearCheckBox.Checked = false; // disable clearing cached updates
                            clearCheckBox.Enabled = false;
                        }
                        else if (result == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                    else if (regkey.GetValueNames().ToList().Count > 0 && exitWhenDone)
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void CheckOSVersion()
        {
            Version OSVerion = Environment.OSVersion.Version;
            if (OSVerion < Version.Parse("6.0") && !exitWhenDone)
            {
                MessageBox.Show("Windows Vista or later required", "Unsupported version of Windows", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else if (OSVerion < Version.Parse("6.0") && exitWhenDone)
            {
                Application.Exit();
            }
            // override options based upon version of OS running
            else if (OSVerion == Version.Parse("6.0"))
            {
                dismCheckBox.Enabled = false;
                dismToolTip.SetToolTip(dismCheckBox, "DISM not supported on Windows Vista");
            }
        }

        private void MoveLegacyRegistrySettings()
        {
            if (Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\WindowsHealthCheck", false) != null)
            {
                using (Microsoft.Win32.RegistryKey software = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true))
                {
                    software.CreateSubKey(@"Dobson Utilities\WindowsHealthCheck", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);

                    using (Microsoft.Win32.RegistryKey legacyKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\WindowsHealthCheck", false))
                    using (Microsoft.Win32.RegistryKey newKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Dobson Utilities\\WindowsHealthCheck", true))
                    {
                        if (legacyKey.GetValue("BackgroundColor") != null)
                            newKey.SetValue("BackgroundColor", legacyKey.GetValue("BackgroundColor"), legacyKey.GetValueKind("BackgroundColor"));
                        if (legacyKey.GetValue("TextColor") != null)
                            newKey.SetValue("TextColor", legacyKey.GetValue("TextColor"), legacyKey.GetValueKind("TextColor"));
                        if (legacyKey.GetValue("SaveOutput") != null)
                            newKey.SetValue("SaveOutput", legacyKey.GetValue("SaveOutput"), legacyKey.GetValueKind("SaveOutput"));
                        if (legacyKey.GetValue("AutoUpdate") != null)
                            newKey.SetValue("AutoUpdate", legacyKey.GetValue("AutoUpdate"), legacyKey.GetValueKind("AutoUpdate"));
                    }
                    software.DeleteSubKeyTree("WindowsHealthCheck");
                }
            }
        }

        private void PopulateDrives()
        {
            string SystemDrive = Environment.ExpandEnvironmentVariables("%SystemDrive%").ToString() + @"\";
            List<string> FixedDisks = new List<string>();

            foreach (DriveInfo Disk in DriveInfo.GetDrives())
            {
                if (Disk.DriveType == DriveType.Fixed)
                {
                    FixedDisks.Add(Disk.Name);
                }
            }

            if (DriveBox1.DataSource == null)
            {
                DriveBox1.DataSource = FixedDisks;
            }
            // Set system drive as default selected disk
            if (FixedDisks.Contains(SystemDrive))
            {
                DriveBox1.SelectedText = SystemDrive; // Must use SelectedText for this
            }
            // if there's only one drive, disable control
            if (FixedDisks.Count == 1)
            {
                DriveBox1.Enabled = false;
            }
        }

        private void LoadPrefs()
        {
            // Create RegHandler instance
            DobsonUtilities.RegHandler winHealthCheckReg = new DobsonUtilities.RegHandler("Dobson Utilities\\WindowsHealthCheck");
            // Get SaveOutput preference
            if (winHealthCheckReg.GetValue("SaveOutput") == "1")
            {
                saveOutputToLogToolStripMenuItem.Checked = true;
            }

            if (winHealthCheckReg.GetValue("AutoUpdate") == "1")
            {
                autoUpdateToolStripMenuItem.Checked = true;
                Updater.GetUpdate(true);
            }
        }

        private void CheckWinDirStat()
        {
            if (File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles%").ToString() + @"\WinDirStat\WinDirStat.exe") || File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%").ToString() + @"\WinDirStat\WinDirSTat.exe"))
            {
                winDirStatToolStripMenuItem.Visible = true;
            }
        }

        private void CheckBlueScreenView()
        {
            if (File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles%").ToString() + @"\NirSoft\BlueScreenView.exe") || File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%").ToString() + @"\NirSoft\BlueSCreenView.exe"))
            {
                blueScreenViewToolStripMenuItem.Visible = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit Windows Health Check?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
                Application.Exit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (!sfcCheckBox.Checked && !dismCheckBox.Checked && !clearCheckBox.Checked && !defragCheckBox.Checked)
            {
                MessageBox.Show("Please select an option.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (clearCheckBox.Checked && !exitWhenDone)
            {
                DialogResult dialogResult = MessageBox.Show("Warning: You have selected to clear Windows updates from your system. You will not be able to uninstall these updates after this process completes.\n\nAre you sure you want to continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                    clearCheckBox.Checked = false;
            }

            Thread thread = new Thread(new ThreadStart(WorkerThread));
            //thread.Priority = ThreadPriority.AboveNormal;
            thread.Start();
        }

        private string RunProgram(DobsonUtilities.RunProcess process)
        {
            toolStripStatusLabel1.Text = $"Running { process.ApplicationName.Name } { process.Arguments }";
            return process.Execute();
        }

        private void WorkerThread()
        {
            // disable parts of the GUI while we work
            StartButton.Enabled = false;
            fileToolStripMenuItem.Enabled = false;
            optionsToolStripMenuItem.Enabled = false;
            // Get OS version
            Version OSVer = Environment.OSVersion.Version;
            // Set variable constants
            string WinDir = Environment.ExpandEnvironmentVariables("%WinDir%").ToString();
            // setup progress bar value
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = 0;
            if (sfcCheckBox.Checked)
                toolStripProgressBar1.Maximum += 25;
            if (dismCheckBox.Checked)
                toolStripProgressBar1.Maximum += 25;
            if (clearCheckBox.Checked)
                toolStripProgressBar1.Maximum += 25;
            if (defragCheckBox.Checked)
                toolStripProgressBar1.Maximum += 25;
            string runResult = string.Empty;
            int checkValue = 0;

            panel1.Enabled = false;
            checkForUpdateToolStripMenuItem.Enabled = false;

            if (sfcCheckBox.Checked)
            {
                FileInfo application = new FileInfo(WinDir + "\\system32\\sfc.exe");
                if (application.Exists && Process.GetProcessesByName(Path.GetFileNameWithoutExtension(application.Name)).Length == 0)
                {
                    DobsonUtilities.RunProcess sfc = new DobsonUtilities.RunProcess(application, "/Scannow", showOutputToolStripMenuItem.Checked, saveOutputToLogToolStripMenuItem.Checked);
                    toolStripStatusLabel1.Text = $"Running { application.Name } { sfc.Arguments }";

                    while (toolStripProgressBar1.Value <= 25)
                    {
                        Application.DoEvents();
                        Thread.Sleep(500);
                        toolStripProgressBar1.PerformStep();
                        if (toolStripProgressBar1.Value == 13)
                            runResult = sfc.Execute();
                    }

                    if (!string.IsNullOrEmpty(runResult) && !exitWhenDone)
                    {
                        MessageBox.Show(runResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        runResult = string.Empty; //reset runResult
                    }
                }
                else
                {
                    if (!exitWhenDone)
                        MessageBox.Show("SFC not found or it is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (dismCheckBox.Checked)
            {
                FileInfo application = new FileInfo(WinDir + "\\System32\\dism.exe");
                if (application.Exists && Process.GetProcessesByName(Path.GetFileNameWithoutExtension(application.Name)).Length == 0)
                {
                    DobsonUtilities.RunProcess dism = new DobsonUtilities.RunProcess(application, null, showOutputToolStripMenuItem.Checked, saveOutputToLogToolStripMenuItem.Checked);
                    if (OSVer >= Version.Parse("6.2") && OSVer < Version.Parse("11.0"))
                    {
                        dism.Arguments = "/Online /Cleanup-Image /RestoreHealth";
                    }
                    else if (OSVer >= Version.Parse("6.1") && OSVer < Version.Parse("6.2"))
                    {
                        dism.Arguments = "/Online /Cleanup-Image /ScanHealth";
                    }
                    toolStripStatusLabel1.Text = $"Running { application.Name } { dism.Arguments }";

                    if (toolStripProgressBar1.Maximum >= 50)
                        checkValue = 36;
                    else if (toolStripProgressBar1.Maximum == 25)
                        checkValue = 13;
                    while ((toolStripProgressBar1.Maximum >= 50 && toolStripProgressBar1.Value <= 50) || (toolStripProgressBar1.Maximum == 25 && toolStripProgressBar1.Value <= 25))
                    {
                        Application.DoEvents();
                        Thread.Sleep(500);
                        toolStripProgressBar1.PerformStep();
                        if (toolStripProgressBar1.Value == checkValue)
                            runResult = dism.Execute();
                        if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
                            break;
                    }

                    if (!string.IsNullOrEmpty(runResult) && !exitWhenDone)
                    {
                        MessageBox.Show(runResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        runResult = string.Empty; //reset runResult
                    }
                }
            }

            if (clearCheckBox.Checked)
            {
                if (Directory.Exists(WinDir + "\\SoftwareDistribution"))
                {
                    if (DobsonUtilities.WindowsService.Status("wuauserv") == "Running")
                        DobsonUtilities.WindowsService.Stop("wuauserv");
                    if (DobsonUtilities.WindowsService.Status("wuauserv") != "Stopped" && !exitWhenDone)
                        MessageBox.Show("Unable to stop the Windows Update service!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = "Removing " + WinDir + "\\SoftwareDistribution";
                    try
                    {
                        RemoveDirectory(new DirectoryInfo(WinDir + "\\SoftwareDistribution"));
                    }
                    catch (Exception error)
                    {
                        if (!exitWhenDone)
                            MessageBox.Show(error.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (DobsonUtilities.WindowsService.Status("wuauserv") == "Stopped")
                        DobsonUtilities.WindowsService.Start("wuauserv");
                }
                else
                {
                    if (!exitWhenDone)
                        MessageBox.Show(WinDir + "\\SoftwareDistribution folder does not exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // clear out excessive msi logs
                UInt64 tempSize = 0;
                string[] tempFiles = Directory.GetFiles(WinDir + "\\Temp", "msi*.log", SearchOption.AllDirectories);
                foreach (string file in tempFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    tempSize += (UInt64)fileInfo.Length;
                }
                if (tempSize > 1073741824) // if logs are consuming more than 1GiB of space
                {
                    foreach (string file in tempFiles)
                    {
                        try
                        {
                            toolStripStatusLabel1.Text = $"Deleting { file }";
                            File.Delete(file);
                        }
                        catch (DirectoryNotFoundException dnf)
                        {
                            if (!exitWhenDone)
                                MessageBox.Show(dnf.ToString(), "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        catch (UnauthorizedAccessException ua)
                        {
                            if (!exitWhenDone)
                                MessageBox.Show(ua.ToString(), "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

                // run Dism component cleanup
                if (OSVer >= Version.Parse("6.2") && OSVer < Version.Parse("11.0"))
                {
                    FileInfo application = new FileInfo(WinDir + "\\system32\\dism.exe");
                    if (application.Exists && Process.GetProcessesByName(Path.GetFileNameWithoutExtension(application.Name)).Length == 0)
                    {
                        DobsonUtilities.RunProcess cleanup = new DobsonUtilities.RunProcess(application, "/online /cleanup-image /StartComponentCleanup", showOutputToolStripMenuItem.Checked, saveOutputToLogToolStripMenuItem.Checked);
                        toolStripStatusLabel1.Text = $"Running { application.Name } { cleanup.Arguments }";

                        if (toolStripProgressBar1.Maximum >= 75)
                            checkValue = 63;
                        else if (toolStripProgressBar1.Maximum == 50)
                            checkValue = 38;
                        else if (toolStripProgressBar1.Maximum == 25)
                            checkValue = 13;
                        while ((toolStripProgressBar1.Maximum >= 75 && toolStripProgressBar1.Value <= 75) || (toolStripProgressBar1.Maximum == 50 && toolStripProgressBar1.Value <= 50) ||
                            (toolStripProgressBar1.Maximum == 25 && toolStripProgressBar1.Value <= 25))
                        {
                            Application.DoEvents();
                            Thread.Sleep(500);
                            toolStripProgressBar1.PerformStep();
                            if (toolStripProgressBar1.Value == checkValue)
                                runResult = cleanup.Execute();
                            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
                                break;
                        }

                        if (!string.IsNullOrEmpty(runResult) && !exitWhenDone)
                        {
                            MessageBox.Show(runResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            runResult = string.Empty; //reset runResult
                        }
                    }
                    else
                    {
                        MessageBox.Show("Could not start DISM: File not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (defragCheckBox.Checked)
            {
                FileInfo application = new FileInfo(WinDir + "\\system32\\defrag.exe");
                if (application.Exists && Process.GetProcessesByName(Path.GetFileNameWithoutExtension(application.Name)).Length == 0)
                {
                    DobsonUtilities.RunProcess defrag = new DobsonUtilities.RunProcess(application, null, showOutputToolStripMenuItem.Checked, saveOutputToLogToolStripMenuItem.Checked);
                    if (OSVer >= Version.Parse("6.2") && OSVer < Version.Parse("11.0"))
                    {
                        defrag.Arguments = Environment.ExpandEnvironmentVariables("%SystemDrive%").ToString() + " /O /U /V";
                    }
                    else if (OSVer.Major == 6 && OSVer.Minor == 1)
                    {
                        defrag.Arguments = Environment.ExpandEnvironmentVariables("%SystemDrive%").ToString() + " /U /V";
                    }
                    else if (OSVer.Major == 6 && OSVer.Minor == 0)
                    {
                        defrag.Arguments = Environment.ExpandEnvironmentVariables("%SystemDrive%").ToString() + " -V";
                    }
                    toolStripStatusLabel1.Text = $"Running { application.Name } { defrag.Arguments }";

                    if (toolStripProgressBar1.Maximum == 100)
                        checkValue = 78;
                    else if (toolStripProgressBar1.Maximum == 75)
                        checkValue = 63;
                    else if (toolStripProgressBar1.Maximum == 50)
                        checkValue = 38;
                    else if (toolStripProgressBar1.Maximum == 25)
                        checkValue = 13;
                    while ((toolStripProgressBar1.Maximum == 100 && toolStripProgressBar1.Value <= 100) || (toolStripProgressBar1.Maximum == 75 && toolStripProgressBar1.Value <= 75) ||
                        (toolStripProgressBar1.Maximum == 50 && toolStripProgressBar1.Value <= 50) || (toolStripProgressBar1.Maximum == 25 && toolStripProgressBar1.Value <= 25))
                    {
                        Application.DoEvents();
                        Thread.Sleep(500);
                        toolStripProgressBar1.PerformStep();
                        if (toolStripProgressBar1.Value == checkValue)
                            runResult = defrag.Execute();
                        if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
                            break;
                    }

                    if (!string.IsNullOrEmpty(runResult) && !exitWhenDone)
                    {
                        MessageBox.Show(runResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        runResult = string.Empty; //reset runResult
                    }

                }
                else
                {
                    MessageBox.Show("Defrag not found or it is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (exitWhenDone)
                Environment.Exit(0);

            toolStripStatusLabel1.Text = string.Empty;

            panel1.Enabled = true;
            sfcCheckBox.Checked = false;
            dismCheckBox.Checked = false;
            clearCheckBox.Checked = false;
            defragCheckBox.Checked = false;
            fileToolStripMenuItem.Enabled = true;
            optionsToolStripMenuItem.Enabled = true;
            checkForUpdateToolStripMenuItem.Enabled = true;
            StartButton.Enabled = true;
        }

        // Remove directory static recursive function
        private static void RemoveDirectory(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.EnumerateFiles())
                file.Delete();
            foreach (DirectoryInfo subFolder in directoryInfo.EnumerateDirectories())
            {
                subFolder.Delete(true);
                //RemoveDirectory(subFolder);
            }
        }

        private void windowsMemoryDiagnosticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string WinDir = Environment.ExpandEnvironmentVariables("%WinDir%").ToString();
            if (File.Exists(WinDir + @"\system32\mdsched.exe"))
            {
                using (Process process = new Process())
                {
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.FileName = WinDir + @"\system32\mdsched.exe";
                    process.Start();
                }
            }
        }

        private void TriggeredUpdateDriveStatus(object source, System.Timers.ElapsedEventArgs e)
        {
            UpdateDriveStatus(DriveBox1.SelectedValue.ToString());
        }

        private void UpdateDriveStatus(string DiskDrive)
        {
            // Specify system drive to gather data
            DriveInfo drive = new DriveInfo(DiskDrive);
            // Get percent free space
            double percentFree = (double)drive.TotalFreeSpace / drive.TotalSize;
            // Get percent used
            double percentUsed = (double)(drive.TotalSize - drive.TotalFreeSpace) / drive.TotalSize;
            // set bar color based upon percent free
            if (percentFree <= 0.1)
                DriveStatusBox2.BackColor = Color.Red;
            else if (percentFree <= 0.2 && percentFree >= 0.11)
                DriveStatusBox2.BackColor = Color.Yellow;
            else
                DriveStatusBox2.BackColor = Color.Blue;
            // Set DriveStatusBox2 size, displaying more or less of DriveStatusBox1 to give appearance of a capacity bar
            DriveStatusBox2.Size = new Size((int)((DriveStatusBox1.Width - 2) * (drive.TotalSize - drive.TotalFreeSpace) / drive.TotalSize), DriveStatusBox1.Height - 4);
            // Set tooltips on drive stats boxes
            DriveToolTip1.SetToolTip(DriveStatusBox1, string.Format("{0} free of {1}   {2:P0} free", DobsonUtilities.FormatBytes.Format(drive.TotalFreeSpace), DobsonUtilities.FormatBytes.Format(drive.TotalSize),
                percentFree));
            DriveToolTip2.SetToolTip(DriveStatusBox2, string.Format("{0} used of {1}   {2:P0} used", DobsonUtilities.FormatBytes.Format(drive.TotalSize - drive.TotalFreeSpace), DobsonUtilities.FormatBytes.Format(drive.TotalSize),
                percentUsed));
        }

        private void UpdateMemoryStatus(object source, System.Timers.ElapsedEventArgs e)
        {
            Microsoft.VisualBasic.Devices.ComputerInfo computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
            // Get percent free memory
            double percentFree = (double)computerInfo.AvailablePhysicalMemory / computerInfo.TotalPhysicalMemory;
            // Get percent used memory
            double percentUsed = (double)(computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) / computerInfo.TotalPhysicalMemory;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox box = new AboutBox())
                box.ShowDialog(this);
        }

        private void getDriveStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DriveStats driveStats = new DriveStats(new DriveInfo(DriveBox1.SelectedValue.ToString())))
                driveStats.ShowDialog(this);
        }

        private void SystemDriveStatusLabel_DoubleClick(object sender, MouseEventArgs e)
        {
            using (DriveStats driveStats = new DriveStats(DriveBox1.SelectedValue.ToString()))
                driveStats.ShowDialog(this);
        }

        private void winDirStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(LaunchWinDirStat));
            thread.Start();
        }

        private void blueScreenViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(LaunchBlueScreenView));
            thread.Start();
        }

        private void LaunchWinDirStat()
        {
            // Check where WindirStat is installed
            string WinDirStatPath = string.Empty;
            if (Environment.ExpandEnvironmentVariables("%PROCESSOR_ARCHITECTURE%") == "x86" && File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles%").ToString() + @"\WinDirStat\WinDirStat.exe"))
                WinDirStatPath = Environment.ExpandEnvironmentVariables("%ProgramFiles%").ToString() + @"\WinDirStat\WinDirStat.exe";
            else if (Environment.ExpandEnvironmentVariables("%PROCESSOR_ARCHITECTURE%") == "AMD64" && File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%").ToString() + @"\WinDirStat\WinDirStat.exe"))
                WinDirStatPath = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%").ToString() + @"\WinDirStat\WinDirStat.exe";

            // Run program
            if (File.Exists(WinDirStatPath))
            {
                FileInfo winDirStat = new FileInfo(WinDirStatPath);
                DobsonUtilities.RunProcess WinDirStat = new DobsonUtilities.RunProcess(winDirStat, DriveBox1.SelectedValue.ToString());
                WinDirStat.Execute();
                while (Process.GetProcessesByName("windirstat").Length > 0)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Could not find WinDirStat.", "Application not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaunchBlueScreenView()
        {
            string BlueScreenViewPath = string.Empty;
            // Check where BlueScreenView is installed
            if (Environment.ExpandEnvironmentVariables("%PROCESSOR_ARCHITECTURE%") == "x86" && File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles%").ToString() + @"\NirSoft\BlueScreenView.exe"))
                BlueScreenViewPath = Environment.ExpandEnvironmentVariables("%ProgramFiles%").ToString() + @"\NirSoft\BlueScreenView.exe";
            else if (Environment.ExpandEnvironmentVariables("%PROCESSOR_ARCHITECTURE%") == "AMD64" && File.Exists(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%").ToString() + @"\NirSoft\BlueScreenView.exe"))
                BlueScreenViewPath = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%").ToString() + @"\NirSoft\BlueScreenView.exe";

            // Run program
            if (File.Exists(BlueScreenViewPath))
            {
                FileInfo blueScreenView = new FileInfo(BlueScreenViewPath);
                DobsonUtilities.RunProcess BlueScreenView = new DobsonUtilities.RunProcess(blueScreenView);
                BlueScreenView.Execute();
                while (Process.GetProcessesByName("BlueScreenView").Length > 0)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Could not find BlueScreenView.", "Application not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater.GetUpdate();
        }

        private void CommandsRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Help help = new Help(this.BackColor, this.ForeColor))
                help.ShowDialog(this);
        }

        private void DriveBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateDriveStatus(DriveBox1.SelectedValue.ToString());
        }

        private void saveOutputToLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveOutputToLogToolStripMenuItem.Checked)
            {
                //saveOutput = false;
                DobsonUtilities.RegHandler.WriteValue("Dobson Utilities\\WindowsHealthCheck", "SaveOutput", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
                //saveOutput = true;
                DobsonUtilities.RegHandler.WriteValue("Dobson Utilities\\WindowsHealthCheck", "SaveOutput", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        private void autoUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!autoUpdateToolStripMenuItem.Checked)
            {
                DobsonUtilities.RegHandler.WriteValue("Dobson Utilities\\WindowsHealthCheck", "AutoUpdate", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
                DobsonUtilities.RegHandler.WriteValue("Dobson Utilities\\WindowsHealthCheck", "AutoUpdate", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        private void formatRemoveableDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormatRemovableDrive rem = new FormatRemovableDrive(this.BackColor, this.ForeColor))
                rem.ShowDialog(this);
        }

        private void groupPolicyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set environment variables
            string TempDir = Environment.ExpandEnvironmentVariables("%Temp%").ToString();
            string WinDir = Environment.ExpandEnvironmentVariables("%WinDir%").ToString();

            FileInfo application = new FileInfo(WinDir + "\\System32\\gpresult.exe");
            if (application.Exists)
            {
                string runResult = string.Empty;
                DobsonUtilities.RunProcess gpr = new DobsonUtilities.RunProcess(application, $@"/h { TempDir }\gpresult.html");
                toolStripStatusLabel1.Text = $"Running { Path.GetFileNameWithoutExtension(application.Name)} { gpr.Arguments }";

                // display progress bar while collecting data
                ProgressDialog progress = new ProgressDialog();
                progress.Step = 1;
                progress.Show();
                for (byte i = 0; i <= 100; ++i)
                {
                    Application.DoEvents();
                    progress.PerformStep();
                    Thread.Sleep(50);
                    if (i == 3)
                        runResult = gpr.Execute();
                }
                progress.Close();
                progress.Dispose();
                toolStripStatusLabel1.Text = string.Empty;

                if (File.Exists(TempDir + "\\gpresult.html"))
                {
                    Uri gpresult = new Uri("file://" + TempDir + "/gpresult.html");
                    using (BrowserWindow browser = new BrowserWindow("Group Policy Result Browser", gpresult, this.BackColor))
                        browser.ShowDialog(this);
                    File.Delete(TempDir + "\\gpresult.html");
                }
                else if (!string.IsNullOrEmpty(runResult))
                {
                    MessageBox.Show(runResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Failed to generate result file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Unable to locate GPResult.exe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
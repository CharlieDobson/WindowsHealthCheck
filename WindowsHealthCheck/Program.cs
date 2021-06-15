using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsHealthCheck
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // set booleans for command line switches
            bool silent = false;
            bool sfc = false;
            bool restore = false;
            bool clear = false;
            bool defrag = false;
            bool all = false;

            // Delete Updater.exe
            if (System.IO.File.Exists("Updater.exe"))
            {
                try
                {
                    System.IO.File.Delete("Updater.exe");
                }
                catch
                {
                    //Do nothing
                }
            }

            // Make sure only a single instance is running
            if (System.Diagnostics.Process.GetProcessesByName("WindowsHealthCheck").Length > 1)
            {
                MessageBox.Show("Windows Health Check is already running.", "Process Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            // process command line arguments
            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg == "/?" || arg == "-?" || arg == "?" || arg.ToLower() == "/h" || arg.ToLower() == "-h" || arg.ToLower() == "/help" || arg.ToLower() == "-help")
                    {
                        ShowHelp();
                        break;
                    }
                    if (arg.ToLower() == "/q" || arg.ToLower() == "-q" || arg.ToLower() == "/quiet" || arg.ToLower() == "-quiet" || arg.ToLower() == "/silent" || arg.ToLower() == "-silent")
                    {
                        silent = true;
                    }
                    if (arg.ToLower() == "/all" || arg.ToLower() == "/a" || arg.ToLower() == "-a" || arg.ToLower() == "-all")
                    {
                        all = true;
                        break;
                    }
                    if (arg.ToLower() == "/clear" || arg.ToLower() == "-clear" || arg.ToLower() == "/c" || arg.ToLower() == "-c")
                        clear = true;
                    if (arg.ToLower() == "/defrag" || arg.ToLower() == "-defrag" || arg.ToLower() == "/d" || arg.ToLower() == "-d")
                        defrag = true;
                    if (arg.ToLower() == "/restore" || arg.ToLower() == "-restore" || arg.ToLower() == "/r" || arg.ToLower() == "-r")
                        restore = true;
                    if (arg.ToLower() == "/sfc" || arg.ToLower() == "-sfc" || arg.ToLower() == "/s" || arg.ToLower() == "-s")
                        sfc = true;
                }

                if (silent)
                    Console.WriteLine("Clear: {0}  Defrag: {1}  Restore: {2}  SFC: {3}", clear, defrag, restore, sfc);

                // run application
                if (all)
                    Application.Run(new WindowsHealthCheck(true, true, true, true, silent));
                else
                    Application.Run(new WindowsHealthCheck(clear, defrag, restore, sfc, silent));
            }
            // if no command line arguments, load GUI
            else
            {
                Application.Run(new WindowsHealthCheck());
            }
        }

        private static void ShowHelp()
        {
            MessageBox.Show("WindowsHealthCheck /C | /D | /R | /S   [/Q]\nWindowsHealthCheck /A [/Q]\nWindowsHealthCheck /? | /H | /Help \n\n" +
                "/A     Runs all health check options.\n" +
                "/C     Clears cached Windows Updates.\n" +
                "/D     Defrags [HDD} or retrims [SSD] the system drive.\n" +
                "/Q     Runs commands then exits.\n" +
                "/R     Runs DISM /Online /Cleanup-Image /RestoreHealth.\n" +
                "/S     Runs SFC /scannow.\n" + 
                "/?     Displays this help screen.\n\n" +
                "Warning: Running Clear cached Windows Updates will prevent you from uninstalling currently installed updates at a later time.", 
                "Help for WindowsHealchCheck " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DobsonUtilities
{
    sealed class RunProcess
    {
        // Getters and Setters
        public System.IO.FileInfo ApplicationName { get; set; }
        public string Arguments { get; set; } = string.Empty;
        public bool ShowOutputWindow { get; set; } = false;
        public bool LogFileEnabled { get; set; } = false;

        // Constructor that takes no arguments
        public RunProcess()
        {

        }

        // Constructor that takes one argument
        public RunProcess(System.IO.FileInfo ApplicationName)
        {
            this.ApplicationName = ApplicationName;
        }

        public RunProcess(string ApplicationName)
        {
            this.ApplicationName = new System.IO.FileInfo(ApplicationName);
        }

        // Constructor that takes two arguments
        public RunProcess(System.IO.FileInfo ApplicationNamee, string Arguments)
        {
            this.ApplicationName = ApplicationName;
            this.Arguments = Arguments;
        }

        public RunProcess(string ApplicationName, string Arguments)
        {
            this.ApplicationName = new System.IO.FileInfo(ApplicationName);
            this.Arguments = Arguments;
        }

        // Constructor that takes three arguments
        public RunProcess(System.IO.FileInfo ApplicationName, string Arguments, bool ShowOutputWindow)
        {
            this.ApplicationName = ApplicationName;
            this.Arguments = Arguments;
            this.ShowOutputWindow = ShowOutputWindow;
        }

        public RunProcess(string ApplicationName, string Arguments, bool ShowOutputWindow)
        {
            this.ApplicationName = new System.IO.FileInfo(ApplicationName);
            this.Arguments = Arguments;
            this.ShowOutputWindow = ShowOutputWindow;
        }

        // constructor that takes all arguments
        public RunProcess(System.IO.FileInfo ApplicationName, string Arguments, bool ShowOutputWindow, bool LogFileEnabled)
        {
            this.ApplicationName = ApplicationName;
            this.Arguments = Arguments;
            this.ShowOutputWindow = ShowOutputWindow;
            this.LogFileEnabled = LogFileEnabled;
        }

        public RunProcess(string ApplicationName, string Arguments, bool ShowOutputWindow, bool LogFileEnabled)
        {
            this.ApplicationName = new System.IO.FileInfo(ApplicationName);
            this.Arguments = Arguments;
            this.ShowOutputWindow = ShowOutputWindow;
            this.LogFileEnabled = LogFileEnabled;
        }

        // Execute program
        public string Execute()
        {
            string processResult = string.Empty;

            if (ApplicationName == null)
                return processResult;

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = ApplicationName.FullName.ToString();
                process.StartInfo.Arguments = Arguments;
                process.StartInfo.UseShellExecute = false; // Must be set to false for redirected output
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = ShowOutputWindow;
                process.StartInfo.RedirectStandardError = ShowOutputWindow;

                // Start execution if program name was specified
                try
                {
                    process.Start();

                    if (ShowOutputWindow)
                    {
                        string output = null;

                        // Capture output
                        using (System.IO.StreamReader reader = process.StandardOutput)
                        {
                            output = reader.ReadToEnd();
                        }
                        process.WaitForExit();

                        ConsoleWindow console = new ConsoleWindow();

                        if (LogFileEnabled)
                        {
                            // write output to log file
                            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() +
                                @"\" + System.IO.Path.GetFileNameWithoutExtension(ApplicationName.ToString()) + @".log"))
                            {
                                writer.WriteLine(output);
                                writer.Close();
                            }
                        }

                        // Display console window
                        console.AppendText(output);
                        console.ShowDialog();
                        console.Dispose();
                    }
                    else
                    {
                        process.WaitForExit();
                    }

                    if (process.ExitCode != 0)
                    {
                        processResult = process.ExitCode.ToString();
                    }
                }
                catch (Exception ex)
                {
                    processResult = ex.Message.ToString();
                }
            }
            return processResult;
        }

    }

    partial class ConsoleWindow : System.Windows.Forms.Form
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 16.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Green;
            this.textBox1.Location = new System.Drawing.Point(5, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(640, 432);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "";
            this.textBox1.WordWrap = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(287, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConsoleWindow
            // 
            this.AcceptButton = button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CancelButton = button1;
            this.ClientSize = new System.Drawing.Size(650, 490);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 490);
            this.MinimizeBox = false;
            this.Name = "ConsoleWindow";
            this.Opacity = 1.00D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;

        public ConsoleWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetOpacity(byte Opacity)
        {
            if (Opacity > 0 && Opacity <= 100)
                this.Opacity = (double)Opacity / 100;
        }

        public void SetText(string input)
        {
            this.textBox1.Text = input;
        }

        public void AppendText(string input)
        {
            this.textBox1.AppendText(input);
        }

        public void LoadTextFile(string FileName)
        {
            string input = "";

            using (System.IO.StreamReader sr = new System.IO.StreamReader(FileName))
            {
                while (!sr.EndOfStream)
                {
                    input += sr.ReadLine();
                }
                sr.Close();
            }

            if (!String.IsNullOrEmpty(input))
                this.textBox1.Text = input;
        }
    }
}

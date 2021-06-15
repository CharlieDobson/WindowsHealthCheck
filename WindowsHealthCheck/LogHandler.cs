using System;
using System.Collections.Generic;
using System.Text;

namespace DobsonUtilities
{
    sealed class LogHandler
    {
        private const UInt64 MAXLOGSIZE = 10000000000;

        // Constructor that takes no arguments
        public LogHandler()
        {
            logFile = string.Empty;
        }

        // Constructor that takes one argument
        public LogHandler(string LogFile)
        {
            logFile = LogFile;
        }

        // Getters and Setters
        public string logFile { get; set; }

        // functions
        public int AppendMessage(string msg)
        {
            // Create a file object to check file size
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(logFile);

            // delete file if it has gotten too large
            if (System.IO.File.Exists(logFile) && (UInt64)fileInfo.Length > MAXLOGSIZE)
            {
                try
                {
                    System.IO.File.Delete(logFile);
                }
                catch
                {
                    return 1;
                }
            }

            // create file if it doesn't exist, or append to existing file
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFile, true))
            {
                try
                {
                    sw.WriteLine($"{ DateTime.Now}: { msg }");
                }
                catch
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}

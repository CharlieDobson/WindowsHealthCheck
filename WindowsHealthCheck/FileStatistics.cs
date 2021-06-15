using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsHealthCheck
{
    public class FileStatistics
    {
        public string FileName { get; set; } = string.Empty;
        public UInt64 FileSize { get; set; } = 0;

        public FileStatistics()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsHealthCheck
{
    public class DirectoryStatistics
    {
        public string FullPathName { get; set; } = string.Empty;
        public string DirectoryName { get; set; } = string.Empty;
        public UInt64 DirectorySize { get; set; } = 0;
        public UInt64 NumberOfFiles { get; set; } = 0;

        public DirectoryStatistics()
        {

        }

    }
}

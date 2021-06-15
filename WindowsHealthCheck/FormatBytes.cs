using System;

namespace DobsonUtilities
{
    sealed class FormatBytes
    {
        public static string Format(long bytes)
        {
            string[] Suffix = { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            byte i;
            double dblByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; ++i, bytes /= 1024)
            {
                dblByte = bytes / 1024.0;
            }

            return String.Format("{0:N1} {1}", dblByte, Suffix[i]);
        }

        public static string Format(UInt64 bytes)
        {
            string[] Suffix = { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            byte i;
            double dblByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; ++i, bytes /= 1024)
            {
                dblByte = bytes / 1024.0;
            }

            return String.Format("{0:N1} {1}", dblByte, Suffix[i]);
        }

        public static string ConvertToSI(long bytes)
        {
            string[] Suffix = { "Bytes", " Kilo", " Mega", " Giga", " Tera", " Peta", " Exa", " Zetta", "Yotta" };
            byte i;
            double dblByte = bytes;

            for (i = 0; i < Suffix.Length && bytes >= 1024; ++i, bytes /= 1024)
            {
                dblByte = bytes / 1024.0;
            }

            return String.Format("{0:N1} {1}", dblByte, Suffix[i]);
        }

        public static string ConvertToSI(UInt64 bytes)
        {
            string[] Suffix = { "Bytes", " Kilo", " Mega", " Giga", " Tera", " Peta", " Exa", " Zetta", "Yotta" };
            byte i;
            double dblByte = bytes;

            for (i = 0; i < Suffix.Length && bytes >= 1024; ++i, bytes /= 1024)
            {
                dblByte = bytes / 1024.0;
            }

            return String.Format("{0:N1} {1}", dblByte, Suffix[i]);
        }
    }

    sealed class FormatBits
    {
        public static string Format(long bits)
        {
            string[] Suffix = { " bits", " Kb", " Mb", " Gb", " Tb", " Pb", " Eb", " Zb", " Yb" };
            byte i;
            double dblBit = bits;
            for (i = 0; i < Suffix.Length && bits >= 1024; ++i, bits /= 1024)
            {
                dblBit = bits / 1024;
            }

            return String.Format("{0:N1} {1}", dblBit, Suffix[i]);
        }

        public static string Format(UInt64 bits)
        {
            string[] Suffix = { " bits", " Kb", " Mb", " Gb", " Tb", " Pb", " Eb", " Zb", " Yb" };
            byte i;
            double dblBit = bits;
            for (i = 0; i < Suffix.Length && bits >= 1024; ++i, bits /= 1024)
            {
                dblBit = bits / 1024;
            }

            return String.Format("{0:N1} {1}", dblBit, Suffix[i]);
        }
    }
}
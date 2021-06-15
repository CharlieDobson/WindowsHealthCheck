using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DobsonUtilities
{
    class RegHandler
    {
        // Constructors
        public RegHandler()
        {

        }

        public RegHandler(string Path)
        {
            this.Path = Path;
        }

        // Getters and setters
        public string Path { get; set; } = string.Empty;

        public string GetValue(string value)
        {
            string getValue = string.Empty;

            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Path))
                    {
                        getValue = key.GetValue(value).ToString();
                    }
                }
                catch
                {
                    // do nothing
                }
            }

            return getValue;
        }

        public bool ValueExists(string value)
        {
            bool keyExists = false;
            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Path))
                    {
                        foreach (string values in key.GetValueNames())
                        {
                            if (values == value)
                            {
                                keyExists = true;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    // do nothing
                }
            }

            return keyExists;
        }

        public bool IsEqual(string firstValue, string secondValue)
        {
            bool isEqual = false;

            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Path))
                    {
                        if (secondValue == key.GetValue(firstValue).ToString())
                            isEqual = true;
                    }
                }
                catch
                {
                    // do nothing
                }
            }

            return isEqual;
        }

        public void CreateSubkey(string subkey)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Path, true))
                    {
                        key.CreateSubKey(subkey, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                    }
                }
                catch
                {
                    // do nothing
                }
            }
        }

        public void WriteValue(string subkey, string value, Microsoft.Win32.RegistryValueKind valueKind)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Path, true))
                    {
                        key.SetValue(subkey, value, valueKind);
                    }
                }
                catch
                {
                    // do nothing
                }
            }
        }

        public void DeleteSubkey(string subkey)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Path, true))
                    {
                        key.DeleteSubKeyTree(subkey);
                    }
                }
                catch
                {
                    // do nothing
                }
            }
        }

        public void DeleteValue(string value)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Path, true))
                    {
                        key.DeleteValue(value);
                    }
                }
                catch
                {
                    // do nothing
                }
            }
        }

        public static string GetValue(string path, string value)
        {
            string getValue = string.Empty;

            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + path))
                {
                    getValue = key.GetValue(value).ToString();
                }
            }
            catch
            {
                // do nothing
            }

            return getValue;
        }

        public static bool ValueExists(string path, string value)
        {
            bool keyExists = false;

            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + path))
            {
                foreach (string values in rk.GetValueNames())
                {
                    if (values == value)
                    {
                        keyExists = true;
                        break;
                    }
                }
                rk.Close();
            }
            return keyExists;
        }

        public static bool IsEqual(string path, string key, string value)
        {
            string registryContent;

            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + path))
            {
                try
                {
                    registryContent = rk.GetValue(key).ToString();
                    rk.Close();
                }
                catch
                {
                    return false;
                }

                if (registryContent == null || registryContent != value)
                    return false;
                else
                    return true;
            }
        }

        public static void WriteValue(string path, string key, string value, Microsoft.Win32.RegistryValueKind valueKind)
        {
            // Check if subkey exists
            if (Microsoft.Win32.Registry.CurrentUser.GetValue(@"SOFTWARE\" + path) == null)
            {
                // Create subkey
                try
                {
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + path);
                }
                catch
                {
                    return;
                }
            }

            // Open subkey for writing
            using (Microsoft.Win32.RegistryKey hkcu = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryView.Default))
            using (Microsoft.Win32.RegistryKey rk = hkcu.OpenSubKey(@"SOFTWARE\" + path, true))
            {
                try
                {
                    rk.SetValue(key, value, valueKind);
                }
                catch
                {
                    // Do nothing
                }
            }
        }

        public static void DeleteValue(string path, string value)
        {
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + path, true))
            {
                try
                {
                    rk.DeleteValue(value);
                }
                catch
                {
                    // Do nothing
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MicMute
{
    internal class StartWithComputer
    {
        private const string Key = "MicMuteBySalih";
        public static bool Status()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            var value = registryKey?.GetValue(Key);
            return value != null;
        }

        public static void Enable()
        {
            if(Status()) return;
            var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            registryKey?.SetValue(Key, "\"" + Application.ExecutablePath + "\"");
        }

        public static void Disable()
        {
            if(!Status()) return;
            var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            registryKey?.DeleteValue(Key);
        }
    }
}

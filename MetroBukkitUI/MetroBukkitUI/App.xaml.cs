using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;

using MetroBukkitUI.Properties;

namespace MetroBukkitUI {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        public App() {

            AttachConsole(ATTACH_PARENT_PROCESS);

            Settings.Default.SettingChanging += (s, evt) =>
                Debug.WriteLine("Setting " + evt.SettingName + " changed from " + Settings.Default[evt.SettingName] + " to " + evt.NewValue);
            Settings.Default.SettingsSaving += (s, evt) =>
                Debug.WriteLine("Preferences have been saved.");

            // Check if computer has enough power to support a server
            if (!Settings.Default.ignorePerformanceWarnings)
                checkSystemSupport();
        }

        private void checkSystemSupport() {
            var objSearcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_Processor");
            var cpuMaxSpeed = 0;
            var ramCurrentAvailable = 0;

            foreach (ManagementObject mObj in objSearcher.Get())
                if (mObj["MaxClockSpeed"] != null)
                    try {
                        cpuMaxSpeed = int.Parse(mObj["MaxClockSpeed"].ToString());
                    } catch (Exception) { cpuMaxSpeed = 0; }

            objSearcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject mObj in objSearcher.Get())
                if (mObj["FreePhysicalMemory"] != null)
                    try { ramCurrentAvailable = ((int.Parse(mObj["FreePhysicalMemory"].ToString())) / 1024); } catch (Exception ex) { ramCurrentAvailable = 0; } 
                else if (mObj["FreeVirtualMemory"] != null)
                    try { ramCurrentAvailable += ((int.Parse(mObj["FreeVirtualMemory"].ToString())) / 1024); } catch (Exception ex) { }

            //if (cpuMaxSpeed < 2000 || ramCurrentAvailable < 2000) {
            new MinimumRequirementWindow(!(cpuMaxSpeed < 2000), !(ramCurrentAvailable < 2000), cpuMaxSpeed, ramCurrentAvailable).ShowDialog();
            Application.Current.Shutdown();
            //}

        }

    }
}

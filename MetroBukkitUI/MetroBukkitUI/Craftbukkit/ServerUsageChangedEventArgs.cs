using System;
using System.Diagnostics;
using System.Management;

namespace MetroBukkitUI.Craftbukkit {

    public class ServerUsageChangedEventArgs : EventArgs {
        private readonly int _basePriority;
        private readonly ProcessThreadCollection _threads;
        private readonly TimeSpan _totalProcessorTime;
        private readonly TimeSpan _userProcessorTime;
        private readonly long _totalAllocatedMemory;

        public int basePriority { get { return _basePriority; } }
        public ProcessThreadCollection threads { get { return _threads; } }
        public TimeSpan totalProcessorTime { get { return _totalProcessorTime; } }
        public TimeSpan userProcessorTime { get { return _userProcessorTime; } }
        public long totalAllocatedMemory { get { return _totalAllocatedMemory; } }
        public static long totalSystemMemory {
            get {
                long physMemory = 0;
                long virtMemory = 0;

                var objSearcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject mObj in objSearcher.Get())
                    if (mObj["FreePhysicalMemory"] != null && mObj["FreeVirtualMemory"] != null)
                        try { 
                            physMemory = ((int.Parse(mObj["FreePhysicalMemory"].ToString())));
                            virtMemory = ((int.Parse(mObj["FreeVirtualMemory"].ToString())));
                        } catch (Exception ex) { physMemory = 0; virtMemory = 0; }

                return physMemory + virtMemory;
            }
        }

        public ServerUsageChangedEventArgs(Process proc) {
            _basePriority = proc.BasePriority;
            _threads = proc.Threads;
            _totalProcessorTime = proc.TotalProcessorTime;
            _userProcessorTime = proc.UserProcessorTime;
            _totalAllocatedMemory = proc.WorkingSet64;
        }

    }

}

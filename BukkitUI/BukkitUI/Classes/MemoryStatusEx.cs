﻿using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace BukkitUI {
    /// <summary>
    /// Snippet from StackOverflow.com.
    /// Thanks to Philip Rieck and Igor Brejc
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MEMORYSTATUSEX {
    
         public uint dwLength;
         public uint dwMemoryLoad;
         public ulong ullTotalPhys;
         public ulong ullAvailPhys;
         public ulong ullTotalPageFile;
         public ulong ullAvailPageFile;
         public ulong ullTotalVirtual;
         public ulong ullAvailVirtual;
         public ulong ullAvailExtendedVirtual;

         public MEMORYSTATUSEX() {
            this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
         }

         [return: MarshalAs(UnmanagedType.Bool)]
         [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
         public static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

  }
}

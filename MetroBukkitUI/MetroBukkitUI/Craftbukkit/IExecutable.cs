using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace MetroBukkitUI.Craftbukkit {

    public interface IExecutable {

        Process process { get; set; }

        StreamWriter inputStream { get; set; }

        StreamReader outputStream { get; set; }

        StreamReader errorStream { get; set; }

        List<string> args { get; set; }

        ProcessStartInfo processStartInfo { get; set; }

        void start();

        void stop();

        void restart();

        String formatArgs(List<String> args);

    }

}

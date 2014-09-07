using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using MetroBukkitUI.Properties;
using MetroBukkitUI.Craftbukkit.Exceptions;

namespace MetroBukkitUI.Craftbukkit {

    public delegate void ServerStateChangedEvent(object sender, ServerStateChangedEventArgs evt);
    public delegate void ServerOutputReceivedEvent(object sender, DataReceivedEventArgs evt);
    public delegate void ServerUsageChangedEvent(object sender, ServerUsageChangedEventArgs evt);

    public class CraftbukkitServer : IExecutable, IDisposable {

        private ServerState _serverState = ServerState.Stopped;
        public event ServerStateChangedEvent stateChanged;
        public event ServerOutputReceivedEvent outputReceived;
        public event ServerUsageChangedEvent serverUsageChanged;

        #region // Properties

        public Process process {
            get; set;
        }

        public StreamWriter inputStream {
            get; set;
        }

        public StreamReader outputStream {
            get; set;
        }

        public StreamReader errorStream {
            get; set;
        }

        public ServerState serverState {
            get { return _serverState; }
            set {
                _serverState = value;
                stateChanged(this, new ServerStateChangedEventArgs(value));
            }
        }

        public List<string> args {
            get; set;
        }

        public ProcessStartInfo processStartInfo {
            get;
            set;
        }

        public bool isRunning { get { return process != null || !process.HasExited; } }
        #endregion

        public void start() {
            // To-Do: Add error-checking logic.
            if (process != null)
                throw new ServerAlreadyRunningException("A server instance was already created!");
            if (args == null || args.Count == 0)
                throw new ArgumentException("No arguments found for process creation!");

            process = new Process();
            #region // Add event handlers 'n shiz
            // Just makes sure that everything gets handled accordingly
            process.ErrorDataReceived += processOutputReceived;
            process.OutputDataReceived += processOutputReceived;
            #endregion
            processStartInfo = new ProcessStartInfo();
            processStartInfo.Arguments = formatArgs(args);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.ErrorDialog = true;
            processStartInfo.FileName = Settings.Default.javaBinaryPath;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.WorkingDirectory = Settings.Default.bukkit_path;

            process.StartInfo = processStartInfo;

            Debug.WriteLine("Starting Minecraft Craftbukkit server...");

            process.Start();
            errorStream = process.StandardError; // This logic is so ballsed...
            inputStream = process.StandardInput;
            outputStream = process.StandardOutput;

            serverState = ServerState.Starting;
            monitorProcess();

        }

        private void processOutputReceived(object sender, DataReceivedEventArgs evt) {
            if (evt.Data == null)
                if (serverState == ServerState.Starting)
                    serverState = ServerState.Failed_to_Start;
                else
                    serverState = ServerState.Stopped;
            Debug.WriteLine(evt.Data);
            outputReceived(sender, evt); 
        }

        public void stop() {
            inputStream.WriteLine("stop");
            inputStream.Flush();
            process.WaitForExit(20000);
            process.Kill();
            process.Close();
            process.Dispose();
        }

        public void restart() {
            stop();
            start();
        }

        public string formatArgs(List<string> args) {
            var _args = new StringBuilder();

            foreach (var arg in args)
                _args.Append(arg + " ");

            Debug.WriteLine(_args);
            return _args.ToString();
        }

        private void monitorProcess() {

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, evt) => {
                if (process.HasExited) {
                    serverState = ServerState.Stopped;
                    timer.Stop();
                    return;
                }
                serverUsageChanged(this, new ServerUsageChangedEventArgs(process));
            };
            timer.Start();
            
        }

        public void Dispose() {
            if (!process.HasExited) {
                inputStream.WriteLine("stop");
                inputStream.Flush();
                process.WaitForExit(20000);
                process.Kill();
                process.Close();
                process.Dispose();
                process = null;
                inputStream.Close();
                inputStream.Dispose();
                errorStream.Close();
                errorStream.Dispose();
                outputStream.Close();
                outputStream.Dispose();
            } else {
                process.Close();
                process.Dispose();
                process = null;
                inputStream.Close();
                inputStream.Dispose();
                errorStream.Close();
                errorStream.Dispose();
                outputStream.Close();
                outputStream.Dispose();
            }
        }

    }

}

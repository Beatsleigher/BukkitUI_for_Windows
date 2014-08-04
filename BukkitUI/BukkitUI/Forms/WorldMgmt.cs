using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BukkitUI.Bukkit;
using BukkitUI.Dialogs;

using Ionic.Zip;
using Ionic.BZip2;
using Ionic.Zlib;

namespace BukkitUI {
    public partial class WorldMgmt : Form {

        ServerProperties serverProps = null;

        public WorldMgmt(ServerProperties serverProps) {
            InitializeComponent();
            this.serverProps = serverProps;
        }

        private void WorldMgmt_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            bool useBZipCompression = false;
            String worldLocation = Path.Combine(Properties.Settings.Default.bukkitDir, serverProps.levelName);
            String backupDestination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BukkitUI_for_Win", serverProps.levelName);
            WorldBackupOptionsDialog backupOps = new WorldBackupOptionsDialog(useBZipCompression, worldLocation, backupDestination);

            Thread zipThread = new Thread(() => {
                using (ZipFile zip = new ZipFile()) {
                    #region AddProgressEvent
                    zip.AddProgress += (s, evt) => {
                        long totalBytes = evt.TotalBytesToTransfer;
                        long bytesTransferred = evt.BytesTransferred;

                        Invoke((MethodInvoker)delegate {
                            label1.Text = "Adding "
                                + evt.CurrentEntry.FileName
                                + "... (" + (bytesTransferred / 1024).ToString() + "KiB / " + (totalBytes / 1024).ToString() + "KiB)";

                            progressBar1.Maximum = (int)totalBytes / 1024;
                            progressBar1.Value = (int)bytesTransferred / 1024;
                        });

                    };
                    #endregion

                    // Create files and folders if necessary
                    if (!Directory.Exists(backupDestination))
                        Directory.CreateDirectory(backupDestination);
                    if (!File.Exists(Path.Combine(backupDestination, serverProps.levelName + ".zip")))
                        File.Create(Path.Combine(backupDestination, serverProps.levelName + ".zip")).Close();

                    addFilesToZip(zip, worldLocation);
                    zip.Save(Path.Combine(backupDestination, serverProps.levelName + ".zip"));
                    zip.Dispose();
                }
                Thread.CurrentThread.Abort();
            });

            if (backupOps.ShowDialog() == DialogResult.OK) {
                useBZipCompression = backupOps.useBZipCompression;
                worldLocation = backupOps.worldLocation;
                backupDestination = backupOps.backupDestination;
            } else return;

            zipThread.Start();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            zipThread.Join();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void addFilesToZip(ZipFile zip, String dir) {
            foreach (String file in Directory.GetFiles(dir)) 
                zip.AddFile(file);
            foreach (String _dir in Directory.GetDirectories(dir))
                addFilesToZip(zip, _dir);
        }
    }
}

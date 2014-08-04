using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Net;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace BukkitUI_Updater {
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm {

        enum UpdatePriority {
            Higher,
            High,
            Above_Normal,
            Normal,
            Below_Normal,
            Low,
            Lower
        }
        enum UpdateType { Update, Patch, QuickFix }

        private bool showPatches { get; set; }
        private bool showQuickFixes { get; set; }
        private bool incrementProgress { get; set; }

        public RadForm1() {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e) {
            showPatches = true;
            showQuickFixes = true;
            // Connect to GitHub and check for new releases
            loadUpdates();
        }

        private void loadUpdates() {

            incrementProgress = true;
            showLoadBar();

            // Clear DataGridView before doing anything else.
            dataGridView1.Rows.Clear();

            new Thread(() => {
                Invoke((MethodInvoker)delegate {
                    using (WebClient webC = new WebClient()) {
                        String rawUpdateInfo = webC.DownloadString("https://raw.githubusercontent.com/Beatsleigher/BukkitUI_for_Windows/master/update/.upd");
                        using (StringReader sReader = new StringReader(rawUpdateInfo)) {
                            // Variables
                            String line = "";
                            String name = "";
                            String desc = "";
                            UpdatePriority priority = UpdatePriority.Normal;
                            String minVersion = "";
                            String maxVersion = "";
                            String dlLink = "";
                            UpdateType type = UpdateType.Update;
                            int idx = 0;

                            while ((line = sReader.ReadLine()) != null) {

                                // Clear all variables
                                name = "";
                                desc = "";
                                priority = UpdatePriority.Normal;
                                minVersion = "";
                                maxVersion = "";
                                dlLink = "";
                                type = UpdateType.Update;

                                if (line.Trim().ToLower().StartsWith("update=>") && line.EndsWith(">>")) {
                                    #region Parser
                                    // Get all the attributes in the "method" header
                                    String[] details = Regex.Split(Regex.Split(Regex.Split(line, "\\[")[1], "\\]")[0], "[,]");
                                    
                                    // Get values from the attributes
                                    foreach (String str in details)
                                        if (str.Trim().ToLower().StartsWith("name"))
                                            name = Regex.Split(str, "[\"]")[1];
                                        else if (str.Trim().ToLower().StartsWith("desc"))
                                            desc = Regex.Split(str, "[\"]")[1];
                                        else if (str.Trim().ToLower().StartsWith("priority"))
                                            #region Parse update priority
                                            switch (Regex.Split(str, "[\"]")[1].ToLower()) {
                                                case "higher":
                                                    priority = UpdatePriority.Higher;
                                                    break;
                                                case "high":
                                                    priority = UpdatePriority.High;
                                                    break;
                                                case "above_normal":
                                                    priority = UpdatePriority.Above_Normal;
                                                    break;
                                                case "normal":
                                                    priority = UpdatePriority.Normal;
                                                    break;
                                                case "below_normal":
                                                    priority = UpdatePriority.Below_Normal;
                                                    break;
                                                case "low":
                                                    priority = UpdatePriority.Low;
                                                    break;
                                                case "lower":
                                                    priority = UpdatePriority.Lower;
                                                    break;
                                                default:
                                                    priority = UpdatePriority.Normal;
                                                    break;
                                            }
                                            #endregion

                                    while (!(line = sReader.ReadLine()).EndsWith("<<")) {
                                        if (line.Trim().ToLower().StartsWith("minappversion")) {
                                            minVersion = Regex.Split(line, "[\"]")[1];
                                            continue;
                                        }
                                        if (line.Trim().ToLower().StartsWith("maxappversion")) {
                                            maxVersion = Regex.Split(line, "[\"]")[1];
                                            continue;
                                        }
                                        if (line.Trim().ToLower().StartsWith("dllink")) {
                                            dlLink = Regex.Split(line, "[\"]")[1];
                                            continue;
                                        }
                                        if (line.Trim().ToLower().StartsWith("updatetype")) {
                                            #region Parse update type
                                            if (!line.Contains("=\"") && !line.EndsWith("\""))
                                                switch (Regex.Split(line, "[\"]")[1].ToLower()) {
                                                    case "update":
                                                        type = UpdateType.Update;
                                                        break;
                                                    case "patch":
                                                        type = UpdateType.Patch;
                                                        break;
                                                    case "quickfix":
                                                        type = UpdateType.QuickFix;
                                                        break;
                                                    default:
                                                        type = UpdateType.Patch;
                                                        break;
                                                }
                                            else
                                                switch (Regex.Split(line, "[=]")[1].ToLower()) {
                                                    case "update":
                                                        type = UpdateType.Update;
                                                        break;
                                                    case "patch":
                                                        type = UpdateType.Patch;
                                                        break;
                                                    case "quickfix":
                                                        type = UpdateType.QuickFix;
                                                        break;
                                                    default:
                                                        type = UpdateType.Patch;
                                                        break;
                                                }
                                            #endregion
                                            continue;
                                        }

                                    }
                                    #endregion

                                    if ((type == UpdateType.Patch && !showPatches) || (type == UpdateType.QuickFix && !showQuickFixes))
                                        continue;

                                    // Put all the values in the DataGridView
                                    dataGridView1.Rows.Add(1);
                                    DataGridViewRow row = dataGridView1.Rows[idx];
                                    row.Cells[0].Value = name;
                                    row.Cells[1].Value = desc;
                                    row.Cells[2].Value = priority.ToString();
                                    row.Cells[3].Value = minVersion;
                                    row.Cells[4].Value = maxVersion;
                                    row.Cells[5].Value = dlLink;
                                    row.Cells[6].Value = type.ToString();

                                    // Increment idx variable so that next time, the next row is used.
                                    idx++;
                                        
                                }
                            }

                            sReader.Close();
                            sReader.Dispose();

                        }
                        webC.Dispose();
                    }
                    
                });
            }).Start();

            incrementProgress = false;

        }

        private void showLoadBar() {
            new Thread(() => {
                Invoke((MethodInvoker)delegate {
                    radProgressBar1.Text = "Fetching updates...";
                    while (incrementProgress) {
                        if (radProgressBar1.Value1 == 100) radProgressBar1.Value1 = 0;

                        radProgressBar1.Value1 = radProgressBar1.Value1 + 1;

                        Thread.Sleep(200);
                    }
                    radProgressBar1.Text = ">> Idle <<";
                });
            }).Start();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            radButton1.Enabled = true;
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args) {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On) {
                showPatches = true;
                loadUpdates();
            } else {
                showPatches = false;
                loadUpdates();
            }
        }

        private void radCheckBox2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args) {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On) {
                showQuickFixes = true;
                loadUpdates();
            } else {
                showQuickFixes = false;
                loadUpdates();
            }
        }

        private void radButton1_Click(object sender, EventArgs e) {
            this.Enabled = false;
            WebClient webC = new WebClient();

            String installLoc = 
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                "BukkitUI_for_Win32", "BukkitUI." + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value + ".exe");

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "BukkitUI_for_Win32")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "BukkitUI_for_Win32"));

            webC.DownloadFileAsync(new Uri(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString()),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "BukkitUI_for_Win32", "BukkitUI." + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value + ".exe"));

            webC.DownloadProgressChanged += (s, evt) => {
                radProgressBar1.Text = "Downloading " 
                    + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value 
                    + "... [" + evt.ProgressPercentage + "%]";
                radProgressBar1.Value1 = evt.ProgressPercentage;
            };
            webC.DownloadFileCompleted += (s, evt) => {
                radProgressBar1.Text = ">> Idle <<";
                radProgressBar1.Value1 = 0;
                this.Enabled = true;
                if (MessageBox.Show(this,
                    "The update has been successfully downloaded!\nWould you like to update BukkitUI?",
                    "Install Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start(installLoc);
                else
                    MessageBox.Show(this, "Fair enough. I understand. The update file can be found here: " + installLoc + ".",
                        "Suit Yourself", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            };
        }
    }
}

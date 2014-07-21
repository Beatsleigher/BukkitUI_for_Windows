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
            new Thread(() => {
                Invoke((MethodInvoker)delegate {

                    incrementProgress = true;
                    showLoadBar();

                    Thread.Sleep(1000);

                    using (WebClient webC = new WebClient()) 
                    using (StringReader sReader = new StringReader(
                        webC.DownloadString("https://raw.githubusercontent.com/Beatsleigher/BukkitUI_for_Windows/master/update/.upd"))) {
                        String line;
                        String updateName = "";
                        String updateDescription = "";
                        UpdatePriority priority = UpdatePriority.Normal;
                        int tableIndex = 0;
                        Version minVersion = null;
                        Version maxVersion = null;
                        String url = "";
                        UpdateType updateType = UpdateType.Update;
                        
                        #region Parser
                        while ((line = sReader.ReadLine()) != null) {

                            if (line.StartsWith("program=") && line.Contains("BukkitUI for Windows") && line.EndsWith(">>")) {
                                while (!(line = sReader.ReadLine()).Equals("<<")) {

                                    Debug.WriteLine("Flushing variables...");
                                    // Wipe variables clean
                                    updateName = "";
                                    updateDescription = "";
                                    priority = UpdatePriority.Normal;
                                    minVersion = null;
                                    maxVersion = null;
                                    url = "";
                                    updateType = UpdateType.Update;

                                    Debug.WriteLine("Searching for update classes...");
                                    if (line.Contains("update=>") && (line.Contains(">>") || line.EndsWith(">>"))) {
                                        Debug.WriteLine("Found update class... Gathering details...");
                                        String[] details = Regex.Split((Regex.Split(Regex.Split(line, @"\[")[1], @"\]")[0]), "[,]");
                                        foreach (String detail in details) {
                                            Debug.WriteLine("Found detail: " + (Regex.Split(detail, "[=]"))[0]);
                                            Debug.WriteLine("(" + Regex.Split(detail, "[\"]")[1] + ")");
                                            if (detail.StartsWith("name"))
                                                updateName = Regex.Split(detail, "[\"]")[1];
                                            else if (detail.StartsWith("desc"))
                                                updateDescription = Regex.Split(detail, "[\"]")[1];
                                            else if (detail.StartsWith("priority"))
                                                #region Priority Switch
                                                switch (Regex.Split(detail, "[\"]")[1].ToLower()) {
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
                                        }

                                        while (!(line = sReader.ReadLine()).EndsWith("<<")) {
                                            Debug.WriteLine(line);
                                            if (line.ToLower().Contains("minappversion"))
                                                minVersion = new Version(Regex.Split(line, "[\"]")[1]);
                                            if (line.ToLower().Contains("maxappversion"))
                                                maxVersion = new Version(Regex.Split(line, "[\"]")[1]);

                                            if (line.ToLower().Contains("dllink"))
                                                url = Regex.Split(line, "[\"]")[1];

                                            if (line.ToLower().Contains("updatetype"))
                                                #region Update Type Switch
                                                switch (Regex.Split(line.ToLower(), "[=]")[1]) {
                                                    case "update":
                                                        updateType = UpdateType.Update;
                                                        break;
                                                    case "patch":
                                                        updateType = UpdateType.Patch;
                                                        break;
                                                    case "quickfix":
                                                        updateType = UpdateType.QuickFix;
                                                        break;
                                                    default:
                                                        updateType = UpdateType.Patch;
                                                        break;
                                                }
                                                #endregion
                                        }

                                        if (String.IsNullOrWhiteSpace(updateName)) continue;
                                        // Assume no update/patch was found in this particular loop

                                        Debug.WriteLine("Checking if update matches search criteria... (searching for patches...)");
                                        // Check if update matches criteria to be added to DataGridView
                                        if (!(updateType == UpdateType.Patch && showPatches)) continue;
                                        Debug.WriteLine("Checking if update matches search criteria... (searching for quick fixes...)");
                                        if (!(updateType == UpdateType.QuickFix && showQuickFixes)) continue;



                                        // Add data to table
                                        dataGridView1.Rows.Add(1);
                                        dataGridView1.Rows[tableIndex].Cells[0].Value = updateName;
                                        dataGridView1.Rows[tableIndex].Cells[1].Value = updateDescription;
                                        dataGridView1.Rows[tableIndex].Cells[2].Value = priority.ToString();
                                        dataGridView1.Rows[tableIndex].Cells[3].Value = minVersion.ToString();
                                        dataGridView1.Rows[tableIndex].Cells[4].Value = maxVersion.ToString();
                                        dataGridView1.Rows[tableIndex].Cells[5].Value = url;
                                        dataGridView1.Rows[tableIndex].Cells[6].Value = updateType.ToString();

                                        // Increment tableIndex
                                        tableIndex++;

                                    }

                                }
                            

                            }

                        }
                        #endregion

                        // Close and dispose of sReader to prevent mem leaks
                        sReader.Close();
                        sReader.Dispose();
                        // Do the same to webC
                        webC.Dispose();
                    }
                    incrementProgress = false;
                    
                });
            }).Start();
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
    }
}

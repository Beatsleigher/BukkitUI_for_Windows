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

        public RadForm1() {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e) {
            // Connect to GitHub and check for new releases
            loadUpdates();
        }

        private void loadUpdates() {
            new Thread(() => {
                Invoke((MethodInvoker)delegate {
                    using (WebClient webC = new WebClient()) {
                        using (StringReader sReader = new StringReader(webC.DownloadString("https://raw.githubusercontent.com/Beatsleigher/BukkitUI_for_Windows/master/update/.upd"))) {
                            String line;
                            String updateName;
                            String updateDescription;
                            UpdatePriority priority;
                            int tableIndex = 0;

                            while ((line = sReader.ReadLine()) != null) {

                                if (line.StartsWith("program=") && line.Contains("BukkitUI for Windows") && line.EndsWith(">>")) {
                                    while (!(line = sReader.ReadLine()).Equals("<<")) {

                                        if (line.Contains("update=>")) {
                                            String[] details = Regex.Split((Regex.Split(Regex.Split(line, @"\[")[1], @"\]")[0]), "[,]");
                                            foreach (String detail in details)
                                                if (detail.StartsWith("name"))
                                                    updateName = Regex.Split(detail, "[\"]")[1];
                                                else if (detail.StartsWith("desc"))
                                                    updateDescription = Regex.Split(detail, "[\"]")[1];
                                                else if (detail.StartsWith("priority"))
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
                                                            case 
                                                    }

                                            while (!(line = sReader.ReadLine()).EndsWith("<<")) {

                                            }

                                        }

                                    }

                                }

                            }
                        }
                    }
                });
            }).Start();
        }
    }
}

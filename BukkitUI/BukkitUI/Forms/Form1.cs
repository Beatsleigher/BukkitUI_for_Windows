using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime;
using System.Net;
using System.Runtime.Serialization;
using System.Management;
using System.Xml.Serialization;

using BukkitUI.Bukkit;
using BukkitUI.ServerManager;

namespace BukkitUI {
    public partial class Form1 : Form {

        public enum ServerState {
            BOOTING, RUNNING, SHUTTING_DOWN, INSTALLING, UPDATING, NOT_RUNNING
        }

        [Serializable]
        public enum ServerAllocationMode {
            /// <summary>
            /// Allocates as little resources as possible to the process. Usually 20% of the total memory.
            /// This is great when you just want to host a small private server and play with a few friends.
            /// </summary>
            [XmlEnum("ResourceSaving")]
            Resource_Saving, 
            
            /// <summary>
            /// Allocates about 30% of the total memory.
            /// This is good for hosting a server for about 10-15 players during a LAN-Party.
            /// </summary>
            [XmlEnum("ReducedResources")]
            Reduced_Resources,

            /// <summary>
            /// Allocates about 35-40% of the total memory.
            /// This option is great for bigger LAN-parties and/or small online servers.
            /// </summary>
            [XmlEnum("NormalResources")]
            Normal_Resources,

            /// <summary>
            /// This option allows the memory allocation to be done by the Java Virtual Machine.
            /// For most cases, this is absolutely adequite, and is the default option.
            /// </summary>
            [XmlEnum("AutoResources")]
            Auto,

            /// <summary>
            /// If the computer has more than 4GiB of RAM installed, then BukkitUI will allocate around 50+% to the server.
            /// This is the optimal option for gamers (e.g.: let's-players) who are hosting Bukkit servers on their computers on which more than 10 players are playing
            /// and the host is gaming as well.
            /// 
            /// Are you a gamer with a decent machine? This option is for you!
            /// </summary>
            [XmlEnum("FullResources")]
            Full_Power,

            /// <summary>
            /// <b>ONLY USE THIS IS YOUR MACHINE IS A DEDICATED SERVER! NORMAL COMPUTERS <i>WILL</i> CRASH!</b>
            /// This option is the most resource-intense version and will only work reliably on dedicated servers.
            /// 
            /// Choosing this option will allocate up to 85% of the system memory to CraftBukkit and <b><i>WILL</i></b> make home computers crash and die!
            /// This is a warning! If you love your computer, DON'T CHOOSE THIS OPTION! However, if you hate it and want it to die a painful death, go ahead.
            /// Did I mention that I'm not responsible for any kind of damage caused by the use of this program, and that it comes without warranty? Good.
            /// </summary>
            [XmlEnum("ServerResources")]
            Server_Mode
        }
        
        #region Aero Stuff
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        [DllImport("DwmApi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int borderLeft = 13;
        private const int borderRight = 13;
        private const int borderTop = 165;
        private const int borderBottom = 58;
        private const int m1 = -1;

        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT) {
                        m.Result = (IntPtr)HTCAPTION;
                    }

                    return;
            }

            base.WndProc(ref m);
        }
        #endregion

        // Variables
        internal ImageList imgList;
        internal BukkitYML bukkitYml;
        internal ServerProperties serverProps;
        internal bool runServer = false;
        internal Process bukkitProcess = null;
        internal String[] keywords = { "FINE", "FINER", "FINEST", "INFO", "WARNING", "SEVERE" };
        internal bool runManagement = true;
        internal int helmIdx = 0;
        internal ServerAllocationMode allocationMode = ServerAllocationMode.Auto;

        // Properties
        public ServerState serverState { get; set; }

        public Form1() {
            if (Environment.OSVersion.Version.Major <= 5) {
                MessageBox.Show(this, "Sorry, BukkitUI is not available for Windows XP, Server 2003 or lower.",
                    "BukkitUI not Compatible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            Debug.Print("Initializing components...");
            InitializeComponent();
            bukkitYml = new BukkitYML(Properties.Settings.Default.bukkitDir, false, this);
            serverProps = new ServerProperties(bukkitYml.bukkitLocation, false);
            Debug.Print("Loading Preferences...");
            #region BukkitUI Preferences
            if (File.Exists(Path.Combine(Environment.GetEnvironmentVariable("windir") + @"\System32", "java.exe")))
                Properties.Settings.Default.javaEXE = Path.Combine(Environment.GetEnvironmentVariable("windir") + @"\System32", "java.exe");
            else
                if (MessageBox.Show(this,
                      "No Java installation found! In order to use Craftbukkit and BukkitUI,\n"
                    + "please download and install the latest Java JRE (Java Runtime Environment) from Oracle®™\n"
                    + "If you like, we can send you directly to the downloads page.\n"
                    + "Do you want to go to the downloads page to download the Java JRE?",
                    "No Java Installation Found",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                    Process.Start("http://bit.ly/downloadJRE");
                    MessageBox.Show(this, "Redirected to http://bit.ly/downloadJRE.");
                }
            Properties.Settings.Default.Save();
            javaInstallPath.Text = Properties.Settings.Default.javaEXE;
            bootOnStartup.Checked = Properties.Settings.Default.autoStartServer;
            autoRebootServer.Checked = Properties.Settings.Default.autoRebootServer;
            serverRebootInterval.Text = Properties.Settings.Default.serverRebootInterval.ToString();
            extendDWMIntoClient.Checked = Properties.Settings.Default.extendDWMIntoClient;
            bukkitLocation.Text = Properties.Settings.Default.bukkit;
            bukkitDir.Text = Properties.Settings.Default.bukkitDir;
            enableCustomHeapSize.Checked = Properties.Settings.Default.useCustomHeapSize;
            initHeapSize.Text = Properties.Settings.Default.javaInitSizeInMegs.ToString();
            maxHeapSize.Text = Properties.Settings.Default.javaInitSizeInMegs.ToString();
            switch (Properties.Settings.Default.serverAllocationMode) {
                case "Resource_Saving":
                    allocationMode = ServerAllocationMode.Resource_Saving;
                    comboBox1.SelectedIndex = 0;
                    break;
                case "Reduced_Resources":
                    allocationMode = ServerAllocationMode.Reduced_Resources;
                    comboBox1.SelectedIndex = 1;
                    break;
                case "Normal_Resources":
                    allocationMode = ServerAllocationMode.Normal_Resources;
                    comboBox1.SelectedIndex = 2;
                    break;
                case "Auto":
                    allocationMode = ServerAllocationMode.Auto;
                    comboBox1.SelectedIndex = 3;
                    break;
                case "Full_Power":
                    allocationMode = ServerAllocationMode.Full_Power;
                    comboBox1.SelectedIndex = 4;
                    break;
                case "Server_Mode":
                    allocationMode = ServerAllocationMode.Server_Mode;
                    comboBox1.SelectedIndex = 5;
                    break;
                default:
                    allocationMode = ServerAllocationMode.Auto;
                    comboBox1.SelectedIndex = 3;
                    break;
            }
            #endregion
            Debug.Print("Loading Aero Crap...");
            Text = "BukkitUI | Welcome, " + Environment.UserName;
            #region More Aero Stuff
            MARGINS margins = new MARGINS();
            margins.cxLeftWidth = 20;
            margins.cxRightWidth = 20;
            margins.cyBottomHeight = 50;
            margins.cyTopHeight = 75;
            if (Properties.Settings.Default.extendDWMIntoClient)
                try {
                    DwmExtendFrameIntoClientArea(Handle, ref margins);
                    this.ResizeRedraw = true;
                    this.BackColor = Color.Black;
                } catch (Exception ex) {

                }
            #endregion
            imgList = new ImageList();
            imgList.Images.Add(Properties.Resources.player_online);
            imgList.Images.Add(Properties.Resources.player_afk);
            imgList.ImageSize = new Size(32, 32);
            playerListView.SmallImageList = imgList;
            loadBukkitYaml();
            serverProps.loadProperties(false);
            propertyGrid1.SelectedObject = serverProps;
            propertyGrid1.PropertyValueChanged += (s, evt) => serverProps.saveProperties();
        }

        private void Form1_Load(object sender, EventArgs evt) {

            serverState = ServerState.NOT_RUNNING;
            runManagement = true;

            if (String.IsNullOrEmpty(Properties.Settings.Default.bukkit) || String.IsNullOrWhiteSpace(Properties.Settings.Default.bukkit)) {
                MessageBox.Show(this, 
                      "It seems as though you're running BukkitUI for the first time! Welcome!\n"
                    + "Before we get on with everything, such as pre-configuration of the server,\n"
                    + "we need to know if you have already downloaded a Craftbukkit server,\n"
                    + "or if we should show you a list of available servers that you can download.\n\n"
                    + "To continue, please dismiss this message.", 
                    "Welcome to BukkitUI!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (MessageBox.Show(this,
                      "Have you already downloaded  a server to your computer prior to opening BukkitUI?\n"
                    + "If so, you can use that and easily get things started!",
                    "Use Existing Server?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.selectBukkitJar.PerformClick();
                else {
                    using (ServerList sList = new ServerList(Properties.Settings.Default.extendDWMIntoClient)) {
                        if (sList.ShowDialog() == DialogResult.OK) {
                            Properties.Settings.Default.bukkit = sList.craftBukkit;
                            bukkitLocation.Text = sList.craftBukkit;
                            String[] arr = sList.craftBukkit.Split(Path.DirectorySeparatorChar);
                            List<String> path = new List<String>();
                            for (int i = 0; i < (arr.Length) - 1; i++)
                                path.Add(arr[i]);

                            if (Regex.IsMatch(path[0], "([A-z][:])", RegexOptions.None) && !path[0].EndsWith(Path.DirectorySeparatorChar.ToString()))
                                path[0] += @"\";

                            Properties.Settings.Default.bukkitDir = Path.Combine(path.ToArray());
                            bukkitDir.Text = Path.Combine(path.ToArray());
                            Properties.Settings.Default.Save();
                        } else {
                            MessageBox.Show(this, "You have not selected/downloaded a Craftbukkit server!\n"
                                + "BukkitUI will not function properly (if at all)!\n"
                                + "To prevent any uncessesary errors, please select a Craftbukkit server as soon as possible.",
                                "No Server Selected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            runManagement = false;
                        }
                    }
                }

            }
            loadServerPlayers();
            getServerOPs();
            getWhiteListedPlayers();
            getBannedPlayers();
            if (Properties.Settings.Default.autoStartServer)
                startServerButton.PerformClick();
        }

        private void savePrefs_Click(object sender, EventArgs evt) {
            Properties.Settings.Default.autoStartServer = bootOnStartup.Checked;
            Properties.Settings.Default.autoRebootServer = autoRebootServer.Checked;
            Properties.Settings.Default.serverRebootInterval = Convert.ToInt16(serverRebootInterval.Text);
            Properties.Settings.Default.extendDWMIntoClient = extendDWMIntoClient.Checked;
            Properties.Settings.Default.bukkit = bukkitLocation.Text;
            Properties.Settings.Default.useCustomHeapSize = enableCustomHeapSize.Checked;
            Properties.Settings.Default.javaInitSizeInMegs = int.Parse(initHeapSize.Text);
            Properties.Settings.Default.javaMaxSizeInMegs = int.Parse(maxHeapSize.Text);
            Properties.Settings.Default.serverAllocationMode = allocationMode.ToString();
            Properties.Settings.Default.Save();
            MessageBox.Show(this,
                "The Preferences you selected have been saved successfully and will become fully functional the next time you start BukitUI.",
                "Your Preferences Have Been Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void autoRebootServer_CheckedChanged(object sender, EventArgs evt) {
            if (autoRebootServer.Checked)
                serverRebootInterval.Enabled = true;
            else
                serverRebootInterval.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs evt) {
            DialogResult result = new AboutBox1().ShowDialog();
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs evt) {
            if (tabControl4.SelectedIndex == 5)
                if (MessageBox.Show(this,
                      "Editing these settings may render your server and all its data useless!\n"
                    + "Are you sure you wish to continue?", "Are you Sure?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    tabControl4.SelectedIndex = 0;
        }

        private void loadBukkitYaml() {
            try {
                if (bukkitYml.isLoaded) {
                    // General settings
                    // CheckBoxes
                    setAllowEnd.Checked = bukkitYml.allowEnd;
                    setWarnOnOverload.Checked = bukkitYml.warnOnOverload;
                    setUseExactLoginLocation.Checked = bukkitYml.useExactLoginLocation;
                    setPluginProfiling.Checked = bukkitYml.pluginProfiling;
                    setQueryPlugins.Checked = bukkitYml.queryPlugins;
                    // (Masked-) TextBoxes
                    setUpdateFolder.Text = bukkitYml.updateFolder;
                    setPingPacketLimit.Text = bukkitYml.pingPacketLimit.ToString();
                    setConnectionThrottle.Text = bukkitYml.connectionThrottle.ToString();
                    setDeprecatedVerbose.Text = bukkitYml.deprecatedVerbose;
                    setShutdownMessage.Text = bukkitYml.shutdownMessage;
                    // Spawn limits
                    setMonsterLimit.Text = bukkitYml.monsters.ToString();
                    setAnimalLimit.Text = bukkitYml.animals.ToString();
                    setWaterAnimalLimit.Text = bukkitYml.waterAnimals.ToString();
                    setAmbientLimit.Text = bukkitYml.ambient.ToString();
                    // Chunk GC
                    setGCPeriodInTicks.Text = bukkitYml.periodInTicks.ToString();
                    setGCLoadThreshold.Text = bukkitYml.loadThreshold.ToString();
                    // Ticks, per (...)
                    setTicksPerAnimalSpawn.Text = bukkitYml.animalSpawns.ToString();
                    setTicksPerMonsterSpawn.Text = bukkitYml.monsterSpawns.ToString();
                    setTicksPerAutoSave.Text = bukkitYml.autoSave.ToString();
                    // Auto updater
                    // CheckBoxes
                    setAutoUpdaterEnabled.Checked = bukkitYml.autoUpdateEnabled;
                    setUpdaterSuggestChannels.Checked = bukkitYml.suggestChannels;
                    // CheckedListBoxes
                    foreach (String str in bukkitYml.onUpdaterBroken)
                        if (str.ToLower().Equals("warn-console"))
                            setsOnUpdaterBroken.SetItemChecked(0, true);
                        else if (str.ToLower().Equals("warn-ops"))
                            setsOnUpdaterBroken.SetItemChecked(1, true);
                    foreach (String str in bukkitYml.onUpdate)
                        if (str.ToLower().Equals("warn-console"))
                            setsOnUpdate.SetItemChecked(0, true);
                        else if (str.ToLower().Equals("warn-ops"))
                            setsOnUpdate.SetItemChecked(1, true);
                    // TextBoxes
                    setUpdaterPreferredChannel.Text = bukkitYml.preferredChannel;
                    setUpdaterHost.Text = bukkitYml.host;
                    // Database
                    setDatabaseUsername.Text = bukkitYml.dbUsername;
                    setDatabaseIsolation.Text = bukkitYml.dbIsolation;
                    setDatabaseDriver.Text = bukkitYml.dbDriver;
                    setDatabasePassword.Text = bukkitYml.dbPassword;
                    setDatabaseURL.Text = bukkitYml.dbURL;
                }
            } catch (Exception ex) {
                DialogResult result = MessageBox.Show(this,
                      "ERROR: An error has occurred while attempting to load the Bukkit preferences!\n"
                    + "Error Message: " + ex.Message + "\n"
                    + "Error Data: " + ex.Data + "\n"
                    + "Error (Inner Exception): " + ex.InnerException + "\n"
                    + "Error StackTrace: " + ex.StackTrace + "\n\n"
                    + "Please take a screenshot and send it to the developer, if this problem persists.",
                    "Error Loading Bukkit Preferences!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (result == DialogResult.Retry) {
                    loadBukkitYaml();
                    return;
                } else if (result == DialogResult.Abort)
                    Application.Exit();
                else // Can only be Ignore
                    return;
            }
        }

        private void selectJavaInstallation_Click(object sender, EventArgs evt) {
            OpenFileDialog jSelect = new OpenFileDialog();
            jSelect.Filter = "Java Platform Binary|java.exe";
            jSelect.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            jSelect.Multiselect = false;
            jSelect.SupportMultiDottedExtensions = false;
            jSelect.Title = "Please Select The Java Binary you Installed...";
            DialogResult result = jSelect.ShowDialog();
            if (result == DialogResult.OK)
                javaInstallPath.Text = jSelect.FileName;
        }

        private void selectBukkitJar_Click(object sender, EventArgs evt) {
            OpenFileDialog bukkitChooser = new OpenFileDialog();
            bukkitChooser.Filter = "Java Jar-Executables|*.jar";
            bukkitChooser.InitialDirectory = Application.ExecutablePath;
            bukkitChooser.Multiselect = false;
            bukkitChooser.SupportMultiDottedExtensions = true;
            bukkitChooser.Title = "Select the Bukkit Server you'd like to Associate with BukkitUI...";
            DialogResult result = bukkitChooser.ShowDialog();
            if (result == DialogResult.OK) {
                bukkitLocation.Text = bukkitChooser.FileName;
                String[] arr = bukkitChooser.FileName.Split(Path.DirectorySeparatorChar);
                List<String> path = new List<String>();
                for (int i = 0; i < (arr.Length) - 1; i++)
                    path.Add(arr[i]);

                if (Regex.IsMatch(path[0], "([A-z][:])", RegexOptions.None) && !path[0].EndsWith(Path.DirectorySeparatorChar.ToString()))
                    path[0] += @"\";

                Properties.Settings.Default.bukkitDir = Path.Combine(path.ToArray());
                bukkitDir.Text = Path.Combine(path.ToArray());
                bukkitYml.bukkitLocation = bukkitDir.Text;
                bukkitYml.load(true);
            }
            bukkitChooser.Dispose();
        }

        private void startServerButton_onClick(object sender, EventArgs evt) {
            startServer();
            startServerButton.Enabled = false;
            stopServerButton.Enabled = true;
            restartServerButton.Enabled = true;
            consoleInput.Enabled = true;
        }

        private void startServer() {

            runServer = true;
            serverState = ServerState.BOOTING;

            // Notify user that server is starting
            statusIcon.Image = Properties.Resources._1391650032_Circle_Orange;
            statusLabel.Text = "Server is Booting...";

            bukkitProcess = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            String args = "";

            if (Properties.Settings.Default.useCustomHeapSize) {
                args += "-Xms " + Properties.Settings.Default.javaInitSizeInMegs.ToString() + "m ";
                args += "-Xmx " + Properties.Settings.Default.javaMaxSizeInMegs.ToString() + "m ";
            } else {
                int[] heapSize = getTotalMemToAllocate();
                consoleOutput.AppendText("--[[ Starting Craftbukkit server with " + heapSize[0] + "->" + heapSize[1] + "MiB RAM. ]]--");
                args += "-Xms " + heapSize[0].ToString() + "m ";
                args += "-Xmx " + heapSize[1].ToString() + "m ";
            }
            args += "-jar " + Properties.Settings.Default.bukkit + " --nojline";

            info.Arguments = args;
            info.CreateNoWindow = true;
            info.FileName = "java.exe";
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.WorkingDirectory = Properties.Settings.Default.bukkitDir;
            bukkitProcess.StartInfo = info;
            bukkitProcess.Exited += bukkitProcess_Exited;
            bukkitProcess.ErrorDataReceived += bukkitProcess_ErrorDataReceived;
            bukkitProcess.OutputDataReceived += bukkitProcess_OutputDataReceived;

            // Clear console output to make sure that the user starts over with a clear log
            consoleOutput.Clear();

            bukkitProcess.Start();
            bukkitProcess.BeginErrorReadLine();
            bukkitProcess.BeginOutputReadLine();
        }

        private void bukkitProcess_OutputDataReceived(object sender, DataReceivedEventArgs evt) {
            if (evt.Data == null) // Assume program has exited.
                runServer = false;
            Invoke((MethodInvoker)delegate { consoleOutput.AppendText(evt.Data + "\n"); });
        }

        private void bukkitProcess_ErrorDataReceived(object sender, DataReceivedEventArgs evt) {
            String data = evt.Data;
            if (data == null) {
                Invoke((MethodInvoker)delegate {
                    statusIcon.Image = Properties.Resources._1391649980_Circle_Red;
                    statusLabel.Text = "Server Halted [ " + new DateTime().Date.ToShortTimeString() + " ]";
                    startServerButton.Enabled = true;
                    stopServerButton.Enabled = false;
                    restartServerButton.Enabled = false;
                    runServer = false;
                });
                return;
            }

            Invoke((MethodInvoker)delegate { consoleOutput.AppendText(data + "\n"); });

            #region Highlight Keywords
            foreach (String word in keywords) {
                Invoke((MethodInvoker)delegate {
                    Color color = Color.Transparent;

                    switch (word) {
                        case "FINE":
                            color = Color.Green;
                            break;
                        case "FINER":
                            color = Color.Green;
                            break;
                        case "FINEST":
                            color = Color.Green;
                            break;
                        case "INFO":
                            color = Color.Blue;
                            break;
                        case "SEVERE":
                            color = Color.Red;
                            break;
                        case "WARNING":
                            color = Color.Yellow;
                            break;
                        default: // Should never happen
                            color = Color.Blue;
                            break;
                    }

                    int s_start = consoleOutput.SelectionStart, startIndex = 0, index;

                    while ((index = consoleOutput.Text.IndexOf(word, startIndex)) != -1) {
                        consoleOutput.Select(index, word.Length);
                        consoleOutput.SelectionColor = color;

                        startIndex = index + word.Length;
                    }

                    consoleOutput.SelectionStart = s_start;
                    consoleOutput.SelectionLength = 0;
                    consoleOutput.SelectionColor = Color.Black;
                });
            }
            #endregion

            if (Regex.IsMatch(data, "(Done)(.)")) {
                // Notify user that server is up and running
                Invoke((MethodInvoker)delegate {
                    statusIcon.Image = Properties.Resources._1391650028_Circle_Green;
                    statusLabel.Text = "Server is Running [ " + bukkitProcess.StartTime.ToShortTimeString() + " ]";
                    serverState = ServerState.RUNNING;
                });
            }

            if (Regex.IsMatch(data, "(Stopping server)(.)")) {
                Invoke((MethodInvoker)delegate {
                    statusIcon.Image = Properties.Resources._1391650032_Circle_Orange;
                    statusLabel.Text = "Server is Stopping... [ " + new DateTime().Date.ToShortTimeString() + " ]";
                    serverState = ServerState.SHUTTING_DOWN;
                });
            }
        }

        private void bukkitProcess_Exited(object sender, EventArgs evt) {
            startServerButton.Enabled = true;
            stopServerButton.Enabled = false;
            restartServerButton.Enabled = false;
            bukkitProcess.Dispose();
            serverState = ServerState.NOT_RUNNING;
        }

        private void stopServerButton_Click(object sender, EventArgs evt) {

            new Thread(() => {
                bukkitProcess.StandardInput.WriteLine("stop");
                bukkitProcess.StandardInput.Flush();
                bukkitProcess.WaitForExit(50000); // Wait for process to end. If by then the process wasn't killed, KILL IT
                try { if (!bukkitProcess.HasExited) bukkitProcess.Kill(); } catch (Exception ex) { }
                bukkitProcess.Close();
                runServer = false;
                consoleInput.Text = "";
                consoleInput.Enabled = false;
            }).Start();

        }

        private void restartServerButton_Click(object sender, EventArgs evt) {
            new Thread(() => {
                Invoke((MethodInvoker)delegate {
                    stopServerButton.PerformClick();
                    startServerButton.Enabled = false;
                    stopServerButton.Enabled = true;
                    restartServerButton.Enabled = true;
                });
            }).Start();
        }

        private String getHelmUrl(String playerName) {
            return "https://minotar.net/helm/" + playerName + "/32.png";
        }

        public void loadServerPlayers() {

            new Thread(() => {

                ImageList helmList = new ImageList();
                helmList.ImageSize = new Size(32, 32);
                serverPlayerList.SmallImageList = helmList;

                helmIdx = 0;
                while (runManagement) {
                    Invoke((MethodInvoker)delegate {
                        try {
                            if (Directory.Exists(Path.Combine(Properties.Settings.Default.bukkitDir, serverProps.levelName, "players")))
                                foreach (String player in Directory.GetFiles(Path.Combine(Properties.Settings.Default.bukkitDir, serverProps.levelName, "players"))) {
                                    if (player.ToLower().EndsWith(".dat")) {
                                        String name = Path.GetFileNameWithoutExtension(player);
                                        // Download player's helm and put into helmList
                                        using (WebClient wc = new WebClient()) {
                                            byte[] helmData;
                                            helmData = wc.DownloadData(getHelmUrl(name));

                                            using (MemoryStream memStream = new MemoryStream(helmData))
                                            using (Bitmap bmp = new Bitmap(memStream)) {
                                                helmList.Images.Add(((Bitmap)bmp.Clone()));
                                            }
                                            wc.Dispose();
                                        }
                                        // Add player name and helm to serverPlayerList
                                        bool add = true;

                                        foreach (ListViewItem item in serverPlayerList.Items) {
                                            if (item.Text.Equals(name))
                                                add = false;
                                        }

                                        if (add) {
                                            serverPlayerList.Items.Add(new ListViewItem(name));
                                            int idx = (serverPlayerList.Items.Count - 1);
                                            serverPlayerList.Items[idx].ImageIndex = helmIdx; ;
                                            helmIdx++;
                                        }
                                    }
                                }
                        } catch (Exception ex) {
                            MessageBox.Show(this, "An error occurred while loading server players: " + ex.InnerException + "\n"
                                + "Stack trace: " + ex.StackTrace + "\n\n"
                                + "Please report this error to the developer!", "Error Occurred While Loading Server Players!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });

                    Thread.Sleep(5000); // Sleep for 5 seconds to prevent any weird overflows.
                }
                Thread.CurrentThread.Abort();
            }).Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs evt) {
            runManagement = false;
            if (bukkitProcess != null)
                if (runServer || !bukkitProcess.HasExited) {
                    evt.Cancel = true;
                    MessageBox.Show(this,
                          "You cannot exit BukkitUI before stopping the Craftbukkit server!\n"
                        + "Please stop the craftbukkit server and then try again.", "Cannot Exit While Server Running!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void consoleInput_TextChanged(object sender, EventArgs evt) {
            if (consoleInput.Text != null && !consoleInput.Text.Equals(""))
                executeCmdButton.Enabled = true;
            else
                executeCmdButton.Enabled = false;
        }

        private void executeCmdButton_Click(object sender, EventArgs evt) {
            bukkitProcess.StandardInput.WriteLine(consoleInput.Text);
            bukkitProcess.StandardInput.Flush();
            consoleInput.Text = "";
        }

        private void consoleInput_KeyDown(object sender, KeyEventArgs evt) {
            if (evt.KeyCode == Keys.Enter)
                executeCmdButton.PerformClick();
        }

        private void button1_Click(object sender, EventArgs evt) {
            DialogResult result = new BukkitCmdBrowser().ShowDialog();
        }

        private void getServerOPs() {
            new Thread(() => {

                ImageList opList = new ImageList();
                opList.ImageSize = new Size(32, 32);
                serverOPList.SmallImageList = opList;
                int idx = 0;

                while (runManagement) {
                    if (!File.Exists(Path.Combine(Properties.Settings.Default.bukkitDir, "ops.txt")))
                        File.Create(Path.Combine(Properties.Settings.Default.bukkitDir, "ops.txt")).Close();

                    String ops = File.ReadAllText(Path.Combine(Properties.Settings.Default.bukkitDir, "ops.txt"));

                    String[] _ops = Regex.Split(ops, @"[\s]");

                    foreach (String op in _ops) {
                        // Download player helm
                        try {
                            using (WebClient wc = new WebClient()) {
                                byte[] data = wc.DownloadData(getHelmUrl(op));

                                using (MemoryStream memStream = new MemoryStream(data))
                                using (Bitmap bmp = new Bitmap(memStream)) {
                                    opList.Images.Add((Bitmap)bmp.Clone());
                                }
                                wc.Dispose();
                            }

                            bool add = true;

                            foreach (ListViewItem item in serverOPList.Items)
                                if (serverOPList.Items.Contains(item))
                                    add = false;

                            if (add) {
                                serverOPList.Items.Add((new ListViewItem(op))).ImageIndex = idx;
                                idx++;
                            }

                        } catch (Exception ex) {
                            Console.WriteLine("An error occurred while downloading op helm: " + ex.InnerException);
                            Console.WriteLine(ex.StackTrace);
                        }
                    }

                    // Sleep for five seconds
                    Thread.Sleep(5000);

                }
            }).Start();
        }

        private void addNewOPToolStripMenuItem_Click(object sender, EventArgs evt) {
            String newOP = "";

            GetPlayerNameDialog dialog = new GetPlayerNameDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                newOP = dialog.playerName;
            else return;

            String opsFile = Path.Combine(Properties.Settings.Default.bukkitDir, "ops.txt");

            String ops = File.ReadAllText(opsFile);

            ops += " " + newOP + "\n";

            File.WriteAllText(opsFile, ops);
        }

        private void removeOPToolStripMenuItem_Click(object sender, EventArgs evt) {

            GetPlayerNameDialog dialog = new GetPlayerNameDialog();
            String name = "";
            if (dialog.ShowDialog() == DialogResult.OK)
                name = dialog.playerName;
            else return;

            File.WriteAllText(Path.Combine(Properties.Settings.Default.bukkitDir, "ops.txt"),
             File.ReadAllText(Path.Combine(Properties.Settings.Default.bukkitDir, "ops.txt")).Replace(name, ""));
        }

        private void clearOPsToolStripMenuItem_Click(object sender, EventArgs evt) {
            File.WriteAllText(Path.Combine(Properties.Settings.Default.bukkitDir, "ops.txt"), "");
        }

        private void getWhiteListedPlayers() {
            new Thread(() => {

                ImageList playerList = new ImageList();
                playerList.ImageSize = new Size(32, 32);
                serverWhiteList.SmallImageList = playerList;
                int idx = 0;
                bool add = true;

                while (runManagement) {
                    Invoke((MethodInvoker)delegate {
                        if (!File.Exists(Path.Combine(Properties.Settings.Default.bukkitDir, "white-list.txt")))
                            File.Create(Path.Combine(Properties.Settings.Default.bukkitDir, "white-list.txt")).Close();
                        String[] whiteList =
                            Regex.Split(File.ReadAllText(Path.Combine(Properties.Settings.Default.bukkitDir, "white-list.txt")), @"[\s]");
                        foreach (String player in whiteList) {
                            foreach (ListViewItem item in serverWhiteList.Items)
                                if (serverWhiteList.Items.Contains(item))
                                    add = false;
                            if (add) {
                                using (WebClient wc = new WebClient()) {
                                    byte[] data = wc.DownloadData(getHelmUrl(player));

                                    using (MemoryStream memStream = new MemoryStream(data))
                                    using (Bitmap bmp = new Bitmap(memStream)) {
                                        playerList.Images.Add((Bitmap)bmp.Clone());
                                        serverWhiteList.Items.Add(new ListViewItem(player)).ImageIndex = idx;
                                        idx++;
                                        memStream.Close();
                                    }
                                    wc.Dispose();

                                }
                            }
                        }
                    });
                }
            }).Start();
        }

        private void getBannedPlayers() {
            // To-Do: Fix
            new Thread(() => {

                int idx = 0;
                List<String> playerList = new List<String>();

                while (runManagement) {
                    Invoke((MethodInvoker)delegate {
                        if (!File.Exists(Path.Combine(Properties.Settings.Default.bukkitDir, "banned-players.txt")))
                            File.Create(Path.Combine(Properties.Settings.Default.bukkitDir, "banned-players.txt")).Close();
                        String[] bannedPlayers = 
                            File.ReadAllText(Path.Combine(Properties.Settings.Default.bukkitDir, "banned-players.txt")).Split('\n');
                        foreach (String str in bannedPlayers) {
                            if (str.StartsWith("#")) continue;
                            if (String.IsNullOrWhiteSpace(str) || String.IsNullOrEmpty(str)) continue;
                            bannedPlayersTable.Rows.Add(1);
                            String[] tableData = Regex.Split(str, "[|]");
                            foreach (System.Windows.Forms.DataGridViewRow row in bannedPlayersTable.Rows)
                                if (playerList.Contains(row.Cells[0].Value)) continue;
                            for (int i = 0; i < tableData.Length; i++)
                                bannedPlayersTable.Rows[idx].Cells[i].Value = tableData[i];
                            playerList.Add(tableData[0]);
                            idx++;

                        }
                    });
                    Thread.Sleep(5000);
                }
                Thread.CurrentThread.Abort();
            }).Start();
        }

        private void enableCustomHeapSize_CheckedChanged(object sender, EventArgs evt) {
            if (enableCustomHeapSize.Checked)
                if (MessageBox.Show(this, "Changing these settings may overload your computer if you're not careful.\n"
                    + "It is said, that this is what causes nuclear war.\n"
                    + "Of course that part is just to make you unsure. Seriously, this can be dangerous!\n"
                    + "Please only change these values if you know what you're doing or you have a feeling that BukkitUI\n"
                    + "isn't allocating enough memory on its own!\n"
                    + "BukkitUI (in any normal case) will determine the right amount of memory to allocate\n"
                    + "to run your server smoothly, while keeping the system usable!\n"
                    + "(Unless you set its mode to \"Server-Mode\", then it will use as much as possible.\n"
                    + "ONLY DO THIS ON ACTUAL SERVER SYSTEMS!)\n\n"
                    + "Do you wish to continue? :)", "Continue?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                    if (enableCustomHeapSize.Checked) {
                        initHeapSize.Enabled = true;
                        initHeapSize.Text = Properties.Settings.Default.javaInitSizeInMegs.ToString();
                        maxHeapSize.Enabled = true;
                        maxHeapSize.Text = Properties.Settings.Default.javaMaxSizeInMegs.ToString();
                        comboBox1.Enabled = false;
                    } else {
                        initHeapSize.Enabled = false;
                        initHeapSize.Text = "";
                        maxHeapSize.Enabled = false;
                        maxHeapSize.Text = "";
                        comboBox1.Enabled = true;
                    } else
                    enableCustomHeapSize.Checked = false;
            else {
                initHeapSize.Enabled = false;
                initHeapSize.Text = "";
                maxHeapSize.Enabled = false;
                maxHeapSize.Text = "";
                comboBox1.Enabled = true;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs evt) {
            ToolTip toolTip = new ToolTip();
            switch (comboBox1.SelectedItem.ToString()) {
                case "Resource Saving":
                    toolTip.IsBalloon = true;
                    toolTip.ToolTipIcon = ToolTipIcon.Info;
                    toolTip.ToolTipTitle = "Information:";
                    toolTip.Show("Allocates as little memory as possible for the server - Usually about 20% of the total memory.\n"
                        + "This is great when you just want to host a small private server and play with a few friends.",
                        this, comboBox1.Location.X, comboBox1.Location.Y, 2000);
                    allocationMode = ServerAllocationMode.Resource_Saving;
                    if (runServer)
                        MessageBox.Show(this, "Please restart the Craftbukkit server for the changes to become active!",
                            "Restart Server.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Reduced Resources":
                    toolTip.IsBalloon = true;
                    toolTip.ToolTipIcon = ToolTipIcon.Info;
                    toolTip.ToolTipTitle = "Information:";
                    toolTip.Show("Allocates about 30% of the total memory to the server.\n"
                        + "This is great for hosting a server during a small LAN-party with 10-15 players.", this,
                        comboBox1.Location.X, comboBox1.Location.Y, 2000);
                    allocationMode = ServerAllocationMode.Reduced_Resources;
                    if (runServer)
                        MessageBox.Show(this, "Please restart the Craftbukkit server for the changes to become active!",
                            "Restart Server.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Normal Resources":
                    toolTip.IsBalloon = true;
                    toolTip.ToolTipIcon = ToolTipIcon.Info;
                    toolTip.ToolTipTitle = "Information:";
                    toolTip.Show("Allocates about 35-40% of the total memory to the server.\n"
                    + "This is ideal for moderately powered computers with more than 2GiB RAM.\n"
                    + "Ideal for bigger LAN-parties and/or small online servers.", this,
                        comboBox1.Location.X, comboBox1.Location.Y, 2000);
                    allocationMode = ServerAllocationMode.Normal_Resources;
                    if (runServer)
                        MessageBox.Show(this, "Please restart the Craftbukkit server for the changes to become active!",
                            "Restart Server.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Automatic":
                    toolTip.IsBalloon = true;
                    toolTip.ToolTipIcon = ToolTipIcon.Info;
                    toolTip.ToolTipTitle = "Information:";
                    toolTip.Show("This option is the recommended option to choose.\n"
                        + "This option allows the JVM to choose how much memory to allocate to the server", this,
                        comboBox1.Location.X, comboBox1.Location.Y, 2000);
                    allocationMode = ServerAllocationMode.Auto;
                    if (runServer)
                        MessageBox.Show(this, "Please restart the Craftbukkit server for the changes to become active!",
                            "Restart Server.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private int[] getTotalMemToAllocate() {
            int[] arr = new int[2];

            #region // Get initial heap size
            switch (allocationMode) {
                case ServerAllocationMode.Resource_Saving:
                    MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
                    ulong availPhysicalMem = 0;
                    ulong availVirtualMem = 0;
                    long totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)((((availPhysicalMem + availVirtualMem) / (1024 / 1024)) / 100) * 20);
                        arr[0] = (int)totalAvailMemory;
                    }
                    break;
                case ServerAllocationMode.Reduced_Resources:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)((((availPhysicalMem + availVirtualMem) / (1024 / 1024)) / 100) * 30);
                        arr[0] = (int)totalAvailMemory;
                    }
                    break;
                case ServerAllocationMode.Normal_Resources:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)((((availPhysicalMem + availVirtualMem) / (1024 / 1024)) / 100) * 40);
                        arr[0] = (int)totalAvailMemory;
                    }
                    break;
                case ServerAllocationMode.Auto:
                    break;
                case ServerAllocationMode.Full_Power:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)(((availPhysicalMem + availVirtualMem) / (1024 / 1024)));
                        if (totalAvailMemory < 4000) // Less than four Gigs. Allocate 45% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 40;
                        else if (totalAvailMemory > 4000) // More than four Gigs. Allocate 50% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 50;
                        else if (totalAvailMemory > 5000) // More than five Gigs. Allocate 55% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 55;
                        else if (totalAvailMemory > 6000) // More than six Gigs. Allocate 60% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 60;
                        else // Undefined. Allocate 45%
                            totalAvailMemory = (totalAvailMemory / 100) * 45;
                        arr[0] = (int)totalAvailMemory;
                    }
                    break;
                case ServerAllocationMode.Server_Mode:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)(((availPhysicalMem + availVirtualMem) / (1024 / 1024)));

                        if (!PCSystemType.isServer) {
                            if (MessageBox.Show(this, "BukkitUI detected, that you are not running a server.\n"
                                + "BukkitUI will not run in this mode unless you are using an actual server!\n"
                                + "(WorkStations do not count as servers!)\n\n"
                                + "Do you wish BukkitUI to choose the Automatic memory allocation mode instead?",
                                "Computer not a Server! Select Auto?",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                allocationMode = ServerAllocationMode.Auto;
                            else
                                Application.Exit();
                            savePrefs.PerformClick();
                            return getTotalMemToAllocate();
                        }
                        arr[0] = (int)(totalAvailMemory / 100) * 90;
                    }
                    break;
            }
            #endregion

            #region // Get max heap size
            switch (allocationMode) {
                case ServerAllocationMode.Resource_Saving:
                    MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
                    ulong availPhysicalMem = 0;
                    ulong availVirtualMem = 0;
                    long totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)((((availPhysicalMem + availVirtualMem) / (1024 / 1024)) / 100) * 20);
                        arr[1] = (int)totalAvailMemory + arr[0] / 3;
                    }
                    break;
                case ServerAllocationMode.Reduced_Resources:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)((((availPhysicalMem + availVirtualMem) / (1024 / 1024)) / 100) * 30);
                        arr[1] = (int)totalAvailMemory + arr[0] / 3;
                    }
                    break;
                case ServerAllocationMode.Normal_Resources:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)((((availPhysicalMem + availVirtualMem) / (1024 / 1024)) / 100) * 40);
                        arr[1] = (int)totalAvailMemory + arr[0] / 3;
                    }
                    break;
                case ServerAllocationMode.Auto:
                    break;
                case ServerAllocationMode.Full_Power:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)(((availPhysicalMem + availVirtualMem) / (1024 / 1024)));
                        if (totalAvailMemory < 4000) // Less than four Gigs. Allocate 45% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 40;
                        else if (totalAvailMemory > 4000) // More than four Gigs. Allocate 50% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 50;
                        else if (totalAvailMemory > 5000) // More than five Gigs. Allocate 55% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 55;
                        else if (totalAvailMemory > 6000) // More than six Gigs. Allocate 60% RAM
                            totalAvailMemory = (totalAvailMemory / 100) * 60;
                        else // Undefined. Allocate 45%
                            totalAvailMemory = (totalAvailMemory / 100) * 45;
                        arr[1] = (int)totalAvailMemory + arr[0] / 3;
                    }
                    break;
                case ServerAllocationMode.Server_Mode:
                    memStatus = new MEMORYSTATUSEX();
                    availPhysicalMem = 0;
                    availVirtualMem = 0;
                    totalAvailMemory = 0;
                    if (MEMORYSTATUSEX.GlobalMemoryStatusEx(memStatus)) {
                        availPhysicalMem = memStatus.ullAvailPhys;
                        availVirtualMem = memStatus.ullAvailVirtual;

                        totalAvailMemory = (long)(((availPhysicalMem + availVirtualMem) / (1024 / 1024)));

                        if (!PCSystemType.isServer) {
                            if (MessageBox.Show(this, "BukkitUI detected, that you are not running a server.\n"
                                + "BukkitUI will not run in this mode unless you are using an actual server!\n"
                                + "(WorkStations do not count as servers!)\n\n"
                                + "Do you wish BukkitUI to choose the Automatic memory allocation mode instead?",
                                "Computer not a Server! Select Auto?",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                allocationMode = ServerAllocationMode.Auto;
                            else
                                Application.Exit();
                            savePrefs.PerformClick();
                            return getTotalMemToAllocate();
                        }
                        arr[1] = (int)(totalAvailMemory / 100) * 90 + arr[0] / 3;
                    }
                    break;
            }
            #endregion

            return arr;
        }

        private void openUpdater_Click(object sender, EventArgs e) {
            String exePath = Path.GetDirectoryName(Application.ExecutablePath);
            MessageBox.Show(this, Path.Combine(exePath, "BukkitUI_Updater.exe"));
            Process.Start(Path.Combine(exePath, "BukkitUI_Updater.exe"));
        }

        private void worldMgmtButton_Click(object sender, EventArgs e) {
            new WorldMgmt(serverProps).ShowDialog();
        }

        private void useColourStars_CheckedChanged(object sender, EventArgs e) {
            if (useColourStars.Checked) {
                ImageList imgList = playerListView.SmallImageList;
                imgList.Images[0] = Properties.Resources.player_online;
                imgList.Images[1] = Properties.Resources.player_afk;
            } else {
                ImageList imgList = playerListView.SmallImageList;
                imgList.Images[0] = Properties.Resources.player_online_metro;
                imgList.Images[1] = Properties.Resources.player_offline_metro;
            }
        }

    }

    class PCSystemType {

        internal static bool isServer { get { return _isServer(); } }

        private static bool _isServer() {
                try {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_ComputerSystem");
                    foreach (ManagementObject obj in searcher.Get()) {
                        if (obj["PCSystemType"] != null && !((String)obj["PCSystemType"].ToString()).Equals("")) {
                            int type = int.Parse(((String)obj["PCSystemType"].ToString()));
                            switch (type) {
                                // In case you don't believe the code: http://msdn.microsoft.com/en-us/library/aa394102%28v=vs.85%29.aspx
                                // Under PCSystemType. Just over half way down the page.
                                case 0x0:
                                    return false;
                                case 0x1:
                                    return false;
                                case 0x2:
                                    return false;
                                case 0x3:
                                    return false;
                                case 0x4:
                                    return true;
                                case 0x5:
                                    return true;
                                case 0x6:
                                    return false;
                                case 0x7:
                                    return true;
                                case 0x8:
                                    return true;
                            }
                        }
                    }
                } catch (ManagementException ex) {
                    return false;
                }
            return false;
        }

    }
    
}
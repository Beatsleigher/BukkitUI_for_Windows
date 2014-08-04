using System.Diagnostics;
using System.Windows.Forms;
namespace BukkitUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.background = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabBukkit = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.playerListView = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updateServerbtn = new System.Windows.Forms.Button();
            this.deleteServerButton = new System.Windows.Forms.Button();
            this.worldMgmtButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.restartServerButton = new System.Windows.Forms.Button();
            this.stopServerButton = new System.Windows.Forms.Button();
            this.startServerButton = new System.Windows.Forms.Button();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.executeCmdButton = new System.Windows.Forms.Button();
            this.consoleInput = new System.Windows.Forms.TextBox();
            this.consoleOutput = new System.Windows.Forms.RichTextBox();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabServerSettings = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.setUseExactLoginLocation = new System.Windows.Forms.CheckBox();
            this.setPluginProfiling = new System.Windows.Forms.CheckBox();
            this.setQueryPlugins = new System.Windows.Forms.CheckBox();
            this.setAllowEnd = new System.Windows.Forms.CheckBox();
            this.setWarnOnOverload = new System.Windows.Forms.CheckBox();
            this.setShutdownMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.setDeprecatedVerbose = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.setConnectionThrottle = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.setPingPacketLimit = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.setUpdateFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.setAmbientLimit = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.setWaterAnimalLimit = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.setAnimalLimit = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.setMonsterLimit = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.setGCLoadThreshold = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.setGCPeriodInTicks = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.setTicksPerAutoSave = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.setTicksPerMonsterSpawn = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.setTicksPerAnimalSpawn = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.setUpdaterSuggestChannels = new System.Windows.Forms.CheckBox();
            this.setUpdaterHost = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.setUpdaterPreferredChannel = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.setsOnUpdate = new System.Windows.Forms.CheckedListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.setsOnUpdaterBroken = new System.Windows.Forms.CheckedListBox();
            this.setAutoUpdaterEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.setDatabaseURL = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.setDatabasePassword = new System.Windows.Forms.TextBox();
            this.setDatabaseDriver = new System.Windows.Forms.TextBox();
            this.setDatabaseIsolation = new System.Windows.Forms.TextBox();
            this.setDatabaseUsername = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabServerProperties = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.serverPlayerList = new System.Windows.Forms.ListView();
            this.tabOps = new System.Windows.Forms.TabPage();
            this.serverOPList = new System.Windows.Forms.ListView();
            this.opContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearOPsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabWhitelist = new System.Windows.Forms.TabPage();
            this.serverWhiteList = new System.Windows.Forms.ListView();
            this.tabBannedPlayers = new System.Windows.Forms.TabPage();
            this.bannedPlayersTable = new System.Windows.Forms.DataGridView();
            this.victimNane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bannedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bannedUntil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverBannedPlayersList = new System.Windows.Forms.ListView();
            this.tabPreferences = new System.Windows.Forms.TabPage();
            this.openUpdater = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.savePrefs = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.useColourStars = new System.Windows.Forms.CheckBox();
            this.selectJavaInstallation = new System.Windows.Forms.Button();
            this.javaInstallPath = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.extendDWMIntoClient = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.maxHeapSize = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.initHeapSize = new System.Windows.Forms.MaskedTextBox();
            this.enableCustomHeapSize = new System.Windows.Forms.CheckBox();
            this.bukkitDir = new System.Windows.Forms.TextBox();
            this.selectBukkitJar = new System.Windows.Forms.Button();
            this.bukkitLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serverRebootInterval = new System.Windows.Forms.MaskedTextBox();
            this.autoRebootServer = new System.Windows.Forms.CheckBox();
            this.bootOnStartup = new System.Windows.Forms.CheckBox();
            this.statusIcon = new System.Windows.Forms.PictureBox();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.statusLabel = new BukkitUI.AntiLabel();
            this.memBar = new BukkitUI.TextProgressBar();
            this.cpuBar = new BukkitUI.TextProgressBar();
            this.tabControl1.SuspendLayout();
            this.background.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabBukkit.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabServerSettings.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabServerProperties.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            this.tabOps.SuspendLayout();
            this.opContextMenu.SuspendLayout();
            this.tabWhitelist.SuspendLayout();
            this.tabBannedPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannedPlayersTable)).BeginInit();
            this.tabPreferences.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.background);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 404);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // background
            // 
            this.background.Controls.Add(this.tabControl2);
            this.background.Location = new System.Drawing.Point(4, 5);
            this.background.Name = "background";
            this.background.Padding = new System.Windows.Forms.Padding(3);
            this.background.Size = new System.Drawing.Size(788, 395);
            this.background.TabIndex = 0;
            this.background.Text = "tabPage1";
            this.background.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabBukkit);
            this.tabControl2.Controls.Add(this.tabConsole);
            this.tabControl2.Controls.Add(this.tabServer);
            this.tabControl2.Controls.Add(this.tabPreferences);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(782, 389);
            this.tabControl2.TabIndex = 0;
            // 
            // tabBukkit
            // 
            this.tabBukkit.Controls.Add(this.groupBox4);
            this.tabBukkit.Controls.Add(this.groupBox3);
            this.tabBukkit.Controls.Add(this.groupBox2);
            this.tabBukkit.Controls.Add(this.groupBox1);
            this.tabBukkit.Location = new System.Drawing.Point(4, 22);
            this.tabBukkit.Name = "tabBukkit";
            this.tabBukkit.Padding = new System.Windows.Forms.Padding(3);
            this.tabBukkit.Size = new System.Drawing.Size(774, 363);
            this.tabBukkit.TabIndex = 0;
            this.tabBukkit.Text = "BukkitUI";
            this.tabBukkit.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.playerListView);
            this.groupBox4.Location = new System.Drawing.Point(7, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(769, 194);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Online Players";
            // 
            // playerListView
            // 
            this.playerListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.playerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.playerListView.Location = new System.Drawing.Point(3, 16);
            this.playerListView.Name = "playerListView";
            this.playerListView.Size = new System.Drawing.Size(763, 175);
            this.playerListView.TabIndex = 0;
            this.playerListView.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.memBar);
            this.groupBox3.Controls.Add(this.cpuBar);
            this.groupBox3.Location = new System.Drawing.Point(258, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 116);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Stats";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updateServerbtn);
            this.groupBox2.Controls.Add(this.deleteServerButton);
            this.groupBox2.Controls.Add(this.worldMgmtButton);
            this.groupBox2.Location = new System.Drawing.Point(109, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 117);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Management";
            // 
            // updateServerbtn
            // 
            this.updateServerbtn.Location = new System.Drawing.Point(10, 78);
            this.updateServerbtn.Name = "updateServerbtn";
            this.updateServerbtn.Size = new System.Drawing.Size(119, 23);
            this.updateServerbtn.TabIndex = 2;
            this.updateServerbtn.Text = "Update Server";
            this.updateServerbtn.UseVisualStyleBackColor = true;
            // 
            // deleteServerButton
            // 
            this.deleteServerButton.Location = new System.Drawing.Point(10, 49);
            this.deleteServerButton.Name = "deleteServerButton";
            this.deleteServerButton.Size = new System.Drawing.Size(119, 23);
            this.deleteServerButton.TabIndex = 1;
            this.deleteServerButton.Text = "Delete Server";
            this.deleteServerButton.UseVisualStyleBackColor = true;
            // 
            // worldMgmtButton
            // 
            this.worldMgmtButton.Location = new System.Drawing.Point(10, 20);
            this.worldMgmtButton.Name = "worldMgmtButton";
            this.worldMgmtButton.Size = new System.Drawing.Size(119, 23);
            this.worldMgmtButton.TabIndex = 0;
            this.worldMgmtButton.Text = "World Management";
            this.worldMgmtButton.UseVisualStyleBackColor = true;
            this.worldMgmtButton.Click += new System.EventHandler(this.worldMgmtButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.restartServerButton);
            this.groupBox1.Controls.Add(this.stopServerButton);
            this.groupBox1.Controls.Add(this.startServerButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 117);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Controls";
            // 
            // restartServerButton
            // 
            this.restartServerButton.Enabled = false;
            this.restartServerButton.Location = new System.Drawing.Point(11, 78);
            this.restartServerButton.Name = "restartServerButton";
            this.restartServerButton.Size = new System.Drawing.Size(75, 23);
            this.restartServerButton.TabIndex = 2;
            this.restartServerButton.Text = "Restart Server";
            this.restartServerButton.UseVisualStyleBackColor = true;
            this.restartServerButton.Click += new System.EventHandler(this.restartServerButton_Click);
            // 
            // stopServerButton
            // 
            this.stopServerButton.Enabled = false;
            this.stopServerButton.Location = new System.Drawing.Point(11, 49);
            this.stopServerButton.Name = "stopServerButton";
            this.stopServerButton.Size = new System.Drawing.Size(75, 23);
            this.stopServerButton.TabIndex = 1;
            this.stopServerButton.Text = "Stop Server";
            this.stopServerButton.UseVisualStyleBackColor = true;
            this.stopServerButton.Click += new System.EventHandler(this.stopServerButton_Click);
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(11, 20);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(75, 23);
            this.startServerButton.TabIndex = 0;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_onClick);
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.button1);
            this.tabConsole.Controls.Add(this.executeCmdButton);
            this.tabConsole.Controls.Add(this.consoleInput);
            this.tabConsole.Controls.Add(this.consoleOutput);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(774, 363);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // executeCmdButton
            // 
            this.executeCmdButton.Enabled = false;
            this.executeCmdButton.Location = new System.Drawing.Point(610, 321);
            this.executeCmdButton.Name = "executeCmdButton";
            this.executeCmdButton.Size = new System.Drawing.Size(75, 23);
            this.executeCmdButton.TabIndex = 2;
            this.executeCmdButton.Text = "Execute";
            this.executeCmdButton.UseVisualStyleBackColor = true;
            this.executeCmdButton.Click += new System.EventHandler(this.executeCmdButton_Click);
            // 
            // consoleInput
            // 
            this.consoleInput.Enabled = false;
            this.consoleInput.Location = new System.Drawing.Point(7, 323);
            this.consoleInput.Name = "consoleInput";
            this.consoleInput.Size = new System.Drawing.Size(597, 20);
            this.consoleInput.TabIndex = 1;
            this.consoleInput.TextChanged += new System.EventHandler(this.consoleInput_TextChanged);
            this.consoleInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consoleInput_KeyDown);
            // 
            // consoleOutput
            // 
            this.consoleOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.consoleOutput.Location = new System.Drawing.Point(6, 6);
            this.consoleOutput.Name = "consoleOutput";
            this.consoleOutput.ReadOnly = true;
            this.consoleOutput.Size = new System.Drawing.Size(744, 308);
            this.consoleOutput.TabIndex = 0;
            this.consoleOutput.Text = "";
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.tabControl3);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(774, 363);
            this.tabServer.TabIndex = 2;
            this.tabServer.Text = "Server";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabServerSettings);
            this.tabControl3.Controls.Add(this.tabServerProperties);
            this.tabControl3.Controls.Add(this.tabPlayers);
            this.tabControl3.Controls.Add(this.tabOps);
            this.tabControl3.Controls.Add(this.tabWhitelist);
            this.tabControl3.Controls.Add(this.tabBannedPlayers);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(768, 357);
            this.tabControl3.TabIndex = 0;
            // 
            // tabServerSettings
            // 
            this.tabServerSettings.Controls.Add(this.tabControl4);
            this.tabServerSettings.Location = new System.Drawing.Point(4, 22);
            this.tabServerSettings.Name = "tabServerSettings";
            this.tabServerSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabServerSettings.Size = new System.Drawing.Size(760, 331);
            this.tabServerSettings.TabIndex = 0;
            this.tabServerSettings.Text = "Server Settings";
            this.tabServerSettings.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl4.Controls.Add(this.tabPage1);
            this.tabControl4.Controls.Add(this.tabPage2);
            this.tabControl4.Controls.Add(this.tabPage3);
            this.tabControl4.Controls.Add(this.tabPage4);
            this.tabControl4.Controls.Add(this.tabPage5);
            this.tabControl4.Controls.Add(this.tabPage6);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(3, 3);
            this.tabControl4.Multiline = true;
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(754, 325);
            this.tabControl4.TabIndex = 0;
            this.tabControl4.SelectedIndexChanged += new System.EventHandler(this.tabControl4_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(746, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "IC";
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.setUseExactLoginLocation);
            this.splitContainer1.Panel1.Controls.Add(this.setPluginProfiling);
            this.splitContainer1.Panel1.Controls.Add(this.setQueryPlugins);
            this.splitContainer1.Panel1.Controls.Add(this.setAllowEnd);
            this.splitContainer1.Panel1.Controls.Add(this.setWarnOnOverload);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.setShutdownMessage);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.setDeprecatedVerbose);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.setConnectionThrottle);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.setPingPacketLimit);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.setUpdateFolder);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(740, 293);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 11;
            // 
            // setUseExactLoginLocation
            // 
            this.setUseExactLoginLocation.AutoSize = true;
            this.setUseExactLoginLocation.Location = new System.Drawing.Point(10, 55);
            this.setUseExactLoginLocation.Name = "setUseExactLoginLocation";
            this.setUseExactLoginLocation.Size = new System.Drawing.Size(148, 17);
            this.setUseExactLoginLocation.TabIndex = 6;
            this.setUseExactLoginLocation.Text = "Use Exact Login Location";
            this.setUseExactLoginLocation.UseVisualStyleBackColor = true;
            // 
            // setPluginProfiling
            // 
            this.setPluginProfiling.AutoSize = true;
            this.setPluginProfiling.Location = new System.Drawing.Point(10, 80);
            this.setPluginProfiling.Name = "setPluginProfiling";
            this.setPluginProfiling.Size = new System.Drawing.Size(95, 17);
            this.setPluginProfiling.TabIndex = 7;
            this.setPluginProfiling.Text = "Plugin Profiling";
            this.setPluginProfiling.UseVisualStyleBackColor = true;
            // 
            // setQueryPlugins
            // 
            this.setQueryPlugins.AutoSize = true;
            this.setQueryPlugins.Location = new System.Drawing.Point(10, 103);
            this.setQueryPlugins.Name = "setQueryPlugins";
            this.setQueryPlugins.Size = new System.Drawing.Size(91, 17);
            this.setQueryPlugins.TabIndex = 10;
            this.setQueryPlugins.Text = "Query Plugins";
            this.setQueryPlugins.UseVisualStyleBackColor = true;
            // 
            // setAllowEnd
            // 
            this.setAllowEnd.AutoSize = true;
            this.setAllowEnd.Location = new System.Drawing.Point(10, 9);
            this.setAllowEnd.Name = "setAllowEnd";
            this.setAllowEnd.Size = new System.Drawing.Size(73, 17);
            this.setAllowEnd.TabIndex = 0;
            this.setAllowEnd.Text = "Allow End";
            this.setAllowEnd.UseVisualStyleBackColor = true;
            // 
            // setWarnOnOverload
            // 
            this.setWarnOnOverload.AutoSize = true;
            this.setWarnOnOverload.Location = new System.Drawing.Point(10, 32);
            this.setWarnOnOverload.Name = "setWarnOnOverload";
            this.setWarnOnOverload.Size = new System.Drawing.Size(115, 17);
            this.setWarnOnOverload.TabIndex = 1;
            this.setWarnOnOverload.Text = "Warn On Overload";
            this.setWarnOnOverload.UseVisualStyleBackColor = true;
            // 
            // setShutdownMessage
            // 
            this.setShutdownMessage.Location = new System.Drawing.Point(10, 190);
            this.setShutdownMessage.Name = "setShutdownMessage";
            this.setShutdownMessage.Size = new System.Drawing.Size(460, 20);
            this.setShutdownMessage.TabIndex = 24;
            this.setShutdownMessage.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Shutdown Message:";
            // 
            // setDeprecatedVerbose
            // 
            this.setDeprecatedVerbose.Location = new System.Drawing.Point(10, 151);
            this.setDeprecatedVerbose.Name = "setDeprecatedVerbose";
            this.setDeprecatedVerbose.Size = new System.Drawing.Size(460, 20);
            this.setDeprecatedVerbose.TabIndex = 22;
            this.setDeprecatedVerbose.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Deprecated Verbose:";
            // 
            // setConnectionThrottle
            // 
            this.setConnectionThrottle.AsciiOnly = true;
            this.setConnectionThrottle.Location = new System.Drawing.Point(10, 112);
            this.setConnectionThrottle.Mask = "00000";
            this.setConnectionThrottle.Name = "setConnectionThrottle";
            this.setConnectionThrottle.Size = new System.Drawing.Size(460, 20);
            this.setConnectionThrottle.TabIndex = 20;
            this.setConnectionThrottle.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Connection Throttle:";
            // 
            // setPingPacketLimit
            // 
            this.setPingPacketLimit.AsciiOnly = true;
            this.setPingPacketLimit.Location = new System.Drawing.Point(10, 73);
            this.setPingPacketLimit.Mask = "00000";
            this.setPingPacketLimit.Name = "setPingPacketLimit";
            this.setPingPacketLimit.Size = new System.Drawing.Size(460, 20);
            this.setPingPacketLimit.TabIndex = 18;
            this.setPingPacketLimit.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ping Packet Limit:";
            // 
            // setUpdateFolder
            // 
            this.setUpdateFolder.Location = new System.Drawing.Point(10, 27);
            this.setUpdateFolder.Name = "setUpdateFolder";
            this.setUpdateFolder.Size = new System.Drawing.Size(460, 20);
            this.setUpdateFolder.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Update Folder:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.setAmbientLimit);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.setWaterAnimalLimit);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.setAnimalLimit);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.setMonsterLimit);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(746, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Spawn Limits";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // setAmbientLimit
            // 
            this.setAmbientLimit.AsciiOnly = true;
            this.setAmbientLimit.Location = new System.Drawing.Point(9, 142);
            this.setAmbientLimit.Mask = "00000";
            this.setAmbientLimit.Name = "setAmbientLimit";
            this.setAmbientLimit.Size = new System.Drawing.Size(713, 20);
            this.setAmbientLimit.TabIndex = 26;
            this.setAmbientLimit.ValidatingType = typeof(int);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Ambient Limit: (e.g.: Bats)";
            // 
            // setWaterAnimalLimit
            // 
            this.setWaterAnimalLimit.AsciiOnly = true;
            this.setWaterAnimalLimit.Location = new System.Drawing.Point(9, 101);
            this.setWaterAnimalLimit.Mask = "00000";
            this.setWaterAnimalLimit.Name = "setWaterAnimalLimit";
            this.setWaterAnimalLimit.Size = new System.Drawing.Size(713, 20);
            this.setWaterAnimalLimit.TabIndex = 24;
            this.setWaterAnimalLimit.ValidatingType = typeof(int);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Water Animal Limit:";
            // 
            // setAnimalLimit
            // 
            this.setAnimalLimit.AsciiOnly = true;
            this.setAnimalLimit.Location = new System.Drawing.Point(9, 60);
            this.setAnimalLimit.Mask = "00000";
            this.setAnimalLimit.Name = "setAnimalLimit";
            this.setAnimalLimit.Size = new System.Drawing.Size(713, 20);
            this.setAnimalLimit.TabIndex = 22;
            this.setAnimalLimit.ValidatingType = typeof(int);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Animal Limit:";
            // 
            // setMonsterLimit
            // 
            this.setMonsterLimit.AsciiOnly = true;
            this.setMonsterLimit.Location = new System.Drawing.Point(9, 19);
            this.setMonsterLimit.Mask = "00000";
            this.setMonsterLimit.Name = "setMonsterLimit";
            this.setMonsterLimit.Size = new System.Drawing.Size(713, 20);
            this.setMonsterLimit.TabIndex = 20;
            this.setMonsterLimit.ValidatingType = typeof(int);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Monster Limit:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.setGCLoadThreshold);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.setGCPeriodInTicks);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(746, 299);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Chunk GC (Advanced)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // setGCLoadThreshold
            // 
            this.setGCLoadThreshold.AsciiOnly = true;
            this.setGCLoadThreshold.Location = new System.Drawing.Point(9, 62);
            this.setGCLoadThreshold.Mask = "00000";
            this.setGCLoadThreshold.Name = "setGCLoadThreshold";
            this.setGCLoadThreshold.Size = new System.Drawing.Size(713, 20);
            this.setGCLoadThreshold.TabIndex = 26;
            this.setGCLoadThreshold.ValidatingType = typeof(int);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Load Threshold:";
            // 
            // setGCPeriodInTicks
            // 
            this.setGCPeriodInTicks.AsciiOnly = true;
            this.setGCPeriodInTicks.Location = new System.Drawing.Point(9, 21);
            this.setGCPeriodInTicks.Mask = "00000";
            this.setGCPeriodInTicks.Name = "setGCPeriodInTicks";
            this.setGCPeriodInTicks.Size = new System.Drawing.Size(713, 20);
            this.setGCPeriodInTicks.TabIndex = 24;
            this.setGCPeriodInTicks.ValidatingType = typeof(int);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Period in Ticks:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.setTicksPerAutoSave);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.setTicksPerMonsterSpawn);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.setTicksPerAnimalSpawn);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(746, 299);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ticks Per (...)";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // setTicksPerAutoSave
            // 
            this.setTicksPerAutoSave.AsciiOnly = true;
            this.setTicksPerAutoSave.Location = new System.Drawing.Point(9, 102);
            this.setTicksPerAutoSave.Mask = "00000";
            this.setTicksPerAutoSave.Name = "setTicksPerAutoSave";
            this.setTicksPerAutoSave.Size = new System.Drawing.Size(713, 20);
            this.setTicksPerAutoSave.TabIndex = 28;
            this.setTicksPerAutoSave.ValidatingType = typeof(int);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Ticks per Auto Save:";
            // 
            // setTicksPerMonsterSpawn
            // 
            this.setTicksPerMonsterSpawn.AsciiOnly = true;
            this.setTicksPerMonsterSpawn.Location = new System.Drawing.Point(9, 62);
            this.setTicksPerMonsterSpawn.Mask = "00000";
            this.setTicksPerMonsterSpawn.Name = "setTicksPerMonsterSpawn";
            this.setTicksPerMonsterSpawn.Size = new System.Drawing.Size(713, 20);
            this.setTicksPerMonsterSpawn.TabIndex = 26;
            this.setTicksPerMonsterSpawn.ValidatingType = typeof(int);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Ticks per Monster Spawn:";
            // 
            // setTicksPerAnimalSpawn
            // 
            this.setTicksPerAnimalSpawn.AsciiOnly = true;
            this.setTicksPerAnimalSpawn.Location = new System.Drawing.Point(9, 21);
            this.setTicksPerAnimalSpawn.Mask = "00000";
            this.setTicksPerAnimalSpawn.Name = "setTicksPerAnimalSpawn";
            this.setTicksPerAnimalSpawn.Size = new System.Drawing.Size(713, 20);
            this.setTicksPerAnimalSpawn.TabIndex = 24;
            this.setTicksPerAnimalSpawn.ValidatingType = typeof(int);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Ticks per Animal Spawn:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.setUpdaterSuggestChannels);
            this.tabPage5.Controls.Add(this.setUpdaterHost);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.setUpdaterPreferredChannel);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.groupBox8);
            this.tabPage5.Controls.Add(this.groupBox7);
            this.tabPage5.Controls.Add(this.setAutoUpdaterEnabled);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(746, 299);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Auto Updater";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // setUpdaterSuggestChannels
            // 
            this.setUpdaterSuggestChannels.AutoSize = true;
            this.setUpdaterSuggestChannels.Location = new System.Drawing.Point(7, 33);
            this.setUpdaterSuggestChannels.Name = "setUpdaterSuggestChannels";
            this.setUpdaterSuggestChannels.Size = new System.Drawing.Size(112, 17);
            this.setUpdaterSuggestChannels.TabIndex = 7;
            this.setUpdaterSuggestChannels.Text = "Suggest Channels";
            this.setUpdaterSuggestChannels.UseVisualStyleBackColor = true;
            // 
            // setUpdaterHost
            // 
            this.setUpdaterHost.Location = new System.Drawing.Point(321, 36);
            this.setUpdaterHost.Name = "setUpdaterHost";
            this.setUpdaterHost.Size = new System.Drawing.Size(401, 20);
            this.setUpdaterHost.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(283, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Host:";
            // 
            // setUpdaterPreferredChannel
            // 
            this.setUpdaterPreferredChannel.Location = new System.Drawing.Point(321, 10);
            this.setUpdaterPreferredChannel.Name = "setUpdaterPreferredChannel";
            this.setUpdaterPreferredChannel.Size = new System.Drawing.Size(401, 20);
            this.setUpdaterPreferredChannel.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Preferred Channel:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.setsOnUpdate);
            this.groupBox8.Location = new System.Drawing.Point(7, 166);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 100);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "On Update:";
            // 
            // setsOnUpdate
            // 
            this.setsOnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setsOnUpdate.FormattingEnabled = true;
            this.setsOnUpdate.Items.AddRange(new object[] {
            "Warn Console",
            "Warn OPs"});
            this.setsOnUpdate.Location = new System.Drawing.Point(3, 16);
            this.setsOnUpdate.Name = "setsOnUpdate";
            this.setsOnUpdate.Size = new System.Drawing.Size(194, 81);
            this.setsOnUpdate.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.setsOnUpdaterBroken);
            this.groupBox7.Location = new System.Drawing.Point(4, 60);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 100);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "On Broken:";
            // 
            // setsOnUpdaterBroken
            // 
            this.setsOnUpdaterBroken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setsOnUpdaterBroken.FormattingEnabled = true;
            this.setsOnUpdaterBroken.Items.AddRange(new object[] {
            "Warn Console",
            "Warn OPs"});
            this.setsOnUpdaterBroken.Location = new System.Drawing.Point(3, 16);
            this.setsOnUpdaterBroken.Name = "setsOnUpdaterBroken";
            this.setsOnUpdaterBroken.Size = new System.Drawing.Size(194, 81);
            this.setsOnUpdaterBroken.TabIndex = 0;
            // 
            // setAutoUpdaterEnabled
            // 
            this.setAutoUpdaterEnabled.AutoSize = true;
            this.setAutoUpdaterEnabled.Location = new System.Drawing.Point(7, 10);
            this.setAutoUpdaterEnabled.Name = "setAutoUpdaterEnabled";
            this.setAutoUpdaterEnabled.Size = new System.Drawing.Size(131, 17);
            this.setAutoUpdaterEnabled.TabIndex = 0;
            this.setAutoUpdaterEnabled.Text = "Auto Updater Enabled";
            this.setAutoUpdaterEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.setDatabaseURL);
            this.tabPage6.Controls.Add(this.label23);
            this.tabPage6.Controls.Add(this.setDatabasePassword);
            this.tabPage6.Controls.Add(this.setDatabaseDriver);
            this.tabPage6.Controls.Add(this.setDatabaseIsolation);
            this.tabPage6.Controls.Add(this.setDatabaseUsername);
            this.tabPage6.Controls.Add(this.label19);
            this.tabPage6.Controls.Add(this.label20);
            this.tabPage6.Controls.Add(this.label21);
            this.tabPage6.Controls.Add(this.label22);
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(746, 299);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Database (Advanced)";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // setDatabaseURL
            // 
            this.setDatabaseURL.Location = new System.Drawing.Point(10, 187);
            this.setDatabaseURL.Name = "setDatabaseURL";
            this.setDatabaseURL.Size = new System.Drawing.Size(715, 20);
            this.setDatabaseURL.TabIndex = 39;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 171);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "URL:";
            // 
            // setDatabasePassword
            // 
            this.setDatabasePassword.Location = new System.Drawing.Point(7, 146);
            this.setDatabasePassword.Name = "setDatabasePassword";
            this.setDatabasePassword.Size = new System.Drawing.Size(715, 20);
            this.setDatabasePassword.TabIndex = 37;
            // 
            // setDatabaseDriver
            // 
            this.setDatabaseDriver.Location = new System.Drawing.Point(7, 105);
            this.setDatabaseDriver.Name = "setDatabaseDriver";
            this.setDatabaseDriver.Size = new System.Drawing.Size(715, 20);
            this.setDatabaseDriver.TabIndex = 36;
            // 
            // setDatabaseIsolation
            // 
            this.setDatabaseIsolation.Location = new System.Drawing.Point(7, 64);
            this.setDatabaseIsolation.Name = "setDatabaseIsolation";
            this.setDatabaseIsolation.Size = new System.Drawing.Size(715, 20);
            this.setDatabaseIsolation.TabIndex = 35;
            // 
            // setDatabaseUsername
            // 
            this.setDatabaseUsername.Location = new System.Drawing.Point(7, 24);
            this.setDatabaseUsername.Name = "setDatabaseUsername";
            this.setDatabaseUsername.Size = new System.Drawing.Size(715, 20);
            this.setDatabaseUsername.TabIndex = 34;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 130);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "Password:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 89);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Driver:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Isolation:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "Username:";
            // 
            // tabServerProperties
            // 
            this.tabServerProperties.Controls.Add(this.propertyGrid1);
            this.tabServerProperties.Location = new System.Drawing.Point(4, 22);
            this.tabServerProperties.Name = "tabServerProperties";
            this.tabServerProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabServerProperties.Size = new System.Drawing.Size(760, 331);
            this.tabServerProperties.TabIndex = 1;
            this.tabServerProperties.Text = "Server Properties";
            this.tabServerProperties.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(768, 328);
            this.propertyGrid1.TabIndex = 35;
            // 
            // tabPlayers
            // 
            this.tabPlayers.Controls.Add(this.serverPlayerList);
            this.tabPlayers.Location = new System.Drawing.Point(4, 22);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayers.Size = new System.Drawing.Size(760, 331);
            this.tabPlayers.TabIndex = 2;
            this.tabPlayers.Text = "Players";
            this.tabPlayers.UseVisualStyleBackColor = true;
            // 
            // serverPlayerList
            // 
            this.serverPlayerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.serverPlayerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverPlayerList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.serverPlayerList.Location = new System.Drawing.Point(3, 3);
            this.serverPlayerList.MultiSelect = false;
            this.serverPlayerList.Name = "serverPlayerList";
            this.serverPlayerList.Size = new System.Drawing.Size(768, 328);
            this.serverPlayerList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.serverPlayerList.TabIndex = 0;
            this.serverPlayerList.UseCompatibleStateImageBehavior = false;
            this.serverPlayerList.View = System.Windows.Forms.View.SmallIcon;
            // 
            // tabOps
            // 
            this.tabOps.Controls.Add(this.serverOPList);
            this.tabOps.Location = new System.Drawing.Point(4, 22);
            this.tabOps.Name = "tabOps";
            this.tabOps.Padding = new System.Windows.Forms.Padding(3);
            this.tabOps.Size = new System.Drawing.Size(760, 331);
            this.tabOps.TabIndex = 3;
            this.tabOps.Text = "OPs";
            this.tabOps.UseVisualStyleBackColor = true;
            // 
            // serverOPList
            // 
            this.serverOPList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.serverOPList.ContextMenuStrip = this.opContextMenu;
            this.serverOPList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverOPList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.serverOPList.Location = new System.Drawing.Point(3, 3);
            this.serverOPList.Name = "serverOPList";
            this.serverOPList.Size = new System.Drawing.Size(768, 328);
            this.serverOPList.TabIndex = 0;
            this.serverOPList.UseCompatibleStateImageBehavior = false;
            this.serverOPList.View = System.Windows.Forms.View.SmallIcon;
            // 
            // opContextMenu
            // 
            this.opContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewOPToolStripMenuItem,
            this.removeOPToolStripMenuItem,
            this.clearOPsToolStripMenuItem});
            this.opContextMenu.Name = "opContextMenu";
            this.opContextMenu.Size = new System.Drawing.Size(141, 70);
            this.opContextMenu.Text = "Operators";
            // 
            // addNewOPToolStripMenuItem
            // 
            this.addNewOPToolStripMenuItem.Name = "addNewOPToolStripMenuItem";
            this.addNewOPToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addNewOPToolStripMenuItem.Text = "Add new OP";
            this.addNewOPToolStripMenuItem.Click += new System.EventHandler(this.addNewOPToolStripMenuItem_Click);
            // 
            // removeOPToolStripMenuItem
            // 
            this.removeOPToolStripMenuItem.Name = "removeOPToolStripMenuItem";
            this.removeOPToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.removeOPToolStripMenuItem.Text = "Remove OP";
            this.removeOPToolStripMenuItem.Click += new System.EventHandler(this.removeOPToolStripMenuItem_Click);
            // 
            // clearOPsToolStripMenuItem
            // 
            this.clearOPsToolStripMenuItem.Name = "clearOPsToolStripMenuItem";
            this.clearOPsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.clearOPsToolStripMenuItem.Text = "Clear OPs";
            this.clearOPsToolStripMenuItem.Click += new System.EventHandler(this.clearOPsToolStripMenuItem_Click);
            // 
            // tabWhitelist
            // 
            this.tabWhitelist.Controls.Add(this.serverWhiteList);
            this.tabWhitelist.Location = new System.Drawing.Point(4, 22);
            this.tabWhitelist.Name = "tabWhitelist";
            this.tabWhitelist.Padding = new System.Windows.Forms.Padding(3);
            this.tabWhitelist.Size = new System.Drawing.Size(760, 331);
            this.tabWhitelist.TabIndex = 4;
            this.tabWhitelist.Text = "Whitelist";
            this.tabWhitelist.UseVisualStyleBackColor = true;
            // 
            // serverWhiteList
            // 
            this.serverWhiteList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.serverWhiteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverWhiteList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.serverWhiteList.Location = new System.Drawing.Point(3, 3);
            this.serverWhiteList.Name = "serverWhiteList";
            this.serverWhiteList.Size = new System.Drawing.Size(768, 328);
            this.serverWhiteList.TabIndex = 0;
            this.serverWhiteList.UseCompatibleStateImageBehavior = false;
            // 
            // tabBannedPlayers
            // 
            this.tabBannedPlayers.Controls.Add(this.bannedPlayersTable);
            this.tabBannedPlayers.Controls.Add(this.serverBannedPlayersList);
            this.tabBannedPlayers.Location = new System.Drawing.Point(4, 22);
            this.tabBannedPlayers.Name = "tabBannedPlayers";
            this.tabBannedPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabBannedPlayers.Size = new System.Drawing.Size(760, 331);
            this.tabBannedPlayers.TabIndex = 5;
            this.tabBannedPlayers.Text = "Banned Players";
            this.tabBannedPlayers.UseVisualStyleBackColor = true;
            // 
            // bannedPlayersTable
            // 
            this.bannedPlayersTable.AllowUserToAddRows = false;
            this.bannedPlayersTable.AllowUserToDeleteRows = false;
            this.bannedPlayersTable.AllowUserToOrderColumns = true;
            this.bannedPlayersTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bannedPlayersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bannedPlayersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.victimNane,
            this.banDate,
            this.bannedBy,
            this.bannedUntil,
            this.reason});
            this.bannedPlayersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bannedPlayersTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.bannedPlayersTable.Location = new System.Drawing.Point(3, 3);
            this.bannedPlayersTable.MultiSelect = false;
            this.bannedPlayersTable.Name = "bannedPlayersTable";
            this.bannedPlayersTable.ReadOnly = true;
            this.bannedPlayersTable.Size = new System.Drawing.Size(768, 328);
            this.bannedPlayersTable.TabIndex = 1;
            // 
            // victimNane
            // 
            this.victimNane.HeaderText = "Victim Name";
            this.victimNane.Name = "victimNane";
            this.victimNane.ReadOnly = true;
            // 
            // banDate
            // 
            this.banDate.HeaderText = "Ban Date";
            this.banDate.Name = "banDate";
            this.banDate.ReadOnly = true;
            // 
            // bannedBy
            // 
            this.bannedBy.HeaderText = "Banned By";
            this.bannedBy.Name = "bannedBy";
            this.bannedBy.ReadOnly = true;
            // 
            // bannedUntil
            // 
            this.bannedUntil.HeaderText = "Banned Until";
            this.bannedUntil.Name = "bannedUntil";
            this.bannedUntil.ReadOnly = true;
            // 
            // reason
            // 
            this.reason.HeaderText = "Reason";
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            // 
            // serverBannedPlayersList
            // 
            this.serverBannedPlayersList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.serverBannedPlayersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverBannedPlayersList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.serverBannedPlayersList.Location = new System.Drawing.Point(3, 3);
            this.serverBannedPlayersList.Name = "serverBannedPlayersList";
            this.serverBannedPlayersList.Size = new System.Drawing.Size(768, 328);
            this.serverBannedPlayersList.TabIndex = 0;
            this.serverBannedPlayersList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPreferences
            // 
            this.tabPreferences.Controls.Add(this.openUpdater);
            this.tabPreferences.Controls.Add(this.button8);
            this.tabPreferences.Controls.Add(this.savePrefs);
            this.tabPreferences.Controls.Add(this.groupBox6);
            this.tabPreferences.Controls.Add(this.groupBox5);
            this.tabPreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPreferences.Name = "tabPreferences";
            this.tabPreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreferences.Size = new System.Drawing.Size(774, 363);
            this.tabPreferences.TabIndex = 3;
            this.tabPreferences.Text = "Preferences";
            this.tabPreferences.UseVisualStyleBackColor = true;
            // 
            // openUpdater
            // 
            this.openUpdater.AutoSize = true;
            this.openUpdater.Location = new System.Drawing.Point(645, 255);
            this.openUpdater.Name = "openUpdater";
            this.openUpdater.Size = new System.Drawing.Size(104, 23);
            this.openUpdater.TabIndex = 4;
            this.openUpdater.Text = "Open Updater";
            this.openUpdater.UseVisualStyleBackColor = true;
            this.openUpdater.Click += new System.EventHandler(this.openUpdater_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(645, 285);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(104, 23);
            this.button8.TabIndex = 3;
            this.button8.Text = "About";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // savePrefs
            // 
            this.savePrefs.Location = new System.Drawing.Point(645, 314);
            this.savePrefs.Name = "savePrefs";
            this.savePrefs.Size = new System.Drawing.Size(104, 23);
            this.savePrefs.TabIndex = 2;
            this.savePrefs.Text = "Save Preferences";
            this.savePrefs.UseVisualStyleBackColor = true;
            this.savePrefs.Click += new System.EventHandler(this.savePrefs_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.useColourStars);
            this.groupBox6.Controls.Add(this.selectJavaInstallation);
            this.groupBox6.Controls.Add(this.javaInstallPath);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.extendDWMIntoClient);
            this.groupBox6.Location = new System.Drawing.Point(212, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 332);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "BukkitUI";
            // 
            // useColourStars
            // 
            this.useColourStars.AutoSize = true;
            this.useColourStars.Checked = true;
            this.useColourStars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useColourStars.Location = new System.Drawing.Point(12, 99);
            this.useColourStars.Name = "useColourStars";
            this.useColourStars.Size = new System.Drawing.Size(174, 30);
            this.useColourStars.TabIndex = 8;
            this.useColourStars.Text = "Use Coloured Stars for dynamic\r\nuser listing";
            this.useColourStars.UseVisualStyleBackColor = true;
            this.useColourStars.CheckedChanged += new System.EventHandler(this.useColourStars_CheckedChanged);
            // 
            // selectJavaInstallation
            // 
            this.selectJavaInstallation.Location = new System.Drawing.Point(170, 63);
            this.selectJavaInstallation.Name = "selectJavaInstallation";
            this.selectJavaInstallation.Size = new System.Drawing.Size(26, 23);
            this.selectJavaInstallation.TabIndex = 7;
            this.selectJavaInstallation.Text = "...";
            this.selectJavaInstallation.UseVisualStyleBackColor = true;
            this.selectJavaInstallation.Click += new System.EventHandler(this.selectJavaInstallation_Click);
            // 
            // javaInstallPath
            // 
            this.javaInstallPath.Location = new System.Drawing.Point(12, 64);
            this.javaInstallPath.Name = "javaInstallPath";
            this.javaInstallPath.Size = new System.Drawing.Size(152, 20);
            this.javaInstallPath.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 13);
            this.label24.TabIndex = 3;
            this.label24.Text = "Java Installation:";
            // 
            // extendDWMIntoClient
            // 
            this.extendDWMIntoClient.AutoSize = true;
            this.extendDWMIntoClient.Checked = true;
            this.extendDWMIntoClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.extendDWMIntoClient.Location = new System.Drawing.Point(9, 19);
            this.extendDWMIntoClient.Name = "extendDWMIntoClient";
            this.extendDWMIntoClient.Size = new System.Drawing.Size(106, 17);
            this.extendDWMIntoClient.TabIndex = 2;
            this.extendDWMIntoClient.Text = "Use Aero Design";
            this.extendDWMIntoClient.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.maxHeapSize);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.initHeapSize);
            this.groupBox5.Controls.Add(this.enableCustomHeapSize);
            this.groupBox5.Controls.Add(this.bukkitDir);
            this.groupBox5.Controls.Add(this.selectBukkitJar);
            this.groupBox5.Controls.Add(this.bukkitLocation);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.serverRebootInterval);
            this.groupBox5.Controls.Add(this.autoRebootServer);
            this.groupBox5.Controls.Add(this.bootOnStartup);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 332);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Server";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(10, 279);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(134, 13);
            this.label29.TabIndex = 16;
            this.label29.Text = "Select an Allocation Mode:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Resource Saving",
            "Reduced Resources",
            "Normal Resources",
            "Automatic (Default)",
            "Full Power",
            "Server Mode"});
            this.comboBox1.Location = new System.Drawing.Point(10, 295);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Text = "Default";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(38, 236);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(82, 13);
            this.label27.TabIndex = 14;
            this.label27.Text = "Max Heap Size:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(155, 258);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(25, 13);
            this.label28.TabIndex = 13;
            this.label28.Text = "MiB";
            // 
            // maxHeapSize
            // 
            this.maxHeapSize.Enabled = false;
            this.maxHeapSize.Location = new System.Drawing.Point(38, 252);
            this.maxHeapSize.Mask = "00000";
            this.maxHeapSize.Name = "maxHeapSize";
            this.maxHeapSize.Size = new System.Drawing.Size(111, 20);
            this.maxHeapSize.TabIndex = 12;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(38, 194);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 13);
            this.label26.TabIndex = 11;
            this.label26.Text = "Init Heap Size:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(155, 216);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(25, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "MiB";
            // 
            // initHeapSize
            // 
            this.initHeapSize.Enabled = false;
            this.initHeapSize.Location = new System.Drawing.Point(38, 210);
            this.initHeapSize.Mask = "00000";
            this.initHeapSize.Name = "initHeapSize";
            this.initHeapSize.Size = new System.Drawing.Size(111, 20);
            this.initHeapSize.TabIndex = 9;
            this.initHeapSize.ValidatingType = typeof(int);
            // 
            // enableCustomHeapSize
            // 
            this.enableCustomHeapSize.AutoSize = true;
            this.enableCustomHeapSize.Location = new System.Drawing.Point(10, 170);
            this.enableCustomHeapSize.Name = "enableCustomHeapSize";
            this.enableCustomHeapSize.Size = new System.Drawing.Size(175, 17);
            this.enableCustomHeapSize.TabIndex = 8;
            this.enableCustomHeapSize.Text = "Use Custom Memory Heap Size";
            this.enableCustomHeapSize.UseVisualStyleBackColor = true;
            this.enableCustomHeapSize.CheckedChanged += new System.EventHandler(this.enableCustomHeapSize_CheckedChanged);
            // 
            // bukkitDir
            // 
            this.bukkitDir.Enabled = false;
            this.bukkitDir.Location = new System.Drawing.Point(7, 143);
            this.bukkitDir.Name = "bukkitDir";
            this.bukkitDir.Size = new System.Drawing.Size(187, 20);
            this.bukkitDir.TabIndex = 7;
            // 
            // selectBukkitJar
            // 
            this.selectBukkitJar.Location = new System.Drawing.Point(168, 114);
            this.selectBukkitJar.Name = "selectBukkitJar";
            this.selectBukkitJar.Size = new System.Drawing.Size(26, 23);
            this.selectBukkitJar.TabIndex = 6;
            this.selectBukkitJar.Text = "...";
            this.selectBukkitJar.UseVisualStyleBackColor = true;
            this.selectBukkitJar.Click += new System.EventHandler(this.selectBukkitJar_Click);
            // 
            // bukkitLocation
            // 
            this.bukkitLocation.Location = new System.Drawing.Point(7, 116);
            this.bukkitLocation.Name = "bukkitLocation";
            this.bukkitLocation.ReadOnly = true;
            this.bukkitLocation.Size = new System.Drawing.Size(155, 20);
            this.bukkitLocation.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bukkit Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "min";
            // 
            // serverRebootInterval
            // 
            this.serverRebootInterval.AsciiOnly = true;
            this.serverRebootInterval.BeepOnError = true;
            this.serverRebootInterval.Enabled = false;
            this.serverRebootInterval.Location = new System.Drawing.Point(38, 67);
            this.serverRebootInterval.Mask = "000";
            this.serverRebootInterval.Name = "serverRebootInterval";
            this.serverRebootInterval.Size = new System.Drawing.Size(111, 20);
            this.serverRebootInterval.TabIndex = 2;
            this.serverRebootInterval.Text = "060";
            // 
            // autoRebootServer
            // 
            this.autoRebootServer.AutoSize = true;
            this.autoRebootServer.Location = new System.Drawing.Point(7, 43);
            this.autoRebootServer.Name = "autoRebootServer";
            this.autoRebootServer.Size = new System.Drawing.Size(160, 17);
            this.autoRebootServer.TabIndex = 1;
            this.autoRebootServer.Text = "Automatically Reboot Server";
            this.autoRebootServer.UseVisualStyleBackColor = true;
            this.autoRebootServer.CheckedChanged += new System.EventHandler(this.autoRebootServer_CheckedChanged);
            // 
            // bootOnStartup
            // 
            this.bootOnStartup.AutoSize = true;
            this.bootOnStartup.Location = new System.Drawing.Point(7, 20);
            this.bootOnStartup.Name = "bootOnStartup";
            this.bootOnStartup.Size = new System.Drawing.Size(134, 17);
            this.bootOnStartup.TabIndex = 0;
            this.bootOnStartup.Text = "Boot Server on Startup";
            this.bootOnStartup.UseVisualStyleBackColor = true;
            // 
            // statusIcon
            // 
            this.statusIcon.Image = global::BukkitUI.Properties.Resources._1391649980_Circle_Red;
            this.statusIcon.Location = new System.Drawing.Point(2, 426);
            this.statusIcon.Name = "statusIcon";
            this.statusIcon.Size = new System.Drawing.Size(32, 32);
            this.statusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statusIcon.TabIndex = 1;
            this.statusIcon.TabStop = false;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(37, 436);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(51, 17);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Tag = "XC";
            this.statusLabel.Text = "OFFLlNE";
            this.statusLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.statusLabel.UseCompatibleTextRendering = true;
            // 
            // memBar
            // 
            this.memBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.memBar.customText = "Server not Running";
            this.memBar.displayStyle = BukkitUI.TextProgressBar.ProgressBarDisplayText.CustomText;
            this.memBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.memBar.Location = new System.Drawing.Point(6, 77);
            this.memBar.Name = "memBar";
            this.memBar.Size = new System.Drawing.Size(498, 23);
            this.memBar.TabIndex = 1;
            // 
            // cpuBar
            // 
            this.cpuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cpuBar.customText = "Server not Running";
            this.cpuBar.displayStyle = BukkitUI.TextProgressBar.ProgressBarDisplayText.CustomText;
            this.cpuBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cpuBar.Location = new System.Drawing.Point(7, 19);
            this.cpuBar.Name = "cpuBar";
            this.cpuBar.Size = new System.Drawing.Size(497, 23);
            this.cpuBar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 469);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusIcon);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.background.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabBukkit.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabConsole.PerformLayout();
            this.tabServer.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabServerSettings.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabServerProperties.ResumeLayout(false);
            this.tabPlayers.ResumeLayout(false);
            this.tabOps.ResumeLayout(false);
            this.opContextMenu.ResumeLayout(false);
            this.tabWhitelist.ResumeLayout(false);
            this.tabBannedPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bannedPlayersTable)).EndInit();
            this.tabPreferences.ResumeLayout(false);
            this.tabPreferences.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void useColourStars_onCheckedChanged(object sender, System.EventArgs e) {
            throw new System.NotImplementedException();
        }

        private void openUpdater_onClick(object sender, System.EventArgs e) {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage background;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabBukkit;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button updateServerbtn;
        private System.Windows.Forms.Button deleteServerButton;
        private System.Windows.Forms.Button worldMgmtButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button restartServerButton;
        private System.Windows.Forms.Button stopServerButton;
        private System.Windows.Forms.Button startServerButton;
        private TextProgressBar cpuBar;
        private TextProgressBar memBar;
        private System.Windows.Forms.PictureBox statusIcon;
        private AntiLabel statusLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView playerListView;
        private System.Windows.Forms.Button executeCmdButton;
        private System.Windows.Forms.TextBox consoleInput;
        private System.Windows.Forms.RichTextBox consoleOutput;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabServerSettings;
        private System.Windows.Forms.TabPage tabServerProperties;
        private System.Windows.Forms.TabPage tabPlayers;
        private System.Windows.Forms.TabPage tabOps;
        private System.Windows.Forms.TabPage tabWhitelist;
        private System.Windows.Forms.TabPage tabBannedPlayers;
        private System.Windows.Forms.TabPage tabPreferences;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox serverRebootInterval;
        private System.Windows.Forms.CheckBox autoRebootServer;
        private System.Windows.Forms.CheckBox bootOnStartup;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox extendDWMIntoClient;
        private System.Windows.Forms.Button savePrefs;
        private System.Windows.Forms.Button selectBukkitJar;
        private System.Windows.Forms.TextBox bukkitLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox bukkitDir;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox setPluginProfiling;
        private System.Windows.Forms.CheckBox setAllowEnd;
        private System.Windows.Forms.CheckBox setWarnOnOverload;
        private System.Windows.Forms.CheckBox setQueryPlugins;
        private System.Windows.Forms.CheckBox setUseExactLoginLocation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox setShutdownMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox setDeprecatedVerbose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox setConnectionThrottle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox setPingPacketLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox setUpdateFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox setAmbientLimit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox setWaterAnimalLimit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox setAnimalLimit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox setMonsterLimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MaskedTextBox setGCLoadThreshold;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox setGCPeriodInTicks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MaskedTextBox setTicksPerAutoSave;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox setTicksPerMonsterSpawn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox setTicksPerAnimalSpawn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox setUpdaterPreferredChannel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckedListBox setsOnUpdate;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckedListBox setsOnUpdaterBroken;
        private System.Windows.Forms.CheckBox setAutoUpdaterEnabled;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox setUpdaterSuggestChannels;
        private System.Windows.Forms.TextBox setUpdaterHost;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox setDatabaseURL;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox setDatabasePassword;
        private System.Windows.Forms.TextBox setDatabaseDriver;
        private System.Windows.Forms.TextBox setDatabaseIsolation;
        private System.Windows.Forms.TextBox setDatabaseUsername;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox javaInstallPath;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button selectJavaInstallation;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ListView serverPlayerList;
        private System.Windows.Forms.ListView serverOPList;
        private System.Windows.Forms.ListView serverWhiteList;
        private System.Windows.Forms.ListView serverBannedPlayersList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip opContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addNewOPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeOPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearOPsToolStripMenuItem;
        private System.Windows.Forms.DataGridView bannedPlayersTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn victimNane;
        private System.Windows.Forms.DataGridViewTextBoxColumn banDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn bannedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn bannedUntil;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.MaskedTextBox maxHeapSize;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.MaskedTextBox initHeapSize;
        private System.Windows.Forms.CheckBox enableCustomHeapSize;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button openUpdater;
        private CheckBox useColourStars;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
    }
}


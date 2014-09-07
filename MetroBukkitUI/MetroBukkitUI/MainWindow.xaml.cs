using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text.RegularExpressions;

using MetroBukkitUI.Properties;
using MetroBukkitUI.Craftbukkit;

using Microsoft.Win32;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;

namespace MetroBukkitUI {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {

        internal CraftbukkitServer cbServer = null;

        public MainWindow() {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            InitializeComponent();
            initComponents();
        }

        #region // Designing methods

        private void initComponents() {
            #region // Settings
            #region // BukkitUI
            WindowTitleBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.windowColour));
            TitleCaps = Settings.Default.titleAllCaps;
            titleAllCapsSwitch.IsChecked = TitleCaps;
            autoStartServerToggleButton.IsChecked = Settings.Default.autoStartServer;
            ignorePerformanceWarningsToggleButton.IsChecked = Settings.Default.ignorePerformanceWarnings;
            enableDynamicLoadingToggleButton.IsChecked = Settings.Default.enableDynamicLoading;
            enableWebServerOutputViaDebugStream.IsChecked = Settings.Default.enableWebServerOutput;
            javaBinaryLocationTextBox.Text = Settings.Default.javaBinaryPath;
            customJVMArgsTextBox.Text = Settings.Default.customJVMArgs;
            javaInitHeapTextBox.Text = Settings.Default.javaInitHeap;
            javaMaxHeapTextBox.Text = Settings.Default.javaMaxHeap;
            #endregion
            #region // Craftbukkit
            serverFileTextBox.Text = Settings.Default.bukkit_executable;
            serverDirLocationTextBox.Text = Settings.Default.bukkit_path;
            #endregion
            #endregion
            colourAllControls();
            addTitleBarIcons();
            addTabIcons();
            addServerControlIcons();
            addBackColourLambdas();
            #region // Lambdas
            titleAllCapsSwitch.Click += (s, evt) => {
                TitleCaps = (bool)titleAllCapsSwitch.IsChecked;
                Settings.Default.titleAllCaps = TitleCaps;
            };
            savePrefs.Click += (s, evt) => Settings.Default.Save();
            webserver_PowerSwitch.Click += (s, evt) => {
                if ((bool)webserver_PowerSwitch.IsChecked)
                    webserver_userSettingsContainer.IsEnabled = true;
                else webserver_userSettingsContainer.IsEnabled = false;
            };
            donateViaPayPalButton.Click += (s, evt) => Process.Start("http://bit.ly/donate_bukkitUI");
            #region selectServerJarButton.Cli...
            selectServerJarButton.Click += (s, evt) => {
                FileDialog fDialog = new OpenFileDialog();
                fDialog.Filter = "Executable Jar Files (*.jar)|*.jar";
                fDialog.Title = "Select your Craftbukkit Server...";
                if ((bool)fDialog.ShowDialog()) {
                    serverFileTextBox.Text = fDialog.FileName;
                    serverDirLocationTextBox.Text = System.IO.Path.GetDirectoryName(fDialog.FileName);
                    Settings.Default.bukkit_executable = fDialog.FileName;
                    Settings.Default.bukkit_path = System.IO.Path.GetDirectoryName(fDialog.FileName);
                }
            };
            #endregion
            #region addBukkitArgButton.Cli...
            addBukkitArgButton.Click += async (s, evt) => {
                MetroDialogSettings settings = new MetroDialogSettings();
                settings.AffirmativeButtonText = "Add Arg";
                settings.AnimateHide = true;
                settings.AnimateShow = true;
                settings.ColorScheme = MetroDialogColorScheme.Accented;
                settings.DefaultText = "";
                settings.NegativeButtonText = "Cancel";
                string arg = await this.ShowInputAsync("Add Craftbukkit Arg...",
                    "Please enter the Craftbukkit argument you'd like to add.\nOnly proceed if you know what you're doing!", settings);
                if (arg != null && !String.IsNullOrWhiteSpace(arg) && !String.IsNullOrEmpty(arg))
                    craftbukkitArgsTextBox.AppendText(arg);
                else return;

                if (!arg.EndsWith(";") && !String.IsNullOrWhiteSpace(arg) && !String.IsNullOrEmpty(arg))
                    craftbukkitArgsTextBox.AppendText(";");

                Settings.Default.bukkit_args = craftbukkitArgsTextBox.Text;
            };
            #endregion
            #region clearBukkitArgsButton.Cli...
            clearBukkitArgsButton.Click += async (s, evt) => {
                MetroDialogSettings settings = new MetroDialogSettings();
                settings.AffirmativeButtonText = "I Understand";
                settings.AnimateHide = true;
                settings.AnimateShow = true;
                settings.ColorScheme = MetroDialogColorScheme.Accented;
                settings.NegativeButtonText = "Cancel";

                MessageDialogResult accepted = await this.ShowMessageAsync("Clear Craftbukkit Args?",
                      "Clearing the Craftbukkit arguments will reset these to the defaults, and depending on the plugins/mods you have installed\n"
                    + "may seriously impair the stability of the server if these arguments are changed after having them on for a prolonged period of time.\n"
                    + "If you proceed, you must accept that if something goes wrong, it is you who is at fault, not BukkitUI and/or its creator.\n"
                    + "You are soley responsible for the use of this feature.",
                    MessageDialogStyle.AffirmativeAndNegative, settings);

                if (accepted == MessageDialogResult.Affirmative)
                    craftbukkitArgsTextBox.Text = "--nojline;";

                Settings.Default.bukkit_args = craftbukkitArgsTextBox.Text;
            };
            #endregion
            saveCraftbukkitPrefsButton.Click += (s, evt) => Settings.Default.Save();
            Settings.Default.SettingsSaving += async (s, evt) => await this.ShowMessageAsync("Preferences Saved", "Your Preferences were saved successfully!");
            #region selectJavaLocation.Cli...
            selectJavaLocation.Click += (s, evt) => {
                FileDialog fDialog = new OpenFileDialog();
                fDialog.Filter = "Java Executable Binary (java.exe)|java.exe";
                fDialog.Title = "Select the Java Binary...";
                if ((bool)fDialog.ShowDialog()) {
                    javaBinaryLocationTextBox.Text = fDialog.FileName;
                    Settings.Default.javaBinaryPath = fDialog.FileName;
                }
            };
            #endregion
            #region addJavaArgButton.Cli...
            addJavaArgButton.Click += async (s, evt) => {
                MetroDialogSettings settings = new MetroDialogSettings();
                settings.AffirmativeButtonText = "Add Arg";
                settings.AnimateHide = true;
                settings.AnimateShow = true;
                settings.ColorScheme = MetroDialogColorScheme.Accented;
                settings.DefaultText = "";
                settings.NegativeButtonText = "Cancel";
                string arg = await this.ShowInputAsync("Add Java VM Arg...",
                    "Please enter the Java VM argument you'd like to add.\nOnly proceed if you know what you're doing!", settings);
                if (arg != null && !String.IsNullOrWhiteSpace(arg) && !String.IsNullOrEmpty(arg))
                    customJVMArgsTextBox.AppendText(arg);
                else return;

                if (!arg.EndsWith(";") && !String.IsNullOrWhiteSpace(arg) && !String.IsNullOrEmpty(arg))
                    customJVMArgsTextBox.AppendText(";");

                Settings.Default.customJVMArgs = customJVMArgsTextBox.Text;
            };
            #endregion
            #region clearJavaArgsButton.Cli...
            clearJavaArgsButton.Click += async (s, evt) => {
                MetroDialogSettings settings = new MetroDialogSettings();
                settings.AffirmativeButtonText = "I Understand";
                settings.AnimateHide = true;
                settings.AnimateShow = true;
                settings.ColorScheme = MetroDialogColorScheme.Accented;
                settings.NegativeButtonText = "Cancel";

                MessageDialogResult accepted = await this.ShowMessageAsync("Clear Java VM Args?",
                      "Clearing the Java VM arguments will reset these to the defaults, and may seriously impair the stability of the server if\n"
                    + "these arguments are changed after having them on for a prolonged period of time.\n"
                    + "If you proceed, you must accept that if something goes wrong, it is you who is at fault, not BukkitUI and/or its creator.\n"
                    + "You are soley responsible for the use of this feature.",
                    MessageDialogStyle.AffirmativeAndNegative, settings);

                if (accepted == MessageDialogResult.Affirmative)
                    craftbukkitArgsTextBox.Text = "";

                Settings.Default.customJVMArgs = customJVMArgsTextBox.Text;
            };
            #endregion
            #endregion
            whatIsBukkitUITextBlock.Text = whatIsIt;
        }

        private String whatIsIt {
            get {
                return
                      "Welcome to BukkitUI!\n"
                    + "BukkitUI is a simple and easy-to-use Minecraft Craftbukkit Server wrapper.\n"
                    + "It was originally designed to be cross-platform and was written in Java.\n"
                    + "However, due to many complaints, that the Java version was not necessarily\n"
                    + "wanted on peoples' Windows machines, I decided to give C# and .NET another\n"
                    + "crack, and out came this. A beautiful (that modesty...) piece of work, which\n"
                    + "took almost a week to just get the base design done!\n\n"
                    + "BukkitUI is written completely in C#, using WPF and MahApps.Metro.\n"
                    + "BukkitUI uses the power provided by the .NET framework and the UI controls\n"
                    + "provided with MahApps.Metro to provide you, the end user, with a rich, and\n"
                    + "great user experience.\n"
                    + "BukkitUI was always designed to be so simple, that a child as young as six\n"
                    + "could potentially run his own server. This is made possible by, well,\n"
                    + "let's face it, not-so-smart people around me, who test my software and\n"
                    + "see how they are able to use it. These people are also known as my friends.\n\n"
                    + "But back to the point; BukkitUI is all you need to run a Minecraft multiplayer\n"
                    + "server - It provides you with the means to download any version of Craftbukkit\n"
                    + "that The Bukkit Project provides (including alpha, beta and test builds).\n"
                    + "This means, that you and your friends can play any and all possible combinations\n"
                    + "of Minecraft - With or without mods!\n\n"
                    + "BukkitUI also provides you with the ability, to remotely run your server, with the\n"
                    + "BukkitUI Remote app for Android. Everything is handled by BukkitUI - All you need to\n"
                    + "do is open the app and see how everyone's going!\n"
                    + "And seeming as there are only going to be a few people who are going to read this...\n"
                    + "Thrrrrrppppttt. Ah, now that was great!";
            }
        }

        private void addTitleBarIcons() {
            MemoryStream memStream = new MemoryStream();
            BitmapImage icon = new BitmapImage();

            Properties.Resources.gear_2_32.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            settingsIcon.Source = icon;
            memStream.Close();
            memStream.Dispose();

            memStream = new MemoryStream();
            icon = new BitmapImage();

            Properties.Resources._1409528388_installing_updates.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            updateIcon.Source = icon;
            memStream.Close();
            memStream.Dispose();

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources.icon1.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            Icon = icon;
            memStream.Close();
            memStream.Dispose();
            
        }

        private void addTabIcons() {
            MemoryStream memStream = new MemoryStream();
            BitmapImage icon = new BitmapImage();

            Properties.Resources._1409534148_heart_monitor.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            memStream.Close();
            memStream.Dispose();
            serverStatusImage.Source = icon;

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409536156_console.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            memStream.Close();
            memStream.Dispose();
            consoleImage.Source = icon;

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409536743_calendar.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            memStream.Close();
            memStream.Dispose();
            scheduleImage.Source = icon;

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409537506_data_backup.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            memStream.Close();
            memStream.Dispose();
            backupImage.Source = icon;

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409538134_user.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            memStream.Close();
            memStream.Dispose();
            userImage.Source = icon;

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409538316_services.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            memStream.Close();
            memStream.Dispose();
            configImage.Source = icon;

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409538506_about.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            memStream.Close();
            memStream.Dispose();
            aboutImage.Source = icon;

        }

        private void addServerControlIcons() {
            MemoryStream memStream = new MemoryStream();
            BitmapImage icon = new BitmapImage();

            Properties.Resources._1409545913_play.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            startServerTileIcon.Source = icon;
            memStream.Close();
            memStream.Dispose();

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409545971_stop.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            stopServerTileIcon.Source = icon;
            memStream.Close();
            memStream.Dispose();

            memStream = new MemoryStream();
            icon = new BitmapImage();
            Properties.Resources._1409546231_POWER___RESTART.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            restartServerTileIcon.Source = icon;
            memStream.Close();
            memStream.Dispose();

        }

        private void addBackColourLambdas() {
            colourBlue.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourBlue.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
                Settings.Default.Save();
            };
            colourBrightGreen.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourBrightGreen.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourDarkBlue.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourDarkBlue.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourDarkGreen.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourDarkGreen.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourDarkOrange.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourDarkOrange.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourDarkPurple.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourDarkPurple.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourDarkYellow.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourDarkYellow.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourLightBlue.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourLightBlue.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourLightPurple.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourLightPurple.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourMagenta.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourMagenta.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourOrange.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourOrange.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourPink.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourPink.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourPoisenGreen.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourPoisenGreen.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourRed.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourRed.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
            colourYellow.MouseLeftButtonUp += (s, evt) => {
                WindowTitleBrush = colourYellow.Background;
                Settings.Default.windowColour = WindowTitleBrush.ToString();
                colourAllControls();
            };
        }

        private void colourAllControls() {
            Brush brush = WindowTitleBrush;
            // Backgrounds
            cpuAndRamContainer.Background = brush;
            serverControlContainer.Background = brush;
            consoleContainer.Background = brush;
            onlinePlayerContainer.Background = brush;
            scheduleContainer.Background = brush;
            scheduleTaskControlContainer.Background = brush;
            backupContainer.Background = brush;
            backupOptionsContainer.Background = brush;
            ipAddressContainer.Background = brush;
            ipAddressTaskContainer.Background = brush;
            bannedPlayersContainer.Background = brush;
            bannedPlayersTaskContainer.Background = brush;
            opsAndModsContainer.Background = brush;
            opsAndModsTaskContainer.Background = brush;
            serverPlayerContainer.Background = brush;
            serverPlayerManagementContainer.Background = brush;
            remoteAdminsContainer.Background = brush;
            remoteModsContainer.Background = brush;
            whiteListPlayerContainer.Background = brush;
            whiteListPlayerTaskContainer.Background = brush;
            bukkitui_generalSettingsContainer.Background = brush;
            bukkitui_apperanceSettingsContainer.Background = brush;
            bukkitui_serverExecutionSettingsContainer.Background = brush;
            craftbukkit_generalSettingsContainer.Background = brush;
            craftbukkit_serverPropertiesContainer.Background = brush;
            craftbukkit_bukkitSettingsContainer.Background = brush;
            webserver_generalSettingsContainer.Background = brush;
            webserver_userSettingsContainer.Background = brush;
            about_bukkitui_whatIsIt.Background = brush;
            about_bukkitui_creditsContainter.Background = brush;

            // Borders (no, not that kind you idiot...)
            cpuAndRamContainer.BorderBrush = brush;
            serverControlContainer.BorderBrush = brush;
            consoleContainer.BorderBrush = brush;
            onlinePlayerContainer.BorderBrush = brush;
            scheduleContainer.BorderBrush = brush;
            scheduleTaskControlContainer.BorderBrush = brush;
            backupContainer.BorderBrush = brush;
            backupOptionsContainer.BorderBrush = brush;
            ipAddressContainer.BorderBrush = brush;
            ipAddressTaskContainer.BorderBrush = brush;
            bannedPlayersContainer.BorderBrush = brush;
            bannedPlayersTaskContainer.BorderBrush = brush;
            opsAndModsContainer.BorderBrush = brush;
            opsAndModsTaskContainer.BorderBrush = brush;
            serverPlayerContainer.BorderBrush = brush;
            serverPlayerManagementContainer.BorderBrush = brush;
            remoteAdminsContainer.BorderBrush = brush;
            remoteModsContainer.BorderBrush = brush;
            whiteListPlayerContainer.BorderBrush = brush;
            whiteListPlayerTaskContainer.BorderBrush = brush;
            bukkitui_generalSettingsContainer.BorderBrush = brush;
            bukkitui_apperanceSettingsContainer.BorderBrush = brush;
            bukkitui_serverExecutionSettingsContainer.BorderBrush = brush;
            craftbukkit_generalSettingsContainer.BorderBrush = brush;
            craftbukkit_serverPropertiesContainer.BorderBrush = brush;
            craftbukkit_bukkitSettingsContainer.BorderBrush = brush;
            webserver_generalSettingsContainer.BorderBrush = brush;
            webserver_userSettingsContainer.BorderBrush = brush;
            about_bukkitui_whatIsIt.BorderBrush = brush;
            about_bukkitui_creditsContainter.BorderBrush = brush;

            // Tiles
            startServerTile.Background = brush;
            stopServerTile.Background = brush;
            restartServerTile.Background = brush;

            // Accented buttons
            consoleCommandExecuteButton.Background = brush;
            addTaskButton.Background = brush;
            removeSelectedTaskButton.Background = brush;
            removeAllTasksButton.Background = brush;
            backupNowButton.Background = brush;
            deleteSelectedBackupButton.Background = brush;
            deleteAllBackupsButton.Background = brush;
            backupOptionsButton.Background = brush;
            addBannedIPButton.Background = brush;
            unbanSelectedIP.Background = brush;
            pardonAllIPsButton.Background = brush;
            banPlayerButton.Background = brush;
            unbanPlayerButton.Background = brush;
            pardonAllPlayersButton.Background = brush;
            addOP.Background = brush;
            removeSelectedOP.Background = brush;
            removeAllOPs.Background = brush;
            viewServerPlayerDetailsButton.Background = brush;
            kickServerPlayerFromServerButton.Background = brush;
            banServerPlayerButton.Background = brush;
            banServerPlayerIP.Background = brush;
            resetServerPlayerData.Background = brush;
            addWhitelistPlayerButton.Background = brush;
            removeWhitelistPlayerButton.Background = brush;
            clearWhitelistButton.Background = brush;
            savePrefs.Background = brush;
            selectServerJarButton.Background = brush;
            downloadServerJarButton.Background = brush;
            addBukkitArgButton.Background = brush;
            selectJavaLocation.Background = brush;
            addJavaArgButton.Background = brush;
            clearJavaArgsButton.Background = brush;
            addBukkitArgButton.Background = brush;
            clearBukkitArgsButton.Background = brush;
            saveCraftbukkitPrefsButton.Background = brush;

            // Toggle Switches
            titleAllCapsSwitch.SwitchForeground = brush;
            webserver_PowerSwitch.SwitchForeground = brush;


        }
        #endregion

        #region // Server event processing
        private void cbServer_outputReceived(object sender, DataReceivedEventArgs evt) {
            #region // Parse basic output - Add output to listview
            ListViewItem item = new ListViewItem();
            Grid grid = new Grid();
            TextBlock procOut = new TextBlock();
            TextBlock timeStamp = new TextBlock();
            String formattedOutput = null;
            String[] parsedOutput = null;

            procOut.FontSize = 18;
            procOut.FontWeight = FontWeights.Bold;

            timeStamp.FontSize = 14;
            timeStamp.FontWeight = FontWeights.Light;

            #region // Lots of ifs. BIG IFs
            if (Regex.IsMatch(evt.Data, @"(\s\[(FINE|FINER|FINEST)\]\s)")) // Excuse the brainfart...
                item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#58FA58"));
            else if (Regex.IsMatch(evt.Data, @"(\s\[(INFO)\]\s)"))
                item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#58ACFA"));
            else if (Regex.IsMatch(evt.Data, @"(\s\[(WARNING)\]\s)"))
                item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4FA58"));
            else if (Regex.IsMatch(evt.Data, @"(\s\[(SEVERE)\]\s)"))
                item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FA5858"));

            formattedOutput = Regex.Replace(evt.Data, @"(\s\[(INFO|FINE|FINER|FINEST|SEVERE|WARNING)\]\s)", ";");
            #endregion

            parsedOutput = Regex.Split(formattedOutput, "[;]");
            timeStamp.Text = "\n\n" + parsedOutput[0];
            for (int i = 1; i < parsedOutput.Length; i++) // Making sure I didn't accidentally split an important command
                procOut.Text += parsedOutput[i];

            grid.Children.Add(procOut);
            grid.Children.Add(timeStamp);
            item.Content = grid;
            consoleListView.Items.Add(item);
            #endregion
            #region // Parse server state
            if (evt.Data.Contains("Preparing spawn area:") && evt.Data.EndsWith("%"))
                cbServer.serverState = ServerState.Generating_Worlds;
            if (evt.Data.Contains("Done") && evt.Data.EndsWith("For help, type \"help\" or \"?\""))
                cbServer.serverState = ServerState.Running;
            if (evt.Data.Contains("[INFO] Stopping server"))
                cbServer.serverState = ServerState.Stopping;
            #endregion
            #region // Parse joins and exits
            if (evt.Data.ToLower().Contains("logged in")) {
                String raw = null;
                String playerName = null;
                String ipAddr = null;
                ListViewItem playerItem = new ListViewItem();
                Grid playerItemGrid = new Grid();
                TextBlock playerNameTB = new TextBlock();
                TextBlock playerIPStamp = new TextBlock();

                playerNameTB.FontWeight = FontWeights.Bold;
                playerNameTB.FontSize = 18;
                playerIPStamp.FontSize = 14;
                playerIPStamp.FontWeight = FontWeights.Light;
                playerItemGrid.Children.Add(playerNameTB);
                playerItemGrid.Children.Add(playerIPStamp);

                raw = Regex.Split(evt.Data, @"(\[INFO\]\s)")[1];
                playerName = Regex.Split(raw, @"[\s]")[0];
                ipAddr = Regex.Split(Regex.Split(raw, @"\[/")[1], @"\]")[0];

                playerIPStamp.Text = "\n\n  " + ipAddr;
                playerNameTB.Text = playerName;
                console_onlinePlayersListView.Items.Add(playerItem);

                // I hope this works...
            }
            if (evt.Data.ToLower().Contains("disconnect.")) {
                String playerName = Regex.Split(Regex.Split(evt.Data, @"(\[INFO\]\s)")[1], @"[\s]")[0];
                foreach (ListViewItem listItem in console_onlinePlayersListView.Items) {
                    var listItemGrid = listItem.Content as Grid;
                    foreach (UIElement child in listItemGrid.Children)
                        if (((TextBlock)child).Text.Contains(playerName)) {
                            console_onlinePlayersListView.Items.Remove(listItem);
                            break;
                        }
                }
            }
            #endregion
        }

        private void cbServer_stateChanged(object sender, ServerStateChangedEventArgs evt) {
            if (evt.State == ServerState.Stopped)
                Title = "BukkitUI - © Beatsleigher 2014";
            else
                Title = String.Format("BukkitUI - © Beatsleigher 2014 [Server: {0}]", evt.State.ToString());
        }

        private void cbServer_serverUsageChanged(object sender, ServerUsageChangedEventArgs evt) {
            var perfCounterCPU = new PerformanceCounter("Process", "% Processor Time", cbServer.process.ProcessName);
            var perfCounterRAM = new PerformanceCounter("Memory", "Committed Bytes", cbServer.process.ProcessName);

            cpuTime.Value = perfCounterCPU.NextValue();
            ramLevel.Maximum = new PerformanceCounter("Memory", "Available Bytes", cbServer.process.ProcessName).NextValue();
            ramLevel.Value = perfCounterRAM.NextValue();

            perfCounterCPU.Close();
            perfCounterCPU.Dispose();
            perfCounterRAM.Close();
            perfCounterRAM.Dispose();
        }
        #endregion

        private void startServerTile_onClick(object sender, RoutedEventArgs evt) {
            if (Settings.Default.bukkit_executable == null || String.IsNullOrEmpty(Settings.Default.bukkit_executable) ||
                String.IsNullOrWhiteSpace(Settings.Default.bukkit_executable)) {
                    MetroDialogSettings settings = new MetroDialogSettings();
                    settings.AffirmativeButtonText = "OK";
                    settings.AnimateHide = true;
                    settings.AnimateShow = true;
                    this.ShowMessageAsync("No Craftbukkit Server Selected!",
                          "You have not selected a Craftbukkit server!\n"
                        + "BukkitUI will not be able to start a server.\n"
                        + "Please select a server in the Preferences and try again.", MessageDialogStyle.Affirmative, settings);
                    return;
            }
            if (cbServer != null && cbServer.isRunning) return;
            
            cbServer = new CraftbukkitServer();
            cbServer.outputReceived += cbServer_outputReceived;
            cbServer.serverUsageChanged += cbServer_serverUsageChanged;
            cbServer.stateChanged += cbServer_stateChanged;
            List<string> args = new List<string>();
            args.Add(Settings.Default.javaBinaryPath);
            args.Add(String.Format("-Xms{0}", Settings.Default.javaInitHeap));
            args.Add(String.Format("-Xmx{0}", Settings.Default.javaMaxHeap));
            foreach (var arg in Regex.Split(Settings.Default.customJVMArgs, @"[;][\s]")) {
                if (!String.IsNullOrEmpty(arg) && !String.IsNullOrWhiteSpace(arg))
                    args.Add(arg);
                Debug.WriteLine(arg);
            }
            args.Add("-jar");
            args.Add(Settings.Default.bukkit_executable);
            foreach (var arg in Regex.Split(Settings.Default.bukkit_args, @"[;][\s]")) {
                if (!String.IsNullOrEmpty(arg) && !String.IsNullOrWhiteSpace(arg))
                    args.Add(arg);
                Debug.WriteLine(arg);
            }
            cbServer.args = args;


            cbServer.start();
        }

    }
}
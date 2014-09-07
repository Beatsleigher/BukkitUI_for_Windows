using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MetroBukkitUI.Properties;

namespace MetroBukkitUI {
    /// <summary>
    /// Interaction logic for MinimumRequirementWindow.xaml
    /// </summary>
    public partial class MinimumRequirementWindow : Window {

        #region Vars and Properties
        internal bool cpuRequirementsMet { get; set; }
        internal bool ramRquirementsMet { get; set; }
        internal int cpuMHz { get; set; }
        internal int availableRAM { get; set; }

        private String cpuChecksOut {
            get {
                return "Your processor seems to be fit for the the job! For BukkitUI to run properly (minimum requirements)\n"
                    + "you'll need a processor with at least 2GHz, the more the merrier!\n"
                    + "Your processor has a maximum speed of " + cpuMHz.ToString() + "MHz - That'll do just fine!";
            }
        }

        private String cpuDoesntCheckOut {
            get {
                return "It seems as though your processor doesn't pack enough punch to be able to run and maintain\n"
                    + "a Minecraft Craftbukkit server.\n"
                    + "For that, I recommend using a processor with at least 2000MHz (2GHz).\n"
                    + "Your processor sadly only packs " + cpuMHz.ToString() + "MHz.";
            }
        }

        private String ramChecksOut {
            get {
                return "You've got enough RAM under the hood, maybe it's time for a CPU upgrade?\n"
                    + "I recommend a processor with at least 2000MHz (2GHz) to run and maintain a\n"
                    + "Minecraft Craftbukkit server with at least 2000MiB (2GiB) RAM.\n"
                    + "You're currently running " + availableRAM.ToString() + "MiB (" + ((float)availableRAM / 1024).ToString() + "GiB).";
            }
        }

        private String ramDoesntCheckOut {
            get {
                return "Uh, oh! It seems as if you're running a bit low on RAM!\n"
                    + "In order to run BukkitUI, I recommend having at least 2000MiB (2GiB) available RAM.\n"
                    + "You're currently running at " + availableRAM.ToString() + "MiB (" + ((float)availableRAM / 1024).ToString() + "GiB).";
            }
        }
        #endregion

        public MinimumRequirementWindow(bool cpuReqMet, bool ramReqMet, int cpuMHz, int availRAM) {

            MemoryStream memStream = new MemoryStream();
            Properties.Resources._1409447707_314316.Save(memStream);
            BitmapImage icon = new BitmapImage();
            icon.BeginInit();
            icon.StreamSource = new MemoryStream(memStream.ToArray());
            icon.EndInit();
            Icon = icon;

            cpuRequirementsMet = cpuReqMet;
            ramRquirementsMet = ramReqMet;
            this.cpuMHz = cpuMHz;
            this.availableRAM = availRAM;

            InitializeComponent();
            memStream = new MemoryStream();
            Properties.Resources._1409447682_698465_icon_20_sad_face_eyebrows_128.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage sadFace = new BitmapImage();
            sadFace.BeginInit();
            sadFace.StreamSource = new MemoryStream(memStream.ToArray());
            sadFace.EndInit();
            this.sadFace.Source = sadFace;
            memStream.Close();
            memStream.Dispose();

            titleText.Text = "Sorry, but your computer lacks the power to run and maintain a Minecraft Craftbukkit server.\n"
                + "Should you, however, still wish to run BukkitUI, please see the details below.\n"
                + "You will then have the option to bypass this safety guard on the next startup.";

            #region // Check all the data and print it to the screen
            if (cpuRequirementsMet) {
                MemoryStream _memStream = new MemoryStream();
                Properties.Resources._1409457248_678134_sign_check_128.Save(_memStream, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(_memStream.ToArray());
                bmp.EndInit();
                cpuOK.Source = bmp;

                cpuInfoText.Document = new FlowDocument(new Paragraph(new Run(cpuChecksOut)));
            } else {
                MemoryStream _memStream = new MemoryStream();
                Properties.Resources._1409457238_678069_sign_error_128.Save(_memStream, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(_memStream.ToArray());
                bmp.EndInit();
                cpuOK.Source = bmp;

                cpuInfoText.Document = new FlowDocument(new Paragraph(new Run(cpuDoesntCheckOut)));
            }

            if (ramReqMet) {
                MemoryStream _memStream = new MemoryStream();
                Properties.Resources._1409457248_678134_sign_check_128.Save(_memStream, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(_memStream.ToArray());
                bmp.EndInit();
                ramOK.Source = bmp;

                ramInfoText.Document = new FlowDocument(new Paragraph(new Run(ramChecksOut)));
            } else {
                MemoryStream _memStream = new MemoryStream();
                Properties.Resources._1409457238_678069_sign_error_128.Save(_memStream, System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(_memStream.ToArray());
                bmp.EndInit();
                ramOK.Source = bmp;

                ramInfoText.Document = new FlowDocument(new Paragraph(new Run(ramDoesntCheckOut)));
            }
            #endregion

            //fixRAMIcon
            memStream = new MemoryStream();
            Properties.Resources._1409513340_onebit_27.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage arrowRight = new BitmapImage();
            arrowRight.BeginInit();
            arrowRight.StreamSource = new MemoryStream(memStream.ToArray());
            arrowRight.EndInit();
            fixRAMIcon.Source = arrowRight;
            memStream.Close();
            memStream.Dispose();

            ignoreStatsToggleButton.Checked += (s, evt) => { 
                Properties.Settings.Default.ignorePerformanceWarnings = (bool)ignoreStatsToggleButton.IsChecked;
                Properties.Settings.Default.Save();
                MessageBox.Show(this, "Please restart BukkitUI by closing this window and re-opening BukkitUI.", "Restart BukkitUI", 
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
            };
            ignoreStatsToggleButton.IsChecked = Settings.Default.ignorePerformanceWarnings;

        }

        private void fixRAM_Click(object sender, RoutedEventArgs evt) {
            System.Diagnostics.Process.Start("http://youtu.be/CC_FuPeBUqw");
        }
    }
}

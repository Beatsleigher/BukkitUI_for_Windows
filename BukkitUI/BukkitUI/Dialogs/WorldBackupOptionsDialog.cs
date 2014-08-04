using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BukkitUI.Dialogs {
    public partial class WorldBackupOptionsDialog : Form {

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public bool useBZipCompression { get; set; }
        public String worldLocation { get; set; }
        public String backupDestination { get; set; }

        public WorldBackupOptionsDialog(bool useBZipCompression, String worldLocation, String backupDestination) {
            this.useBZipCompression = useBZipCompression;
            this.worldLocation = worldLocation;
            this.backupDestination = backupDestination;
            InitializeComponent();
        }

        private void WorldBackupOptionsDialog_Load(object sender, EventArgs evt) {
            radioButton1.CheckedChanged += (s, e) => { if (radioButton1.Checked) useBZipCompression = false; };
            textBox1.Text = worldLocation;
            textBox2.Text = backupDestination;
        }

        private void button1_Click(object sender, EventArgs evt) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "Select the World you want to back up...";
            dialog.SelectedPath = textBox1.Text;
            dialog.ShowNewFolderButton = false;
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                worldLocation = dialog.SelectedPath;
                textBox1.Text = dialog.SelectedPath;
            } 
        }

        private void button2_Click(object sender, EventArgs evt) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "Select the location to back up your world to...";
            dialog.SelectedPath = textBox2.Text;
            dialog.ShowNewFolderButton = true;
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                backupDestination = dialog.SelectedPath;
                textBox2.Text = dialog.SelectedPath;
            } 
        }

        private void button3_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
        
    }
}

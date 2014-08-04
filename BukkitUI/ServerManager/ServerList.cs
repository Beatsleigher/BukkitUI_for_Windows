using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace BukkitUI.ServerManager {
    public partial class ServerList : Form {

        public String craftBukkit { get { return cBukkit; } }
        private String cBukkit = "";
        private BackgroundWorker worker = null;
        private bool startup = true;

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

        public ServerList(bool extendDWM) {
            InitializeComponent();
            #region More Aero Stuff
            MARGINS margins = new MARGINS();
            margins.cxLeftWidth = 13;
            margins.cxRightWidth = 13;
            margins.cyBottomHeight = 75;
            margins.cyTopHeight = 13;
            if (extendDWM)
                try {
                    DwmExtendFrameIntoClientArea(Handle, ref margins);
                    this.ResizeRedraw = true;
                    this.BackColor = Color.Black;
                } catch (Exception ex) {

                }
            #endregion
            worker = new BackgroundWorker();
            worker.DoWork += (s, evt) => {
                Invoke((MethodInvoker)delegate {

                    if (startup) {
                        Thread.Sleep(5000);
                        startup = false;
                    }

                    progressBar1.Style = ProgressBarStyle.Marquee;
                    Text = "List of Available Servers [Working...]";

                    dataGridView1.Rows.Clear();
                    Dictionary<String, String> linkDict = new HTMLParser(progressBar1).linkDescTable;
                    int idx = 0;

                    progressBar1.Maximum = linkDict.Keys.Count;

                    foreach (String key in linkDict.Keys) {
                        progressBar1.Value = idx;
                        dataGridView1.Rows.Add(1);
                        DataGridViewRow row = dataGridView1.Rows[idx];
                        String value = null;

                        row.Cells[0].Value = Regex.Split(Regex.Split(key, "(Download )")[2], "[(]")[0];
                        row.Cells[1].Value = Regex.Split(Regex.Split(Regex.Split(key, "(Download )")[2], "[(]")[1], "[)]")[0];
                        linkDict.TryGetValue(key, out value);
                        row.Cells[2].Value = value;

                        idx++;
                    }

                });
            };
            worker.RunWorkerCompleted += (s, evt) => { progressBar1.Value = 0; Text = "List of Available Servers"; };
            
        }

        private void button1_Click(object sender, EventArgs evt) {
            worker.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs evt) {
            WebClient webC = new WebClient();
            progressBar1.Maximum = 100;

            webC.DownloadProgressChanged += (s, e) => progressBar1.Value = e.ProgressPercentage;
            webC.DownloadFileCompleted += (s, e) => MessageBox.Show(this, 
                    "Your download has completed!\n"
                + "Click the Close button to complete the installation and use BukkitUI."
                , "Hooray!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            String bukkitDir = "";
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.RootFolder = Environment.SpecialFolder.UserProfile;
            folderBrowser.ShowNewFolderButton = true;
            folderBrowser.Description = "Select a folder to save Craftbukkit to...";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                bukkitDir = folderBrowser.SelectedPath;
            else return;

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
            DataGridViewCell urlCell = selectedRow.Cells[2];
            DataGridViewCell filenameCell = selectedRow.Cells[0];

            Uri uri = new Uri(urlCell.Value.ToString());
            cBukkit = Path.Combine(bukkitDir, "craftbukkit-" + filenameCell.Value.ToString() + ".jar");

            webC.DownloadFileAsync(uri, cBukkit);

        }

        private void progressBar1_Click(object sender, EventArgs evt) {

        }

        private void ServerList_Load(object sender, EventArgs evt) {
            worker.RunWorkerAsync();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e) {
            Close();
            if (!String.IsNullOrWhiteSpace(cBukkit) && !String.IsNullOrEmpty(cBukkit))
                DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }

        private void ServerList_FormClosing(object sender, FormClosingEventArgs e) {
            if (!String.IsNullOrWhiteSpace(cBukkit) && !String.IsNullOrEmpty(cBukkit))
                DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }
    }
}

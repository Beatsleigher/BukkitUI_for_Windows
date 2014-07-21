using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BukkitUI {
    public partial class BukkitCmdBrowser : Form {
        public BukkitCmdBrowser() {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e) {
            webBrowser1.GoBack();
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e) {
            webBrowser1.GoForward();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e) {
            webBrowser1.Navigate("http://wiki.bukkit.org/CraftBukkit_commands");
        }
    }
}

namespace BukkitUI_Updater
{
    partial class RadForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadForm1));
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.radCheckBox2 = new Telerik.WinControls.UI.RadCheckBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.updateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateMinVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDlLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Location = new System.Drawing.Point(13, 324);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.Size = new System.Drawing.Size(744, 24);
            this.radProgressBar1.TabIndex = 0;
            this.radProgressBar1.Text = ">> Idle <<";
            this.radProgressBar1.ThemeName = "TelerikMetro";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(98, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Available Updates:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.updateName,
            this.updateDesc,
            this.updatePriority,
            this.updateMinVersion,
            this.updateVersion,
            this.updateDlLink,
            this.updateType});
            this.dataGridView1.Location = new System.Drawing.Point(13, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(744, 280);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radCheckBox1.Location = new System.Drawing.Point(122, 13);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(98, 19);
            this.radCheckBox1.TabIndex = 3;
            this.radCheckBox1.Text = "Show Patches";
            this.radCheckBox1.ThemeName = "TelerikMetro";
            this.radCheckBox1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            // 
            // radCheckBox2
            // 
            this.radCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radCheckBox2.Location = new System.Drawing.Point(217, 13);
            this.radCheckBox2.Name = "radCheckBox2";
            this.radCheckBox2.Size = new System.Drawing.Size(114, 19);
            this.radCheckBox2.TabIndex = 4;
            this.radCheckBox2.Text = "Show QuickFixes";
            this.radCheckBox2.ThemeName = "TelerikMetro";
            this.radCheckBox2.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radCheckBox2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox2_ToggleStateChanged);
            // 
            // radButton1
            // 
            this.radButton1.Enabled = false;
            this.radButton1.Location = new System.Drawing.Point(330, 355);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 5;
            this.radButton1.Text = "Download Update";
            this.radButton1.ThemeName = "TelerikMetro";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // updateName
            // 
            this.updateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.updateName.HeaderText = "Update Name";
            this.updateName.Name = "updateName";
            this.updateName.ReadOnly = true;
            this.updateName.Width = 98;
            // 
            // updateDesc
            // 
            this.updateDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.updateDesc.HeaderText = "Update Description";
            this.updateDesc.Name = "updateDesc";
            this.updateDesc.ReadOnly = true;
            this.updateDesc.Width = 113;
            // 
            // updatePriority
            // 
            this.updatePriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.updatePriority.HeaderText = "Update Priority";
            this.updatePriority.Name = "updatePriority";
            this.updatePriority.ReadOnly = true;
            this.updatePriority.Width = 93;
            // 
            // updateMinVersion
            // 
            this.updateMinVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.updateMinVersion.HeaderText = "Min. Required Version for Update";
            this.updateMinVersion.Name = "updateMinVersion";
            this.updateMinVersion.ReadOnly = true;
            this.updateMinVersion.Width = 127;
            // 
            // updateVersion
            // 
            this.updateVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.updateVersion.HeaderText = "Updated Version";
            this.updateVersion.Name = "updateVersion";
            this.updateVersion.ReadOnly = true;
            this.updateVersion.Width = 102;
            // 
            // updateDlLink
            // 
            this.updateDlLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.updateDlLink.HeaderText = "Update Download URL";
            this.updateDlLink.Name = "updateDlLink";
            this.updateDlLink.ReadOnly = true;
            this.updateDlLink.Width = 111;
            // 
            // updateType
            // 
            this.updateType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.updateType.HeaderText = "Update Type";
            this.updateType.Name = "updateType";
            this.updateType.ReadOnly = true;
            this.updateType.Width = 87;
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 392);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radCheckBox2);
            this.Controls.Add(this.radCheckBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "BukkitUI Updater";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateMinVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDlLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateType;
    }
}

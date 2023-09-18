namespace DiskSpaceWatcher {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (_indicators != null) { _indicators.ForEach(indicator => indicator.Dispose()); }
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listboxDrives = new System.Windows.Forms.CheckedListBox();
            this.picture_Warning = new System.Windows.Forms.PictureBox();
            this.comboBoxWarning = new System.Windows.Forms.ComboBox();
            this.picture_Caution = new System.Windows.Forms.PictureBox();
            this.comboBoxCaution = new System.Windows.Forms.ComboBox();
            this.timerWatch = new System.Windows.Forms.Timer(this.components);
            this.labelWarning = new System.Windows.Forms.Label();
            this.picture_OK = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemGroupInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemUninstall = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Warning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Caution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_OK)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxDrives
            // 
            this.listboxDrives.FormattingEnabled = true;
            this.listboxDrives.Location = new System.Drawing.Point(6, 18);
            this.listboxDrives.Name = "listboxDrives";
            this.listboxDrives.ScrollAlwaysVisible = true;
            this.listboxDrives.Size = new System.Drawing.Size(64, 130);
            this.listboxDrives.TabIndex = 0;
            this.listboxDrives.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listboxDrives_ItemCheck);
            this.listboxDrives.SelectedIndexChanged += new System.EventHandler(this.listboxDrives_SelectedIndexChanged);
            // 
            // picture_Warning
            // 
            this.picture_Warning.Image = global::DiskSpaceWatcher.Properties.Resources.warning_20;
            this.picture_Warning.Location = new System.Drawing.Point(6, 18);
            this.picture_Warning.Name = "picture_Warning";
            this.picture_Warning.Size = new System.Drawing.Size(20, 20);
            this.picture_Warning.TabIndex = 1;
            this.picture_Warning.TabStop = false;
            // 
            // comboBoxWarning
            // 
            this.comboBoxWarning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWarning.FormattingEnabled = true;
            this.comboBoxWarning.Location = new System.Drawing.Point(32, 44);
            this.comboBoxWarning.Name = "comboBoxWarning";
            this.comboBoxWarning.Size = new System.Drawing.Size(56, 20);
            this.comboBoxWarning.TabIndex = 2;
            this.comboBoxWarning.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarning_SelectedIndexChanged);
            // 
            // picture_Caution
            // 
            this.picture_Caution.Image = global::DiskSpaceWatcher.Properties.Resources.caution_20;
            this.picture_Caution.Location = new System.Drawing.Point(6, 70);
            this.picture_Caution.Name = "picture_Caution";
            this.picture_Caution.Size = new System.Drawing.Size(20, 20);
            this.picture_Caution.TabIndex = 3;
            this.picture_Caution.TabStop = false;
            // 
            // comboBoxCaution
            // 
            this.comboBoxCaution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaution.FormattingEnabled = true;
            this.comboBoxCaution.Location = new System.Drawing.Point(32, 96);
            this.comboBoxCaution.Name = "comboBoxCaution";
            this.comboBoxCaution.Size = new System.Drawing.Size(56, 20);
            this.comboBoxCaution.TabIndex = 4;
            this.comboBoxCaution.SelectedIndexChanged += new System.EventHandler(this.comboBoxCaution_SelectedIndexChanged);
            // 
            // timerWatch
            // 
            this.timerWatch.Tick += new System.EventHandler(this.timerWatch_Tick);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelWarning.Location = new System.Drawing.Point(32, 18);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(52, 14);
            this.labelWarning.TabIndex = 7;
            this.labelWarning.Text = "Warning";
            // 
            // picture_OK
            // 
            this.picture_OK.Image = global::DiskSpaceWatcher.Properties.Resources.ok_20;
            this.picture_OK.Location = new System.Drawing.Point(6, 122);
            this.picture_OK.Name = "picture_OK";
            this.picture_OK.Size = new System.Drawing.Size(20, 20);
            this.picture_OK.TabIndex = 8;
            this.picture_OK.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(32, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Caution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(33, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "OK";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listboxDrives);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 160);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drives";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.picture_Warning);
            this.groupBox2.Controls.Add(this.comboBoxWarning);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.picture_Caution);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxCaution);
            this.groupBox2.Controls.Add(this.picture_OK);
            this.groupBox2.Controls.Add(this.labelWarning);
            this.groupBox2.Location = new System.Drawing.Point(98, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 160);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thresholds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(94, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "GB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(94, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "GB";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSetting,
            this.toolStripMenuItem1,
            this.menuitemGroupInstall,
            this.toolStripMenuItem2,
            this.menuItemExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(112, 82);
            this.contextMenu.Text = "DiskSpaceWatcher";
            // 
            // menuItemSetting
            // 
            this.menuItemSetting.Image = global::DiskSpaceWatcher.Properties.Resources.Setting;
            this.menuItemSetting.Name = "menuItemSetting";
            this.menuItemSetting.Size = new System.Drawing.Size(180, 22);
            this.menuItemSetting.Text = "&Setting";
            this.menuItemSetting.Click += new System.EventHandler(this.menuItemSetting_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Image = global::DiskSpaceWatcher.Properties.Resources.SignOut;
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(180, 22);
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuitemGroupInstall
            // 
            this.menuitemGroupInstall.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemInstall,
            this.menuitemUninstall});
            this.menuitemGroupInstall.Image = global::DiskSpaceWatcher.Properties.Resources.AddTo;
            this.menuitemGroupInstall.Name = "menuitemGroupInstall";
            this.menuitemGroupInstall.Size = new System.Drawing.Size(111, 22);
            this.menuitemGroupInstall.Text = "&Install";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // menuitemInstall
            // 
            this.menuitemInstall.Image = global::DiskSpaceWatcher.Properties.Resources.AddTo;
            this.menuitemInstall.Name = "menuitemInstall";
            this.menuitemInstall.Size = new System.Drawing.Size(180, 22);
            this.menuitemInstall.Text = "&Install";
            this.menuitemInstall.Click += new System.EventHandler(this.menuitemInstall_Click);
            // 
            // menuitemUninstall
            // 
            this.menuitemUninstall.Image = global::DiskSpaceWatcher.Properties.Resources.RemoveFrom;
            this.menuitemUninstall.Name = "menuitemUninstall";
            this.menuitemUninstall.Size = new System.Drawing.Size(180, 22);
            this.menuitemUninstall.Text = "&Uninstall";
            this.menuitemUninstall.Click += new System.EventHandler(this.menuitemUninstall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 185);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "DiskSpaceWatcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picture_Warning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Caution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_OK)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listboxDrives;
        private System.Windows.Forms.PictureBox picture_Warning;
        private System.Windows.Forms.ComboBox comboBoxWarning;
        private System.Windows.Forms.PictureBox picture_Caution;
        private System.Windows.Forms.ComboBox comboBoxCaution;
        private System.Windows.Forms.Timer timerWatch;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.PictureBox picture_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuitemGroupInstall;
        private System.Windows.Forms.ToolStripMenuItem menuitemInstall;
        private System.Windows.Forms.ToolStripMenuItem menuitemUninstall;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

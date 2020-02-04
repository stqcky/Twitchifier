namespace Twitchfier
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pboxActive2 = new System.Windows.Forms.PictureBox();
            this.pboxActive1 = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStreamerList = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pnlStreamerList = new System.Windows.Forms.Panel();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkLiveOnly = new System.Windows.Forms.CheckBox();
            this.chkEveryChannel = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblSelfUsername = new System.Windows.Forms.Label();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTwitchUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lboxChannels = new System.Windows.Forms.ListBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.btnRefreshApply = new System.Windows.Forms.Button();
            this.txtRefreshTime = new System.Windows.Forms.TextBox();
            this.lblRefreshTime = new System.Windows.Forms.Label();
            this.chkHideToTray = new System.Windows.Forms.CheckBox();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.rightStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxActive2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxActive1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.pnlStreamerList.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.rightStrip.SuspendLayout();
            this.trayStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(165)))));
            this.pnlTop.Controls.Add(this.pboxActive2);
            this.pnlTop.Controls.Add(this.pboxActive1);
            this.pnlTop.Controls.Add(this.btnSettings);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnStreamerList);
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(567, 30);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pboxActive2
            // 
            this.pboxActive2.BackColor = System.Drawing.Color.Lime;
            this.pboxActive2.Location = new System.Drawing.Point(215, 0);
            this.pboxActive2.Name = "pboxActive2";
            this.pboxActive2.Size = new System.Drawing.Size(113, 5);
            this.pboxActive2.TabIndex = 6;
            this.pboxActive2.TabStop = false;
            this.pboxActive2.Visible = false;
            // 
            // pboxActive1
            // 
            this.pboxActive1.BackColor = System.Drawing.Color.Lime;
            this.pboxActive1.Location = new System.Drawing.Point(96, 0);
            this.pboxActive1.Name = "pboxActive1";
            this.pboxActive1.Size = new System.Drawing.Size(113, 5);
            this.pboxActive1.TabIndex = 5;
            this.pboxActive1.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(47)))), ((int)(((byte)(117)))));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSettings.Location = new System.Drawing.Point(215, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(113, 30);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Twitchifier";
            // 
            // btnStreamerList
            // 
            this.btnStreamerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(47)))), ((int)(((byte)(117)))));
            this.btnStreamerList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStreamerList.FlatAppearance.BorderSize = 0;
            this.btnStreamerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStreamerList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStreamerList.ForeColor = System.Drawing.Color.White;
            this.btnStreamerList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStreamerList.Location = new System.Drawing.Point(96, 0);
            this.btnStreamerList.Name = "btnStreamerList";
            this.btnStreamerList.Size = new System.Drawing.Size(113, 30);
            this.btnStreamerList.TabIndex = 0;
            this.btnStreamerList.Text = "Streamer List";
            this.btnStreamerList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStreamerList.UseVisualStyleBackColor = false;
            this.btnStreamerList.Click += new System.EventHandler(this.btnStreamerList_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackgroundImage = global::Twitchifier.Properties.Resources.btnMinimize1;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.Location = new System.Drawing.Point(514, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(22, 22);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseEnter += new System.EventHandler(this.btnMinimize_MouseEnter);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.btnMinimize_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::Twitchifier.Properties.Resources.btnClose1;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(542, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // pnlStreamerList
            // 
            this.pnlStreamerList.Controls.Add(this.chkActive);
            this.pnlStreamerList.Controls.Add(this.chkLiveOnly);
            this.pnlStreamerList.Controls.Add(this.chkEveryChannel);
            this.pnlStreamerList.Controls.Add(this.btnImport);
            this.pnlStreamerList.Controls.Add(this.lblSelfUsername);
            this.pnlStreamerList.Controls.Add(this.txtImport);
            this.pnlStreamerList.Controls.Add(this.btnAdd);
            this.pnlStreamerList.Controls.Add(this.lblTwitchUsername);
            this.pnlStreamerList.Controls.Add(this.txtUsername);
            this.pnlStreamerList.Controls.Add(this.lboxChannels);
            this.pnlStreamerList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlStreamerList.Location = new System.Drawing.Point(0, 28);
            this.pnlStreamerList.Name = "pnlStreamerList";
            this.pnlStreamerList.Size = new System.Drawing.Size(567, 227);
            this.pnlStreamerList.TabIndex = 2;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(337, 180);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // chkLiveOnly
            // 
            this.chkLiveOnly.AutoSize = true;
            this.chkLiveOnly.Location = new System.Drawing.Point(112, 203);
            this.chkLiveOnly.Name = "chkLiveOnly";
            this.chkLiveOnly.Size = new System.Drawing.Size(70, 17);
            this.chkLiveOnly.TabIndex = 9;
            this.chkLiveOnly.Text = "Live only";
            this.chkLiveOnly.UseVisualStyleBackColor = true;
            this.chkLiveOnly.CheckedChanged += new System.EventHandler(this.chkLiveOnly_CheckedChanged);
            // 
            // chkEveryChannel
            // 
            this.chkEveryChannel.AutoSize = true;
            this.chkEveryChannel.Checked = true;
            this.chkEveryChannel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEveryChannel.Location = new System.Drawing.Point(13, 203);
            this.chkEveryChannel.Name = "chkEveryChannel";
            this.chkEveryChannel.Size = new System.Drawing.Size(98, 17);
            this.chkEveryChannel.TabIndex = 8;
            this.chkEveryChannel.Text = "Every Channel";
            this.chkEveryChannel.UseVisualStyleBackColor = true;
            this.chkEveryChannel.CheckedChanged += new System.EventHandler(this.chkEveryChannel_CheckedChanged);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(337, 145);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(171, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import followed channels";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblSelfUsername
            // 
            this.lblSelfUsername.AutoSize = true;
            this.lblSelfUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelfUsername.Location = new System.Drawing.Point(333, 92);
            this.lblSelfUsername.Name = "lblSelfUsername";
            this.lblSelfUsername.Size = new System.Drawing.Size(165, 21);
            this.lblSelfUsername.TabIndex = 6;
            this.lblSelfUsername.Text = "Your Twitch Username";
            // 
            // txtImport
            // 
            this.txtImport.Location = new System.Drawing.Point(337, 116);
            this.txtImport.Name = "txtImport";
            this.txtImport.Size = new System.Drawing.Size(171, 22);
            this.txtImport.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(337, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(171, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTwitchUsername
            // 
            this.lblTwitchUsername.AutoSize = true;
            this.lblTwitchUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTwitchUsername.Location = new System.Drawing.Point(333, 8);
            this.lblTwitchUsername.Name = "lblTwitchUsername";
            this.lblTwitchUsername.Size = new System.Drawing.Size(129, 21);
            this.lblTwitchUsername.TabIndex = 3;
            this.lblTwitchUsername.Text = "Twitch Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(337, 32);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(171, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // lboxChannels
            // 
            this.lboxChannels.FormattingEnabled = true;
            this.lboxChannels.Location = new System.Drawing.Point(12, 11);
            this.lboxChannels.Name = "lboxChannels";
            this.lboxChannels.Size = new System.Drawing.Size(284, 186);
            this.lboxChannels.TabIndex = 0;
            this.lboxChannels.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lboxChannels_MouseDown);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.chkStartMinimized);
            this.pnlSettings.Controls.Add(this.chkStartWithWindows);
            this.pnlSettings.Controls.Add(this.btnRefreshApply);
            this.pnlSettings.Controls.Add(this.txtRefreshTime);
            this.pnlSettings.Controls.Add(this.lblRefreshTime);
            this.pnlSettings.Controls.Add(this.chkHideToTray);
            this.pnlSettings.Controls.Add(this.chkDarkMode);
            this.pnlSettings.Location = new System.Drawing.Point(0, 28);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(567, 227);
            this.pnlSettings.TabIndex = 3;
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkStartMinimized.Location = new System.Drawing.Point(12, 92);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(133, 24);
            this.chkStartMinimized.TabIndex = 6;
            this.chkStartMinimized.Text = "Start Minimized";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            this.chkStartMinimized.CheckedChanged += new System.EventHandler(this.chkStartMinimized_CheckedChanged);
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkStartWithWindows.Location = new System.Drawing.Point(12, 64);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(156, 24);
            this.chkStartWithWindows.TabIndex = 5;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            this.chkStartWithWindows.CheckedChanged += new System.EventHandler(this.chkStartWithWindows_CheckedChanged);
            // 
            // btnRefreshApply
            // 
            this.btnRefreshApply.Location = new System.Drawing.Point(321, 68);
            this.btnRefreshApply.Name = "btnRefreshApply";
            this.btnRefreshApply.Size = new System.Drawing.Size(177, 23);
            this.btnRefreshApply.TabIndex = 4;
            this.btnRefreshApply.Text = "Apply";
            this.btnRefreshApply.UseVisualStyleBackColor = true;
            this.btnRefreshApply.Click += new System.EventHandler(this.btnRefreshApply_Click);
            // 
            // txtRefreshTime
            // 
            this.txtRefreshTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefreshTime.Location = new System.Drawing.Point(321, 41);
            this.txtRefreshTime.Name = "txtRefreshTime";
            this.txtRefreshTime.Size = new System.Drawing.Size(177, 20);
            this.txtRefreshTime.TabIndex = 3;
            this.txtRefreshTime.Text = "60";
            // 
            // lblRefreshTime
            // 
            this.lblRefreshTime.AutoSize = true;
            this.lblRefreshTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRefreshTime.Location = new System.Drawing.Point(317, 11);
            this.lblRefreshTime.Name = "lblRefreshTime";
            this.lblRefreshTime.Size = new System.Drawing.Size(178, 21);
            this.lblRefreshTime.TabIndex = 2;
            this.lblRefreshTime.Text = "Refresh every X seconds";
            // 
            // chkHideToTray
            // 
            this.chkHideToTray.AutoSize = true;
            this.chkHideToTray.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkHideToTray.Location = new System.Drawing.Point(12, 36);
            this.chkHideToTray.Name = "chkHideToTray";
            this.chkHideToTray.Size = new System.Drawing.Size(163, 24);
            this.chkHideToTray.TabIndex = 1;
            this.chkHideToTray.Text = "Close = Hide to Tray";
            this.chkHideToTray.UseVisualStyleBackColor = true;
            this.chkHideToTray.CheckedChanged += new System.EventHandler(this.chkHideToTray_CheckedChanged);
            // 
            // chkDarkMode
            // 
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkDarkMode.Location = new System.Drawing.Point(12, 8);
            this.chkDarkMode.Name = "chkDarkMode";
            this.chkDarkMode.Size = new System.Drawing.Size(102, 24);
            this.chkDarkMode.TabIndex = 0;
            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.UseVisualStyleBackColor = true;
            this.chkDarkMode.CheckedChanged += new System.EventHandler(this.chkDarkMode_CheckedChanged);
            // 
            // rightStrip
            // 
            this.rightStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.openInBrowserToolStripMenuItem});
            this.rightStrip.Name = "rightStrip";
            this.rightStrip.Size = new System.Drawing.Size(162, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // openInBrowserToolStripMenuItem
            // 
            this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openInBrowserToolStripMenuItem.Text = "Open in browser";
            this.openInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Twitchifier";
            this.trayIcon.Visible = true;
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.trayIcon_BalloonTipClicked);
            // 
            // trayStrip
            // 
            this.trayStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.trayStrip.Name = "trayStrip";
            this.trayStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Show";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 255);
            this.Controls.Add(this.pnlStreamerList);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Twitchifier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxActive2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxActive1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.pnlStreamerList.ResumeLayout(false);
            this.pnlStreamerList.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.rightStrip.ResumeLayout(false);
            this.trayStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.Button btnStreamerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.PictureBox pboxActive1;
        private System.Windows.Forms.PictureBox pboxActive2;
        private System.Windows.Forms.Panel pnlStreamerList;
        private System.Windows.Forms.ListBox lboxChannels;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTwitchUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblSelfUsername;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button btnRefreshApply;
        private System.Windows.Forms.TextBox txtRefreshTime;
        private System.Windows.Forms.Label lblRefreshTime;
        private System.Windows.Forms.CheckBox chkHideToTray;
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.CheckBox chkEveryChannel;
        private System.Windows.Forms.CheckBox chkLiveOnly;
        private System.Windows.Forms.ContextMenuStrip rightStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkActive;
    }
}


namespace TwitchNotifier
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Textbox_username = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.ListView_usernames = new System.Windows.Forms.ListView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.chk_startup = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Textbox_username
            // 
            resources.ApplyResources(this.Textbox_username, "Textbox_username");
            this.Textbox_username.Name = "Textbox_username";
            // 
            // button_add
            // 
            resources.ApplyResources(this.button_add, "button_add");
            this.button_add.Name = "button_add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.Button_add_Click);
            // 
            // button_remove
            // 
            resources.ApplyResources(this.button_remove, "button_remove");
            this.button_remove.Name = "button_remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // ListView_usernames
            // 
            resources.ApplyResources(this.ListView_usernames, "ListView_usernames");
            this.ListView_usernames.HideSelection = false;
            this.ListView_usernames.Name = "ListView_usernames";
            this.ListView_usernames.TileSize = new System.Drawing.Size(200, 15);
            this.ListView_usernames.UseCompatibleStateImageBehavior = false;
            this.ListView_usernames.View = System.Windows.Forms.View.Tile;
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // chk_startup
            // 
            resources.ApplyResources(this.chk_startup, "chk_startup");
            this.chk_startup.Name = "chk_startup";
            this.chk_startup.UseVisualStyleBackColor = true;
            this.chk_startup.CheckedChanged += new System.EventHandler(this.chk_startup_CheckedChanged);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.chk_startup);
            this.Controls.Add(this.ListView_usernames);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.Textbox_username);
            this.Name = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Textbox_username;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.ListView ListView_usernames;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox chk_startup;
    }
}


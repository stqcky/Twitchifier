using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchLib.Api;

namespace Twitchfier
{
    public partial class frmMain : Form
    {
        public bool isMaximized = false;
        public int refreshTime = 60000;
        public static BindingList<string> channelList = new BindingList<string>(Twitchifier.Properties.Settings.Default.usernames.Split(',').ToList());
        public static List<string> uids = new List<string>();
        public BindingList<string> live = new BindingList<string>();
        public string channelLink = "https://www.twitch.tv";
        public static string appVersion = "2.0.0";
        public string lastLink = "";
        public static TwitchAPI api;


        // Make window move by clicking and holding on the top panel
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public frmMain()
        {
            InitializeComponent();

            api = new TwitchAPI();
            api.Settings.ClientId = "dmv33cb8zz000hq4y2a6coi0wc8zcl";
            api.Settings.AccessToken = "";

            // Load Settings
            chkDarkMode.Checked = Twitchifier.Properties.Settings.Default.DarkMode;
            chkHideToTray.Checked = Twitchifier.Properties.Settings.Default.HideToTray;
            chkStartWithWindows.Checked = Twitchifier.Properties.Settings.Default.StartWithWindows;
            chkStartMinimized.Checked = Twitchifier.Properties.Settings.Default.StartMinimized;
            
            lboxChannels.DataSource = channelList;
            if (channelList[0] == "")
                channelList.RemoveAt(0);

            setUIDs();
            LiveCheck();
            chkActive.Checked = true;
        }

        static async void setUIDs()
        {
            foreach (var channel in channelList)
            {
                var uid = await GetUserID(channel);
                uids.Add(uid);
            }
        }

        static async Task<string> GetGame(string uid)
        {
            var stream = await api.V5.Streams.GetStreamByUserAsync(uid);
            return stream.Stream.Game;
        }

        static async Task<string> GetUserID(string username)
        {
            TwitchLib.Api.V5.Models.Users.Users user = await api.V5.Users.GetUserByNameAsync(username);
            return user.Matches[0].Id;
        }

        static async Task<List<string>> GetFollowing(string uid)
        {
            TwitchLib.Api.V5.Models.Users.UserFollows user = await api.V5.Users.GetUserFollowsAsync(uid);
            var following = new List<string>();
            foreach (var chan in user.Follows)
            {
                following.Add(chan.Channel.Name);
            }
            return following;
        }

        static async Task<bool> IsOnline(string uid)
        {
            bool isStreaming = await api.V5.Streams.BroadcasterOnlineAsync(uid);
            return isStreaming;
        }

        async void LiveCheck()
        {
            while (true)
            {
                while (chkActive.Checked)
                {
                    var toCheck = new List<string>();
                    foreach (var item in channelList)
                    {
                        toCheck.Add(item);
                    }

                    foreach (var channel in toCheck)
                    {
                        if (live.Contains(channel)) continue;
                        var curUID = uids[channelList.IndexOf(channel)];
                        bool isOnline = await IsOnline(curUID);
                        if (isOnline && !live.Contains(channel))
                        {
                            live.Add(channel);
                            var game = await GetGame(curUID);
                            trayIcon.ShowBalloonTip(2000, channel + " is live!", game, ToolTipIcon.None);
                            lastLink = "https://www.twitch.tv/" + channel;
                            await Task.Delay(7000);
                        }
                        if (!isOnline && live.Contains(channel))
                        {
                            live.Remove(channel);
                            live.Remove(curUID);
                        }                
                    }
                    await Task.Delay(refreshTime);
                }
                await Task.Delay(5000);
            }
        }

        public void SaveChannels()
        {
            Twitchifier.Properties.Settings.Default.usernames = string.Join(",", channelList);
            Twitchifier.Properties.Settings.Default.Save();
        }

        public void DarkMode(Panel pnl)
        {
            pnl.BackColor = SystemColors.ActiveCaptionText;
            foreach (Control c in pnl.Controls)
            {
                if (c.GetType() == typeof(CheckBox) || c.GetType() == typeof(Label))
                {
                    c.ForeColor = SystemColors.Window;
                }
                else if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(Button) || c.GetType() == typeof(ListBox))
                {
                    c.BackColor = SystemColors.WindowText;
                    c.ForeColor = SystemColors.Window;
                }
            }
        }

        public void LightMode(Panel pnl)
        {
            pnl.BackColor = default(Color);
            foreach (Control c in pnl.Controls)
            {
                if (c.GetType() == typeof(CheckBox) || c.GetType() == typeof(Label))
                {
                    c.ForeColor = SystemColors.ControlText;
                }
                else if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ListBox))
                {
                    c.BackColor = SystemColors.Window;
                    c.ForeColor = SystemColors.WindowText;
                }
                else if (c.GetType() == typeof(Button))
                {
                    c.BackColor = SystemColors.ButtonFace;
                    c.ForeColor = default(Color);
                }
            }
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Twitchifier.Properties.Resources.btnClose2;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Twitchifier.Properties.Resources.btnClose1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (chkHideToTray.Checked)
                this.Visible = false;
            else
                Application.Exit(); 
        }


        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (isMaximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
            isMaximized = !isMaximized;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = Twitchifier.Properties.Resources.btnMinimize2;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackgroundImage = Twitchifier.Properties.Resources.btnMinimize1;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            // This is done in order to enable animations
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Minimized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnStreamerList_Click(object sender, EventArgs e)
        {
            pboxActive1.Visible = true;
            pboxActive2.Visible = false;
            pnlSettings.Visible = false;
            pnlStreamerList.Visible = true;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pboxActive2.Visible = true;
            pboxActive1.Visible = false;
            pnlSettings.Visible = true;
            pnlStreamerList.Visible = false;
        }

        private void btnRefreshApply_Click(object sender, EventArgs e)
        {
            try
            {
                refreshTime = Convert.ToInt32(txtRefreshTime.Text) * 1000;
                MessageBox.Show("Refresh time changed");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid value");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (channelList.Count != 30)
            {
                var channel = txtUsername.Text;
                if (Regex.Match(channel, @"^[a-zA-Z0-9_]{4,25}$").Success)
                {
                    channelList.Add(channel);
                    var uid = await GetUserID(channel);
                    uids.Add(uid);
                    SaveChannels();
                }
                else MessageBox.Show("Incorrect username. Try again");
            }
            else MessageBox.Show("You can't add more than 30 streamers due to Twitch's Rate Limits");
        }

        private void chkEveryChannel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEveryChannel.Checked)
                chkLiveOnly.Checked = false;
            if (!chkLiveOnly.Checked && !chkEveryChannel.Checked)
                chkEveryChannel.Checked = true;
            if (chkEveryChannel.Checked)
                lboxChannels.DataSource = channelList;
        }

        private void chkLiveOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLiveOnly.Checked)
                chkEveryChannel.Checked = false;
            if (!chkLiveOnly.Checked && !chkEveryChannel.Checked)
                chkLiveOnly.Checked = true;
            if (chkLiveOnly.Checked)
                lboxChannels.DataSource = live;
        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            Twitchifier.Properties.Settings.Default.DarkMode = chkDarkMode.Checked;
            Twitchifier.Properties.Settings.Default.Save();

            if (chkDarkMode.Checked)
            {
                DarkMode(pnlSettings);
                DarkMode(pnlStreamerList);
            }
            else
            {
                LightMode(pnlSettings);
                LightMode(pnlStreamerList);
            }
        }

        private void chkHideToTray_CheckedChanged(object sender, EventArgs e)
        {
            Twitchifier.Properties.Settings.Default.HideToTray = chkHideToTray.Checked;
            Twitchifier.Properties.Settings.Default.Save();
        }

        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            Twitchifier.Properties.Settings.Default.StartWithWindows = chkStartWithWindows.Checked;
            Twitchifier.Properties.Settings.Default.Save();

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (chkStartWithWindows.Checked)
                registryKey.SetValue("Twitchifier V2", Application.ExecutablePath);
            else
                registryKey.DeleteValue("Twitchifier V2");
        }

        private void chkStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Twitchifier.Properties.Settings.Default.StartMinimized = chkStartMinimized.Checked;
            Twitchifier.Properties.Settings.Default.Save();
        }

        private void lboxChannels_MouseDown(object sender, MouseEventArgs e)
        {
            var menu = new ContextMenuStrip();

            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    lboxChannels.SelectedIndex = lboxChannels.IndexFromPoint(e.X, e.Y);
                    channelLink = "https://www.twitch.tv/" + lboxChannels.Items[lboxChannels.SelectedIndex].ToString();
                    rightStrip.Show(Cursor.Position);
                }
                catch (Exception)
                {
                    return;
                }

            }       
        }

        private void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(channelLink);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = 0;
            if (lboxChannels.SelectedIndex != -1)
            {
                index = lboxChannels.SelectedIndex;
            }
            else
            {
                index = 0;
            }

            var channel = channelList[index];
            channelList.RemoveAt(index);
            uids.RemoveAt(index);

            try
            {
                if (live.Contains(channel)) live.RemoveAt(index);
            }
            catch (Exception)
            {
                return;
            }
            
            SaveChannels();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (chkStartMinimized.Checked)
                this.Visible = false;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            trayIcon.Visible = false;
            SaveChannels();
        }

        private void trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lastLink);
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            var login = txtImport.Text;
            var following = new List<string>();
            var added = 0;
            
            if (Regex.Match(login, @"^[a-zA-Z0-9_]{4,25}$").Success)
            {
                string uid = await GetUserID(login);
                following = await GetFollowing(uid);
            }
            if (following.Count > 0)
            {
                foreach (var item in following)
                {
                    if (!channelList.Contains(item))
                    {
                        channelList.Add(item);
                        var itemUID = await GetUserID(item);
                        uids.Add(itemUID);
                        added++;
                    }
                    if (channelList.Count == 30)
                    {
                        MessageBox.Show("Can't add more than 30 streamers due to Twitch's Rate Limit");
                        break;
                    }
                }
                MessageBox.Show($"Added {added} new channels!");
                SaveChannels();
            }
            else
            {
                MessageBox.Show("Not found any followed channels/Invalid Username/Network Error");
            }

        }
    }
}

using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchNotifier
{
    public partial class MainWindow : Form
    {

        static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string folder = appdata + "\\TwitchNotifier";
        static string usernames = folder + "\\usernames.txt";
        List<string> toCheck = new List<string>();

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            this.Visible = false;
        }

        static async Task<bool> IsOnline(string channel)
        {
            try
            {
                HttpClientHandler hcHandle = new HttpClientHandler();
                using (var hc = new HttpClient(hcHandle, false))
                {
                    hc.DefaultRequestHeaders.Add("Client-ID", "dmv33cb8zz000hq4y2a6coi0wc8zcl");
                    hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "");
                    hc.DefaultRequestHeaders.UserAgent.ParseAdd("Twitch Notifier");
                    hc.Timeout = TimeSpan.FromSeconds(5);

                    using (var response = await hc.GetAsync($"https://api.twitch.tv/helix/streams?user_login={channel}"))
                    {
                        response.EnsureSuccessStatusCode();
                        string jsonString = await response.Content.ReadAsStringAsync();
                        var r = JsonConvert.DeserializeObject<RootObject>(jsonString);

                        return !(r == default(RootObject) || r.data.Count == 0);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
                return false;
            }  
        }

        string lastLink = "";
        List<string> live = new List<string>();
        async void LiveCheck()
        {
            while (true)
            {
                await Task.Delay(5000);
                foreach (ListViewItem item in ListView_usernames.Items)
                {
                    var curNick = item.Text;
                    if (live.Contains(curNick)) continue;
                    bool isOnline = await IsOnline(curNick);
                    if (isOnline && !live.Contains(curNick))
                    {
                        live.Add(curNick);
                        notifyIcon1.ShowBalloonTip(2000, curNick + " is live!", "twitch.tv/" + curNick, ToolTipIcon.None);
                        lastLink = "https://www.twitch.tv/" + curNick;
                        await Task.Delay(7000);
                    }
                    if (!isOnline && live.Contains(curNick))
                    {
                        live.Remove(curNick);
                    }
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LiveCheck();

            try
            {
                if (!Directory.Exists(folder) || !File.Exists(usernames))
                {
                    Directory.CreateDirectory(folder);
                    File.Create(usernames);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Can't create folder in AppData to store information");
            }

            using (StreamReader sr = File.OpenText(usernames))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    ListView_usernames.Items.Add(s);
                }
            }

            notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, this.MenuExit_Click);
        }

        void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public class Datum
        {
            [JsonProperty("id")] public string ID { get; set; }
            [JsonProperty("userId")] public string user_id { get; set; }
            [JsonProperty("user_name")] public string user_name { get; set; }
            [JsonProperty("game_id")] public string game_id { get; set; }
            [JsonProperty("type")] public string type { get; set; }
            [JsonProperty("title")] public string title { get; set; }
            [JsonProperty("viewer_count")] public int viewer_count { get; set; }
            [JsonProperty("datetime")] public DateTime started_at { get; set; }
            [JsonProperty("language")] public string language { get; set; }
            [JsonProperty("thumb_url")] public string thumbnail_url { get; set; }
            [JsonProperty("tag_ids")] public List<string> tag_ids { get; set; }
        }

        public class Pagination
        {
            public string cursor { get; set; }
        }

        public class RootObject
        {
            public List<Datum> data { get; set; }
            public Pagination pagination { get; set; }
        }


        private void Button_add_Click(object sender, EventArgs e)
        {
            var username = Textbox_username.Text.Replace(" ", "");
            Match match = Regex.Match(username, @"^[a-zA-Z0-9_]{4,25}$");
            if (match.Success)
            {
                var item = new ListViewItem(username, 0);
                ListView_usernames.Items.Add(item);
                File.AppendAllText(usernames, username + Environment.NewLine);
                toCheck.Add(username);
            }
            else
            {
                MessageBox.Show("Incorrect username");
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (ListView_usernames.SelectedItems.Count > 0)
            {
                var toRemove = ListView_usernames.SelectedItems[0];
                if (live.Contains(toRemove.Text))
                    live.Remove(toRemove.Text);

                ListView_usernames.Items.Remove(toRemove);
                File.WriteAllText(usernames, "");
                toCheck.Clear();
                foreach (ListViewItem item in ListView_usernames.Items)
                {
                    File.AppendAllText(usernames, item.Text + Environment.NewLine);
                    toCheck.Add(item.Text);
                }             
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lastLink);
        }

        private void chk_startup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (chk_startup.Checked)
                registryKey.SetValue("ApplicationName", Application.ExecutablePath);
            else
                registryKey.DeleteValue("ApplicationName");
        }
    }
}

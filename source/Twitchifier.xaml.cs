using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using TwitchLib.Api;
using TwitchLib.Api.Events;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Twitchifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public List<Streamer> StreamerList = new List<Streamer>();
        public Dictionary<string, string> StreamerDict = new Dictionary<string, string>();
        public TwitchAPI TwitchAPI = new TwitchAPI();
        public int CheckDelay = 60;
        NotifyIcon notifyIcon = new NotifyIcon();
        string clickLink = "";

        public class Streamer
        {
            public string Image { get; set; }
            public string Username { get; set; }
            public string IsLive { get; set; }
            public string Category { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            StreamerTable.ItemsSource = StreamerList;
            StreamerTable.Items.Refresh();

            TwitchAPI.Settings.ClientId = "dmv33cb8zz000hq4y2a6coi0wc8zcl";
            TwitchAPI.Settings.AccessToken = "";
            
            notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon.Visible = true;
            notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(ShowMenu);

            LoadSettings();
            LiveCheck();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            GC.Collect();         
        }

        public async void LoadSettings()
        {
            try
            {
                chkStartMinimized.IsChecked = Properties.Settings.Default.StartMinimized;
                if (chkStartMinimized.IsChecked ?? false) this.Hide();
                DarkTheme.IsChecked = Properties.Settings.Default.DarkTheme;
                StartWithWindows.IsChecked = Properties.Settings.Default.StartWithWindows;
                CheckDelay = Properties.Settings.Default.Delay;

                TwitchAPI.Settings.AccessToken = Properties.Settings.Default.AccessToken;
                try
                {
                    var user = await TwitchAPI.V5.Users.GetUserAsync();
                    SnackBar($"Logged in as {user.DisplayName}");

                }
                catch (Exception)
                {
                    if (TwitchAPI.Settings.AccessToken != "")
                    {
                        TwitchAPI.Settings.AccessToken = "";
                        SnackBar("Invalid Access Token");
                    }
                }

                var usernames = Properties.Settings.Default.StreamerList;
                foreach (var username in usernames)
                {
                    AddStreamer(username, true);
                    await Task.Delay(100);
                }
            }
            catch (Exception) { }

            if (Properties.Settings.Default.StreamerList == null) Properties.Settings.Default.StreamerList = new List<string>();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            GC.Collect();
        }

        public async void LiveCheck()
        {
            while (true)
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                GC.Collect();

                var StreamerListCopy = new List<Streamer>();
                foreach (var item in StreamerList)
                {
                    StreamerListCopy.Add(item);
                }
                foreach (var streamer in StreamerListCopy)
                {
                    var userID = "";
                    if (StreamerDict.TryGetValue(streamer.Username, out userID)) {}
                    else
                    {
                        var user = await TwitchAPI.V5.Users.GetUserByNameAsync(streamer.Username);
                        userID = user.Matches[0].Id;
                    }

                    var isLive = await TwitchAPI.V5.Streams.BroadcasterOnlineAsync(userID);
                    if (isLive && streamer.IsLive == "No")
                    {
                        streamer.IsLive = "Yes";
                        var stream = await TwitchAPI.V5.Streams.GetStreamByUserAsync(userID);
                        var game = stream.Stream.Game;
                        if (game == "") game = "No category";
                        streamer.Category = game;
                        StreamerTable.Items.Refresh();

                        clickLink = "https://twitch.tv/" + streamer.Username;
                        notifyIcon.BalloonTipClicked += NotifyIcon_BalloonTipClicked;
                        notifyIcon.ShowBalloonTip(0, $"{streamer.Username} is live!", game, ToolTipIcon.None);
                        await Task.Delay(10000);
                        notifyIcon.BalloonTipClicked -= NotifyIcon_BalloonTipClicked;
                    }
                    else if (isLive && streamer.IsLive == "Yes")
                    {
                        var stream = await TwitchAPI.V5.Streams.GetStreamByUserAsync(userID);
                        var game = stream.Stream.Game;
                        streamer.Category = game;
                        StreamerTable.Items.Refresh();
                    }
                    else if (!isLive && streamer.IsLive == "Yes")
                    {
                        streamer.IsLive = "No";
                        streamer.Category = "";
                    }
                }
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                GC.Collect();

                await Task.Delay(CheckDelay * 1000);
            }
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Process.Start(clickLink);
        }

        public async void AddStreamer(string username, bool fromSettings)
        {
            TwitchLib.Api.V5.Models.Users.Users user;
            try
            {
                user = await TwitchAPI.V5.Users.GetUserByNameAsync(username);
            }
            catch (Exception)
            {
                SnackBar("Invalid username");
                return;
            }
            
            if (user.Matches.Length == 1)
            {
                try
                {
                    var streamer = new Streamer
                    {
                        Image = user.Matches[0].Logo.Replace("300x300", "70x70"),
                        Username = user.Matches[0].DisplayName,
                        Category = "",
                        IsLive = "No"
                    };

                    StreamerList.Add(streamer);
                    StreamerTable.Items.Refresh();
                }
                catch (Exception) {}
            }
            else
            {
                SnackBar("Invalid username");
                return;
            }

            if (!fromSettings)
            {
                try
                {
                    Properties.Settings.Default.StreamerList.Add(username);
                    Properties.Settings.Default.Save();
                }
                catch (Exception) {}

            }
        }

        public async void Import(string username)
        {
            var user = await TwitchAPI.V5.Users.GetUserByNameAsync(username);
            if (user.Matches.Length == 1)
            {
                var userID = user.Matches[0].Id;
                var userFollows = await TwitchAPI.V5.Users.GetUserFollowsAsync(userID);
                
                foreach (var userFollowed in userFollows.Follows)
                {
                    try
                    {
                        AddStreamer(userFollowed.Channel.Name, false);
                        StreamerTable.Items.Refresh();
                        await Task.Delay(50);
                    }
                    catch (Exception) {}
                }
            }
        }

        private async void AddStreamerClick(object sender, RoutedEventArgs e)
        {
            
            AddPages.SelectedIndex = 0;
            await Task.Delay(400);
            AddStreamer(AddUsername.Text, false);
        }

        private async void ImportClick(object sender, RoutedEventArgs e)
        {
            AddPages.SelectedIndex = 0;
            await Task.Delay(400);
            Import(ImportUsername.Text);
        }

        private void SetDelayClick(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckDelay = Convert.ToInt32(Delay.Text);
                Properties.Settings.Default.Delay = CheckDelay;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                SnackBar("Invalid value");
            }
            SettingsPages.SelectedIndex = 0;
        }

        private void SwitchTheme(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DarkTheme = DarkTheme.IsChecked ?? false;
            Properties.Settings.Default.Save();
            if (DarkTheme.IsChecked ?? false)
            {
                var dark = new MaterialDesignThemes.Wpf.BundledTheme();
                dark.BaseTheme = MaterialDesignThemes.Wpf.BaseTheme.Dark;
                dark.PrimaryColor = MaterialDesignColors.PrimaryColor.DeepPurple;
                dark.SecondaryColor = MaterialDesignColors.SecondaryColor.Lime;
                System.Windows.Application.Current.Resources.MergedDictionaries.Add(dark);
            }
            else
            {
                var light = new MaterialDesignThemes.Wpf.BundledTheme();
                light.BaseTheme = MaterialDesignThemes.Wpf.BaseTheme.Light;
                light.PrimaryColor = MaterialDesignColors.PrimaryColor.DeepPurple;
                light.SecondaryColor = MaterialDesignColors.SecondaryColor.Lime;
                System.Windows.Application.Current.Resources.MergedDictionaries.Add(light);
            }
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamerList.RemoveAt(StreamerTable.SelectedIndex);
                StreamerTable.Items.Refresh();

                var usernameList = new List<string>();
                foreach (var streamer in StreamerList)
                {
                    usernameList.Add(streamer.Username);
                }
                Properties.Settings.Default.StreamerList = usernameList;
                Properties.Settings.Default.Save();
            }
            catch (Exception) {}

        }

        private void Visit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://twitch.tv/" + StreamerList[StreamerTable.SelectedIndex].Username);
            }
            catch (Exception) {}
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            WindowStyle = WindowStyle.SingleBorderWindow;

            if (WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;

            WindowStyle = WindowStyle.None;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowStyle = WindowStyle.SingleBorderWindow;
            WindowState = WindowState.Minimized;
            WindowStyle = WindowStyle.None;
        }

        public void AddStreamersPage(object sender, RoutedEventArgs e)
        {
            var srcButton = e.Source as System.Windows.Controls.Button;
            var btnName = srcButton.Name;

            if (btnName == "AddByUsername") AddPages.SelectedIndex = 1;
            else if (btnName == "ImportFromFollowing") AddPages.SelectedIndex = 2;
            else AddPages.SelectedIndex = 0;
        }

        public void SettingsPage(object sender, RoutedEventArgs e)
        {
            var srcButton = e.Source as System.Windows.Controls.Button;
            var btnName = srcButton.Name;

            if (btnName == "SetDelay") SettingsPages.SelectedIndex = 1;
            else if (btnName == "LoginToTwitch") SettingsPages.SelectedIndex = 2;
            else SettingsPages.SelectedIndex = 0;
        }

        private void StartWithWindows_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (StartWithWindows.IsChecked ?? false) registryKey.SetValue("Twitchifier 3", Assembly.GetExecutingAssembly().Location);
            else registryKey.DeleteValue("Twitchifier 3");

            Properties.Settings.Default.StartWithWindows = StartWithWindows.IsChecked ?? false;
            Properties.Settings.Default.Save();
        }

        public void ShowMenu(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Windows.Controls.ContextMenu menu = (System.Windows.Controls.ContextMenu)this.FindResource("Menu");
            menu.IsOpen = true;
        }

        private void MenuShow(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void MenuExit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public async void SnackBar(string text)
        {
            this.Dispatcher.Invoke(() =>
            {
                snackbar.Message.Content = text;
                snackbar.IsActive = true;           
            });
            await Task.Delay(4000);
            this.Dispatcher.Invoke(() =>
            {
                snackbar.IsActive = false;
            });
        }

        private void StartMinimized_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.StartMinimized = chkStartMinimized.IsChecked ?? false;
            Properties.Settings.Default.Save();
        }

        private async void TwitchLogin(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                TwitchAPI.ThirdParty.AuthorizationFlow.OnUserAuthorizationDetected += AuthorizationFlow_OnUserAuthorizationDetected;
                TwitchAPI.ThirdParty.AuthorizationFlow.OnError += AuthorizationFlow_OnError;

                var scopes = new List<TwitchLib.Api.Core.Enums.AuthScopes>() { TwitchLib.Api.Core.Enums.AuthScopes.User_Read };
                var flow = TwitchAPI.ThirdParty.AuthorizationFlow.CreateFlow("Twitchifier", scopes);
                Process.Start(flow.Url);
                TwitchAPI.ThirdParty.AuthorizationFlow.BeginPingingStatus(flow.Id, 5000);
            });
        }

        private void AuthorizationFlow_OnError(object sender, OnAuthorizationFlowErrorArgs e)
        {
            SnackBar("Something went wrong");
        }

        private void AuthorizationFlow_OnUserAuthorizationDetected(object sender, OnUserAuthorizationDetectedArgs e)
        {
            SnackBar($"Successfully logged in as {e.Username}");
            TwitchAPI.Settings.AccessToken = e.Token;
            Properties.Settings.Default.AccessToken = e.Token;
            Properties.Settings.Default.Save();
        }

        private void StreamerTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StreamerTable.SelectedIndex = -1;
        }
    }
}

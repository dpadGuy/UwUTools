using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using UwUTools_Prototype.WinForms.Emulator_Sections;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Net;

namespace UwUTools_Prototype.WinForms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        // Download progress code taken from Galactic Tools V3 (https://github.com/GalacticTools/GalacticToolsV3)
        public void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double receive = double.Parse(e.BytesReceived.ToString());
            double total = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = receive / total * 100;

            Invoke(new MethodInvoker(delegate ()
            {
                guna2ProgressBar1.Minimum = 0;
                guna2ProgressBar1.Text = $"{string.Format("{0:0#}", percentage)}%";
                guna2ProgressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            }));
        }
        private void notificationSwitch_CheckedChanged(object sender, EventArgs e)
        {
            string filePath = @"C:\UwUTools\config.txt";
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                lines = new string[1];
            }

            if (notificationSwitch.Checked == true)
            {
                lines[0] = "Notifications=Yes";
            }
            else if (notificationSwitch.Checked == false)
            {
                lines[0] = "Notifications=No";
            }

            File.WriteAllLines(filePath, lines);
        }
        private async void Settings_Load(object sender, EventArgs e)
        {
            string txtFile = @"C:\UwUTools\Config.txt";
            string notificationOn = "Notifications=Yes";
            string notificationOff = "Notifications=Off";
            string fileContent = File.ReadAllText(txtFile);

            if (fileContent.Contains(notificationOn))
            {
                notificationSwitch.Checked = true;
            }
            else if (fileContent.Contains(notificationOff))
            {
                notificationSwitch.Checked = false;
            }

            Opacity = 0;
            await Task.Delay(200);
            timer1.Start();
        }

        private void appsSection_Click(object sender, EventArgs e)
        {
            Apps apps = new Apps();
            apps.StartPosition = FormStartPosition.Manual;
            apps.Location = this.Location;
            apps.Show();
            this.Close();
        }

        private void emulartorsSection_Click(object sender, EventArgs e)
        {
            Emulators emulators = new Emulators();
            emulators.StartPosition = FormStartPosition.Manual;
            emulators.Location = this.Location;
            emulators.Show();
            this.Close();
        }
        private void welcomeSection_Click(object sender, EventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.StartPosition = FormStartPosition.Manual;
            welcomePage.Location = this.Location;
            welcomePage.Show();
            this.Close();
        }
        private async void gamesSection_Click(object sender, EventArgs e)
        {
            Coming_Soon form1 = new Coming_Soon();
            form1.StartPosition = FormStartPosition.CenterParent;
            form1.Location = this.Location;
            await Task.Delay(100);
            form1.ShowDialog();
        }

        private async void unknownSection_Click(object sender, EventArgs e)
        {
            Coming_Soon form1 = new Coming_Soon();
            form1.StartPosition = FormStartPosition.CenterParent;
            form1.Location = this.Location;
            await Task.Delay(100);
            form1.ShowDialog();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .10;
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            //WebClient webClient = new WebClient();
            //webClient.DownloadFileTaskAsync(new Uri("");
            //webClient.DownloadProgressChanged += DownloadProgressChanged;
            //webClient.DownloadFileCompleted += (s, args) =>
            //{
            //    Process.Start(@"C:\UwUTools\UwUTools Updater.exe");
            //    Application.Exit();
            //};

            Coming_Soon form1 = new Coming_Soon();
            form1.StartPosition = FormStartPosition.CenterParent;
            form1.Location = this.Location;
            await Task.Delay(100);
            form1.ShowDialog();
        }
    }
}

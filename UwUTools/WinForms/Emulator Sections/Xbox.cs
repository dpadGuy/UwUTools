using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using UwUTools_Prototype.WinForms;
using UwUTools_Prototype.WinForms.Emulator_Sections;
using Guna.UI2.WinForms;

namespace UwUTools_Prototype.WinForms.Emulator_Sections
{
    public partial class Xbox : Form
    {
        public Xbox()
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
        private void ZipDownloadProcess(string exePath, string link, string appZip, string appPath, string Choice, string UwUToolsPath)
        {
            string txtFile = @"C:\UwUTools\Config.txt";
            string notificationOn = "Notifications=Yes";
            string notificationOff = "Notifications=Off";
            string fileContent = File.ReadAllText(txtFile);

            if (File.Exists(exePath))
            {
                Process.Start(exePath);
            }
            else
            {
                Directory.CreateDirectory(Choice);
                SuccessNotification notification = new SuccessNotification();

                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += DownloadProgressChanged;
                webClient.DownloadFileAsync(new Uri(link), appZip);
                webClient.DownloadFileCompleted += (s, args) =>
                {
                    if (Directory.Exists(@"C:\UwUTools\Choices\No"))
                    {
                        Directory.Delete(@"C:\UwUTools\Choices\No");
                        ZipFile.ExtractToDirectory(appZip, UwUToolsPath);
                        File.Delete(appZip);
                    }
                    else if (Directory.Exists(@"C:\UwUTools\Choices\Yes"))
                    {
                        Directory.Delete(@"C:\UwUTools\Choices\Yes");
                        Directory.CreateDirectory(appPath);
                        ZipFile.ExtractToDirectory(appZip, appPath);
                        File.Delete(appZip);
                    }

                    if (fileContent.Contains(notificationOn))
                    {
                        notification.showAlert("Success message", SuccessNotification.enmType.Success);
                    }
                    else if (fileContent.Contains(notificationOff))
                    {

                    }

                    Process.Start(exePath);
                };
            }
        }
        private async void Xbox_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            string PathFolder = @"C:/UwUTools";
            Directory.CreateDirectory(PathFolder);
            await Task.Delay(200);
            timer1.Start();
        }
        private void welcomeSection_Click(object sender, EventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.StartPosition = FormStartPosition.Manual;
            welcomePage.Location = this.Location;
            welcomePage.Show();
            this.Opacity = 0;
            this.Close();
        }

        private void appsSection_Click(object sender, EventArgs e)
        {
            Apps apps = new Apps();
            apps.StartPosition = FormStartPosition.Manual;
            apps.Location = this.Location;
            apps.Show();
            this.Opacity = 0;
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

        private void settingsSection_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.StartPosition = FormStartPosition.Manual;
            settings.Location = this.Location;
            settings.Show();
            this.Opacity = 0;
            this.Close();
        }

        private void playstationSection_Click(object sender, EventArgs e)
        {
            Playstation playstation = new Playstation();
            playstation.StartPosition = FormStartPosition.Manual;
            playstation.Location = this.Location;
            playstation.Show();
            this.Opacity = 0;
            this.Close();
        }
        private void emulatorsSection_Click(object sender, EventArgs e)
        {
            Emulators emulators = new Emulators();
            emulators.StartPosition = FormStartPosition.Manual;
            emulators.Location = this.Location;
            emulators.Show();
            this.Opacity = 0;
            this.Close();
        }

        private void nintendoSection_Click(object sender, EventArgs e)
        {
            Emulators emulators = new Emulators();
            emulators.StartPosition = FormStartPosition.Manual;
            emulators.Location = this.Location;
            emulators.Show();
            this.Opacity = 0;
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .10;
        }

        private void xemuDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/xemu-project/xemu/releases/latest/download/xemu-win-release.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\xemu-win-release.zip";
            string exePath = @"C:\UwUTools\Xemu\Xemu.exe";
            string appPath = @"C:\UwUTools\Xemu";
            string Choice = @"C:\UwUTools\Choices\Yes";

            xemuDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void xeniaDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/xenia-project/release-builds-windows/releases/latest/download/xenia_master.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\xenia_master.zip";
            string exePath = @"C:\UwUTools\Xenia\Xenia.exe";
            string appPath = @"C:\UwUTools\Xenia";
            string Choice = @"C:\UwUTools\Choices\Yes";

            xeniaDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }
    }
}

using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using UwUTools_Prototype.WinForms;
using UwUTools_Prototype.WinForms.Emulator_Sections;

namespace UwUTools_Prototype.WinForms
{
    public partial class Playstation : Form
    {
        public Playstation()
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
        private async void Playstation_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            string PathFolder = @"C:/UwUTools";
            Directory.CreateDirectory(PathFolder);
            await Task.Delay(200);
            timer1.Start();
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

        private void emulatorsSection_Click(object sender, EventArgs e)
        {
            Emulators emulators = new Emulators();
            emulators.StartPosition = FormStartPosition.Manual;
            emulators.Location = this.Location;
            emulators.Show();
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

        private void nintendoSection_Click(object sender, EventArgs e)
        {
            Emulators emulators = new Emulators();
            emulators.StartPosition = FormStartPosition.Manual;
            emulators.Location = this.Location;
            emulators.Show();
            this.Opacity = 0;
            this.Close();
        }
        private void xboxSection_Click(object sender, EventArgs e)
        {
            Xbox xbox = new Xbox();
            xbox.StartPosition = FormStartPosition.Manual;
            xbox.Location = this.Location;
            xbox.Show();
            this.Opacity = 0;
            this.Close();
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

        private void duckstationDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/stenzek/duckstation/releases/download/latest/duckstation-windows-x64-release.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\duckstation-windows-x64-release.zip";
            string exePath = @"C:\UwUTools\DuckStation\duckstation-qt-x64-ReleaseLTCG.exe";
            string appPath = @"C:\UwUTools\DuckStation";
            string Choice = @"C:\UwUTools\Choices\Yes";

            duckstationDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void pcsxDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/PCSX2.1.6.0.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\PCSX2.1.6.0.zip";
            string exePath = @"C:\UwUTools\PCSX2 1.6.0\pcsx2.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            pcsxDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void ppssppDownload_Click(object sender, EventArgs e)
        {
            string link = "https://www.ppsspp.org/files/1_17_1/ppsspp_win.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\ppsspp_win.zip";
            string exePath = @"C:\UwUTools\PPSSPP\PPSSPPWindows64.exe";
            string appPath = @"C:\UwUTools\PPSSPP";
            string Choice = @"C:\UwUTools\Choices\Yes";

            ppssppDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void rpcsDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/rpcs3.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\rpcs3.zip";
            string exePath = @"C:\UwUTools\rpcs3\rpcs3.exe";
            string appPath = @"C:\UwUTools\rpcs3";
            string Choice = @"C:\UwUTools\Choices\No";

            rpcsDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }
    }
}

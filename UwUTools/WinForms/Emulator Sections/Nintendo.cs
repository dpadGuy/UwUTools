using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using UwUTools_Prototype.WinForms.Emulator_Sections;
using UwUTools_Prototype.WinForms;

namespace UwUTools_Prototype
{
    public partial class Emulators : Form
    {
        public Emulators()
        {
            InitializeComponent();
            this.Load += Form1_Load;
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
        private async void Form1_Load(object sernder, EventArgs e) //yessir
        {
            Opacity = 0;
            string PathFolder = @"C:/UwUTools";
            Directory.CreateDirectory(PathFolder);
            await Task.Delay(150);
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
        private void xboxSection_Click(object sender, EventArgs e)
        {
            Xbox xbox = new Xbox();
            xbox.StartPosition = FormStartPosition.Manual;
            xbox.Location = this.Location;
            xbox.Show();
            this.Opacity = 0;
            this.Close();
        }
        private void playstastionSection_Click(object sender, EventArgs e)
        {
            Playstation playstation = new Playstation();
            playstation.StartPosition = FormStartPosition.Manual;
            playstation.Location = this.Location;
            playstation.Show();
            this.Opacity = 0;
            this.Close();
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

        private void suyuDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/suyu-windows-mingw-20240410-0de49070e4.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\suyu-windows-mingw-20240410-0de49070e4.zip";
            string exePath = @"C:\UwUTools\suyu-windows-mingw-20240410-0de49070e4_\suyu.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            suyuDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void dolphinDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/Dolphin-x64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\Dolphin-x64.zip";
            string exePath = @"C:\UwUTools\Dolphin-x64\dolphin.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            dolphinDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void desmumeDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/TASEmulators/desmume/releases/download/release_0_9_13/desmume-0.9.13-win64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\desmume-0.9.13-win64.zip";
            string exePath = @"C:\UwUTools\DeSmuME\DeSmuME_0.9.13_x64.exe";
            string appPath = @"C:\UwUTools\DeSmuME";
            string Choice = @"C:\UwUTools\Choices\Yes";

            desmumeDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void mgbaDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/mGBA-0.10.3-win64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\mGBA-0.10.3-win64.zip";
            string exePath = @"C:\UwUTools\mGBA-0.10.3-win64\mGBA.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            mgbaDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void projectDownload_Click(object sender, EventArgs e)
        {
            string link = "https://www.pj64-emu.com/file/project64-dev-4-0-0-6365-e7178db/";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\Project64-Dev-4.0.0-6365-e7178db.zip";
            string exePath = @"C:\UwUTools\Project64\Project64.exe";
            string appPath = @"C:\UwUTools\Project64";
            string Choice = @"C:\UwUTools\Choices\Yes";

            projectDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void mesenDownload_Click(object sender, EventArgs e)
        {
            string link = "https://nightly.link/SourMesen/Mesen2/workflows/build/master/Mesen%20%28Windows%20-%20net8.0%29.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\Mesen.zip";
            string exePath = @"C:\UwUTools\Mesen\Mesen.exe";
            string appPath = @"C:\UwUTools\Mesen";
            string Choice = @"C:\UwUTools\Choices\Yes";

            mesenDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void retroarchDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/RetroArch-Win64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\RetroArch-Win64.zip";
            string exePath = @"C:\UwUTools\RetroArch-Win64\retroarch.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            retroarchDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void snesxDownload_Click(object sender, EventArgs e)
        {
            string link = "https://dl.emulator-zone.com/download.php/emulators/snes/snes9x/snes9x-1.62.3-win32-x64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\Snes9x.zip";
            string exePath = @"C:\UwUTools\Snes9x\Snes9x-x64.exe";
            string appPath = @"C:\UwUTools\Snes9x";
            string Choice = @"C:\UwUTools\Choices\Yes";

            snesxDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void citraDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/PabloMK7/citra/releases/download/r64e3e9f/citra-windows-msvc-20240516-64e3e9f.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\citra-windows-msvc-20240516-64e3e9f.zip";
            string exePath = @"C:\UwUTools\citra-windows-msvc-20240516-64e3e9f\citra-qt.exe";
            string appPath = @"C:\UwUTools\";
            string Choice = @"C:\UwUTools\Choices\No";

            citraDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }
    }
}

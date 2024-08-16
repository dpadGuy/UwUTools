using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using UwUTools_Prototype.WinForms;
using UwUTools_Prototype;
using System.Drawing;
using static System.Windows.Forms.LinkLabel;
using System.Windows.Documents;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using Guna.UI2.WinForms;
using UwUTools_Prototype.WinForms.Messages;
using System.Runtime.InteropServices;

namespace UwUTools_Prototype
{
    public partial class Apps : Form
    {
        // Import the FindWindow function from user32.dll
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Import the PostMessage function from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // Constants for Windows messages
        private const uint WM_CLOSE = 0x0010;

        public Apps()
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
        private async void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            string PathFolder = @"C:/UwUTools";
            Directory.CreateDirectory(PathFolder);
            await Task.Delay(100);
            timer1.Start();
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
        private void welcomeSection_Click(object sender, EventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.StartPosition = FormStartPosition.Manual;
            welcomePage.Location = this.Location;
            welcomePage.Show();
            this.Opacity = 0;
            this.Close();
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .10;
        }
        private void exeDownloadProcess(string exePath, string link, string appPath)
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
                Directory.CreateDirectory(appPath);
                SuccessNotification notification = new SuccessNotification();
                WebClient webClient = new WebClient();
                webClient.DownloadProgressChanged += DownloadProgressChanged;
                webClient.DownloadFileAsync(new Uri(link), exePath);
                webClient.DownloadFileCompleted += (s, args) =>
                {
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

        private void explorerDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/Explorer++.exe";
            string appPath = @"C:\UwUTools\Explorer++";
            string exePath = @"C:\UwUTools\Explorer++\Explorer++.exe";

            explorerDownload.Text = "Open";

            exeDownloadProcess(exePath, link, appPath);
        }

        private async void phDownload_Click(object sender, EventArgs e)
        {
            ProcessHacker processhacker = new ProcessHacker();
            processhacker.StartPosition = FormStartPosition.CenterParent;
            processhacker.Location = this.Location;
            await Task.Delay(100);
            processhacker.ShowDialog();
        }

        private void sevenzipDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/7-Zip.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\7-Zip.zip";
            string exePath = @"C:\UwUTools\7-Zip\7zFM.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\Yes";

            sevenzipDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void firefoxDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/MozillaFirefox.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\MozillaFirefox.zip";
            string exePath = @"C:\UwUTools\Mozilla Firefox\firefox.exe";
            string appPath = @"C:\UwUTools\";
            string Choice = @"C:\UwUTools\Choices\No";

            firefoxDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void qbittorrentDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/qBittorrent.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\qBittorrent.zip";
            string exePath = @"C:\UwUTools\qBittorrent\qBittorrent.exe";
            string appPath = @"C:\UwUTools\";
            string Choice = @"C:\UwUTools\Choices\No";

            qbittorrentDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void Parsec_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/Parsec.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\parsec-flat-windows.zip";
            string exePath = @"C:\UwUTools\Parsec\Parsec.lnk";
            string appPath = @"C:\UwUTools\Parsec";
            string Choice = @"C:\UwUTools\Choices\Yes";

            parsecDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void anydeskDownload_Click(object sender, EventArgs e)
        {
            string link = "https://download.anydesk.com/AnyDesk.exe";
            string appPath = @"C:\UwUTools\Anydesk";
            string exePath = @"C:\UwUTools\Anydesk\Anydesk.exe";

            anydeskDownload.Text = "Open";

            exeDownloadProcess(exePath, link, appPath);
        }

        private void notepadDownload_Click(object sender, EventArgs e)
        {
            string link = "https://www.flos-freeware.ch/zip/notepad2_4.2.25_x64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\notepad2_4.2.25_x64.zip";
            string exePath = @"C:\UwUTools\Notepad2\Notepad2.exe";
            string appPath = @"C:\UwUTools\Notepad2";
            string Choice = @"C:\UwUTools\Choices\Yes";

            notepadDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void NotepadPlusDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v8.6.5/npp.8.6.5.portable.x64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\npp.8.6.5.portable.x64.zip";
            string exePath = @"C:\UwUTools\Notepad++\Notepad++.exe";
            string appPath = @"C:\UwUTools\Notepad++";
            string Choice = @"C:\UwUTools\Choices\Yes";

            NotepadPlusDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void obsDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/OBS-Studio-30.1.1.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\OBS-Studio-30.1.1.zip";
            string exePath = @"C:\UwUTools\OBS\bin\64bit\OBS.lnk";
            string appPath = @"C:\UwUTools\OBS";
            string Choice = @"C:\UwUTools\Choices\Yes";

            obsDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void blenderDownload_Click(object sender, EventArgs e)
        {
            string link = "https://mirrors.sahilister.in/blender/release/Blender4.1/blender-4.1.1-windows-x64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\blender-4.1.1-windows-x64.zip";
            string exePath = @"C:\UwUTools\blender-4.1.1-windows-x64\blender.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            blenderDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void vscodeDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/Microsoft.VS.Code.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\Microsoft-VS-Code.zip";
            string exePath = @"C:\UwUTools\Microsoft VS Code\code.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            vscodeDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void sublimeDownload_Click(object sender, EventArgs e)
        {
            string link = "https://download.sublimetext.com/sublime_text_build_4169_x64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\sublime_text_build_4169_x64.zip";
            string exePath = @"C:\UwUTools\Sublime\sublime_text.exe";
            string appPath = @"C:\UwUTools\Sublime";
            string Choice = @"C:\UwUTools\Choices\Yes";

            sublimeDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void furmarkDownload_Click(object sender, EventArgs e)
        {
            string link = "https://geeks3d.com/downloads/2024p/furmark2/FurMark_2.3.0.0_win64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\FurMark_2.3.0.0_win64.zip";
            string exePath = @"C:\UwUTools\FurMark_win64\FurMark_GUI.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            furmarkDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void heroicDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/Heroic.Launcher.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\Heroic.Launcher.zip";
            string exePath = @"C:\UwUTools\Heroic Launcher\heroic.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            if (File.Exists(exePath))
            {
                Process.Start(exePath);
                return;
            }

            DialogResult result = MessageBox.Show("Heroic Launcher does not work on geforce now ERROR(0x80030017), do you wish to continue ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

            }
            else if (result == DialogResult.No)
            {
                return;
            }

            heroicDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void gimpDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/GIMP.2.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\GIMP.2.zip";
            string exePath = @"C:\UwUTools\GIMP 2\bin\gimp-2.10.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            gimpDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void sharexDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/ShareX/ShareX/releases/download/v16.1.0/ShareX-16.1.0-portable.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\ShareX-16.1.0-portable.zip";
            string exePath = @"C:\UwUTools\ShareX\ShareX.exe";
            string appPath = @"C:\UwUTools\ShareX";
            string Choice = @"C:\UwUTools\Choices\Yes";

            sharexDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private async void exerunButton_Click(object sender, EventArgs e)
        {
            ExeRunner exeRunner = new ExeRunner();
            exeRunner.StartPosition = FormStartPosition.CenterParent;
            exeRunner.Location = this.Location;
            await Task.Delay(100);
            exeRunner.ShowDialog();
        }

        private void chromiumDownload_Click(object sender, EventArgs e)
        {
            string link = "https://download-chromium.appspot.com/dl/Win_x64?type=snapshots";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\chrome-win.zip";
            string exePath = @"C:\UwUTools\chrome-win\chrome.exe";
            string appPath = @"C:\UwUTools\";
            string Choice = @"C:\UwUTools\Choices\No";

            chromiumDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }
        private void fdmDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/Free.Download.Manager.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\FreeDownloadManager.zip";
            string exePath = @"C:\UwUTools\Free Download Manager\fdm.exe";
            string appPath = @"C:\UwUTools\";
            string Choice = @"C:\UwUTools\Choices\No";

            fdmDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }
        private void powershellDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/PowerShell/PowerShell/releases/download/v7.4.3/PowerShell-7.4.3-win-x86.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\PowerShell-7.4.3-win-x86.zip";
            string exePath = @"C:\UwUTools\PowerShell\pwsh.exe";
            string appPath = @"C:\UwUTools\PowerShell";
            string Choice = @"C:\UwUTools\Choices\Yes";

            powershellDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void discordDownload_Click(object sender, EventArgs e)
        {
            string directory = "Discord";
            string fileName = "Update.exe";
            string arguments = "--processStart Discord.exe";
            string link = "https://dl.discordapp.net/distro/app/stable/win/x86/1.0.9048/DiscordSetup.exe";
            string appPath = @"C:\UwUTools\Discord";
            string exePath = @"C:\UwUTools\Discord\DiscordSetup.exe";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(appDataPath, directory, fileName);

            if (File.Exists(filePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(filePath, arguments);

                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                // Create a new process and assign the ProcessStartInfo
                Process process = new Process();
                process.StartInfo = startInfo;

                // Start the process
                process.Start();

                return;
            }

            explorerDownload.Text = "Open";

            exeDownloadProcess(exePath, link, appPath);
        }

        private void desktopButton_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/WinXShell_x64.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\WinXShell_x64.zip";
            string exePath = @"C:\UwUTools\WinXShell_x64\WinXShell.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            // Find the window handle by window title
            IntPtr hWnd = FindWindow(null, "CustomExplorer");

            // Check if the window handle is valid
            if (hWnd != IntPtr.Zero)
            {
                // Send the WM_CLOSE message to the window
                PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
            else
            {
                Process[] processes = Process.GetProcessesByName("Explorer");

                foreach (Process process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void sysinfoDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/SystemInformer.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\SystemInformer.zip";
            string exePath = @"C:\UwUTools\amd64\SystemInformer.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            sysinfoDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void regscannerDownload_Click(object sender, EventArgs e)
        {
            string link = "https://www.nirsoft.net/utils/regscanner.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\regscanner.zip";
            string exePath = @"C:\UwUTools\regscanner\RegScanner.exe";
            string appPath = @"C:\UwUTools\regscanner";
            string Choice = @"C:\UwUTools\Choices\Yes";

            regscannerDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void ooregDownload_Click(object sender, EventArgs e)
        {
            string link = "https://dl5.oo-software.com/files/ooregeditor12/120/ooregeditor.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\ooregeditor.zip";
            string exePath = @"C:\UwUTools\ooregeditor\OORegEdt.exe";
            string appPath = @"C:\UwUTools\ooregeditor";
            string Choice = @"C:\UwUTools\Choices\Yes";
            
            ooregDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }
    }
}

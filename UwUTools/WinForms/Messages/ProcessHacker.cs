using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace UwUTools_Prototype.WinForms.Messages
{
    public partial class ProcessHacker : Form
    {
        public ProcessHacker()
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

        private async void ProcessHacker_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            await Task.Delay(200);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .20;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phDownload_Click(object sender, EventArgs e)
        {
            string link = "https://picteon.dev/files/ProcessHacker.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\ProcessHacker.zip";
            string exePath = @"C:\UwUTools\ProcessHacker\ProcessHacker.exe";
            string appPath = @"C:\UwUTools";
            string Choice = @"C:\UwUTools\Choices\No";

            phDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }

        private void terminatorDownload_Click(object sender, EventArgs e)
        {
            string link = "https://github.com/dpadGuy/UwUToolsSoftware/releases/download/Files/ProcessHackerTerminator.zip";
            string UwUToolsPath = @"C:\UwUTools";
            string appZip = @"C:\UwUTools\ProcessHackerTerminator.zip";
            string exePath = @"C:\UwUTools\ProcessHackerTerminator\ProcessHacker.exe";
            string appPath = @"C:\UwUTools\ProcessHackerTerminator";
            string Choice = @"C:\UwUTools\Choices\Yes";

            terminatorDownload.Text = "Open";

            ZipDownloadProcess(exePath, link, appZip, appPath, Choice, UwUToolsPath);
        }
    }
}

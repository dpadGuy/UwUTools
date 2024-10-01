using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Net;
using System.IO.Compression;
using System.Windows.Documents;

namespace UwUTools_Prototype.WinForms.Messages
{
    public partial class ExeRunner : Form
    {
        public ExeRunner()
        {
            InitializeComponent();
        }

        private void NotificationSuccess()
        {
                var successNotification = new SuccessNotification();
                successNotification.showAlert("Success message", SuccessNotification.enmType.Success);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .20;
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

        private void UnzippingProgress(int extractedFiles, int totalFiles)
        {
            double percentage = (double)extractedFiles / totalFiles * 100;

            Invoke(new MethodInvoker(delegate ()
            {
                guna2ProgressBar2.Minimum = 0;
                guna2ProgressBar2.Text = $"{string.Format("{0:0#}", percentage)}%";
                guna2ProgressBar2.Value = (int)Math.Truncate(percentage);
            }));
        }

        private void explorerDownload_Click(object sender, EventArgs e)
        {
            string exePath = guna2TextBox1.Text;

            try
            {
                Process.Start(exePath);
            }
            catch (Exception)
            {

            }
        }
        private async void ExeRunner_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            await Task.Delay(200);
            timer1.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string processName = guna2TextBox2.Text;
            string exePath = null;

            foreach (var process in Process.GetProcessesByName(processName))
            {
                try
                {
                    exePath = process.MainModule.FileName;
                    process.Kill();
                }
                catch (Win32Exception)
                {
                    continue;
                }
            }

            Process.Start(exePath);

            return;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string processName = guna2TextBox3.Text;

            foreach (var process in Process.GetProcessesByName(processName))
            {
                try
                {
                    process.Kill();
                }
                catch (Win32Exception)
                {
                    continue;
                }
            }
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            string downloadLink = guna2TextBox4.Text;
            string path = guna2TextBox5.Text;
            string fileName = guna2TextBox6.Text;
            string uwutoolsPath = @"C:\UwUTools\Downloads\";
            string exeName = Path.GetFileName(new Uri(downloadLink).AbsolutePath);
            string finalPath = Path.Combine(uwutoolsPath, exeName);
            string finalFile = Path.Combine(path, fileName);

            WebClient webClient = new WebClient();

            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    Directory.CreateDirectory(uwutoolsPath);

                    webClient.DownloadProgressChanged += DownloadProgressChanged;
                    await webClient.DownloadFileTaskAsync(new Uri(downloadLink), uwutoolsPath + exeName);

                    if (Path.GetExtension(finalPath).ToLower() == ".exe")
                    {
                        Process.Start(finalPath);
                        NotificationSuccess();
                    }
                    else
                    {
                        MessageBox.Show("The file you just downloaded failed to open, you might need to take a look at it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    Directory.CreateDirectory(path);

                    webClient.DownloadProgressChanged += DownloadProgressChanged;
                    await webClient.DownloadFileTaskAsync(new Uri(downloadLink), finalFile);

                    if (Path.GetExtension(finalFile).ToLower() == ".exe")
                    {
                        Process.Start(finalFile);
                        NotificationSuccess();
                    }
                    else
                    {
                        MessageBox.Show("The file you just downloaded failed to open, you might need to take a look at it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void unzipperButton_Click(object sender, EventArgs e)
        {
            string zipPath = guna2TextBox9.Text;
            string zipExtractPath = guna2TextBox8.Text;

            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    int totalFiles = archive.Entries.Count;
                    int extractedFiles = 0;

                    await Task.Run(() =>
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string destinationPath = Path.Combine(zipExtractPath, entry.FullName);

                            if (entry.FullName.EndsWith("/"))
                            {
                                Directory.CreateDirectory(destinationPath);
                            }
                            else
                            {
                                entry.ExtractToFile(destinationPath, true);
                            }

                            extractedFiles++;
                            UnzippingProgress(extractedFiles, totalFiles);
                        }
                    });

                    NotificationSuccess();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

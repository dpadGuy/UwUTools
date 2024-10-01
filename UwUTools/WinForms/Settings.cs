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
using System.Management;
using Microsoft.Win32;

namespace UwUTools_Prototype.WinForms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            GetSpecs();
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
        private void specscopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label6.Text);
        }

        private void dxdiagButton_Click(object sender, EventArgs e)
        {
            Process.Start("dxdiag");
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
            string darkmodeOn = "WinDarkMode=Yes";
            string darkmodeOff = "WinDarkMode=No";
            string fileContent = File.ReadAllText(txtFile);

            if (fileContent.Contains(notificationOn))
            {
                notificationSwitch.Checked = true;
            }
            else if (fileContent.Contains(notificationOff))
            {
                notificationSwitch.Checked = false;
            }

            if (fileContent.Contains(darkmodeOn))
            {
                windarkmodeSwitch.Checked = true;
            }
            else if (fileContent.Contains(darkmodeOff))
            {
                windarkmodeSwitch.Checked = false;
            }

            Opacity = 0;
            await Task.Delay(200);
            timer1.Start();
        }

        private async void GetSpecs()
        {
            StringBuilder specs = new StringBuilder();

            await Task.Run(() =>
            {
                // Get CPU Information
                ManagementObjectSearcher cpuSearcher = new ManagementObjectSearcher("select * from Win32_Processor");
                foreach (ManagementObject obj in cpuSearcher.Get())
                {
                    specs.AppendLine("CPU: " + obj["Name"] + ", " + obj["NumberOfLogicalProcessors"] + " Cores");
                }

                // Get GPU Information
                ManagementObjectSearcher gpuSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");
                foreach (ManagementObject obj in gpuSearcher.Get())
                {
                    specs.AppendLine("GPU: " + obj["Name"] + ", VRAM: " + (Convert.ToInt64(obj["AdapterRAM"]) / 1024 / 1024 / 1024) + " GB");
                }

                // Get RAM Information
                ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("select * from Win32_PhysicalMemory");
                foreach (ManagementObject obj in ramSearcher.Get())
                {
                    specs.AppendLine("RAM Capacity: " + (Convert.ToInt64(obj["Capacity"]) / 1024 / 1024 / 1024) + " GB" + ", Speed: " + obj["Speed"] + " MHz");
                }

                // Get Disk Information
                ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");
                foreach (ManagementObject obj in diskSearcher.Get())
                {
                    specs.AppendLine("Disk Model: " + obj["Model"] + ", Disk Size: " + (Convert.ToInt64(obj["Size"]) / 1024 / 1024 / 1024) + " GB");
                }

                // Get OS Information
                ManagementObjectSearcher osSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject obj in osSearcher.Get())
                {
                    specs.AppendLine("OS Name: " + obj["Caption"]);
                    specs.AppendLine("Version: " + obj["Version"]);
                    specs.AppendLine("Architecture: " + obj["OSArchitecture"]);
                }
            });

            label6.Text = specs.ToString();
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

        private void windarkmodeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            string filePath = @"C:\UwUTools\config.txt";
            string[] lines = File.ReadAllLines(filePath);
            string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            string valueName = "AppsUseLightTheme";
            int darkMode = 0;
            int lightMode = 1;

            if (lines.Length < 3)
            {
                // Expand the array if necessary
                Array.Resize(ref lines, 3); // Resize to at least 3 elements
            }

            if (windarkmodeSwitch.Checked == true)
            {
                lines[2] = "WinDarkMode=Yes"; // Write to line 3 (index 2)

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, darkMode, RegistryValueKind.DWord);
                    }
                }
            }
            else if (windarkmodeSwitch.Checked == false)
            {
                lines[2] = "WinDarkMode=No"; // Write to line 3 (index 2)

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, lightMode, RegistryValueKind.DWord);
                    }
                }
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}

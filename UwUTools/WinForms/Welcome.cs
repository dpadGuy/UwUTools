using Guna.UI2.WinForms;
using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using UwUTools_Prototype.WinForms;
using UwUTools_Prototype.WinForms.Emulator_Sections;

namespace UwUTools_Prototype
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();

            string PathFolder = @"C:\UwUTools";
            string Choices = @"C:\UwUTools\Choices";
            string filePath = @"C:\UwUTools\config.txt";
            string[] lines = { "Notifications=Yes" };

            Directory.CreateDirectory(PathFolder);
            Directory.CreateDirectory(Choices);

            if (!File.Exists(@"C:\UwUTools\config.txt"))
            {
                File.WriteAllLines(filePath, lines);
            }

            if (File.Exists(@"C:\UwUTools\Update.txt"))
            {
                SuccessNotification notification = new SuccessNotification();
                notification.showAlert("Success message", SuccessNotification.enmType.Success);
                File.Delete(@"C:\UwUTools\Update.txt");
            }

            this.Load += WelcomePage_Load;
        }

        private async void WelcomePage_Load(object sernder, EventArgs e) //this one remains ofc lmfao
        {
            Opacity = 0;
            await Task.Delay(150);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .10;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/dpadGuy");
        }

        private void youtubeButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/@rain.7669");
        }
    }
}

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

namespace UwUTools_Prototype.WinForms.Messages
{
    public partial class ExeRunner : Form
    {
        public ExeRunner()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .20;
        }

        private void explorerDownload_Click(object sender, EventArgs e)
        {
            string exePath = guna2TextBox1.Text;

            try
            {
                Process.Start(exePath);
            }
            catch (Exception ex)
            {

            }
        }
        private async void ExeRunner_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            await Task.Delay(200);
            timer1.Start();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
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
                catch (Win32Exception ex)
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
                catch (Win32Exception ex)
                {
                    continue;
                }
            }
        }
    }
}

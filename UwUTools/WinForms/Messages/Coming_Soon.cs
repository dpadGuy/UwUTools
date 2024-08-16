using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using UwUTools_Prototype.WinForms;
using UwUTools_Prototype.WinForms.Emulator_Sections;

namespace UwUTools_Prototype.WinForms
{
    public partial class Coming_Soon : Form
    {
        public Coming_Soon()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            await Task.Delay(200);
            timer1.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .20;
        }
    }
}

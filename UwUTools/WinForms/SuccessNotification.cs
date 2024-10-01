using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UwUTools.Properties;

namespace UwUTools_Prototype.WinForms
{
    public partial class SuccessNotification : Form
    {
        private SuccessNotification.enmAction action; // Code taken and modified a little from (https://codeinpc.com/custom-alert-box)

        private int x, y;
        public SuccessNotification()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case SuccessNotification.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = SuccessNotification.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            this.Opacity -= 0.1;

            this.Left -= 3;
            if (base.Opacity == 0.0)
            {
                base.Close();
            }
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                SuccessNotification frm = (SuccessNotification)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    break;
            }

            this.Show();
            this.action = enmAction.start;
            this.Opacity = 0;
            Thread.Sleep(500);
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}

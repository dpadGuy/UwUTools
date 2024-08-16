using System;
using System.Windows.Forms;

namespace UwUTools_Prototype
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create instances of your forms
            WelcomePage form1 = new WelcomePage();
            GFN_Icon_Desktop_Fix form2 = new GFN_Icon_Desktop_Fix();

            // Show both forms
            form1.Show();

            form2.Show();
            form2.Opacity = 0;
            form2.ShowInTaskbar = false;

            Application.Run();
        }
    }
}

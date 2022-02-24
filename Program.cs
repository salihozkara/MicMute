using System;
using System.Windows.Forms;

namespace MicMute
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.Build();
            var mainFrm = new MainForm();
            Application.Run(mainFrm);
            mainFrm.Hide();
        }
    }
}

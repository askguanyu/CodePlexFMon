using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FMon.UI;

namespace FMon.App
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
            try
            {
                Application.Run(new FMonMainForm());
            }
            catch (Exception)
            {
            }
        }
    }
}

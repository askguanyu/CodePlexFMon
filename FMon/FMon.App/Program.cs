//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.App
{
    using System;
    using System.Windows.Forms;
    using FMon.UI;

    /// <summary>
    ///
    /// </summary>
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

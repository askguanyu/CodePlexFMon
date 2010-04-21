//-----------------------------------------------------------------------
// <copyright file="FMonAboutForm.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.UI
{
    using System;
    using System.Windows.Forms;
    using FMon.Utilities;

    /// <summary>
    ///
    /// </summary>
    partial class FMonAboutForm : Form
    {
        /// <summary>
        ///
        /// </summary>
        public FMonAboutForm()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyAccessors.AssemblyTitle());
            this.labelProductName.Text = AssemblyAccessors.AssemblyProduct();
            this.labelVersion.Text = String.Format("Version {0}", AssemblyAccessors.AssemblyVersion());
            this.labelCopyright.Text = AssemblyAccessors.AssemblyCopyright();
            this.labelCompanyName.Text = AssemblyAccessors.AssemblyCompany();
            this.textBoxDescription.Text = AssemblyAccessors.AssemblyDescription();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

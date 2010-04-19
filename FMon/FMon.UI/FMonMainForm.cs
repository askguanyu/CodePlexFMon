﻿//-----------------------------------------------------------------------
// <copyright file="FMonMainForm.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    ///
    /// </summary>
    public partial class FMonMainForm : Form
    {
        /// <summary>
        ///
        /// </summary>
        public FMonMainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMonAboutForm aboutForm = new FMonAboutForm();
            aboutForm.ShowDialog();
        }
    }
}

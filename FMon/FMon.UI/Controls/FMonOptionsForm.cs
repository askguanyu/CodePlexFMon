//-----------------------------------------------------------------------
// <copyright file="FMonOptionsForm.cs" company="Contoso Corporation">
//     Copyright (c) Contoso Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.UI
{
    using System.Windows.Forms;

    /// <summary>
    ///
    /// </summary>
    public partial class FMonOptionsForm : Form
    {
        private FMonFileSystemWatcher fileWatcher = new FMonFileSystemWatcher();

        /// <summary>
        ///
        /// </summary>
        public FMonOptionsForm()
        {
            InitializeComponent();

            foreach (var item in this.fileWatcher.WatcherList)
            {
                folderGridView.Rows.Add(item.Key);
            }
        }

        private void OnCancelButtonClick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

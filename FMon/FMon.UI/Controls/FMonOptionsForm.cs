//-----------------------------------------------------------------------
// <copyright file="FMonOptionsForm.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
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
        /// <summary>
        ///
        /// </summary>
        private FMonFileSystemWatcher fileWatcher = new FMonFileSystemWatcher();

        /// <summary>
        ///
        /// </summary>
        public FMonOptionsForm()
        {
            InitializeComponent();

            foreach (var item in this.fileWatcher.WatcherList)
            {
                this.folderListBox.Items.Add(item.Key);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelButtonClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAddButtonClick(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (DialogResult.OK == folderDialog.ShowDialog())
                {
                    this.folderListBox.Items.Add(folderDialog.SelectedPath);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRemoveButtonClick(object sender, System.EventArgs e)
        {
            this.folderListBox.Items.Remove(this.folderListBox.SelectedItem);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkButtonClick(object sender, System.EventArgs e)
        {
            this.fileWatcher.Suspend();
            this.fileWatcher.Clear();

            foreach (var item in this.folderListBox.Items)
            {
                this.fileWatcher.Add(item.ToString());
            }

            this.fileWatcher.Resume();
            this.Close();
        }
    }
}

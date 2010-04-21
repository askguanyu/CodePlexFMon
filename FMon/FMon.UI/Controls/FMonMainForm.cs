//-----------------------------------------------------------------------
// <copyright file="FMonMainForm.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.UI
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    ///
    /// </summary>
    public partial class FMonMainForm : Form
    {
        /// <summary>
        ///
        /// </summary>
        private FMonGridView gridView;

        /// <summary>
        ///
        /// </summary>
        private string filePath;

        /// <summary>
        ///
        /// </summary>
        private FMonFileSystemWatcher fileWatcher;

        /// <summary>
        ///
        /// </summary>
        public FMonMainForm()
        {
            InitializeComponent();
            this.gridView = new FMonGridView();
            this.gridView.Dock = DockStyle.Fill;
            this.mainFormPanel.Controls.Add(gridView);
        }

        /// <summary>
        ///Gets or sets
        /// </summary>
        public string FilePath
        {
            get
            {
                return this.filePath;
            }

            private set
            {
                this.filePath = value;
                this.filePathStatusLabel.Text = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aWatcher_FileChanged(object sender, System.IO.FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // this bit runs on the UI thread
                this.gridView.Insert(e.ChangeType.ToString(), e.FullPath, DateTime.Now.ToLongTimeString());
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAboutMenuItemClick(object sender, EventArgs e)
        {
            using (FMonAboutForm aboutForm = new FMonAboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExitMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOptionsMenuItemClick(object sender, EventArgs e)
        {
            using (FMonOptionsForm options = new FMonOptionsForm())
            {
                options.ShowDialog();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFMonMainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFMonNotifyIconMouseDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStartButtonClick(object sender, EventArgs e)
        {
            if (this.fileWatcher == null)
            {
                this.fileWatcher = new FMonFileSystemWatcher();
            }

            this.fileWatcher.FileChanged += new System.IO.FileSystemEventHandler(aWatcher_FileChanged);

            if (!string.IsNullOrEmpty(this.filePath))
            {
                this.fileWatcher.Start(this.filePath);
                this.ToolStripVisualChange(true);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isRunning"></param>
        private void ToolStripVisualChange(bool isRunning)
        {
            this.startButton.Enabled = !(this.stopButton.Enabled = isRunning);
            this.toolStripProgressBar.MarqueeAnimationSpeed = isRunning ? 100 : 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStopButtonClick(object sender, EventArgs e)
        {
            if (this.fileWatcher != null)
            {
                this.fileWatcher.Stop();
                this.ToolStripVisualChange(false);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClearButtonClick(object sender, EventArgs e)
        {
            this.gridView.Clear();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenButtonClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (DialogResult.OK == folderDialog.ShowDialog())
                {
                    this.FilePath = folderDialog.SelectedPath;
                }
            }
        }
    }
}
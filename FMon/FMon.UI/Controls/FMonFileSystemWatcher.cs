//-----------------------------------------------------------------------
// <copyright file="FMonFileSystemWatcher.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.UI
{
    using System;
    using System.ComponentModel;
    using System.IO;

    /// <summary>
    ///
    /// </summary>
    public partial class FMonFileSystemWatcher : Component
    {
        /// <summary>
        ///
        /// </summary>
        public FMonFileSystemWatcher()
        {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="container"></param>
        public FMonFileSystemWatcher(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        public event FileSystemEventHandler FileChanged;

        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        public void Start(string path)
        {
            try
            {
                this.fileSystemWatcher.Path = Path.GetFullPath(path);
                this.fileSystemWatcher.IncludeSubdirectories = true;
                this.fileSystemWatcher.Changed += this.OnFileSystemWatche;
                this.fileSystemWatcher.Created += this.OnFileSystemWatche;
                this.fileSystemWatcher.Deleted += this.OnFileSystemWatche;
                this.fileSystemWatcher.Renamed += this.OnFileSystemWatche;
                this.fileSystemWatcher.EnableRaisingEvents = true;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Stop()
        {
            try
            {
                this.fileSystemWatcher.EnableRaisingEvents = false;
                this.fileSystemWatcher.Changed -= this.OnFileSystemWatche;
                this.fileSystemWatcher.Created -= this.OnFileSystemWatche;
                this.fileSystemWatcher.Deleted -= this.OnFileSystemWatche;
                this.fileSystemWatcher.Renamed -= this.OnFileSystemWatche;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileSystemWatche(object sender, FileSystemEventArgs e)
        {
            this.FileChanged(sender, e);
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="FMonFileSystemWatcher.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    ///
    /// </summary>
    public class FMonFileSystemWatcher
    {
        /// <summary>
        ///
        /// </summary>
        private static Dictionary<string, FileSystemWatcher> watcherList = new Dictionary<string, FileSystemWatcher>();

        /// <summary>
        ///
        /// </summary>
        private static bool isRunning;

        /// <summary>
        ///
        /// </summary>
        private static bool lastRunning;

        /// <summary>
        ///
        /// </summary>
        public FMonFileSystemWatcher()
        {
        }

        /// <summary>
        ///
        /// </summary>
        public event FileSystemEventHandler FileChanged;

        /// <summary>
        ///Gets
        /// </summary>
        public Dictionary<string, FileSystemWatcher> WatcherList
        {
            get { return FMonFileSystemWatcher.watcherList; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filePath"></param>
        public bool Add(string filePath)
        {
            if (!FMonFileSystemWatcher.watcherList.ContainsKey(Path.GetFullPath(filePath)))
            {
                FMonFileSystemWatcher.watcherList.Add(Path.GetFullPath(filePath), new FileSystemWatcher(Path.GetFullPath(filePath)));
                return true;
            }

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool Remove(string filePath)
        {
            return FMonFileSystemWatcher.watcherList.Remove(Path.GetFullPath(filePath));
        }

        /// <summary>
        ///
        /// </summary>
        public void Clear()
        {
            FMonFileSystemWatcher.watcherList.Clear();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="path"></param>
        public bool Start()
        {
            try
            {
                if (FMonFileSystemWatcher.watcherList.Count > 0)
                {
                    foreach (var item in FMonFileSystemWatcher.watcherList)
                    {
                        item.Value.IncludeSubdirectories = true;
                        item.Value.Changed += this.OnFileSystemWatche;
                        item.Value.Created += this.OnFileSystemWatche;
                        item.Value.Deleted += this.OnFileSystemWatche;
                        item.Value.Renamed += this.OnFileSystemWatche;
                        item.Value.EnableRaisingEvents = true;
                    }

                    FMonFileSystemWatcher.isRunning = true;
                    return true;
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (PlatformNotSupportedException)
            {
            }

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        public bool Stop()
        {
            try
            {
                if (FMonFileSystemWatcher.watcherList.Count > 0)
                {
                    foreach (var item in FMonFileSystemWatcher.watcherList)
                    {
                        item.Value.EnableRaisingEvents = false;
                        item.Value.Changed -= this.OnFileSystemWatche;
                        item.Value.Created -= this.OnFileSystemWatche;
                        item.Value.Deleted -= this.OnFileSystemWatche;
                        item.Value.Renamed -= this.OnFileSystemWatche;
                    }

                    FMonFileSystemWatcher.isRunning = false;
                    return true;
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (PlatformNotSupportedException)
            {
            }

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return FMonFileSystemWatcher.watcherList.Count;
        }

        /// <summary>
        ///
        /// </summary>
        public void Resume()
        {
            if (FMonFileSystemWatcher.lastRunning)
            {
                this.Start();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Suspend()
        {
            FMonFileSystemWatcher.lastRunning = FMonFileSystemWatcher.isRunning;
            this.Stop();
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

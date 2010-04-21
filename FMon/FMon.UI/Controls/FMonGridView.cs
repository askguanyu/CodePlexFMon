//-----------------------------------------------------------------------
// <copyright file="FMonGridView.cs" company="GY Corporation">
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
    public partial class FMonGridView : UserControl
    {
        /// <summary>
        ///
        /// </summary>
        public FMonGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        ///Gets
        /// </summary>
        public DataGridView Data
        {
            get
            {
                return this.dataGridView;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="number"></param>
        /// <param name="action"></param>
        /// <param name="file"></param>
        /// <param name="time"></param>
        /// <param name="user"></param>
        public void Insert(string number, string action, string file, string time, string user)
        {
            try
            {
                this.dataGridView.Rows.Add(number, action, file, time, user);
                this.dataGridView.FirstDisplayedScrollingRowIndex = this.dataGridView.RowCount - 1;
                this.dataGridView.Update();
            }
            catch (ArgumentNullException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="action"></param>
        /// <param name="file"></param>
        /// <param name="time"></param>
        /// <param name="user"></param>
        public void Insert(string action, string file, string time, string user)
        {
            this.Insert(dataGridView.RowCount.ToString(), action, file, time, user);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="action"></param>
        /// <param name="file"></param>
        /// <param name="time"></param>
        public void Insert(string action, string file, string time)
        {
            this.Insert(dataGridView.RowCount.ToString(), action, file, time, string.Empty);
        }

        /// <summary>
        ///
        /// </summary>
        public void Clear()
        {
            try
            {
                this.dataGridView.Rows.Clear();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}

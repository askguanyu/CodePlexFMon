//-----------------------------------------------------------------------
// <copyright file="AssemblyAccessors.cs" company="GY Corporation">
//     Copyright (c) GY Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FMon.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    ///
    /// </summary>
    public static class AssemblyAccessors
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string AssemblyTitle()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }

            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string AssemblyDescription()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }

            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string AssemblyProduct()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }

            return ((AssemblyProductAttribute)attributes[0]).Product;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string AssemblyCopyright()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }

            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string AssemblyCompany()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }

            return ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }
}

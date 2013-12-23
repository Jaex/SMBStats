#region License Information (GNU GPL v3)

/*
    Super Meat Boy Stats
    Copyright (C) Jaex

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GNU GPL v3)

using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace SMBStats
{
    internal static class Program
    {
        public static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        public static string Title
        {
            get
            {
                string title = string.Format("{0} {1}.{2}", Application.ProductName, AssemblyVersion.Major, AssemblyVersion.Minor);
                if (AssemblyVersion.Build > 0) title += "." + AssemblyVersion.Build;
                return title;
            }
        }

        public static Settings Settings { get; private set; }

        public const string UpdateURL = "http://smbstats.googlecode.com/svn/Update.xml";

        [STAThread]
        private static void Main()
        {
            Settings = new Settings();

            Application.CurrentCulture = CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Settings.Save();
        }
    }
}
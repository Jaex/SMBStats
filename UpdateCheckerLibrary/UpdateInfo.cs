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
using System.Text;

namespace UpdateCheckerLibrary
{
    public class UpdateInfo
    {
        public Version ApplicationVersion { get; set; }
        public Version LatestVersion { get; set; }
        public string URL { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }

        private const bool ForceUpdate = false;

        public bool IsUpdateRequired
        {
            get
            {
                return ApplicationVersion != null && LatestVersion != null && !string.IsNullOrEmpty(URL) &&
                    (LatestVersion.CompareTo(ApplicationVersion) > 0 || ForceUpdate);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Current version: " + ApplicationVersion);
            sb.AppendLine("Latest version: " + LatestVersion);
            sb.AppendLine("Latest version date: " + Date.ToLongDateString());
            return sb.ToString();
        }
    }
}
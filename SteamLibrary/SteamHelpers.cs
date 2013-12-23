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
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace SteamLibrary
{
    public static class SteamHelpers
    {
        public static string GetSteamDirectory()
        {
            string steamPath = string.Empty;

            try
            {
                steamPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Valve\Steam", "InstallPath", null) as string;

                if (string.IsNullOrEmpty(steamPath))
                {
                    steamPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Wow6432Node\Valve\Steam", "InstallPath", null) as string;

                    if (string.IsNullOrEmpty(steamPath))
                    {
                        steamPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", null) as string;
                    }
                }

                if (!string.IsNullOrEmpty(steamPath))
                {
                    steamPath = steamPath.Trim().Replace('/', '\\');
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            return steamPath;
        }

        public static bool IsFriendID(string friendID)
        {
            return Regex.IsMatch(friendID, @"\b\d{17}\b");
        }

        public static bool IsFriendID(long friendID)
        {
            return IsFriendID(friendID.ToString());
        }

        public static bool IsSteamID(string steamID)
        {
            return Regex.IsMatch(steamID, @"\bsteam_\d:\d:\d+\b", RegexOptions.IgnoreCase);
        }
    }
}
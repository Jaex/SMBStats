#region License Information (GPL v3)

/*
    Copyright (C) Jaex

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using IniParser;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SMBStats
{
    public class Settings
    {
        public bool AutoLoad { get; set; }
        public bool AutoUpdate { get; set; }
        public string LastLoadPath { get; set; }
        public long SteamID { get; set; }
        public string UserKey { get; set; }

        private const string SettingFile = "Settings.ini";

        public string SettingPath
        {
            get { return Path.Combine(Application.StartupPath, SettingFile); }
        }

        public Settings()
        {
            Init();

            if (File.Exists(SettingFile))
            {
                Load();
            }
            else
            {
                Save();
            }
        }

        public void Init()
        {
            AutoLoad = true;
            AutoUpdate = true;
        }

        public void Save()
        {
            try
            {
                IniData data = new IniData();
                data.Sections.AddSection("Settings");
                data.Sections.GetSectionData("Settings").Keys.AddKey("AutoLoad", AutoLoad.ToString());
                data.Sections.GetSectionData("Settings").Keys.AddKey("AutoUpdate", AutoUpdate.ToString());
                data.Sections.GetSectionData("Settings").Keys.AddKey("LastLoadPath", LastLoadPath);
                data.Sections.GetSectionData("Settings").Keys.AddKey("SteamID", SteamID.ToString());
                data.Sections.GetSectionData("Settings").Keys.AddKey("UserKey", UserKey);

                FileIniDataParser parser = new FileIniDataParser();
                parser.SaveFile(SettingPath, data);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public bool Load()
        {
            if (File.Exists(SettingFile))
            {
                try
                {
                    FileIniDataParser parser = new FileIniDataParser();
                    IniData data = parser.LoadFile(SettingPath);

                    string autoLoad = data["Settings"]["AutoLoad"];
                    if (!string.IsNullOrEmpty(autoLoad)) AutoLoad = CheckBool(autoLoad);

                    string autoUpdate = data["Settings"]["AutoUpdate"];
                    if (!string.IsNullOrEmpty(autoUpdate)) AutoUpdate = CheckBool(autoUpdate);

                    LastLoadPath = data["Settings"]["LastLoadPath"];

                    string steamID = data["Settings"]["SteamID"];
                    if (!string.IsNullOrEmpty(steamID)) SteamID = Convert.ToInt64(steamID);

                    UserKey = data["Settings"]["UserKey"];

                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }

            return false;
        }

        private bool CheckBool(string text)
        {
            text = text.ToLowerInvariant().Trim();
            return text == "true" || text == "1";
        }
    }
}
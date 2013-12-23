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
using System.Media;
using System.Windows.Forms;
using SteamLibrary;

namespace SMBStats
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.smb;
            cbAutoLoad.Checked = Program.Settings.AutoLoad;
            cbAutoUpdate.Checked = Program.Settings.AutoUpdate;
            lblSteamID.Text = "Steam ID is: " + Program.Settings.SteamID;
        }

        private void cbAutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoLoad = cbAutoLoad.Checked;
        }

        private void cbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoUpdate = cbAutoUpdate.Checked;
        }

        private void btnSteamIDApply_Click(object sender, EventArgs e)
        {
            string id = txtSteamID.Text;

            try
            {
                long steamID = SteamConvert.ConvertToFriendID(id);

                if (steamID > 0)
                {
                    lblSteamID.Text = "Steam ID is: " + steamID;
                    Program.Settings.SteamID = steamID;
                    txtSteamID.Clear();
                    SystemSounds.Exclamation.Play();
                }
                else
                {
                    MessageBox.Show("Input is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
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
using System.Drawing;
using System.Windows.Forms;
using SteamLibrary;
using SuperMeatBoyLibrary;

namespace SMBStats
{
    public partial class LeaderboardForm : Form
    {
        private bool isFormLoaded;
        private ELeaderboardType leaderboardType;
        private ELeaderboardFilterType leaderboardFilterType;
        private long steamID;
        private SMBLevel level;
        private int rangeStart = 0;
        private int rangeEnd = 100;

        public LeaderboardForm(long steamID, SMBLevel level = null)
        {
            InitializeComponent();
            Icon = Properties.Resources.smb;

            this.steamID = steamID;
            this.level = level;

            cbLeaderboardType.SelectedIndex = level == null ? 0 : 1;
            cbLeaderboardFilterType.SelectedIndex = steamID > 0 ? 0 : 1;
            nudLevelRange.Value = 100;

            lvLevelLeaderboard.SmallImageList = HelperMethods.GetCharactersImageList();

            isFormLoaded = true;
        }

        private void LeaderboardForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            LoadLeaderboard();
        }

        public bool LoadLeaderboard()
        {
            if (isFormLoaded)
            {
                if (leaderboardFilterType == ELeaderboardFilterType.Friends && steamID <= 0)
                {
                    MessageBox.Show("Steam ID is required. (Settings -> Steam ID)", "SMBStats - Leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (leaderboardType == ELeaderboardType.Level)
                    {
                        if (level != null && level.LevelType != LevelType.Warp)
                        {
                            SMBLeaderboard leaderboard = new SMBLeaderboard(level);

                            if (leaderboardFilterType == ELeaderboardFilterType.Friends)
                            {
                                leaderboard.GetLeaderboardFriends(steamID);
                            }
                            else
                            {
                                leaderboard.GetLeaderboardGlobal(rangeStart, rangeEnd);
                            }

                            lvLevelLeaderboard.Items.Clear();

                            for (int i = 0; i < leaderboard.Entries.Length; i++)
                            {
                                SMBLeaderboardEntry entry = leaderboard.Entries[i];
                                ListViewItem lvi = new ListViewItem(string.Format(" {0}.", entry.Rank));
                                lvi.Tag = entry;
                                lvi.SubItems.Add(entry.Nickname);
                                lvi.SubItems.Add(entry.Time.ToString("0.###"));
                                lvi.ImageKey = entry.Character.ToString();
                                if (entry.SteamID == leaderboard.SteamID)
                                {
                                    lvi.BackColor = Color.LightGreen;
                                }
                                else if (i % 2 == 0)
                                {
                                    lvi.BackColor = Color.White;
                                }
                                else
                                {
                                    lvi.BackColor = Color.WhiteSmoke;
                                }
                                lvLevelLeaderboard.Items.Add(lvi);
                            }
                        }
                    }
                    else if (leaderboardType == ELeaderboardType.Global)
                    {
                        SMBGlobalLeaderboard leaderboard = new SMBGlobalLeaderboard();

                        if (leaderboardFilterType == ELeaderboardFilterType.Friends)
                        {
                            leaderboard.GetLeaderboardFriends(steamID);
                        }
                        else
                        {
                            leaderboard.GetLeaderboardGlobal(rangeStart, rangeEnd);
                        }

                        lvGlobalLeaderboard.Items.Clear();

                        for (int i = 0; i < leaderboard.Entries.Length; i++)
                        {
                            SMBGlobalLeaderboardEntry entry = leaderboard.Entries[i];
                            ListViewItem lvi = new ListViewItem(string.Format("{0}.", entry.Rank));
                            lvi.Tag = entry;
                            lvi.SubItems.Add(entry.Nickname);
                            lvi.SubItems.Add(entry.TotalTime.ToString("0.###"));
                            lvi.SubItems.Add(entry.LevelsBeat.ToString());
                            if (entry.SteamID == leaderboard.SteamID)
                            {
                                lvi.BackColor = Color.LightGreen;
                            }
                            else if (i % 2 == 0)
                            {
                                lvi.BackColor = Color.White;
                            }
                            else
                            {
                                lvi.BackColor = Color.WhiteSmoke;
                            }
                            lvGlobalLeaderboard.Items.Add(lvi);
                        }
                    }

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            return false;
        }

        private void cbLeaderboardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbLeaderboardType.SelectedIndex;

            if (index >= 0)
            {
                leaderboardType = (ELeaderboardType)index;

                if (leaderboardType == ELeaderboardType.Level)
                {
                    lvLevelLeaderboard.Visible = true;
                    lvGlobalLeaderboard.Visible = false;

                    if (level != null)
                    {
                        lblInfo.Text = level.LevelNameWithNumber;
                    }
                    else
                    {
                        lblInfo.Text = "Choose a level";
                    }
                }
                else if (leaderboardType == ELeaderboardType.Global)
                {
                    lvLevelLeaderboard.Visible = false;
                    lvGlobalLeaderboard.Visible = true;

                    lblInfo.Text = "Best overall times";
                }

                LoadLeaderboard();
            }
        }

        private void cbLeaderboardFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbLeaderboardFilterType.SelectedIndex;

            if (index >= 0)
            {
                leaderboardFilterType = (ELeaderboardFilterType)index;

                LoadLeaderboard();
            }
        }

        private void nudLevelRange_ValueChanged(object sender, EventArgs e)
        {
            rangeEnd = (int)nudLevelRange.Value;
            rangeStart = rangeEnd - 99;
            lblLevelRange.Text = string.Format("Range: {0} - {1}", rangeStart, rangeEnd);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaderboard();
        }

        private void tsmiLevelLeaderboardOpenCommunity_Click(object sender, EventArgs e)
        {
            if (lvLevelLeaderboard.SelectedItems.Count > 0)
            {
                SMBLeaderboardEntry entry = lvLevelLeaderboard.SelectedItems[0].Tag as SMBLeaderboardEntry;

                if (entry != null && entry.SteamID > 0)
                {
                    string url = string.Format("http://steamcommunity.com/profiles/{0}", entry.SteamID);

                    Process.Start(url);
                }
            }
        }

        private void tsmiLevelLeaderboardCopy_Click(object sender, EventArgs e)
        {
            if (lvLevelLeaderboard.SelectedItems.Count > 0 && level != null)
            {
                SMBLeaderboardEntry entry = lvLevelLeaderboard.SelectedItems[0].Tag as SMBLeaderboardEntry;

                if (entry != null)
                {
                    string text = string.Format("{0} - {1}. {2} - {3:0.###}", level.LevelNameWithNumber, entry.Rank, entry.Nickname, entry.Time);

                    Clipboard.SetText(text);
                }
            }
        }

        private void tsmiGlobalLeaderboardOpenCommunity_Click(object sender, EventArgs e)
        {
            if (lvGlobalLeaderboard.SelectedItems.Count > 0)
            {
                SMBGlobalLeaderboardEntry entry = lvGlobalLeaderboard.SelectedItems[0].Tag as SMBGlobalLeaderboardEntry;

                if (entry != null && entry.SteamID > 0)
                {
                    string url = string.Format("http://steamcommunity.com/profiles/{0}", entry.SteamID);

                    Process.Start(url);
                }
            }
        }

        private void tsmiGlobalLeaderboardCopy_Click(object sender, EventArgs e)
        {
            if (lvGlobalLeaderboard.SelectedItems.Count > 0)
            {
                SMBGlobalLeaderboardEntry entry = lvGlobalLeaderboard.SelectedItems[0].Tag as SMBGlobalLeaderboardEntry;

                if (entry != null)
                {
                    string text = string.Format("{0}. {1} - {2:0.###} - {3}", entry.Rank, entry.Nickname, entry.TotalTime, entry.LevelsBeat);

                    Clipboard.SetText(text);
                }
            }
        }
    }
}
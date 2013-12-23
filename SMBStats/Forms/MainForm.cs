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

using BrightIdeasSoftware;
using HelpersLibrary;
using SteamLibrary;
using SuperMeatBoyLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UpdateCheckerLibrary;

namespace SMBStats
{
    public partial class MainForm : Form
    {
        private SMBManager smb;
        private SMBManager smb2;
        private bool isCompare;

        public MainForm()
        {
            // ParserHelper.ParseAllLevels(@"C:\Users\Computer\Desktop\Others\Super Meat Boy\gamedata\Levels");

            InitializeComponent();
            InitGUI();

            smb = new SMBManager();
            smb2 = new SMBManager();
            isCompare = false;

            if (Program.Settings.AutoUpdate)
            {
                UpdaterFormOptions options = new UpdaterFormOptions
                {
                    WindowIcon = Properties.Resources.smb,
                    Logo = Properties.Resources.potatoSmall,
                    LogoPosition = new Point(15, 5)
                };
                UpdateChecker updateChecker = new UpdateChecker(Program.UpdateURL, "SMBStats", new Version(Application.ProductVersion), true, null, options);
                updateChecker.CheckUpdateAsync(true);
            }

            if (Program.Settings.AutoLoad)
            {
                OpenSaveGameFile(Program.Settings.LastLoadPath);
            }
        }

        private void InitGUI()
        {
            Text = Program.Title;
            Icon = Properties.Resources.smb;

            tsbLoad.ToolTipText = "Locate and open a SMB save file (savegame.dat)";
            tsbRefresh.ToolTipText = "Reload a currently used save file";
            tsbCopyAll.ToolTipText = "Copy all chapter info to clipboard";
            tsbCopySelected.ToolTipText = "Copy selected chapter info to clipboard";
            tsbLeaderboard.ToolTipText = "View Steam leaderboards";
            tsbUnpackData.ToolTipText = "Extract SMB data file (gameaudio.dat or gamedata.dat)";
            tsbSettings.ToolTipText = "Customize the program settings";
            tsbAbout.ToolTipText = "Credits";

            ImageList ilChapters = new ImageList();
            ilChapters.ColorDepth = ColorDepth.Depth32Bit;
            ilChapters.Images.Add(Properties.Resources.ch1);
            ilChapters.Images.Add(Properties.Resources.ch2);
            ilChapters.Images.Add(Properties.Resources.ch3);
            ilChapters.Images.Add(Properties.Resources.ch4);
            ilChapters.Images.Add(Properties.Resources.ch5);
            ilChapters.Images.Add(Properties.Resources.ch6);
            ilChapters.Images.Add(Properties.Resources.ch7);
            lvChapters.SmallImageList = ilChapters;

            ImageList ilLevels = new ImageList();
            ilLevels.ColorDepth = ColorDepth.Depth32Bit;
            ilLevels.Images.Add("completed", Properties.Resources.completed);
            ilLevels.Images.Add("gradea", Properties.Resources.gradea);
            ilLevels.Images.Add("bandage", Properties.Resources.bandage);
            ilLevels.Images.Add("bandage_grayscale", Properties.Resources.bandage_black);
            ilLevels.Images.Add("warp", Properties.Resources.warp);
            ilLevels.Images.Add("warp_grayscale", Properties.Resources.warp_black);
            olvLevels.SmallImageList = ilLevels;

            TextOverlay textOverlay = olvLevels.EmptyListMsgOverlay as TextOverlay;
            textOverlay.TextColor = Color.Firebrick;
            textOverlay.BackColor = Color.AntiqueWhite;
            textOverlay.BorderColor = Color.DarkRed;
            textOverlay.BorderWidth = 4.0f;
            textOverlay.Font = new Font(FontFamily.GenericSerif, 36);
            textOverlay.Rotation = -5;
            olvLevels.EmptyListMsg = "Choose a chapter!";

            olvColumnGradeA.Renderer = new MappedImageRenderer(CompletedStatus.Completed, "completed", CompletedStatus.GradeA, "gradea");
            olvColumnBandage.Renderer = new MappedImageRenderer(BandageStatus.Exist, "bandage_grayscale", BandageStatus.Got, "bandage");
            olvColumnWarp.Renderer = new MappedImageRenderer(WarpStatus.Exist, "warp_grayscale", WarpStatus.Got, "warp");

            olvCharacters.SmallImageList = HelperMethods.GetCharactersImageList();

            olvColumnCharactersName.ImageGetter = new ImageGetterDelegate(CharactersImageGetter);
            olvColumnCharactersStatus.Renderer = new MappedImageRenderer(true, "unlocked", false, "locked");

            cbLevelType.SelectedIndex = 0;
            cbCompareFilter.SelectedIndex = 0;
        }

        private bool OpenSaveGameFile(string path, bool isRefresh = false)
        {
            lock (this)
            {
                try
                {
                    bool isLoaded;

                    if (isRefresh)
                    {
                        isLoaded = smb.Refresh();
                    }
                    else
                    {
                        isLoaded = smb.Init(path);

                        if (isLoaded)
                        {
                            Text = string.Format("{0} - {1}", Program.Title, path);
                        }
                    }

                    if (isLoaded)
                    {
                        ClearLists();

                        foreach (SMBChapter chapter in smb.Chapters)
                        {
                            ListViewItem lvi = new ListViewItem(string.Format("Chapter {0} - {1}", chapter.Number, chapter.Name), chapter.Number - 1);

                            lvi.Tag = chapter;

                            lvi.SubItems.Add(chapter.LightLevelsCompletedText);
                            lvi.SubItems.Add(chapter.DarkLevelsCompletedText);
                            lvi.SubItems.Add(chapter.BandagesText);
                            lvi.SubItems.Add(chapter.WarpLevelsCompletedText);
                            lvi.SubItems.Add(chapter.ProgressText);

                            lvChapters.Items.Add(lvi);
                        }

                        lvStats.Items.Add("Leaderboard score").SubItems.Add(smb.LeaderboardScoreText);
                        lvStats.Items.Add("Total deaths").SubItems.Add(smb.TotalDeathsText);
                        lvStats.Items.Add("Total time / Total par time").SubItems.Add(smb.TotalTimeText);
                        lvStats.Items.Add("Total progress").SubItems.Add(smb.TotalProgressText);
                        lvStats.Items.Add("Total levels completed").SubItems.Add(smb.TotalLevelsCompletedText);
                        lvStats.Items.Add("Total light levels completed").SubItems.Add(smb.TotalLightCompletedText);
                        lvStats.Items.Add("Total dark levels completed").SubItems.Add(smb.TotalDarkCompletedText);
                        lvStats.Items.Add("Total warp levels completed").SubItems.Add(smb.TotalWarpCompletedText);
                        lvStats.Items.Add("Total glitch levels completed").SubItems.Add(smb.TotalGlitchCompletedText);
                        lvStats.Items.Add("Total bandages collected").SubItems.Add(smb.TotalBandagesText);
                        lvStats.Items.Add("Total light levels grade A+").SubItems.Add(smb.TotalLightGradeAText);
                        lvStats.Items.Add("Total dark levels grade A+").SubItems.Add(smb.TotalDarkGradeAText);

                        olvCharacters.SetObjects(smb.CharactersList);

                        tsbRefresh.Enabled = tsbCopyAll.Enabled = tsbCopySelected.Enabled = true;

                        return true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ClearLists();
            tsbRefresh.Enabled = tsbCopyAll.Enabled = tsbCopySelected.Enabled = false;

            return false;
        }

        private void ClearLists()
        {
            lvChapters.Items.Clear();
            lvStats.Items.Clear();
            lvChapterStats.Items.Clear();
            olvCharacters.ClearObjects();
            olvLevels.ClearObjects();
            lvCompare.Items.Clear();
        }

        private bool OpenCompareSaveGameFile(string path, bool isRefresh = false)
        {
            lock (this)
            {
                try
                {
                    if (isRefresh)
                    {
                        return smb2.Refresh();
                    }
                    else
                    {
                        return smb2.Init(path);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        private string GetChapterInfoText(SMBChapter chapterInfo)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(chapterInfo.ToString());

            if (chapterInfo.LightLevels.Count(x => x.IsCompleted) > 0) str.AppendLine();

            foreach (SMBLevel levelInfo in chapterInfo.LightLevels)
            {
                if (levelInfo != null && levelInfo.IsCompleted)
                {
                    str.AppendLine(levelInfo.ToString());
                }
            }

            if (chapterInfo.DarkLevels.Count(x => x.IsCompleted) > 0) str.AppendLine();

            foreach (SMBLevel levelInfo in chapterInfo.DarkLevels)
            {
                if (levelInfo != null && levelInfo.IsCompleted)
                {
                    str.AppendLine(levelInfo.ToString());
                }
            }

            if (chapterInfo.WarpLevels.Count(x => x.IsCompleted) > 0) str.AppendLine();

            foreach (SMBLevel levelInfo in chapterInfo.WarpLevels)
            {
                if (levelInfo != null && levelInfo.IsCompleted)
                {
                    str.AppendLine(levelInfo.ToString());
                }
            }

            return str.ToString();
        }

        private void UpdateLevels()
        {
            if (smb != null && smb.IsLoaded && lvChapters.SelectedIndices.Count > 0 && cbLevelType.SelectedIndex > -1)
            {
                LoadChapterInfo();

                LevelTypeFilter levelType = (LevelTypeFilter)cbLevelType.SelectedIndex;
                List<SMBLevel> levels = smb.GetLevels(lvChapters.SelectedIndices[0] + 1, levelType);

                if (levels != null)
                {
                    if (isCompare)
                    {
                        if (smb2 != null && smb2.IsLoaded)
                        {
                            List<SMBLevel> levels2 = smb2.GetLevels(lvChapters.SelectedIndices[0] + 1, levelType);

                            if (levels2 != null)
                            {
                                CompareFilter compareFilter = (CompareFilter)cbCompareFilter.SelectedIndex;
                                List<SMBLevelCompare> compareLevels = SMBHelpers.CompareLevels(levels, levels2, compareFilter);

                                if (compareLevels != null)
                                {
                                    lvCompare.SuspendLayout();
                                    lvCompare.Items.Clear();

                                    if (compareLevels.Count > 0)
                                    {
                                        int minCount = compareLevels.Count(x => x.Difference < 0) - 1;
                                        int maxCount = compareLevels.Count(x => x.Difference > 0) - 1;
                                        float min = 0, max = maxCount;

                                        foreach (SMBLevelCompare level in compareLevels)
                                        {
                                            ListViewItem lvi = new ListViewItem(level.LevelName);
                                            lvi.SubItems.Add(string.Format("{0:0.000}", level.Time1));
                                            lvi.SubItems.Add(string.Format("{0:0.000}", level.Time2));
                                            lvi.SubItems.Add(string.Format("{0:0.000}", level.Difference));
                                            lvi.SubItems.Add(string.Format("{0:0.000}", level.ParTime));

                                            if (level.Difference > 0)
                                            {
                                                lvi.BackColor = Helpers.GetColor(max-- / maxCount, Color.FromArgb(255, 240, 240), Color.FromArgb(255, 125, 125));
                                            }
                                            else if (level.Difference < 0)
                                            {
                                                lvi.BackColor = Helpers.GetColor(min++ / minCount, Color.FromArgb(240, 255, 240), Color.FromArgb(125, 255, 125));
                                            }

                                            lvi.Tag = level;
                                            lvCompare.Items.Add(lvi);
                                        }
                                    }

                                    lvCompare.ResumeLayout();
                                }
                            }
                        }
                    }
                    else
                    {
                        olvLevels.SetObjects(levels);
                    }
                }
            }
        }

        private void LoadChapterInfo()
        {
            int index = lvChapters.SelectedIndices[0];

            if (smb.Chapters != null && smb.Chapters.Count > index)
            {
                SMBChapter chapter = smb.Chapters[index];

                if (chapter != null)
                {
                    lvChapterStats.Items.Clear();

                    if (chapter.Number <= 6) lvChapterStats.Items.Add("Glitch level status").SubItems.Add(chapter.GlitchStatusText);
                    if (chapter.Number <= 6) lvChapterStats.Items.Add("Light boss status").SubItems.Add(chapter.LightBossStatusText);
                    if (chapter.Number == 6) lvChapterStats.Items.Add("Dark boss status").SubItems.Add(chapter.DarkBossStatusText);
                    lvChapterStats.Items.Add("Total progress").SubItems.Add(chapter.ProgressText);
                    lvChapterStats.Items.Add("Total levels completed").SubItems.Add(chapter.TotalLevelsCompletedText);
                    lvChapterStats.Items.Add("Light levels completed").SubItems.Add(chapter.LightLevelsCompletedText);
                    lvChapterStats.Items.Add("Dark levels completed").SubItems.Add(chapter.DarkLevelsCompletedText);
                    lvChapterStats.Items.Add("Warp levels completed").SubItems.Add(chapter.WarpLevelsCompletedText);
                    lvChapterStats.Items.Add("Bandages collected").SubItems.Add(chapter.BandagesText);
                    lvChapterStats.Items.Add("Total levels time").SubItems.Add(chapter.TotalLevelTimesText);
                    lvChapterStats.Items.Add("Light levels time").SubItems.Add(chapter.LightLevelTimesText);
                    lvChapterStats.Items.Add("Dark levels time").SubItems.Add(chapter.DarkLevelTimesText);
                    lvChapterStats.Items.Add("Total grade A+ levels").SubItems.Add(chapter.TotalLevelsGradeAText);
                    lvChapterStats.Items.Add("Light grade A+ levels").SubItems.Add(chapter.TotalLightGradeAText);
                    lvChapterStats.Items.Add("Dark grade A+ levels").SubItems.Add(chapter.TotalDarkGradeAText);
                }
            }
        }

        private void CopyArrayToClipboard(string[] array)
        {
            if (array != null && array.Length > 0)
            {
                string text = string.Join(Environment.NewLine, array);
                Clipboard.SetText(text);
            }
        }

        private object CharactersImageGetter(object rowObject)
        {
            SMBCharacter character = rowObject as SMBCharacter;

            if (character != null) return character.Character.ToString();

            return "unknown";
        }

        #region Form events

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop, false) as string[];

                if (files != null && files.Length > 0)
                {
                    if (OpenSaveGameFile(files[0]))
                    {
                        Program.Settings.LastLoadPath = files[0];
                    }
                }
            }
        }

        private void lvChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLevels();
        }

        private void cbLevelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLevels();
        }

        private void btnNextType_Click(object sender, EventArgs e)
        {
            int index = cbLevelType.SelectedIndex;
            if (++index == cbLevelType.Items.Count) index = 0;
            cbLevelType.SelectedIndex = index;
        }

        private void cbCompare_CheckedChanged(object sender, EventArgs e)
        {
            isCompare = cbCompare.Checked;

            if (isCompare)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "*.dat|*.dat|All files (*.*)|*.*";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        OpenCompareSaveGameFile(ofd.FileName);
                    }
                }
            }

            olvLevels.Visible = !isCompare;
            lvCompare.Visible = isCompare;

            UpdateLevels();
        }

        private void cbCompareFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLevels();
        }

        private void tsbLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                string steamPath = SteamHelpers.GetSteamDirectory();

                if (!string.IsNullOrEmpty(steamPath))
                {
                    steamPath = Path.Combine(steamPath, @"SteamApps\common\super meat boy\UserData");

                    if (Directory.Exists(steamPath))
                    {
                        ofd.InitialDirectory = steamPath;
                    }
                }

                ofd.Filter = "*.dat|*.dat|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (OpenSaveGameFile(ofd.FileName))
                    {
                        Program.Settings.LastLoadPath = ofd.FileName;
                    }
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            int lastIndex = -1;

            if (lvChapters.SelectedIndices.Count > 0)
            {
                lastIndex = lvChapters.SelectedIndices[0];
            }

            if (smb != null)
            {
                OpenSaveGameFile(null, true);
            }

            if (isCompare && smb2 != null)
            {
                OpenCompareSaveGameFile(null, true);
            }

            if (lastIndex > -1 && lvChapters.Items.Count > lastIndex)
            {
                lvChapters.Items[lastIndex].Selected = true;
            }
        }

        private void tsbCopyAll_Click(object sender, EventArgs e)
        {
            if (lvChapters.Items.Count > 0)
            {
                StringBuilder str = new StringBuilder();

                foreach (ListViewItem lvi in lvChapters.Items)
                {
                    SMBChapter chapterInfo = lvi.Tag as SMBChapter;

                    if (chapterInfo != null)
                    {
                        string text = GetChapterInfoText(chapterInfo);

                        if (!string.IsNullOrEmpty(text))
                        {
                            str.AppendLine(text);
                        }
                    }
                }

                string result = str.ToString().Trim();

                if (!string.IsNullOrEmpty(result))
                {
                    Clipboard.SetText(result);
                }
            }
        }

        private void tsbCopySelected_Click(object sender, EventArgs e)
        {
            if (lvChapters.Items.Count > 0 && lvChapters.SelectedItems.Count > 0)
            {
                SMBChapter chapterInfo = lvChapters.SelectedItems[0].Tag as SMBChapter;

                if (chapterInfo != null)
                {
                    string result = GetChapterInfoText(chapterInfo).Trim();

                    if (!string.IsNullOrEmpty(result))
                    {
                        Clipboard.SetText(result);
                    }
                }
            }
        }

        private void tsbLeaderboard_Click(object sender, EventArgs e)
        {
            new LeaderboardForm(Program.Settings.SteamID).ShowDialog();
        }

        private void tsbUnpack_Click(object sender, EventArgs e)
        {
            new UnpackForm().ShowDialog();
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void tsmiChaptersCopy_Click(object sender, EventArgs e)
        {
            string[] texts = lvChapters.SelectedItems.OfType<ListViewItem>().Select(x => x.Tag as SMBChapter).Where(x => x != null).Select(x => x.ToString()).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiChaptersCopyAll_Click(object sender, EventArgs e)
        {
            string[] texts = lvChapters.Items.OfType<ListViewItem>().Select(x => x.Tag as SMBChapter).Where(x => x != null).Select(x => x.ToString()).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiStatsCopy_Click(object sender, EventArgs e)
        {
            string[] texts = lvStats.SelectedItems.OfType<ListViewItem>().Select(x => x.Text + ": " + x.SubItems[1].Text).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiStatsCopyAll_Click(object sender, EventArgs e)
        {
            string[] texts = lvStats.Items.OfType<ListViewItem>().Select(x => x.Text + ": " + x.SubItems[1].Text).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiChapterStatsCopy_Click(object sender, EventArgs e)
        {
            string[] texts = lvChapterStats.SelectedItems.OfType<ListViewItem>().Select(x => x.Text + ": " + x.SubItems[1].Text).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiChapterStatsCopyAll_Click(object sender, EventArgs e)
        {
            string[] texts = lvChapterStats.Items.OfType<ListViewItem>().Select(x => x.Text + ": " + x.SubItems[1].Text).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiLevelsLeaderboard_Click(object sender, EventArgs e)
        {
            SMBLevel level = olvLevels.SelectedObject as SMBLevel;

            if (level != null && level.LevelType != LevelType.Warp)
            {
                new LeaderboardForm(Program.Settings.SteamID, level).ShowDialog();
            }
        }

        private void tsmiLevelsCopy_Click(object sender, EventArgs e)
        {
            string[] texts = olvLevels.SelectedObjects.OfType<SMBLevel>().Select(x => x.ToString()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiLevelsCopyAll_Click(object sender, EventArgs e)
        {
            if (olvLevels.Objects != null)
            {
                string[] texts = olvLevels.Objects.OfType<SMBLevel>().Select(x => x.ToString()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                CopyArrayToClipboard(texts);
            }
        }

        private void tsmiCompareCopy_Click(object sender, EventArgs e)
        {
            string[] texts = lvCompare.SelectedItems.OfType<ListViewItem>().Select(x => x.Tag as SMBLevelCompare).Where(x => x != null).Select(x => x.ToString()).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void tsmiCompareCopyAll_Click(object sender, EventArgs e)
        {
            string[] texts = lvCompare.Items.OfType<ListViewItem>().Select(x => x.Tag as SMBLevelCompare).Where(x => x != null).Select(x => x.ToString()).ToArray();
            CopyArrayToClipboard(texts);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #endregion Form events
    }
}
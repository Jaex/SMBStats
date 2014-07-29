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

using SteamLibrary;
using SuperMeatBoyLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace SMBStats
{
    public partial class UnpackForm : Form
    {
        private string dataPath;
        private string extractPath;
        private DataManager data;

        public UnpackForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.smb;
        }

        private void btnBrowseData_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                string steamPath = SteamHelpers.GetSteamDirectory();

                if (!string.IsNullOrEmpty(steamPath))
                {
                    steamPath = Path.Combine(steamPath, @"SteamApps\common\super meat boy");

                    if (Directory.Exists(steamPath))
                    {
                        ofd.InitialDirectory = steamPath;
                    }
                }

                ofd.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = Path.GetFileName(ofd.FileName).ToLowerInvariant();

                    if (filename != "gameaudio.dat" && filename != "gamedata.dat")
                    {
                        if (MessageBox.Show("You must select gameaudio.dat or gamedata.dat file!\nAre you still want to continue?",
                            "SMBStats - Unpack data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    txtDataPath.Text = ofd.FileName;
                    UpdateDestination();
                }
            }
        }

        private void btnBrowseExtract_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = Application.StartupPath;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtExtractPath.Text = fbd.SelectedPath;
                    UpdateDestination();
                }
            }
        }

        private void UpdateDestination()
        {
            dataPath = txtDataPath.Text;

            if (!string.IsNullOrEmpty(dataPath))
            {
                extractPath = txtExtractPath.Text;

                if (!string.IsNullOrEmpty(extractPath))
                {
                    extractPath = Path.Combine(extractPath, Path.GetFileNameWithoutExtension(dataPath));
                    lblDestination.Text = "Extract path:  " + extractPath;
                    btnExtract.Enabled = true;
                    btnOpenResult.Enabled = true;
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dataPath) && !string.IsNullOrEmpty(extractPath))
            {
                btnExtract.Enabled = false;
                data = new DataManager { AutoConvertPNG = cbAutoConvert.Checked };
                data.ProgressChanged += new DataManager.DataManagerProgressChanged(data_ProgressChanged);
                data.Completed += new DataManager.DataManagerCompleted(data_Completed);
                data.UnpackData(dataPath, extractPath);
            }
        }

        private void data_ProgressChanged(ProgressInfo progress)
        {
            pbProgress.Value = (int)progress.Percentage;
            string text = string.Format("Progress: {0} / {1} ({2:0.00}%)", progress.Index, progress.Length, progress.Percentage);
            if (!string.IsNullOrEmpty(progress.FileName)) text += " - " + progress.FileName;
            lblProgress.Text = text;
        }

        private void data_Completed(string error)
        {
            btnExtract.Enabled = true;

            if (string.IsNullOrEmpty(error))
            {
                SystemSounds.Exclamation.Play();
            }
            else
            {
                MessageBox.Show("Error: " + error, "SMBStats - Unpack data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenResult_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(extractPath) && Directory.Exists(extractPath))
            {
                Process.Start(extractPath);
            }
        }

        private void btnCreateEmptyData_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string steamPath = SteamHelpers.GetSteamDirectory();

                if (!string.IsNullOrEmpty(steamPath))
                {
                    steamPath = Path.Combine(steamPath, @"SteamApps\common\super meat boy");

                    if (Directory.Exists(steamPath))
                    {
                        sfd.InitialDirectory = steamPath;
                    }
                }

                sfd.Title = "Create empty data file";
                sfd.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
                sfd.FileName = "gamedata.dat";
                sfd.OverwritePrompt = false;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName;

                    if (!string.IsNullOrEmpty(path))
                    {
                        if (CheckBackup(path))
                        {
                            DataHelpers.CreateEmptyDataFile(path);
                        }
                    }
                }
            }
        }

        private void btnConvertPNGtoTP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Application.StartupPath;
                ofd.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;

                    if (File.Exists(path))
                    {
                        string destination = Path.ChangeExtension(path, "tp");

                        if (CheckBackup(destination))
                        {
                            DataHelpers.ConvertPNGtoTP(path, destination);
                        }
                    }
                }
            }
        }

        private void btnConvertTPtoPNG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Application.StartupPath;
                ofd.Filter = "TP files (*.tp)|*.tp|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;

                    if (File.Exists(path))
                    {
                        string destination = Path.ChangeExtension(path, "png");

                        if (CheckBackup(destination))
                        {
                            DataHelpers.ConvertTPtoPNG(path, destination);
                        }
                    }
                }
            }
        }

        private bool CheckBackup(string path)
        {
            if (File.Exists(path))
            {
                if (MessageBox.Show("File is exist:\r\n" + path + "\r\nDo you want to backup it?\r\n\r\nYes = Backup, No = Overwrite", "File is exist",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string backupPath = path + ".bak";

                    if (File.Exists(backupPath))
                    {
                        return MessageBox.Show("Can't backup. Backup file already exist:\r\n" + backupPath +
                            "\r\nAre you want to overwrite?\r\n\r\nYes = Overwrite, No = Cancel", "Backup file is exist", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Error) == DialogResult.Yes;
                    }
                    else
                    {
                        File.Copy(path, backupPath);
                    }
                }
            }

            return true;
        }

        private void UnpackForm_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
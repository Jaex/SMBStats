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

using HelpersLibrary;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace UpdateCheckerLibrary
{
    public class UpdateChecker
    {
        public delegate void CheckUpdateCompletedEventHandler(bool result);
        public event CheckUpdateCompletedEventHandler CheckUpdateCompleted;

        public string URL { get; private set; }
        public string ApplicationName { get; private set; }
        public Version ApplicationVersion { get; private set; }
        public bool CheckBeta { get; private set; }
        public UpdateInfo UpdateInfo { get; private set; }

        private IWebProxy proxy;
        private UpdaterFormOptions updaterFormOptions;

        public UpdateChecker(string url, string applicationName, Version applicationVersion, bool checkBeta, IWebProxy proxy, UpdaterFormOptions updaterFormOptions)
        {
            URL = url;
            ApplicationName = applicationName;
            ApplicationVersion = applicationVersion;
            CheckBeta = checkBeta;
            this.proxy = proxy;
            this.updaterFormOptions = updaterFormOptions;
        }

        public void CheckUpdateAsync(bool showPrompt = false)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync(showPrompt);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool result = CheckUpdate();
            e.Result = result;
            if (result && (bool)e.Argument) ShowPrompt();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = (bool)e.Result;

            if (CheckUpdateCompleted != null)
            {
                CheckUpdateCompleted(result);
            }
        }

        public bool CheckUpdate()
        {
            try
            {
                using (WebClient wc = new WebClient { Proxy = proxy })
                using (MemoryStream ms = new MemoryStream(wc.DownloadData(URL)))
                using (XmlTextReader xml = new XmlTextReader(ms))
                {
                    XDocument xd = XDocument.Load(xml);

                    if (xd != null)
                    {
                        string path = string.Format("Update/{0}/{1}", ApplicationName, CheckBeta ? "Beta|Stable" : "Stable");
                        XElement xe = xd.GetNode(path);

                        if (xe != null)
                        {
                            UpdateInfo = new UpdateInfo
                            {
                                ApplicationVersion = ApplicationVersion,
                                LatestVersion = new Version(xe.GetValue("Version")),
                                URL = xe.GetValue("URL"),
                                Date = DateTime.Parse(xe.GetValue("Date"), CultureInfo.InvariantCulture),
                                Summary = xe.GetValue("Summary")
                            };

                            if (UpdateInfo.IsUpdateRequired && !string.IsNullOrEmpty(UpdateInfo.Summary) && UpdateInfo.Summary.IsValidUrl())
                            {
                                UpdateInfo.Summary = wc.DownloadString(UpdateInfo.Summary.Trim());
                            }

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return false;
        }

        public bool ShowPrompt()
        {
            if (UpdateInfo != null && UpdateInfo.IsUpdateRequired)
            {
                updaterFormOptions.Question = string.Format("Do you want to download it now?\n\n{0}", UpdateInfo.ToString());
                updaterFormOptions.UpdateInfo = UpdateInfo;
                updaterFormOptions.ProjectName = ApplicationName;

                using (UpdaterForm ver = new UpdaterForm(updaterFormOptions))
                {
                    if (ver.ShowDialog() == DialogResult.Yes)
                    {
                        Process.Start(UpdateInfo.URL);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UpdateCheckerLibrary
{
    public partial class UpdaterForm : Form
    {
        public UpdaterFormOptions Options { get; private set; }

        public UpdaterForm(UpdaterFormOptions options)
        {
            InitializeComponent();

            Options = options;

            if (Options.WindowIcon != null) Icon = Options.WindowIcon;

            lblQuestion.Text = Options.Question;

            if (!string.IsNullOrEmpty(Options.UpdateInfo.Summary))
            {
                txtVersionHistory.Text = Options.UpdateInfo.Summary;
            }

            Text = string.Format("{0} update is available", Options.ProjectName);

            BringToFront();
            Activate();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void TxtVerLinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void NewVersionWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Black, Color.FromArgb(50, 50, 50), LinearGradientMode.Vertical))
            {
                brush.SetSigmaBellShape(0.20f);
                g.FillRectangle(brush, rect);
            }

            if (Options.Logo != null)
            {
                g.DrawImageUnscaled(Options.Logo, Options.LogoPosition);
            }
        }
    }

    public class UpdaterFormOptions
    {
        public Icon WindowIcon { get; set; }
        public Image Logo { get; set; }
        public Point LogoPosition { get; set; }
        public string Question { get; set; }
        public string ProjectName { get; set; }
        public UpdateInfo UpdateInfo { get; set; }
    }
}
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

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SMBStats
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.smb;
            lblTitle.Text = Program.Title;
        }

        private void AboutForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Black, Color.FromArgb(50, 50, 50), LinearGradientMode.Vertical))
            {
                brush.SetSigmaBellShape(0.25f);
                g.FillRectangle(brush, rect);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            Process.Start("http://code.google.com/p/smbstats");
        }

        private void lblJuzz_Click(object sender, EventArgs e)
        {
            Process.Start("http://steamcommunity.com/id/ww");
        }

        private void lblTeamMeat_Click(object sender, EventArgs e)
        {
            Process.Start("http://supermeatboy.com");
        }
    }
}
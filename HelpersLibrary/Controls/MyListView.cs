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

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace HelpersLibrary
{
    public class MyListView : ListView
    {
        private const int WM_PAINT = 0xF;
        private const int WM_ERASEBKGND = 0x14;

        [DefaultValue(false)]
        public bool AutoFillColumn { get; set; }

        [DefaultValue(-1)]
        public int AutoFillColumnIndex { get; set; }

        public MyListView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.EnableNotifyMessage, true);

            AutoFillColumn = false;
            AutoFillColumnIndex = -1;
            FullRowSelect = true;
            View = View.Details;
        }

        public void FillColumn(int index)
        {
            if (View == View.Details && Columns.Count > 0 && index >= -1 && index < Columns.Count)
            {
                if (index == -1)
                {
                    index = Columns.Count - 1;
                }

                int width = 0;

                for (int i = 0; i < Columns.Count; i++)
                {
                    if (i != index) width += Columns[i].Width;
                }

                Columns[index].Width = ClientSize.Width - width;
            }
        }

        public void FillLastColumn()
        {
            FillColumn(-1);
        }

        [DebuggerStepThrough]
        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg == WM_PAINT && !DesignMode && AutoFillColumn)
            {
                FillColumn(AutoFillColumnIndex);
            }

            if (m.Msg != WM_ERASEBKGND)
            {
                base.OnNotifyMessage(m);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (MultiSelect && e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem lvi in Items)
                {
                    lvi.Selected = true;
                }
            }

            base.OnKeyDown(e);
        }
    }
}
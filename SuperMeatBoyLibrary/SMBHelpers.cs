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
using System.Collections.Generic;
using System.Linq;

namespace SuperMeatBoyLibrary
{
    public static class SMBHelpers
    {
        public static int GetMaxLevelCount(int chapter)
        {
            return chapter != 6 ? 20 : 5;
        }

        public static int GetMaxWarpLevelCount(int chapter)
        {
            return chapter < 6 ? 12 : 0;
        }

        public static List<SMBLevelCompare> CompareLevels(List<SMBLevel> levels1, List<SMBLevel> levels2, CompareFilter compareFilter)
        {
            return (from levels in levels1.Zip(levels2, (x1, x2) => new { x1, x2 })
                    where levels.x1.IsCompleted && levels.x2.IsCompleted
                    let difference = levels.x1.Time - levels.x2.Time
                    where compareFilter == CompareFilter.All || (compareFilter == CompareFilter.Bigger && difference > 0)
                    || (compareFilter == CompareFilter.Smaller && difference < 0)
                    orderby difference descending
                    select new SMBLevelCompare
                    {
                        LevelName = levels.x1.LevelNameWithNumber,
                        Time1 = levels.x1.Time,
                        Time2 = levels.x2.Time,
                        Difference = difference,
                        ParTime = levels.x1.ParTime
                    }).ToList();
        }
    }
}
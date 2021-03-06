﻿#region License Information (GPL v3)

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
using System.Collections.Generic;
using System.Linq;

namespace SuperMeatBoyLibrary
{
    public class SMBGlobalLeaderboard
    {
        private const int GlobaLeaderboardID = 28829;

        public long SteamID { get; private set; }
        public ELeaderboardFilterType LeaderboardType { get; private set; }
        public SMBGlobalLeaderboardEntry[] Entries { get; private set; }

        public void GetLeaderboardFriends(long steamid)
        {
            SteamID = steamid;
            LeaderboardType = ELeaderboardFilterType.Friends;
            List<LeaderboardEntry> entries = SteamLib.GetLeaderboardFriends("SuperMeatBoy", GlobaLeaderboardID, steamid, true);
            Entries = entries.Select(x => new SMBGlobalLeaderboardEntry(x)).ToArray();
        }

        public void GetLeaderboardGlobal(int rangeStart, int rangeEnd)
        {
            LeaderboardType = ELeaderboardFilterType.Global;
            List<LeaderboardEntry> entries = SteamLib.GetLeaderboardGlobal("SuperMeatBoy", GlobaLeaderboardID, rangeStart, rangeEnd, true);
            Entries = entries.Select(x => new SMBGlobalLeaderboardEntry(x)).ToArray();
        }
    }
}
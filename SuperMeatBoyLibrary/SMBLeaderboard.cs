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

using System.Collections.Generic;
using System.Linq;
using SteamLibrary;

namespace SuperMeatBoyLibrary
{
    public class SMBLeaderboard
    {
        public SMBLevel Level { get; private set; }
        public long SteamID { get; private set; }
        public ELeaderboardFilterType LeaderboardType { get; private set; }
        public SMBLeaderboardEntry[] Entries { get; private set; }

        public SMBLeaderboard(SMBLevel level)
        {
            Level = level;
        }

        public void GetLeaderboardFriends(long steamid)
        {
            SteamID = steamid;
            LeaderboardType = ELeaderboardFilterType.Friends;
            List<LeaderboardEntry> entries = SteamLib.GetLeaderboardFriends("SuperMeatBoy", Level.LeaderboardID, steamid, true);
            Entries = entries.Select(x => new SMBLeaderboardEntry(x)).ToArray();
        }

        public void GetLeaderboardGlobal(int rangeStart, int rangeEnd)
        {
            LeaderboardType = ELeaderboardFilterType.Global;
            List<LeaderboardEntry> entries = SteamLib.GetLeaderboardGlobal("SuperMeatBoy", Level.LeaderboardID, rangeStart, rangeEnd, true);
            Entries = entries.Select(x => new SMBLeaderboardEntry(x)).ToArray();
        }

        private string GetLeaderboardName(SMBChapter chapter, int level, LevelType type)
        {
            int id = 100 + ((chapter.Number - 1) * 50) + (level - 1);
            if (type == LevelType.Dark) id += chapter.MaxLevelCount;
            return "SMB_LEADERBOARD_" + id;
        }
    }
}
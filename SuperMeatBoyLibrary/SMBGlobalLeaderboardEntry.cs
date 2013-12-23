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
using HelpersLibrary;
using SteamLibrary;

namespace SuperMeatBoyLibrary
{
    public class SMBGlobalLeaderboardEntry
    {
        public long SteamID { get; private set; }
        public int Rank { get; private set; }
        public string Nickname { get; private set; }
        public float TotalTime { get; private set; }
        public int LevelsBeat { get; private set; }

        public SMBGlobalLeaderboardEntry(LeaderboardEntry entry)
        {
            SteamID = entry.SteamID;
            Rank = entry.Rank;
            Nickname = entry.Nickname;

            byte[] bytes = entry.Details.HexToBytes();
            TotalTime = (float)BitConverter.ToInt32(bytes, 0) / 1000;
            LevelsBeat = BitConverter.ToInt32(bytes, 4);
        }
    }
}
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

using System.Diagnostics;
using System.Globalization;
using System.Linq;
using HelpersLibrary;

namespace SuperMeatBoyLibrary
{
    public class SMBLevel
    {
        public int ChapterNumber { get; set; }
        public int LevelNumber { get; set; }
        public LevelType LevelType { get; set; }
        public float Time { get; set; }
        public LevelStatus Progress { get; set; }

        public string LevelName
        {
            get
            {
                string levelName = SMBDatabase.LevelNames[ChapterNumber - 1][(int)LevelType][LevelNumber - 1];
                return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(levelName);
            }
        }

        public string LevelNameWithNumber
        {
            get
            {
                string numbers = ChapterNumber + "-" + LevelNumber;
                if (LevelType == LevelType.Dark) numbers += "X";
                return numbers + ": " + LevelName;
            }
        }

        public bool IsCompleted
        {
            get { return Progress.HasFlag(LevelStatus.Completed); }
        }

        public bool IsBandageExist
        {
            get
            {
                if (ChapterNumber <= 5)
                {
                    if (LevelType == LevelType.Light)
                    {
                        return SMBDatabase.LightLevelBandages[ChapterNumber - 1].Contains(LevelNumber);
                    }
                    else if (LevelType == LevelType.Dark)
                    {
                        return SMBDatabase.DarkLevelBandages[ChapterNumber - 1].Contains(LevelNumber);
                    }
                    else if (LevelType == LevelType.Warp)
                    {
                        return SMBDatabase.WarpLevelBandages[ChapterNumber - 1].Contains(LevelNumber);
                    }
                }

                return false;
            }
        }

        public bool GotBandage
        {
            get { return Progress.HasFlag(LevelStatus.GotBandage); }
        }

        public BandageStatus GetBandageStatus
        {
            get
            {
                Debug.WriteLineIf(GotBandage && !IsBandageExist, "IsBandageExist wrong: " + LevelNameWithNumber);

                if (GotBandage)
                {
                    return BandageStatus.Got;
                }
                else if (IsBandageExist)
                {
                    return BandageStatus.Exist;
                }

                return BandageStatus.None;
            }
        }

        public bool IsWarpExist
        {
            get
            {
                if (ChapterNumber <= 5)
                {
                    if (LevelType == LevelType.Light)
                    {
                        return SMBDatabase.LightLevelWarps[ChapterNumber - 1].Contains(LevelNumber);
                    }
                    else if (LevelType == LevelType.Dark)
                    {
                        return SMBDatabase.DarkLevelWarps[ChapterNumber - 1].Contains(LevelNumber);
                    }
                }

                return false;
            }
        }

        public bool GotWarp
        {
            get { return Progress.HasFlag(LevelStatus.GotWarp); }
        }

        public WarpStatus GetWarpStatus
        {
            get
            {
                Debug.WriteLineIf(GotWarp && !IsWarpExist, "IsWarpExist wrong: " + LevelNameWithNumber);

                if (GotWarp)
                {
                    return WarpStatus.Got;
                }
                else if (IsWarpExist)
                {
                    return WarpStatus.Exist;
                }

                return WarpStatus.None;
            }
        }

        public string TimeText
        {
            get
            {
                return IsCompleted ? Time.ToString("0.000") : string.Empty;
            }
        }

        public float ParTime
        {
            get
            {
                return SMBDatabase.ParTimes[ChapterNumber - 1][(int)LevelType][LevelNumber - 1];
            }
        }

        public bool IsGradeA
        {
            get
            {
                return Time <= ParTime;
            }
        }

        public CompletedStatus GetCompletedStatus
        {
            get
            {
                if (IsCompleted)
                {
                    if (IsGradeA)
                    {
                        return CompletedStatus.GradeA;
                    }

                    return CompletedStatus.Completed;
                }

                return CompletedStatus.None;
            }
        }

        public int LeaderboardID
        {
            get
            {
                if (LevelType == LevelType.Light && ChapterNumber <= SMBDatabase.LightLevelLeaderboards.Length)
                {
                    return SMBDatabase.LightLevelLeaderboards[ChapterNumber - 1][LevelNumber - 1];
                }
                else if (LevelType == LevelType.Dark && ChapterNumber <= SMBDatabase.DarkLevelLeaderboards.Length)
                {
                    return SMBDatabase.DarkLevelLeaderboards[ChapterNumber - 1][LevelNumber - 1];
                }

                return 0;
            }
        }

        public override string ToString()
        {
            string text = LevelNameWithNumber;
            if (IsCompleted) text += " - " + TimeText;
            if (IsGradeA) text += " - Grade A+";
            if (GotBandage) text += " - Bandage";
            if (GotWarp) text += " - Portal";
            return text;
        }
    }
}
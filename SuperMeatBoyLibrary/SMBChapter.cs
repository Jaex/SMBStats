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
using HelpersLibrary;

namespace SuperMeatBoyLibrary
{
    public class SMBChapter
    {
        public int Number { get; private set; }
        public string Name { get; private set; }

        public int MaxLevelCount { get; private set; }
        public int MaxWarpCount { get; private set; }
        public int MaxTotalLevelCount { get; private set; }
        public int MaxBandagesCount { get; private set; }
        public int MaxTotalCount { get; private set; }

        public int LightCompleted { get; private set; }
        public int DarkCompleted { get; private set; }
        public int WarpCompleted { get; private set; }
        public int TotalLevelCompleted { get; private set; }
        public int Bandages { get; private set; }
        public int TotalCount { get; private set; }
        public ChapterStatus Status { get; private set; }
        public bool IsGlitchCompleted { get; private set; }

        public List<SMBLevel> LightLevels { get; private set; }
        public List<SMBLevel> DarkLevels { get; private set; }
        public List<SMBLevel> WarpLevels { get; private set; }

        public float TotalTime { get; private set; }
        public float TotalLightTime { get; private set; }
        public float TotalDarkTime { get; private set; }
        public float TotalWarpTime { get; private set; }
        public int TotalLevelsGradeA { get; private set; }
        public int TotalLightGradeA { get; private set; }
        public int TotalDarkGradeA { get; private set; }
        public float TotalCompletedParTime { get; private set; }
        public float TotalLightCompletedParTime { get; private set; }
        public float TotalDarkCompletedParTime { get; private set; }
        public float TotalWarpCompletedParTime { get; private set; }

        public string GlitchStatusText { get; private set; }
        public string LightBossStatusText { get; private set; }
        public string DarkBossStatusText { get; private set; }
        public string ProgressText { get; private set; }
        public string TotalLevelsCompletedText { get; private set; }
        public string LightLevelsCompletedText { get; private set; }
        public string DarkLevelsCompletedText { get; private set; }
        public string WarpLevelsCompletedText { get; private set; }
        public string BandagesText { get; private set; }
        public string TotalLevelTimesText { get; private set; }
        public string LightLevelTimesText { get; private set; }
        public string DarkLevelTimesText { get; private set; }
        public string TotalLevelsGradeAText { get; private set; }
        public string TotalLightGradeAText { get; private set; }
        public string TotalDarkGradeAText { get; private set; }

        public SMBChapter(SMBManager smb, int chapterNumber)
        {
            Number = chapterNumber;
            Name = SMBDatabase.ChapterNames[Number - 1];

            MaxLevelCount = SMBHelpers.GetMaxLevelCount(chapterNumber);
            MaxWarpCount = SMBHelpers.GetMaxWarpLevelCount(chapterNumber);
            MaxTotalLevelCount = MaxLevelCount * 2 + MaxWarpCount + (Number < 7 ? 1 : 0);
            MaxBandagesCount = Number < 6 ? 20 : 0;
            MaxTotalCount = MaxTotalLevelCount + MaxBandagesCount;

            Status = (ChapterStatus)smb.GetChapterInfo(Number, ChapterStatType.Status);
            LightCompleted = smb.GetChapterInfo(Number, ChapterStatType.LightCompleted);
            DarkCompleted = smb.GetChapterInfo(Number, ChapterStatType.DarkCompleted);
            WarpCompleted = smb.GetChapterInfo(Number, ChapterStatType.WarpCompleted);
            IsGlitchCompleted = Status.HasFlag(ChapterStatus.GlitchCompleted);
            TotalLevelCompleted = LightCompleted + DarkCompleted + WarpCompleted + (IsGlitchCompleted ? 1 : 0);
            Bandages = smb.GetChapterInfo(Number, ChapterStatType.Bandages);
            TotalCount = TotalLevelCompleted + Bandages;

            LightLevels = GetLevels(smb, LevelType.Light);
            DarkLevels = GetLevels(smb, LevelType.Dark);
            WarpLevels = GetLevels(smb, LevelType.Warp);

            TotalLightTime = LightLevels.Where(x => x.IsCompleted).Sum(x => x.Time);
            TotalDarkTime = DarkLevels.Where(x => x.IsCompleted).Sum(x => x.Time);
            TotalWarpTime = WarpLevels.Where(x => x.IsCompleted).Sum(x => x.Time);
            TotalTime = TotalLightTime + TotalDarkTime + TotalWarpTime;
            TotalLightGradeA = LightLevels.Count(x => x.IsCompleted && x.IsGradeA);
            TotalDarkGradeA = DarkLevels.Count(x => x.IsCompleted && x.IsGradeA);
            TotalLevelsGradeA = TotalLightGradeA + TotalDarkGradeA;
            TotalLightCompletedParTime = LightLevels.Where(x => x.IsCompleted).Sum(x => x.ParTime);
            TotalDarkCompletedParTime = DarkLevels.Where(x => x.IsCompleted).Sum(x => x.ParTime);
            TotalWarpCompletedParTime = WarpLevels.Where(x => x.IsCompleted).Sum(x => x.ParTime);
            TotalCompletedParTime = TotalLightCompletedParTime + TotalDarkCompletedParTime + TotalWarpCompletedParTime;

            SetTexts();
        }

        private void SetTexts()
        {
            if (Number <= 6)
            {
                if (Status.HasFlag(ChapterStatus.GlitchUnlocked))
                {
                    if (Status.HasFlag(ChapterStatus.GlitchCompleted))
                    {
                        GlitchStatusText = "Completed";
                    }
                    else
                    {
                        GlitchStatusText = "Unlocked";
                    }
                }
                else
                {
                    GlitchStatusText = "Locked";
                }
            }
            else
            {
                GlitchStatusText = "Unavailable";
            }

            if (Number <= 6)
            {
                if (Status.HasFlag(ChapterStatus.LightBossCompleted))
                {
                    LightBossStatusText = "Completed";
                }
                else
                {
                    LightBossStatusText = "Not completed";
                }
            }
            else
            {
                LightBossStatusText = "Unavailable";
            }

            if (Number == 6)
            {
                if (Status.HasFlag(ChapterStatus.DarkBossCompleted))
                {
                    DarkBossStatusText = "Completed";
                }
                else
                {
                    DarkBossStatusText = "Not completed";
                }
            }
            else
            {
                DarkBossStatusText = "Unavailable";
            }

            ProgressText = string.Format("{0:0.##}%", Helpers.GetPercentage(TotalCount, MaxTotalCount));
            TotalLevelsCompletedText = string.Format("{0} / {1}", TotalLevelCompleted, MaxTotalLevelCount);
            LightLevelsCompletedText = string.Format("{0} / {1}", LightCompleted, MaxLevelCount);
            DarkLevelsCompletedText = string.Format("{0} / {1}", DarkCompleted, MaxLevelCount);
            WarpLevelsCompletedText = MaxWarpCount > 0 ? string.Format("{0} / {1}", WarpCompleted, MaxWarpCount) : string.Empty;
            BandagesText = MaxBandagesCount > 0 ? string.Format("{0} / {1}", Bandages, MaxBandagesCount) : string.Empty;
            TotalLevelTimesText =  string.Format("{0:0.000} / {1:0.000}", TotalTime, TotalCompletedParTime);
            LightLevelTimesText =  string.Format("{0:0.000} / {1:0.000}", TotalLightTime, TotalLightCompletedParTime);
            DarkLevelTimesText =  string.Format("{0:0.000} / {1:0.000}", TotalDarkTime, TotalDarkCompletedParTime);
            TotalLevelsGradeAText = string.Format("{0} / {1}", TotalLevelsGradeA, MaxLevelCount * 2);
            TotalLightGradeAText =  string.Format("{0} / {1}", TotalLightGradeA, MaxLevelCount);
            TotalDarkGradeAText =  string.Format("{0} / {1}", TotalDarkGradeA, MaxLevelCount);
        }

        private List<SMBLevel> GetLevels(SMBManager smb, LevelType levelType)
        {
            List<SMBLevel> levels = new List<SMBLevel>();

            int maxLevel = levelType != LevelType.Warp ? MaxLevelCount : MaxWarpCount;

            for (int i = 1; i <= maxLevel; i++)
            {
                SMBLevel info = smb.GetLevelInfo(Number, i, levelType);
                if (info != null) levels.Add(info);
            }

            return levels;
        }

        public override string ToString()
        {
            string text = string.Format("Chapter {0}: {1} - Light: {2} - Dark: {3}", Number, Name, LightLevelsCompletedText, DarkLevelsCompletedText);
            if (Number < 6) text += string.Format(" - Bandages: {0} - Warp: {1}", BandagesText, WarpLevelsCompletedText);
            text += string.Format(" - Progress: {0}", ProgressText);
            return text;
        }
    }
}
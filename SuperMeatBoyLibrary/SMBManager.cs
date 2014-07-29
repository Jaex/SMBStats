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
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuperMeatBoyLibrary
{
    public class SMBManager
    {
        public bool IsLoaded { get; private set; }
        public List<SMBChapter> Chapters { get; private set; }
        public Characters UnlockedCharacters { get; private set; }
        public List<SMBCharacter> CharactersList { get; private set; }

        public int TotalDeaths { get; private set; }
        public int TotalProgress { get; private set; }
        public float TotalTime { get; private set; }
        public float TotalParTime { get; private set; }
        public int TotalLevelsCompleted { get; private set; }
        public int TotalLightCompleted { get; private set; }
        public int TotalDarkCompleted { get; private set; }
        public int TotalWarpCompleted { get; private set; }
        public int TotalGlitchCompleted { get; private set; }
        public int TotalBandages { get; private set; }
        public int TotalLightGradeA { get; private set; }
        public int TotalDarkGradeA { get; private set; }
        public int LeaderboardScore { get; private set; }

        public int MaxTotalProgress { get; private set; }
        public int MaxTotalAllLevels { get; private set; }
        public int MaxTotalLevels { get; private set; }
        public int MaxTotalWarp { get; private set; }
        public int MaxTotalBandages { get; private set; }
        public int MaxTotalGlitchLevels { get; private set; }

        public string LeaderboardScoreText { get; private set; }
        public string TotalDeathsText { get; private set; }
        public string TotalTimeText { get; private set; }
        public string TotalProgressText { get; private set; }
        public string TotalLevelsCompletedText { get; private set; }
        public string TotalLightCompletedText { get; private set; }
        public string TotalDarkCompletedText { get; private set; }
        public string TotalWarpCompletedText { get; private set; }
        public string TotalGlitchCompletedText { get; private set; }
        public string TotalBandagesText { get; private set; }
        public string TotalLightGradeAText { get; private set; }
        public string TotalDarkGradeAText { get; private set; }

        private string savegamePath;
        private byte[] savegame;

        public bool Init(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                savegame = Helpers.FileGetBytes(path, 10000);

                if (savegame != null && savegame.Length > 0)
                {
                    Chapters = new List<SMBChapter>();

                    for (int chapterNumber = 1; chapterNumber <= 7; chapterNumber++)
                    {
                        SMBChapter chapter = new SMBChapter(this, chapterNumber);
                        Chapters.Add(chapter);
                    }

                    TotalDeaths = BitConverter.ToInt32(savegame, TotalDeathsOffset);
                    TotalProgress = Chapters.Sum(x => x.TotalCount);
                    TotalTime = Chapters.Sum(x => x.TotalTime);
                    TotalParTime = Chapters.Sum(x => x.TotalCompletedParTime);
                    TotalLevelsCompleted = Chapters.Sum(x => x.TotalLevelCompleted);
                    TotalLightCompleted = Chapters.Sum(x => x.LightCompleted);
                    TotalDarkCompleted = Chapters.Sum(x => x.DarkCompleted);
                    TotalWarpCompleted = Chapters.Sum(x => x.WarpCompleted);
                    TotalGlitchCompleted = Chapters.Count(x => x.IsGlitchCompleted);
                    TotalBandages = Chapters.Sum(x => x.Bandages);
                    TotalLightGradeA = Chapters.Sum(x => x.TotalLightGradeA);
                    TotalDarkGradeA = Chapters.Sum(x => x.TotalDarkGradeA);
                    LeaderboardScore = (int)(((TotalLevelsCompleted - TotalGlitchCompleted) * 1000000) - (TotalTime * 1000));

                    MaxTotalProgress = Chapters.Sum(x => x.MaxTotalCount);
                    MaxTotalAllLevels = Chapters.Sum(x => x.MaxTotalLevelCount);
                    MaxTotalLevels = Chapters.Sum(x => x.MaxLevelCount);
                    MaxTotalWarp = Chapters.Sum(x => x.MaxWarpCount);
                    MaxTotalGlitchLevels = 6;
                    MaxTotalBandages = Chapters.Sum(x => x.MaxBandagesCount);

                    LoadCharacters();

                    LeaderboardScoreText = string.Format("{0:N0}", LeaderboardScore);
                    TotalDeathsText = string.Format("{0}", TotalDeaths);
                    TotalTimeText = string.Format("{0:0.000} / {1:0.000}", TotalTime, TotalParTime);
                    TotalProgressText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalProgress - TotalGlitchCompleted, MaxTotalProgress - MaxTotalGlitchLevels) + TotalGlitchCompleted, TotalProgress, MaxTotalProgress);
                    TotalLevelsCompletedText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalLevelsCompleted, MaxTotalAllLevels), TotalLevelsCompleted, MaxTotalAllLevels);
                    TotalLightCompletedText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalLightCompleted, MaxTotalLevels), TotalLightCompleted, MaxTotalLevels);
                    TotalDarkCompletedText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalDarkCompleted, MaxTotalLevels), TotalDarkCompleted, MaxTotalLevels);
                    TotalWarpCompletedText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalWarpCompleted, MaxTotalWarp), TotalWarpCompleted, MaxTotalWarp);
                    TotalGlitchCompletedText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalGlitchCompleted, MaxTotalGlitchLevels), TotalGlitchCompleted, MaxTotalGlitchLevels);
                    TotalBandagesText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalBandages, MaxTotalBandages), TotalBandages, MaxTotalBandages);
                    TotalLightGradeAText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalLightGradeA, MaxTotalLevels), TotalLightGradeA, MaxTotalLevels);
                    TotalDarkGradeAText = string.Format("{0:0.##}% ( {1} / {2} )", Helpers.GetPercentage(TotalDarkGradeA, MaxTotalLevels), TotalDarkGradeA, MaxTotalLevels);

                    savegamePath = path;
                    IsLoaded = true;
                    return true;
                }
            }

            IsLoaded = false;
            return false;
        }

        public bool Refresh()
        {
            return Init(savegamePath);
        }

        private void LoadCharacters()
        {
            UnlockedCharacters = (Characters)BitConverter.ToInt32(savegame, 0);

            CharactersList = new List<SMBCharacter>();

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.MeatBoy,
                Name = "Meat Boy",
                Origin = "Meat Boy",
                Requirement = "Buy the game",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.MeatBoy)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.CommanderVideo,
                Name = "Commander Video",
                Origin = "Bit.Trip Runner",
                Requirement = "Chapter 1 warp zone",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.CommanderVideo)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Jill,
                Name = "Jill",
                Origin = "Mighty Jill Off",
                Requirement = "Chapter 2 warp zone",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Jill)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Ogmo,
                Name = "Ogmo",
                Origin = "Jumper",
                Requirement = "Chapter 3 warp zone",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Ogmo)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Flywrench,
                Name = "Flywrench",
                Origin = "Flywrench",
                Requirement = "Chapter 4 warp zone",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Flywrench)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.TheKid,
                Name = "The Kid",
                Origin = "I Wanna Be The Guy",
                Requirement = "Chapter 5 warp zone",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.TheKid)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Headcrab,
                Name = "Headcrab",
                Origin = "Half-Life",
                Requirement = "10 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Headcrab)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Josef,
                Name = "Josef",
                Origin = "Machinarium",
                Requirement = "30 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Josef)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.AlienHominid,
                Name = "Alien Hominid",
                Origin = "Alien Hominid",
                Requirement = "30 bandages (Ultra Edition)",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.AlienHominid)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.MeatBoy8Bit,
                Name = "8 Bit Meat Boy",
                Origin = "Meat Boy",
                Requirement = "40 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.MeatBoy8Bit)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Naija,
                Name = "Naija",
                Origin = "Aquaria",
                Requirement = "50 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Naija)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.MeatBoy4Bit,
                Name = "4 Bit Meat Boy",
                Origin = "Meat Boy",
                Requirement = "60 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.MeatBoy4Bit)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Runman,
                Name = "Runman",
                Origin = "Runman",
                Requirement = "70 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Runman)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.MeatBoy4Color,
                Name = "4 Color Meat Boy",
                Origin = "Meat Boy",
                Requirement = "80 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.MeatBoy4Color)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.CaptainViridian,
                Name = "Captain Viridian",
                Origin = "VVVVVV",
                Requirement = "90 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.CaptainViridian)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Steve,
                Name = "Steve",
                Origin = "Minecraft",
                Requirement = "100 bandages",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Steve)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.MeatNinja,
                Name = "Meat Ninja",
                Origin = "Super Meat Boy",
                Requirement = "100% the game",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.MeatNinja)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.BandageGirl,
                Name = "Bandage Girl",
                Origin = "Meat Boy",
                Requirement = "Only in Cotton Alley",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.BandageGirl)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.Brownie,
                Name = "Brownie",
                Origin = "Super Meat Boy",
                Requirement = "Press: RB RB RB B B B X",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.Brownie)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.GooBall,
                Name = "Goo Ball",
                Origin = "World of Goo",
                Requirement = "Type: ballgoo",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.GooBall)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.TofuBoy,
                Name = "Tofu Boy",
                Origin = "Super Tofu Boy",
                Requirement = "Type: petaphile",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.TofuBoy)
            });

            CharactersList.Add(new SMBCharacter
            {
                Character = Characters.PotatoBoy,
                Name = "Potato Boy",
                Origin = "Super Meat Boy",
                Requirement = "Only in Super Potato Boy",
                IsUnlocked = UnlockedCharacters.HasFlag(Characters.PotatoBoy)
            });
        }

        public List<SMBLevel> GetLevels(int chapterNumber, LevelTypeFilter levelType)
        {
            if (Chapters != null && chapterNumber <= Chapters.Count)
            {
                SMBChapter chapter = Chapters[chapterNumber - 1];

                switch (levelType)
                {
                    case LevelTypeFilter.All: return chapter.LightLevels.Concat(chapter.DarkLevels).Concat(chapter.WarpLevels).ToList();
                    case LevelTypeFilter.Light: return chapter.LightLevels;
                    case LevelTypeFilter.Dark: return chapter.DarkLevels;
                    case LevelTypeFilter.Warp: return chapter.WarpLevels;
                }
            }

            return null;
        }

        private const float InvalidTime = 1.0E+8f;
        private const int TotalDeathsOffset = 0x8;
        private const int ChapterInfoStart = 0x1C;
        private const int ChapterInfoOffset = 12;
        private const int LevelStart = 0x88;
        private const int TheGuyWarpZoneStart = 0xF10;
        private const int LevelOffset = 12;
        private const int LevelProgressOffset = 4;

        public byte GetChapterInfo(int chapterNumber, ChapterStatType info)
        {
            int offset = ChapterInfoStart + ((chapterNumber - 1) * ChapterInfoOffset) + (int)info;
            return savegame[offset];
        }

        public SMBLevel GetLevelInfo(int chapter, int level, LevelType type)
        {
            int offset;

            // if The Guy Warp Zone
            if (type == LevelType.Warp && chapter == 5 && level >= 4 && level <= 6)
            {
                offset = TheGuyWarpZoneStart + ((level - 4) * LevelOffset);
            }
            else
            {
                int chaptersOffset = 0;

                for (int i = 1; i < chapter; i++)
                {
                    chaptersOffset += ((SMBHelpers.GetMaxLevelCount(i) * 2) + SMBHelpers.GetMaxWarpLevelCount(i)) * LevelOffset;
                }

                int levelsOffset = (level - 1 + (SMBHelpers.GetMaxLevelCount(chapter) * (int)type)) * LevelOffset;

                offset = LevelStart + chaptersOffset + levelsOffset;
            }

            SMBLevel info = new SMBLevel
            {
                ChapterNumber = chapter,
                LevelNumber = level,
                LevelType = type,
                Time = BitConverter.ToSingle(savegame, offset),
                Progress = (LevelStatus)savegame[offset + LevelProgressOffset]
            };

            // Debug.WriteLine(string.Format("{0} - {1:X} - {1}", info.LevelName, offset));

            return info;
        }
    }
}
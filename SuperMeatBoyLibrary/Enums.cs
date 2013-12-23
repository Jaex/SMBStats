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

namespace SuperMeatBoyLibrary
{
    public enum ChapterStatType
    {
        LightCompleted, DarkCompleted, Bandages, WarpCompleted, Status
    }

    public enum LevelType
    {
        Light, Dark, Warp
    }

    [Flags]
    public enum ChapterStatus
    {
        None = 0,
        GlitchUnlocked = 1,
        Unknown2 = 2, // DarkGlitchUnlocked?
        LightBossCompleted = 4,
        DarkBossCompleted = 8,
        Unknown5 = 16,
        GlitchCompleted = 32,
        Unknown7 = 64 // DarkGlitchCompleted?
    }

    [Flags]
    public enum LevelStatus
    {
        None = 0,
        GotBandage = 1,
        Completed = 2,
        Unknown3 = 4,
        GotWarp = 8
    }

    public enum BandageStatus
    {
        None, Exist, Got
    }

    public enum WarpStatus
    {
        None, Exist, Got
    }

    public enum CompletedStatus
    {
        None, Completed, GradeA
    }

    public enum LevelTypeFilter
    {
        All, Light, Dark, Warp
    }

    public enum CompareFilter
    {
        All, Bigger, Smaller
    }

    [Flags]
    public enum Characters
    {
        None = 0,
        MeatBoy = 1,
        MeatBoy8Bit = 1 << 1,
        MeatBoy4Color = 1 << 2,
        MeatBoy4Bit = 1 << 3,
        DrFetus = 1 << 4,
        Brownie = 1 << 5,
        BandageGirl = 1 << 6,
        MeatNinja = 1 << 7,
        Unknown9 = 1 << 8,
        Unknown10 = 1 << 9,
        Naija = 1 << 10,
        CommanderVideo = 1 << 11,
        Runman = 1 << 12,
        GooBall = 1 << 13,
        Steve = 1 << 14,
        Unknown16 = 1 << 15,
        Flywrench = 1 << 16,
        Unknown18 = 1 << 17,
        Jill = 1 << 18,
        CaptainViridian = 1 << 19,
        TofuBoy = 1 << 20,
        Josef = 1 << 21,
        TheKid = 1 << 22,
        Headcrab = 1 << 23,
        Ogmo = 1 << 24,
        PotatoBoy = 1 << 25,
        EndingMeatBoy = 1 << 26,
        AlienHominid = 1 << 27,
        Unknown29 = 1 << 28
    }
}
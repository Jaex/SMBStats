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

using System.Runtime.InteropServices;

namespace SuperMeatBoyLibrary
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DirectoryInfo
    {
        public int a, b;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FileInfo
    {
        public int Offset, Size, Directory;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DirectoryName
    {
        public DirectoryInfo Directory;
        public string Name;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FileName
    {
        public FileInfo File;
        public string Name;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ImageFileInfo
    {
        public int Offset, Length;
    }

    public class ProgressInfo
    {
        public int Index { get; private set; }

        public int Length { get; private set; }

        public float Percentage
        {
            get { return (float)Index / Length * 100; }
        }

        public string FileName { get; private set; }

        public ProgressInfo(int index, int length, string filename)
        {
            Index = index;
            Length = length;
            FileName = filename;
        }
    }
}
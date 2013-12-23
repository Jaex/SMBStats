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

using System.Drawing;
using System.IO;

namespace HelpersLibrary
{
    public static class Helpers
    {
        public static byte[] FileGetBytes(string filePath, int maxLength = 0)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (maxLength == 0 || maxLength >= stream.Length)
                {
                    return stream.GetBytes();
                }
            }

            return null;
        }

        public static float GetPercentage(float value, float maxValue)
        {
            if (maxValue == 0) return 0;
            return value / maxValue * 100;
        }

        public static float GetPercentage(int value, int maxValue)
        {
            return GetPercentage((float)value, (float)maxValue);
        }

        public static Color GetColor(float perc, Color min, Color max)
        {
            if (float.IsNaN(perc)) perc = 1;
            int r = (int)(min.R + (max.R - min.R) * perc);
            int g = (int)(min.G + (max.G - min.G) * perc);
            int b = (int)(min.B + (max.B - min.B) * perc);
            return Color.FromArgb(r, g, b);
        }

        public static int IndexOf(byte[] array, byte[] pattern)
        {
            if (pattern.Length > array.Length) return -1;

            for (int i = 0; i < array.Length - pattern.Length; i++)
            {
                bool found = true;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (array[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found) return i;
            }

            return -1;
        }
    }
}
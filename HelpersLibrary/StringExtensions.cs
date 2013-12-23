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
using System.Text;

namespace HelpersLibrary
{
    public static class StringExtensions
    {
        public static string Left(this string str, int length)
        {
            if (length < 1) return string.Empty;
            if (length < str.Length) return str.Substring(0, length);
            return str;
        }

        public static string Right(this string str, int length)
        {
            if (length < 1) return string.Empty;
            if (length < str.Length) return str.Substring(str.Length - length);
            return str;
        }

        public static string RemoveLeft(this string str, int length)
        {
            if (length < 1) return string.Empty;
            if (length < str.Length) return str.Remove(0, length);
            return str;
        }

        public static string RemoveRight(this string str, int length)
        {
            if (length < 1) return string.Empty;
            if (length < str.Length) return str.Remove(str.Length - length);
            return str;
        }

        public static string ReplaceWith(this string str, string search, string replace,
            int occurrence = 0, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (!string.IsNullOrEmpty(search))
            {
                int count = 0, location;

                while (occurrence == 0 || occurrence > count)
                {
                    location = str.IndexOf(search, comparison);
                    if (location < 0) break;
                    count++;
                    str = str.Remove(location, search.Length).Insert(location, replace);
                }
            }

            return str;
        }

        public static string RemoveWhiteSpaces(this string str)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in str)
            {
                if (!Char.IsWhiteSpace(c)) result.Append(c);
            }

            return result.ToString();
        }

        public static string Reverse(this string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        public static string Truncate(this string str, int length, string endings = "...")
        {
            if (length < 1) return string.Empty;

            if (length < str.Length)
            {
                str = str.Left(length - endings.Length);
                str += endings;
            }

            return str;
        }

        public static bool IsValidUrl(this string url)
        {
            return Uri.IsWellFormedUriString(url.Trim(), UriKind.Absolute);
        }

        public static byte[] HexToBytes(this string hex)
        {
            hex = hex.Replace("-", "").Replace(" ", "");
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}
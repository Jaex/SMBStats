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

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperMeatBoyLibrary
{
    public static class ParserHelper
    {
        public static void ParseAllLevels(string folderPath)
        {
            Console.WriteLine(ParseLevelNames(Path.Combine(folderPath, "Forest.chapter")));
            Console.WriteLine(ParseLevelNames(Path.Combine(folderPath, "Hospital.chapter")));
            Console.WriteLine(ParseLevelNames(Path.Combine(folderPath, "SaltFactory.chapter")));
            Console.WriteLine(ParseLevelNames(Path.Combine(folderPath, "Hell.chapter")));
            Console.WriteLine(ParseLevelNames(Path.Combine(folderPath, "Rapture.chapter")));
            Console.WriteLine(ParseLevelNames(Path.Combine(folderPath, "DrFetus.chapter")));
            Console.WriteLine(ParseLevelNames(Path.Combine(folderPath, "Bandage.chapter")));

            Console.WriteLine(ParseParTimes(Path.Combine(folderPath, "Forest.chapter")));
            Console.WriteLine(ParseParTimes(Path.Combine(folderPath, "Hospital.chapter")));
            Console.WriteLine(ParseParTimes(Path.Combine(folderPath, "SaltFactory.chapter")));
            Console.WriteLine(ParseParTimes(Path.Combine(folderPath, "Hell.chapter")));
            Console.WriteLine(ParseParTimes(Path.Combine(folderPath, "Rapture.chapter")));
            Console.WriteLine(ParseParTimes(Path.Combine(folderPath, "DrFetus.chapter")));
            Console.WriteLine(ParseParTimes(Path.Combine(folderPath, "Bandage.chapter")));
        }

        public static string ParseLevelNames(string path)
        {
            string text = File.ReadAllText(path);
            StringBuilder str = new StringBuilder();
            str.AppendLine("new string[][] {");
            str.AppendLine("    new string[] { " + GetLevelNames(text, LevelType.Light) + " },");
            str.AppendLine("    new string[] { " + GetLevelNames(text, LevelType.Dark) + " }");
            str.Append("},");
            return str.ToString();
        }

        public static string GetLevelNames(string text, LevelType levelType)
        {
            string pattern = "{0}(?:.|\\s)+?name\\s*=\\s*\"(.+)\";";
            string levelTypeName;

            switch (levelType)
            {
                default:
                case LevelType.Light:
                    levelTypeName = "normlevel";
                    break;
                case LevelType.Dark:
                    levelTypeName = "altlevel";
                    break;
            }

            string[] result = Regex.Matches(text, string.Format(pattern, levelTypeName)).OfType<Match>().
                Where(x => x.Success).Select(x => '"' + x.Groups[1].Value + '"').ToArray();

            return string.Join(", ", result);
        }

        public static string ParseParTimes(string path)
        {
            string text = File.ReadAllText(path);
            StringBuilder str = new StringBuilder();
            str.AppendLine("new float[][] {");
            str.AppendLine("    new float[] { " + GetParTimes(text, LevelType.Light) + " },");
            str.AppendLine("    new float[] { " + GetParTimes(text, LevelType.Dark) + " },");
            str.AppendLine("    new float[] { 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f }");
            str.Append("},");
            return str.ToString();
        }

        public static string GetParTimes(string text, LevelType levelType)
        {
            string pattern = "{0}(?:.|\\s)+?par\\s*=\\s*(.+);";
            string levelTypeName;

            switch (levelType)
            {
                default:
                case LevelType.Light:
                    levelTypeName = "normlevel";
                    break;
                case LevelType.Dark:
                    levelTypeName = "altlevel";
                    break;
            }

            string[] result = Regex.Matches(text, string.Format(pattern, levelTypeName)).OfType<Match>().
                Where(x => x.Success).Select(x => x.Groups[1].Value).Select(x => float.Parse(x).ToString("0.00") + "f").ToArray();

            return string.Join(", ", result);
        }
    }
}
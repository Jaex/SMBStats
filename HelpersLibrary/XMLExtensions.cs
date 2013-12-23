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

using System.Linq;
using System.Xml.Linq;

namespace HelpersLibrary
{
    public static class XMLExtensions
    {
        public static XElement GetNode(this XContainer element, string path)
        {
            path = path.Trim().Trim('/');

            if (element != null && !string.IsNullOrEmpty(path))
            {
                XContainer lastElement = element;

                string[] splitPath = path.Split('/');

                if (splitPath != null && splitPath.Length > 0)
                {
                    foreach (string name in splitPath)
                    {
                        if (name.Contains('|'))
                        {
                            string[] splitName = name.Split('|');

                            XContainer lastElement2 = null;

                            foreach (string name2 in splitName)
                            {
                                lastElement2 = lastElement.Element(name2);
                                if (lastElement2 != null) break;
                            }

                            lastElement = lastElement2;
                        }
                        else
                        {
                            lastElement = lastElement.Element(name);
                        }

                        if (lastElement == null) return null;
                    }

                    return (XElement)lastElement;
                }
            }

            return null;
        }

        public static XElement[] GetNodes(this XContainer element, string path)
        {
            path = path.Trim().Trim('/');

            if (element != null && !string.IsNullOrEmpty(path))
            {
                int index = path.LastIndexOf('/');

                if (index > -1)
                {
                    string leftPath = path.Left(index);
                    string lastPath = path.RemoveLeft(index + 1);

                    XElement lastNode = element.GetNode(leftPath);

                    if (lastNode != null)
                    {
                        return lastNode.Elements(lastPath).Where(x => x != null).ToArray();
                    }
                }
            }

            return null;
        }

        public static string GetValue(this XContainer element, string path, string defaultValue = null)
        {
            XElement xe = element.GetNode(path);

            if (xe != null) return xe.Value;

            return defaultValue;
        }
    }
}
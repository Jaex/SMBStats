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
using System.IO;
using HelpersLibrary;

namespace SuperMeatBoyLibrary
{
    public static class DataHelpers
    {
        // private static readonly byte[] PNGHeader = new byte[8] { 137, 80, 78, 71, 13, 10, 26, 10 };

        public static void ConvertTPtoPNG(string tpPath, string pngPath)
        {
            using (FileStream fs = new FileStream(tpPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                DataHelpers.ConvertTPtoPNG(fs, pngPath);
            }
        }

        public static bool ConvertTPtoPNG(Stream stream, string savePath, bool overwrite = false)
        {
            stream.Position = 0;

            int imageCount = stream.Read<int>();

            if (imageCount > 0 && imageCount < 10)
            {
                ImageFileInfo[] imageList = new ImageFileInfo[imageCount];

                for (int i = 0; i < imageCount; i++)
                {
                    imageList[i] = stream.Read<ImageFileInfo>();
                    stream.Seek(9, SeekOrigin.Current);
                }

                string filename = savePath.Left(savePath.LastIndexOf('.'));

                for (int i = 0; i < imageList.Length; i++)
                {
                    string num = "";
                    if (i > 0) num = "-" + (i + 1);
                    savePath = filename + num + ".png";

                    if (overwrite || !File.Exists(savePath))
                    {
                        using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            stream.CopyStream(fs, imageList[i].Offset, imageList[i].Length);
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public static void ConvertPNGtoTP(string pngPath, string tpPath)
        {
            using (FileStream fs = new FileStream(pngPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                DataHelpers.ConvertPNGtoTP(fs, tpPath);
            }
        }

        public static void ConvertPNGtoTP(Stream stream, string tpPath)
        {
            using (FileStream fs = new FileStream(tpPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                fs.Write(BitConverter.GetBytes(1), 0, 4);
                fs.Write(BitConverter.GetBytes(21), 0, 4);
                fs.Write(BitConverter.GetBytes((int)stream.Length), 0, 4);
                fs.Seek(9, SeekOrigin.Current);
                stream.CopyStream(fs);
            }
        }

        public static void CreateEmptyDataFile(string savePath)
        {
            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                fs.Write(new byte[8], 0, 8);
            }
        }
    }
}
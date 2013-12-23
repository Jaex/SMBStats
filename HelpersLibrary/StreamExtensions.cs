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
using System.Runtime.InteropServices;

namespace HelpersLibrary
{
    public static class StreamExtensions
    {
        private const int BufferLength = 4096;

        public static void CopyStream(this Stream fromStream, Stream toStream)
        {
            fromStream.Position = 0;

            byte[] buffer = new byte[BufferLength];
            int bytesRead;

            while ((bytesRead = fromStream.Read(buffer, 0, BufferLength)) > 0)
            {
                toStream.Write(buffer, 0, bytesRead);
            }
        }

        public static void CopyStream(this Stream fromStream, Stream toStream, int offset, int length)
        {
            fromStream.Position = offset;

            byte[] buffer = new byte[BufferLength];
            int bytesRead, readLength = BufferLength, currentLength = 0;

            while (readLength == BufferLength)
            {
                if ((currentLength + BufferLength) > length)
                {
                    readLength = length - currentLength;
                }

                bytesRead = fromStream.Read(buffer, 0, readLength);
                currentLength += bytesRead;
                toStream.Write(buffer, 0, bytesRead);
            }
        }

        public static byte[] GetBytes(this Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyStream(ms);
                return ms.ToArray();
            }
        }

        public static byte[] GetBytes(this Stream stream, int offset, int length)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyStream(ms, offset, length);
                return ms.ToArray();
            }
        }

        public static void WriteFile(this Stream stream, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string directoryPath = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    stream.CopyStream(fileStream);
                }
            }
        }

        public static T Read<T>(this Stream stream)
        {
            byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
            int bytes = stream.Read(buffer, 0, buffer.Length);

            if (bytes == 0) throw new InvalidOperationException("End-of-file reached");
            if (bytes != buffer.Length) throw new ArgumentException("File contains bad data");

            GCHandle hdl = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T retval;

            try
            {
                retval = (T)Marshal.PtrToStructure(hdl.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                hdl.Free();
            }

            return retval;
        }
    }
}
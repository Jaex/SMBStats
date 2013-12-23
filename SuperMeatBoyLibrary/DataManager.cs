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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using HelpersLibrary;

namespace SuperMeatBoyLibrary
{
    public class DataManager
    {
        public delegate void DataManagerProgressChanged(ProgressInfo progress);
        public event DataManagerProgressChanged ProgressChanged;

        public delegate void DataManagerCompleted(string error);
        public event DataManagerCompleted Completed;

        public bool AutoConvertPNG { get; set; }

        private DirectoryInfo[] directoryList;
        private FileInfo[] fileList;
        private DirectoryName[] directoryNameList;
        private FileName[] fileNameList;

        private BackgroundWorker bw;
        private string filePath, extractFolderPath;
        private bool isBusy;

        public void UnpackData(string filePath, string extractFolderPath)
        {
            if (!isBusy && !string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(extractFolderPath) && File.Exists(filePath))
            {
                isBusy = true;
                this.filePath = Path.GetFullPath(filePath);
                this.extractFolderPath = Path.GetFullPath(extractFolderPath);
                bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.WorkerReportsProgress = true;
                bw.RunWorkerAsync();
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    GetFileDetails(fs);
                    ExtractFiles(fs, extractFolderPath);
                }
            }
            catch (Exception ex)
            {
                e.Result = ex.ToString();
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressInfo progress = e.UserState as ProgressInfo;

            if (ProgressChanged != null && progress != null)
            {
                ProgressChanged(progress);
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Completed != null)
            {
                Completed(e.Result as string);
            }
        }

        private void GetFileDetails(FileStream fs)
        {
            // Directory info

            int directoryCount = fs.Read<int>();

            if (directoryCount < 1 || directoryCount > 100) throw new Exception("Directory count invalid: " + directoryCount);

            directoryList = new DirectoryInfo[directoryCount];

            for (int i = 0; i < directoryCount; i++)
            {
                DirectoryInfo directoryInfo = fs.Read<DirectoryInfo>();
                directoryList[i] = directoryInfo;
            }

            // File info

            int fileCount = fs.Read<int>();

            if (fileCount < 1 || fileCount > 10000) throw new Exception("File count invalid: " + fileCount);

            fileList = new FileInfo[fileCount];

            for (int i = 0; i < fileCount; i++)
            {
                FileInfo file = fs.Read<FileInfo>();
                fileList[i] = file;
            }

            int directoryNameCount = fs.Read<int>();
            int fileNameCount = fs.Read<int>();

            // Directory names

            byte[] bytesDirectoryNames = new byte[directoryNameCount];
            fs.Read(bytesDirectoryNames, 0, directoryNameCount);
            string directoryNames = Encoding.UTF8.GetString(bytesDirectoryNames);

            directoryNameList = new DirectoryName[directoryCount];

            string[] splitDirectory = directoryNames.Split('\0');

            for (int i = 0; i < directoryCount; i++)
            {
                directoryNameList[i] = new DirectoryName { Directory = directoryList[i], Name = splitDirectory[i] };
            }

            // File names

            byte[] bytesFileNames = new byte[fileNameCount];
            fs.Read(bytesFileNames, 0, fileNameCount);
            string fileNames = Encoding.UTF8.GetString(bytesFileNames);

            fileNameList = new FileName[fileCount];

            string[] splitFile = fileNames.Split('\0');

            for (int i = 0; i < fileCount; i++)
            {
                fileNameList[i] = new FileName { File = fileList[i], Name = splitFile[i] };
            }
        }

        private void ExtractFiles(FileStream fs, string extractFolderPath)
        {
            if (!Directory.Exists(extractFolderPath))
            {
                Directory.CreateDirectory(extractFolderPath);
            }

            for (int i = 0; i < directoryNameList.Length; i++)
            {
                string path = Path.GetFullPath(Path.Combine(extractFolderPath, directoryNameList[i].Name));

                if (!path.StartsWith(extractFolderPath)) throw new Exception("Invalid folder path: " + path);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }

            Stopwatch timer = Stopwatch.StartNew();

            for (int i = 0; i < fileNameList.Length; i++)
            {
                if (timer.ElapsedMilliseconds > 100)
                {
                    bw.ReportProgress(0, new ProgressInfo(i, fileNameList.Length, fileNameList[i].Name));
                    timer.Reset();
                    timer.Start();
                }

                string path = Path.GetFullPath(Path.Combine(extractFolderPath, fileNameList[i].Name));

                if (!path.StartsWith(extractFolderPath)) throw new Exception("Invalid file path: " + path);

                if (!File.Exists(path))
                {
                    using (FileStream fs2 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        fs.CopyStream(fs2, fileNameList[i].File.Offset, fileNameList[i].File.Size);
                    }
                }

                if (AutoConvertPNG && Path.GetExtension(path) == ".tp")
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyStream(ms, fileNameList[i].File.Offset, fileNameList[i].File.Size);
                        DataHelpers.ConvertTPtoPNG(ms, path);
                    }
                }
            }

            bw.ReportProgress(0, new ProgressInfo(fileNameList.Length, fileNameList.Length, null));
        }
    }
}
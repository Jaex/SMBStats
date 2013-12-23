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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace HelpersLibrary
{
    public static class MyWebRequest
    {
        public static string SendPostRequest(string url, Dictionary<string, string> arguments = null)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(JoinArguments(arguments));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = false;
            request.ServicePoint.Expect100Continue = false;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            return GetStringResponse(request);
        }

        public static string SendGetRequest(string url, Dictionary<string, string> arguments = null)
        {
            if (arguments != null && arguments.Count > 0) url += "?" + JoinArguments(arguments);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = false;
            request.ServicePoint.Expect100Continue = false;

            return GetStringResponse(request);
        }

        private static string JoinArguments(Dictionary<string, string> arguments)
        {
            if (arguments != null && arguments.Count > 0)
            {
                return string.Join("&", arguments.Select(x => x.Key + "=" + HttpUtility.UrlEncode(x.Value)).ToArray());
            }

            return string.Empty;
        }

        private static string GetStringResponse(HttpWebRequest request)
        {
            using (WebResponse response = request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
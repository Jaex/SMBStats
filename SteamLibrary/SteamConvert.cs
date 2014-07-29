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
using System.Collections.Generic;

namespace SteamLibrary
{
    public static class SteamConvert
    {
        private const long SteamKey = 76561197960265728;

        public static string FriendIDToSteamID(long friendID)
        {
            if (friendID > 0 && SteamHelpers.IsFriendID(friendID))
            {
                int server = friendID % 2 == 0 ? 0 : 1;
                int auth = (int)(friendID - SteamKey - server) / 2;
                return string.Format("STEAM_0:{0}:{1}", server, auth);
            }

            return null;
        }

        public static string FriendIDToCommunityID(long friendID)
        {
            if (friendID > 0 && SteamHelpers.IsFriendID(friendID))
            {
                List<SteamPlayerProfile> profile = SteamLib.GetPlayerProfiles(friendID.ToString());

                if (profile != null && profile.Count > 0)
                {
                    return profile[0].CommunityID;
                }
            }

            return null;
        }

        public static long SteamIDToFriendID(string steamID)
        {
            if (!string.IsNullOrEmpty(steamID) && SteamHelpers.IsSteamID(steamID))
            {
                string[] split = steamID.Split(':');
                return int.Parse(split[2]) * 2 + SteamKey + int.Parse(split[1]);
            }

            return 0;
        }

        public static long CommunityIDToFriendID(string communityID)
        {
            if (!string.IsNullOrEmpty(communityID))
            {
                SteamPlayerProfile profile = SteamLib.GetPlayerProfile(communityID);

                if (profile != null)
                {
                    return profile.SteamID64;
                }
            }

            return 0;
        }

        public static string CommunityURLToID(string url)
        {
            url = url.Trim('/');
            return url.Remove(0, url.LastIndexOf('/') + 1);
        }

        public static long ConvertToFriendID(string id)
        {
            long friendID = 0;

            if (!string.IsNullOrEmpty(id))
            {
                id = id.Trim();

                if (id.Contains("steamcommunity.com"))
                {
                    id = CommunityURLToID(id);
                }

                if (SteamHelpers.IsFriendID(id))
                {
                    friendID = Convert.ToInt64(id);
                }
                else if (SteamHelpers.IsSteamID(id))
                {
                    friendID = SteamIDToFriendID(id);
                }
                else
                {
                    friendID = CommunityIDToFriendID(id);
                }
            }

            return friendID;
        }
    }
}
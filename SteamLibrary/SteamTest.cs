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

using System.Diagnostics;

namespace SteamLibrary
{
    public static class SteamTest
    {
        private static long FriendID = 76561197964799523;
        private static string SteamID = "STEAM_0:1:2266897";
        private static string CommunityID = "ww";
        private static string CommunityURL = "http://steamcommunity.com/profiles/" + FriendID;
        private static string CommunityCustomURL = "http://steamcommunity.com/id/" + CommunityID;

        public static void Start()
        {
            // SteamHelpers.cs
            Debug.WriteLine("SteamDirectory: " + SteamHelpers.GetSteamDirectory());
            Debug.WriteLine("IsFriendID: " + SteamHelpers.IsFriendID(FriendID));
            Debug.WriteLine("IsSteamID: " + SteamHelpers.IsSteamID(SteamID));

            // SteamConvert.cs
            Debug.WriteLine("FriendIDToSteamID: " + (SteamConvert.FriendIDToSteamID(FriendID) == SteamID));
            Debug.WriteLine("FriendIDToCommunityID: " + (SteamConvert.FriendIDToCommunityID(FriendID) == CommunityID));
            Debug.WriteLine("SteamIDToFriendID: " + (SteamConvert.SteamIDToFriendID(SteamID) == FriendID));
            Debug.WriteLine("CommunityIDToFriendID: " + (SteamConvert.CommunityIDToFriendID(CommunityID) == FriendID));
            Debug.WriteLine("CommunityURLToID (CommunityURL): " + (SteamConvert.CommunityURLToID(CommunityURL) == FriendID.ToString()));
            Debug.WriteLine("CommunityURLToID (CommunityCustomURL): " + (SteamConvert.CommunityURLToID(CommunityCustomURL) == CommunityID));
            Debug.WriteLine("ConvertToFriendID (FriendID): " + (SteamConvert.ConvertToFriendID(FriendID.ToString()) == FriendID));
            Debug.WriteLine("ConvertToFriendID (SteamID): " + (SteamConvert.ConvertToFriendID(SteamID) == FriendID));
            Debug.WriteLine("ConvertToFriendID (CommunityID): " + (SteamConvert.ConvertToFriendID(CommunityID) == FriendID));
            Debug.WriteLine("ConvertToFriendID (CommunityURL): " + (SteamConvert.ConvertToFriendID(CommunityURL) == FriendID));
            Debug.WriteLine("ConvertToFriendID (CommunityCustomURL): " + (SteamConvert.ConvertToFriendID(CommunityCustomURL) == FriendID));
        }
    }
}
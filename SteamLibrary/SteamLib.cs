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
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HelpersLibrary;

namespace SteamLibrary
{
    public static class SteamLib
    {
        private const string APIKey = "D983F60325677CF3FA1EF33C9932BE50";

        private const string PlayerProfileURL = "http://steamcommunity.com/profiles/{0}/?xml=1";
        private const string PlayerProfileCustomURL = "http://steamcommunity.com/id/{0}/?xml=1";
        private const string LeaderboardsListURL = "http://steamcommunity.com/stats/{0}/leaderboards/?xml=1";
        private const string LeaderboardFriendsURL = "http://steamcommunity.com/stats/{0}/leaderboards/{1}/?xml=1&steamid={2}";
        private const string LeaderboardGlobalURL = "http://steamcommunity.com/stats/{0}/leaderboards/{1}/?xml=1&start={2}&end={3}";
        private const string GetPlayerSummaries = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0001/?key={0}&steamids={1}&format=xml";

        public static List<LeaderboardEntry> GetLeaderboardGlobal(string gameName, int leaderboardID, int rangeStart, int rangeEnd, bool requestNicknames = false)
        {
            string url = string.Format(LeaderboardGlobalURL, gameName, leaderboardID, rangeStart, rangeEnd);

            return GetLeaderboard(url, requestNicknames);
        }

        public static List<LeaderboardEntry> GetLeaderboardFriends(string gameName, int leaderboardID, long steamID, bool requestNicknames = false)
        {
            string url = string.Format(LeaderboardFriendsURL, gameName, leaderboardID, steamID);

            return GetLeaderboard(url, requestNicknames);
        }

        public static SteamPlayerProfile GetPlayerProfile(string communityID)
        {
            SteamPlayerProfile playerProfile = null;

            string url = string.Format(PlayerProfileCustomURL, communityID);

            XDocument xd = XDocument.Load(url);

            if (xd != null)
            {
                XElement xe = xd.Element("profile");

                if (xe != null)
                {
                    playerProfile = new SteamPlayerProfile
                    {
                        SteamID64 = Convert.ToInt64(xe.GetValue("steamID64")),
                        Nickname = xe.GetValue("steamID"),
                        CommunityID = communityID
                    };
                }
            }

            return playerProfile;
        }

        public static List<SteamPlayerProfile> GetPlayerProfiles(params string[] steamids)
        {
            List<SteamPlayerProfile> profiles = new List<SteamPlayerProfile>();

            string steamIDList = string.Join(",", steamids);

            string url = string.Format(GetPlayerSummaries, APIKey, steamIDList);

            XDocument xd = XDocument.Load(url);

            if (xd != null)
            {
                foreach (XElement xe in xd.GetNodes("response/players/player"))
                {
                    profiles.Add(new SteamPlayerProfile
                    {
                        SteamID64 = Convert.ToInt64(xe.GetValue("steamid")),
                        Nickname = xe.GetValue("personaname"),
                        CommunityID = SteamConvert.CommunityURLToID(xe.GetValue("profileurl"))
                    });
                }
            }

            return profiles;
        }

        private static List<LeaderboardEntry> GetLeaderboard(string url, bool requestNicknames)
        {
            List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

            XDocument xd = XDocument.Load(url);

            if (xd != null)
            {
                foreach (XElement xe in xd.GetNodes("response/entries/entry"))
                {
                    entries.Add(new LeaderboardEntry
                    {
                        SteamID = Convert.ToInt64(xe.GetValue("steamid")),
                        Score = Convert.ToInt32(xe.GetValue("score")),
                        Rank = Convert.ToInt32(xe.GetValue("rank")),
                        Details = xe.GetValue("details")
                    });
                }
            }

            if (requestNicknames && entries.Count > 0)
            {
                string[] steamids = entries.Take(100).Select(x => x.SteamID.ToString()).ToArray();

                List<SteamPlayerProfile> profiles = GetPlayerProfiles(steamids);

                foreach (SteamPlayerProfile profile in profiles)
                {
                    LeaderboardEntry entry = entries.FirstOrDefault(x => x.SteamID == profile.SteamID64);
                    if (entry != null) entry.Nickname = profile.Nickname;
                }
            }

            return entries;
        }
    }
}
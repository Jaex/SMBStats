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

namespace SteamLibrary
{
    public class SteamPlayerProfile
    {
        public long SteamID64 { get; set; }
        public string CommunityID { get; set; }
        public string Nickname { get; set; }

        public string CommunityURL
        {
            get { return "http://steamcommunity.com/profiles/" + SteamID64; }
        }

        public string CommunityCustomURL
        {
            get { return "http://steamcommunity.com/id/" + CommunityID; }
        }
    }
}
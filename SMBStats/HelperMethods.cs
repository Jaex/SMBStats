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

using System.Windows.Forms;
using SuperMeatBoyLibrary;

namespace SMBStats
{
    public class HelperMethods
    {
        public static ImageList GetCharactersImageList()
        {
            ImageList il = new ImageList { ColorDepth = ColorDepth.Depth32Bit };
            il.Images.Add("unlocked", Properties.Resources.completed);
            il.Images.Add("locked", Properties.Resources.completed_black);
            il.Images.Add(Characters.None.ToString(), Properties.Resources.char_unknown);
            il.Images.Add(Characters.MeatBoy.ToString(), Properties.Resources.char_meatboy);
            il.Images.Add(Characters.CommanderVideo.ToString(), Properties.Resources.char_video);
            il.Images.Add(Characters.Jill.ToString(), Properties.Resources.char_jill);
            il.Images.Add(Characters.Ogmo.ToString(), Properties.Resources.char_ogmo);
            il.Images.Add(Characters.Flywrench.ToString(), Properties.Resources.char_flywrench);
            il.Images.Add(Characters.TheKid.ToString(), Properties.Resources.char_kid);
            il.Images.Add(Characters.Headcrab.ToString(), Properties.Resources.char_headcrab);
            il.Images.Add(Characters.Josef.ToString(), Properties.Resources.char_josef);
            il.Images.Add(Characters.AlienHominid.ToString(), Properties.Resources.char_hominid);
            il.Images.Add(Characters.MeatBoy8Bit.ToString(), Properties.Resources.char_8bit);
            il.Images.Add(Characters.Naija.ToString(), Properties.Resources.char_naija);
            il.Images.Add(Characters.MeatBoy4Bit.ToString(), Properties.Resources.char_4bit);
            il.Images.Add(Characters.Runman.ToString(), Properties.Resources.char_runman);
            il.Images.Add(Characters.MeatBoy4Color.ToString(), Properties.Resources.char_4color);
            il.Images.Add(Characters.CaptainViridian.ToString(), Properties.Resources.char_viridian);
            il.Images.Add(Characters.Steve.ToString(), Properties.Resources.char_steve);
            il.Images.Add(Characters.MeatNinja.ToString(), Properties.Resources.char_ninja);
            il.Images.Add(Characters.BandageGirl.ToString(), Properties.Resources.char_bandage);
            il.Images.Add(Characters.Brownie.ToString(), Properties.Resources.char_brownie);
            il.Images.Add(Characters.GooBall.ToString(), Properties.Resources.char_gooball);
            il.Images.Add(Characters.TofuBoy.ToString(), Properties.Resources.char_tofu);
            il.Images.Add(Characters.PotatoBoy.ToString(), Properties.Resources.char_potato);
            return il;
        }
    }
}
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

namespace SuperMeatBoyLibrary
{
    internal static class SMBDatabase
    {
        public static string[] ChapterNames = { "Forest", "Hospital", "Salt Factory", "Hell", "Rapture", "The End", "Cotton Alley" };

        public static string[][][] LevelNames = {
            new string[][] {
                new string[] { "Hello World", "Upward", "The Gap", "Nutshell", "Holy Mountain", "Bladecatcher", "Diverge", "The Bit", "Safety Third", "The Levee", "Fired", "Revolve", "Tommy's Cabin", "Blood Mountain", "Cactus Jumper", "Sidewinder", "MorningStar", "Altamont", "Intermission", "The Test" },
                new string[] { "oh, hello", "Onward", "BZZZZZ", "Plum Rain", "Creamsoda", "I am the night", "Two Roads", "Big Red", "So close", "Walls", "Doused ", "Fireal", "Tommy's Condo", "Mystery Spot", "Kick Machine", "Night Game", "The Clock", "Whitewash", "The Queener", "A perfect end" },
                new string[] { "Sky Pup", "Sky Pup", "Sky Pup", "The Commander!", "The Commander!", "The Commander!", "Hand Held Hack", "Hand Held Hack", "Hand Held Hack", "Space boy", "Space boy", "Space boy" }
            },
            new string[][] {
                new string[] { "Biohazard", "One Down", "Memories", "Blew", "Big Empty", "The Grain", "Hush", "The Sabbath", "Blood Swamp", "johnny's cage", "Ghost Key", "Above", "Ulcer pop", "Aunt Flo", "Gallbladder", "Synj", "Worm food", "destructoid", "six feet", "Day Breaker" },
                new string[] { "back track", "pinkeye falls", "Buzzzzcut", "Blown", "Agent Orange", "Cher noble", "The Moon", "Grape Soda", "Centipede", "The Kracken", "Spineless", "Grey Matter", "Dust Bunnies", "Crawl Space", "Insurance?", "P.S.Y.", "Nels Box", "electrolysis", "Tenebrae", "Solemnity" },
                new string[] { "The Blood Shed", "The Blood Shed", "The Blood Shed", "The Bootlicker!", "The Bootlicker!", "The Bootlicker!", "Castle Crushers", "Castle Crushers", "Castle Crushers", "1977", "1977", "1977" }
            },
            new string[][] {
                new string[] { "Pit Stop", "The Salt Lick", "Push", "Transmissions", "Uptown", "The Shaft", "Mind the Gap", "Boomtown", "Shotzie!", "Breakdown", "Box Tripper", "The Dumper", "The Bend", "Gurdy", "Vertigo", "Mono", "Rustic", "The Grundle", "Dig", "White Noise" },
                new string[] { "Step one", "Salt + Wound", "The Red Room", "Assemble", "Wasp", "Not You Again", "Pluck", "Salt Crown", "Goliath", "Exploder", "The Salt Man", "Hellevator", "Black Circle", "Salmon", "Vertebreaker", "The Chaser", "Ashes", "Bile Duct", "El Topo", "Sweet Pea" },
                new string[] { "Tunnel Vision", "Tunnel Vision", "Tunnel Vision", "The Jump Man!", "The Jump Man!", "The Jump Man!", "Cartridge Dump", "Cartridge Dump", "Cartridge Dump", "Kontra", "Kontra", "Kontra" }
            },
            new string[][] {
                new string[] { "Boilermaker", "Brindle", "Heck Hole", "Hex", "Pyro", "Leviathan", "Rickets", "Weibe", "Deceiver", "Ball n Chain", "Oracle", "Big Brother", "Lazy", "Adversary", "Abaddon", "Bow", "Lost Highway", "Boris", "The Hive", "Babylon" },
                new string[] { "Gretel", "Golgotha", "Char", "Altered", "Wicked One", "The Gnashing", "Thistle", "Billy Boy", "Glut", "Gallow", "Surrender", "Beholder", "Oblivion", "Old Scratch", "Bone Yard", "Starless", "Invocation", "Sag Chamber", "Long Goodbye", "Imperial" },
                new string[] { "The Key Master", "The Key Master", "The Key Master", "The Fly Guy!", "The Fly Guy!", "The Fly Guy!", "Brimstone", "Brimstone", "Brimstone", "mmmmmm", "mmmmmm", "mmmmmm" }
            },
            new string[][] {
                new string[] { "the witness", "evangel", "Ripe Decay", "Rise", "Panic Switch", "Left Behind", "The Fallen", "Descent", "Abomination", "Grinding Mill", "Heretic", "10 Horns", "The Lamb", "King Carrion", "The Flood", "Rotgut", "The Kingdom", "Gate of Ludd", "Wrath", "Judgment" },
                new string[] { "The Clot", "Loomer", "Spank", "Alabaster", "Nix", "Ripcord", "Downpour", "Downer", "Swine", "Pulp Factory", "Blight", "Canker", "Halo of Flies", "Necrosis", "Choke", "Coil", "Millenium", "Stain", "Magog", "Quietus" },
                new string[] { "Skyscraper", "Skyscraper", "Skyscraper", "The Guy!", "The Guy!", "The Guy!", "Sunshine Island", "Sunshine Island", "Sunshine Island", "Meat is Death", "Meat is Death", "Meat is Death" }
            },
            new string[][] {
                new string[] { "The Pit", "Schism", "Echoes", "Gently", "Omega" },
                new string[] { "Detox", "Ghost Tomb", "From Beyond", "Maze of Ith", "No Quarter" }
            },
            new string[][] {
                new string[] { "Pink Noise", "Run Rabbit Run", "Spinal Tap", "Stag", "Tommunism", "Panic Attack", "Tunnel Blower", "Pig Latin", "Hatch", "Bullet Bob", "Train Eater", "Peel", "Pepto", "Watchtower", "Lock out", "hopscotch", "lead sheets", "Oobs revenge", "The Rash", "4 letter word" },
                new string[] { "White  Noise", "Flipside", "Organ Grinder", "The Tower", "Waiting Room", "Bone Machine", "Going up", "In Line", "Salt Shaker", "MasterBlaster", "Thumb", "Pink", "bleach", "20/20", "Patience", "Curls", "bullet proof", "They Bite", "XOXO", "Brag rights" }
            }
        };

        public static float[][][] ParTimes = {
            new float[][] {
                new float[] { 3.00f, 5.00f, 9.00f, 9.00f, 11.00f, 7.00f, 5.00f, 4.50f, 8.00f, 7.50f, 8.00f, 7.00f, 7.00f, 8.00f, 10.00f, 9.00f, 9.00f, 4.00f, 20.00f, 22.00f },
                new float[] { 3.00f, 4.50f, 10.00f, 12.00f, 10.00f, 7.00f, 5.00f, 6.00f, 11.00f, 11.00f, 13.00f, 12.00f, 12.00f, 14.00f, 18.00f, 17.00f, 12.00f, 5.00f, 17.00f, 25.00f },
                new float[] { 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f }
            },
            new float[][] {
                new float[] { 11.00f, 10.50f, 14.00f, 9.50f, 16.00f, 15.00f, 19.00f, 25.00f, 11.00f, 12.00f, 9.00f, 11.00f, 10.00f, 16.00f, 19.00f, 15.00f, 14.00f, 16.50f, 14.00f, 24.00f },
                new float[] { 17.00f, 14.00f, 13.00f, 14.00f, 20.00f, 19.00f, 30.00f, 33.00f, 14.00f, 13.00f, 12.50f, 22.50f, 11.00f, 31.00f, 32.00f, 16.00f, 12.00f, 17.00f, 26.00f, 36.00f },
                new float[] { 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f }
            },
            new float[][] {
                new float[] { 9.50f, 8.30f, 16.00f, 12.00f, 12.20f, 4.50f, 12.40f, 8.30f, 12.50f, 10.50f, 9.00f, 11.60f, 15.80f, 14.80f, 14.80f, 14.80f, 10.50f, 17.00f, 17.00f, 20.00f },
                new float[] { 23.00f, 16.00f, 16.50f, 20.00f, 28.00f, 20.00f, 15.50f, 17.50f, 21.00f, 18.00f, 24.00f, 11.60f, 40.00f, 18.00f, 27.00f, 24.00f, 11.50f, 17.00f, 17.00f, 25.50f },
                new float[] { 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f }
            },
            new float[][] {
                new float[] { 11.00f, 23.00f, 11.50f, 11.50f, 12.00f, 8.00f, 17.00f, 16.00f, 6.00f, 15.00f, 12.50f, 10.80f, 11.50f, 17.50f, 9.00f, 12.00f, 12.00f, 24.50f, 14.00f, 22.00f },
                new float[] { 19.00f, 16.50f, 12.00f, 17.50f, 14.00f, 19.00f, 18.00f, 19.00f, 10.50f, 17.00f, 16.50f, 18.50f, 23.00f, 20.00f, 11.00f, 11.50f, 18.00f, 29.00f, 14.00f, 31.00f },
                new float[] { 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f }
            },
            new float[][] {
                new float[] { 22.00f, 13.00f, 18.00f, 13.50f, 12.50f, 11.00f, 23.00f, 20.00f, 19.50f, 15.50f, 18.50f, 16.00f, 20.00f, 30.50f, 13.50f, 30.00f, 23.00f, 17.00f, 29.00f, 32.00f },
                new float[] { 30.00f, 17.00f, 35.00f, 27.00f, 18.00f, 12.00f, 15.00f, 26.00f, 40.00f, 15.00f, 25.00f, 26.00f, 25.00f, 60.00f, 15.00f, 32.00f, 27.00f, 19.00f, 41.00f, 48.00f },
                new float[] { 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f, 5.00f }
            },
            new float[][] {
                new float[] { 30.00f, 44.00f, 34.00f, 33.00f, 44.00f },
                new float[] { 40.00f, 50.00f, 70.00f, 50.00f, 60.00f }
            },
            new float[][] {
                new float[] { 11.00f, 13.00f, 23.00f, 26.00f, 30.00f, 7.50f, 10.50f, 26.00f, 21.00f, 32.00f, 18.00f, 11.60f, 22.00f, 40.00f, 24.00f, 20.00f, 20.00f, 21.00f, 17.00f, 45.00f },
                new float[] { 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.00f, 60.50f, 60.50f, 60.00f, 60.00f, 60.00f }
            }
        };

        public static int[][] LightLevelBandages = {
            new int[] { 4, 7, 9, 11, 13, 18, 20 },
            new int[] { 2, 5, 10, 13, 16, 18, 20 },
            new int[] { 1, 2, 4, 10, 11, 18, 20 },
            new int[] { 2, 6, 9, 13, 16, 17, 20 },
            new int[] { 3, 5, 9, 12, 16, 18, 20 }
        };

        public static int[][] DarkLevelBandages = {
            new int[] { 3, 5, 10, 14, 15, 17, 19 },
            new int[] { 4, 6, 7, 10, 12, 15, 16 },
            new int[] { 3, 5, 6, 7, 14, 16, 19 },
            new int[] { 3, 4, 8, 10, 14, 18, 19 },
            new int[] { 4, 5, 8, 10, 11, 17, 18 }
        };

        public static int[][] WarpLevelBandages = {
            new int[] { 1, 2, 8, 9, 11, 12 },
            new int[] { 1, 3, 7, 8, 10, 12 },
            new int[] { 1, 3, 7, 9, 11, 12 },
            new int[] { 2, 3, 8, 9, 11, 12 },
            new int[] { 2, 3, 7, 9, 10, 11 }
        };

        public static int[][] LightLevelWarps = {
            new int[] { 5, 12, 19 },
            new int[] { 8, 12, 15 },
            new int[] { 5, 7, 16 },
            new int[] { 8, 14, 18 },
            new int[] { 1, 7, 12 }
        };

        public static int[][] DarkLevelWarps = {
            new int[] { 13 },
            new int[] { 5 },
            new int[] { 8 },
            new int[] { 7 },
            new int[] { 20 }
        };

        public static int[][] LightLevelLeaderboards = {
            new int[] { 28828, 28832, 28833, 28834, 28836, 28837, 28838, 28846, 28847, 28848, 28849, 28850, 28851, 28852, 28854, 28855, 28856, 28857, 28858, 28860},
            new int[] { 28870, 28871, 28872, 28873, 28876, 28877, 28878, 28881, 28883, 28884, 28886, 28888, 28889, 28891, 28893, 28896, 28898, 28899, 28900, 28901},
            new int[] { 28907, 28908, 28909, 28911, 28912, 28913, 28914, 28915, 28916, 28895, 28918, 28919, 28920, 28921, 28922, 28923, 28924, 28925, 28926, 28927},
            new int[] { 28931, 28932, 28933, 28934, 28935, 28936, 28937, 28938, 28939, 28928, 28941, 28942, 28943, 28944, 28949, 28951, 28953, 28947, 28958, 28960},
            new int[] { 28977, 28978, 28982, 28962, 28983, 28984, 28985, 28902, 28986, 28988, 29009, 29022, 29023, 29024, 29026, 29027, 29028, 29029, 29030, 29031},
            new int[] { 29040, 29041, 29044, 29045, 29052},
            new int[] { 29193, 29194, 29195, 29144, 29197, 29198, 29199, 29108, 29200, 29201, 29202, 29203, 29208, 29210, 29217, 29220, 29215, 29222, 29216, 29127}
        };

        public static int[][] DarkLevelLeaderboards = {
            new int[] { 28853, 28861, 28859, 28867, 28862, 28875, 28863, 28864, 28865, 28882, 28866, 28868, 28887, 28869, 28874, 28892, 28894, 28879, 28880, 28897},
            new int[] { 28885, 28929, 28950, 28954, 28957, 28961, 28955, 28964, 28965, 28968, 28971, 28974, 28975, 28976, 28979, 28959, 28989, 28998, 29003, 29004},
            new int[] { 29053, 29054, 29055, 28930, 29056, 29005, 29062, 28910, 29063, 29021, 29064, 29059, 29066, 29067, 29069, 29065, 29070, 28945, 29071, 29072},
            new int[] { 29085, 29086, 29068, 29025, 29087, 29089, 29088, 28948, 29090, 28906, 29091, 29092, 29101, 28905, 29094, 29095, 29096, 28904, 29097, 28980},
            new int[] { 29110, 29111, 29116, 29112, 29117, 29114, 29118, 29119, 29100, 29115, 29120, 29121, 29122, 29103, 29129, 29130, 29128, 29135, 29136, 29106},
            new int[] { 29131, 29132, 29137, 29138, 29133},
            new int[] { 29228, 29207, 29230, 29209, 29232, 29234, 29218, 29219, 29235, 29221, 29223, 29224, 29236, 29225, 29237, 29238, 29226, 29231, 29227, 29158}
        };
    }
}
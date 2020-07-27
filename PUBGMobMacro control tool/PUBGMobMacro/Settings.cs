using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGMobMacro
{
    class Settings
    {
        public static string[] guns = { "AKM", "SCAR", "M416", "M762", "QBZ", "SKS", "MINI" };
        public static int Gun1;
        public static int Gun2;
        public static int Gun1Scope = 0;
        public static int Gun2Scope = 0;
        public static int currentGun;
        public static bool isCrouch = false;
        public static Dictionary<int, int> recoil = new Dictionary<int, int>()
                                            {
                                                {0, 12},
                                                {1, 12},
                                                {2, 13},
                                                {3, 11},
                                                {10, 8},
                                                {11, 8},
                                                {12, 9},
                                                {13, 7},
                                                {20, 8},
                                                {21, 8},
                                                {22, 10},
                                                {23, 8},
                                                {30, 14},
                                                {31, 14},
                                                {32, 16},
                                                {33, 13},
                                                {40, 9},
                                                {41, 9},
                                                {42, 10},
                                                {43, 8},
                                                {54, 23},
                                                {56, 21},
                                                {58, 19},
                                                {64, 21},
                                                {66, 19},
                                                {68, 17}
                                                
                                            };
        public static Dictionary<int, int> delay = new Dictionary<int, int>()
                                            {
                                                {0, 100},
                                                {1, 100},
                                                {2, 100},
                                                {3, 100},
                                                {10, 100},
                                                {11, 100},
                                                {12, 100},
                                                {13, 100},
                                                {20, 100},
                                                {21, 100},
                                                {22, 100},
                                                {23, 100},
                                                {30, 100},
                                                {31, 100},
                                                {32, 100},
                                                {33, 100},
                                                {40, 100},
                                                {41, 100},
                                                {42, 100},
                                                {43, 100},
                                                {54, 100},
                                                {56, 100},
                                                {58, 100},
                                                {64, 100},
                                                {66, 100},
                                                {68, 100}
                                            };
    }
}

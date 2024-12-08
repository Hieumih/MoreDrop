using Config;
using Config.Model;
using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyPatches.Patches
{
    [HarmonyPatch(typeof(GameLocation), nameof(GameLocation.monsterDrop))]
    internal class MonsterDropPatch
    {
        private static MonsterDropConfig Config;
        private static MethodInfo MethodInfo;

        internal static void Initialize( MonsterDropConfig config, MethodInfo methodInfo)
        {
            Config = config;
            MethodInfo = methodInfo;
        }

        static void Prefix(GameLocation __instance, Monster monster, int x, int y, Farmer who)
        {
            bool TurnOn_MoreMonsterDrops = Config.TurnOnMoreMonsterDrops == 1;
            int NumberOfDrops = Config.WithBurglarRing;
            int NumberOfDropsWithRing = Config.WithoutBurglarRing;
            if (!TurnOn_MoreMonsterDrops)
            {
                NumberOfDrops = 1;
                NumberOfDropsWithRing = 2;
            }

            int numberOfDrops = who.isWearingRing("526") ? NumberOfDropsWithRing : NumberOfDrops;
            Console.WriteLine($"MonsterDropPatches.Prefix {__instance}");

            for (int i = 0; i < numberOfDrops; i++)
            {
                MethodInfo.Invoke(__instance, new object[] { __instance, monster, x, y, who });
            }
        }
    }


}

using Config;
using Config.Model;
using HarmonyLib;
using HarmonyPatches.Patches;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyPatches
{
    public class LoadPatches
    {
        private static ModConfig Config;
        private static Harmony Harmony;
        public static void Initialize(string uniqueId, ModConfig config)
        {
            Config = config;
            Harmony = new Harmony(uniqueId);
        }

        public static void LoadPatch()
        {
            LoadMonsterDropPatch();
            Harmony.PatchAll();
        }

        private static void LoadMonsterDropPatch()
        {
            var old = Harmony.Patch(AccessTools.Method(typeof(GameLocation), nameof(GameLocation.monsterDrop)));
            MonsterDropPatch.Initialize(Config.MonsterDrop, old);
        }
    }
}

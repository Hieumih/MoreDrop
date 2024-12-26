using HarmonyLib;
using MoreDrop.Patches.Patches;
using MoreDrop.Core.Model;
using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoreDrop.Patches
{
    public class LoadPatches
    {
        private static ModConfig Config;
        private static Harmony Harmony;
        private static IMonitor Monitor;
        private static bool EnableMod => Config.Enable;

        public static void Initialize(string uniqueId, ModConfig config, IMonitor monitor)
        {
            Config = config;
            Monitor = monitor;
            Harmony = new Harmony(uniqueId);
        }

        public static void LoadPatch()
        {
            LoadMonsterDropPatch();
            LoadTreeDropPatch();
            Harmony.PatchAll();
        }

        public static void ReloadPatch(ModConfig config)
        {
            Config = config;
            LoadMonsterDropPatch();
            LoadTreeDropPatch();
        }

        private static void LoadMonsterDropPatch()
        {
            MonsterDropPatch.Initialize(Config.MonsterDrop, Monitor, EnableMod);
        }

        private static void LoadTreeDropPatch()
        {
            TreeDropPatch.Initialize(Config.TreeDrop, Monitor, EnableMod);
        }
    }
}

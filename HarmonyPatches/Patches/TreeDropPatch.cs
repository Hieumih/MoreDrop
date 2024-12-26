using HarmonyLib;
using MoreDrop.Core.Model;
using StardewValley;
using StardewValley.TerrainFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoreDrop.Patches.Patches
{
    [HarmonyPatch(typeof(Tree))]
    public class TreeDropPatch : BasePatch<TreeDropConfig>
    {

        [HarmonyPostfix]
        [HarmonyPatch(nameof(Tree.TryGetDrop))]
        private static void TryGetDrop(ref Item __result) 
        {
            if (!IsEnabled)
            {
                return;
            }
            if (__result == null) return;
            if (__result.QualifiedItemId == "(O)709")
            {
                int stack = __result.stack.Value + Config.ExtraWoodDrop;
                Item item = ItemRegistry.Create(__result.QualifiedItemId, stack, __result.quality.Value);
                __result = item;
            };

        }

        [HarmonyPostfix]
        [HarmonyPatch("extraWoodCalculator")]
        private static void ExtraWoodCalculator(ref int __result)
        {
            if (!IsEnabled)
            {
                return;
            }
            __result += Config.ExtraWoodDrop;
        }
    }
}

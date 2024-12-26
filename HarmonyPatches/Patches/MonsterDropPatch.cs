using HarmonyLib;
using Microsoft.Xna.Framework;
using MoreDrop.Core.Model;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Monsters;
using StardewValley.Objects.Trinkets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoreDrop.Patches.Patches
{
    [HarmonyPatch(typeof(GameLocation))]
    internal class MonsterDropPatch : BasePatch<MonsterDropConfig>
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(GameLocation.monsterDrop))]
        static void AfterMonsterDrop(GameLocation __instance, Monster monster, int x, int y, Farmer who)
        {
            if (!IsEnabled)
            {
                return;
            }

            IList<string> objects = monster.objectsToDrop;
            var playerPosition = Utility.PointToVector2(who.StandingPixel);
            var debrisToAdd = new List<Debris>();

            HandleCommonMonsterDrop(monster, x, y, playerPosition, ref objects, ref debrisToAdd);

            HandleHardModeDrop(__instance, monster, x, y);

            HandleTrinketDrop(__instance, monster);

            HandleMoneyDrop(__instance, monster, x, y);

            HandleAdditionCustionDrop(__instance, monster, x, y);

            HandleMoreExtraDrop(monster, x, y, playerPosition, debrisToAdd);

            foreach (Debris d2 in debrisToAdd)
            {
                __instance.debris.Add(d2);
            }
        }

        private static void HandleAdditionCustionDrop(GameLocation __instance, Monster monster, int x, int y)
        {
            if (!Config.Addition.Enable) return;

            if (!Config.Addition.CustomDrop.TryGetValue(monster.Name, out var data)) return;

            foreach (var item in data)
            {
                monster.ModifyMonsterLoot(Game1.createItemDebris(ItemRegistry.Create(item.Id, item.Count), new Vector2(x, y), -1, __instance));
            }

        }

        private static void HandleMoreExtraDrop(Monster monster, int x, int y, Vector2 playerPosition, List<Debris> debrisToAdd)
        {
            if (Config.MoreExtraDropNum == 0) return;
            for (var i = 0; i < Config.MoreExtraDropNum; ++i)
            {
                var extradropItems = monster.getExtraDropItems();
                for (int j = 0; j < extradropItems.Count; j++)
                {
                    debrisToAdd.Add(monster.ModifyMonsterLoot(new Debris(extradropItems[j], new Vector2(x, y), playerPosition)));
                }
            }
        }

        private static void HandleMoneyDrop(GameLocation __instance, Monster monster, int x, int y)
        {
            if (Config.MoreGoldDrop == 0) return;
            monster.ModifyMonsterLoot(Game1.createItemDebris(ItemRegistry.Create("GoldCoin", Config.MoreGoldDrop), new Vector2(x, y), -1, __instance));
        }

        private static void HandleTrinketDrop(GameLocation __instance, Monster monster)
        {
            if (Config.Trinket.MoreTrinketDrop == 0) return;

            if (!Trinket.CanSpawnTrinket(Game1.player) && !Config.Trinket.ByPassMasteryCheck)
            {
                return;
            }

            for (int i = 0; i < Config.Trinket.MoreTrinketDrop; i++)
            {
                Trinket.SpawnTrinket(__instance, monster.getStandingPosition());
            }
        }

        private static void HandleHardModeDrop(GameLocation __instance, Monster monster, int x, int y)
        {
            if (Game1.netWorldState.Value.GoldenWalnutsFound >= 100)
            {
                if (monster.isHardModeMonster.Value && Game1.stats.Get("hardModeMonstersKilled") > 50 && Config.HardMode.MoreGalaxySouls != 0)
                {
                    monster.ModifyMonsterLoot(Game1.createItemDebris(ItemRegistry.Create("(O)896", Config.HardMode.MoreGalaxySouls), new Vector2(x, y), -1, __instance));
                }
                if (monster.isHardModeMonster.Value && Config.HardMode.MoreQiGems != 0)
                {
                    monster.ModifyMonsterLoot(Game1.createItemDebris(ItemRegistry.Create("(O)858", Config.HardMode.MoreQiGems), new Vector2(x, y), -1, __instance));
                }
            }
        }

        private static void HandleCommonMonsterDrop(Monster monster, int x, int y, Vector2 playerPosition, ref IList<string> objects, ref List<Debris> debrisToAdd)
        {
            if (Config.MoreCommonLootNum == 0) return;
            if (DataLoader.Monsters(Game1.content).TryGetValue(monster.Name, out var result))
            {
                string[] objectsSplit = ArgUtility.SplitBySpace(result.Split('/')[6]);

                for (int num = 0; num < Config.MoreCommonLootNum; num++)
                {
                    for (int l = 0; l < objectsSplit.Length; l += 2)
                    {
                        objects.Add(objectsSplit[l]);
                    }
                }
            }
        }
    }


}


using GenericModConfigMenu;
using MoreDrop.Core.Model;
using StardewModdingAPI;

namespace MoreDrop.ConfigModMenu
{
    internal static class MonsterDropPage
    {

        public static string MonsterDropPageId = "MonsterDrop";
        public static string HardMoreDropPageId = "HardMoreDrop";
        public static string TrinketPageId = "Trinket";

        public static void MoreMonsterDrop(IManifest manifest, IGenericModConfigMenuApi configMenu, ModConfig config, IModHelper helper)
        {

            configMenu.AddPageLink(
                 mod: manifest,
                 pageId: MonsterDropPageId,
                 text: () => helper.Translation.Get(MonsterDropPageId)
                );

            configMenu.AddPage(
                 mod: manifest,
                 pageId: MonsterDropPageId,
                 pageTitle: () => helper.Translation.Get(MonsterDropPageId)
            );

            configMenu.AddBoolOption(
                mod: manifest,
                name: () => helper.Translation.Get("Enable"),
                getValue: () => config.MonsterDrop.Enable,
                setValue: value => config.MonsterDrop.Enable = value
             );

            configMenu.AddNumberOption(
                mod: manifest,
                name: () => helper.Translation.Get("MonsterDrop.CommonDrop"),
                getValue: () => config.MonsterDrop.MoreCommonLootNum,
                setValue: value => config.MonsterDrop.MoreCommonLootNum = value,
                tooltip: () => helper.Translation.Get("MonsterDrop.CommonDrop.ToolTip"),
                min: 0,
                max: 999
             );

            configMenu.AddNumberOption(
                mod: manifest,
                name: () => helper.Translation.Get("MonsterDrop.MoreExtraDropNum"),
                getValue: () => config.MonsterDrop.MoreExtraDropNum,
                setValue: value => config.MonsterDrop.MoreExtraDropNum = value,
                tooltip: () => helper.Translation.Get("MonsterDrop.MoreExtraDropNum.ToolTip"),
                min: 0,
                max: 999
             );

            configMenu.AddNumberOption(
                mod: manifest,
                name: () => helper.Translation.Get("MonsterDrop.GoodCoinDrop"),
                tooltip: () => helper.Translation.Get("MonsterDrop.GoodCoinDrop.ToolTip"),
                getValue: () => config.MonsterDrop.MoreGoldDrop,
                setValue: value => config.MonsterDrop.MoreGoldDrop = value,
                min: 0,
                max: 100
            );

            TrinketPage(manifest, configMenu, config, helper);

            HardModeDropPage(manifest, configMenu, config, helper);

            // back to main page
            configMenu.AddPage(
                 mod: manifest,
                 pageId: ""
            );
        }
        private static void TrinketPage(IManifest manifest, IGenericModConfigMenuApi configMenu, ModConfig config, IModHelper helper)
        {
            configMenu.AddPageLink(mod: manifest, pageId: TrinketPageId, text: () => helper.Translation.Get("MonsterDrop.Trinket"));

            configMenu.AddPage(manifest, TrinketPageId, () => helper.Translation.Get("MonsterDrop.Trinket"));

            configMenu.AddBoolOption(
                mod: manifest,
                name: () => helper.Translation.Get("MonsterDrop.Trinket.ByPassMasteryCheck"),
                getValue: () => config.MonsterDrop.Trinket.ByPassMasteryCheck,
                setValue: value => config.MonsterDrop.Trinket.ByPassMasteryCheck = value
             );

            configMenu.AddNumberOption(
                mod: manifest,
                name: () => helper.Translation.Get("MonsterDrop.Trinket.AdditionNum"),
                getValue: () => config.MonsterDrop.Trinket.MoreTrinketDrop,
                setValue: value => config.MonsterDrop.Trinket.MoreTrinketDrop = value,
                tooltip: () => helper.Translation.Get("MonsterDrop.Trinket.AdditionNum.ToolTip"),
                min: 0,
                max: 20
            );

            // back to main page
            configMenu.AddPage(
                 mod: manifest,
                 pageId: MonsterDropPageId
            );
        }
        private static void HardModeDropPage(IManifest manifest, IGenericModConfigMenuApi configMenu, ModConfig config, IModHelper helper)
        {
            configMenu.AddPageLink(mod: manifest, pageId: HardMoreDropPageId, text: () => helper.Translation.Get("MonsterDrop.HardMode"));

            configMenu.AddPage(manifest, HardMoreDropPageId, () => helper.Translation.Get("MonsterDrop.HardMode"));

            configMenu.AddNumberOption(
                mod: manifest,
                name: () => helper.Translation.Get("MonsterDrop.HardMode.QiGem"),
                getValue: () => config.MonsterDrop.HardMode.MoreQiGems,
                setValue: value => config.MonsterDrop.HardMode.MoreQiGems = value,
                min: 0,
                max: 999
             );

            configMenu.AddNumberOption(
                mod: manifest,
                name: () => helper.Translation.Get("MonsterDrop.HardMode.GalaxySoul"),
                getValue: () => config.MonsterDrop.HardMode.MoreGalaxySouls,
                setValue: value => config.MonsterDrop.HardMode.MoreGalaxySouls = value,
                min: 0,
                max: 999
            );

            // back to main page
            configMenu.AddPage(
                 mod: manifest,
                 pageId: MonsterDropPageId
            );
        }
    }
}
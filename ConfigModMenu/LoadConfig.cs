using GenericModConfigMenu;
using MoreDrop.Core.Model;
using MoreDrop.Patches;
using StardewModdingAPI;

namespace MoreDrop.ConfigModMenu
{
    public class LoadConfig
    {
        static IModHelper Helper;
        static IMonitor Monitor;
        static IManifest ModManifest;
        static ModConfig Config;

        public static void Initialize(ModConfig config, IMonitor monitor, IManifest manifest, IModHelper helper)
        {
            Config = config;
            Monitor = monitor;
            ModManifest = manifest;
            Helper = helper;
        }

        public static void Load()
        {
            // get Generic Mod Config Menu's API (if it's installed)
            var configMenu = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;

            // register mod
            configMenu.Register(
                mod: ModManifest,
                reset: () => Config = new ModConfig(),
                save: () =>
                {
                    Helper.WriteConfig(Config);
                    LoadPatches.ReloadPatch(Config);
                }
            );

            configMenu.AddBoolOption(
                mod: ModManifest,
                name: () => Helper.Translation.Get("Enable"),
                getValue: () => Config.Enable,
                setValue: value => Config.Enable = value
             );

            MonsterDropPage.MoreMonsterDrop(ModManifest, configMenu, Config, Helper);
            WoodDropPage.MoreWoodDrop(ModManifest, configMenu, Config, Helper);
        }
    }
}

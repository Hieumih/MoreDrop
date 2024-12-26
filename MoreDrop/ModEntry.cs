using MoreDrop.Core.Model;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using MoreDrop.Patches;
using MoreDrop.ConfigModMenu;

namespace MoreDrop
{
    internal sealed class ModEntry : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            Config = helper.ReadConfig<ModConfig>();
            helper.Events.GameLoop.GameLaunched += OnGameLaunch;
            LoadPatches.Initialize(ModManifest.UniqueID, Config, Monitor);
            LoadPatches.LoadPatch();
        }

        private void OnGameLaunch(object sender, GameLaunchedEventArgs e)
        {
            LoadConfig.Initialize(Config, Monitor, ModManifest, Helper);
            LoadConfig.Load();
        }
    }
}

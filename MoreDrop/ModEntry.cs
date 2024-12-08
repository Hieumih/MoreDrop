using Config;
using HarmonyLib;
using HarmonyPatches;
using Newtonsoft.Json;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System.Reflection;

namespace MoreDrop
{
    internal sealed class ModEntry : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            Config = helper.ReadConfig<ModConfig>();
            helper.Events.GameLoop.GameLaunched += OnGameLaunch;
            LoadPatches.Initialize(ModManifest.UniqueID, Config);
            LoadPatches.LoadPatch();
        }

        private void OnGameLaunch(object sender, GameLaunchedEventArgs e)
        {
            Monitor.Log($"Loaded config.json: {JsonConvert.SerializeObject(this.Config)}", LogLevel.Debug);
        }
    }
}

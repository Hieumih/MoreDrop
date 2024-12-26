using GenericModConfigMenu;
using MoreDrop.Core.Model;
using StardewModdingAPI;

namespace MoreDrop.ConfigModMenu
{
    public class WoodDropPage
    {
        public static void MoreWoodDrop(IManifest manifest, IGenericModConfigMenuApi configMenu, ModConfig config, IModHelper helper)
        {
            var WoodDropPageId = "WoodDrop";
            configMenu.AddPageLink(
                 mod: manifest,
                 pageId: WoodDropPageId,
                 text: () => helper.Translation.Get("TreeDrop")
            );

            configMenu.AddPage(
                 mod: manifest,
                 pageId: WoodDropPageId,
                 pageTitle: () => helper.Translation.Get("TreeDrop")
            );

            configMenu.AddBoolOption(
                mod: manifest,
                name: () => helper.Translation.Get("Enable"),
                getValue: () => config.TreeDrop.Enable,
                setValue: value => config.TreeDrop.Enable = value
             );

            configMenu.AddNumberOption(
                mod: manifest,
                name: () => "Extra Wood Drop",
                tooltip: () => "Number of extra wood item drop",
                getValue: () => config.TreeDrop.ExtraWoodDrop,
                setValue: value => config.TreeDrop.ExtraWoodDrop = value,
                min: 0,
                max: 999  
             );
        }
    }
}
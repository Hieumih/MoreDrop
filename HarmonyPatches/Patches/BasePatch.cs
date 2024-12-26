using MoreDrop.Core.Model;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoreDrop.Patches.Patches
{
    public class BasePatch<T> where T : BaseConfig
    {
        public static T Config { get; set; }
        public static IMonitor Monitor { get; set; }
        private static bool EnableMod { get; set; }
        public static bool IsEnabled => Config.Enable & EnableMod;

        internal static void Initialize(T config, IMonitor monitor, bool enableMod)
        {
            Config = config;
            Monitor = monitor;
            EnableMod = enableMod;
        }
    }
}

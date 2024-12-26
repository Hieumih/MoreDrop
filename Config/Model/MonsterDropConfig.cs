using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDrop.Core.Model
{
    public class MonsterDropConfig : BaseConfig
    {
        public int MoreCommonLootNum { get; set; } = 0;
        public int MoreExtraDropNum { get; set; } = 0;
        public int MoreGoldDrop { get; set; } = 0;
        public TrinketConfig Trinket { get; set; } = new();
        public HardModeConfig HardMode { get; set; } = new();
        public AdditionCustomDrop Addition { get; set; } = new();

    }

    public class HardModeConfig
    {
        public int MoreGalaxySouls { get; set; } = 0;
        public int MoreQiGems { get; set; } = 0;
    }

    public class TrinketConfig
    {
        public bool ByPassMasteryCheck { get; set; } = false;
        public int MoreTrinketDrop { get; set; } = 0;
    }

    public class AdditionCustomDrop : BaseConfig
    {
        public IDictionary<string, List<AdditionCustomDropItem>> CustomDrop { get; set; }

        public AdditionCustomDrop()
        {
            Enable = false;
            CustomDrop = new Dictionary<string, List<AdditionCustomDropItem>>();

            var list = new List<AdditionCustomDropItem>
            {
                new AdditionCustomDropItem { Count = 10, Id = "(O)178" }
            };

            CustomDrop.Add("Green Slime", list);
        }
    }

    public class AdditionCustomDropItem
    {
        public string Id { get; set; } = null!;
        public int Count { get; set; } = 0;
    }

}

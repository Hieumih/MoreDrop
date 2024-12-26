using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDrop.Core.Model
{
    public sealed class ModConfig : BaseConfig
    {
        public MonsterDropConfig MonsterDrop { get; set; } = new MonsterDropConfig();
        public TreeDropConfig TreeDrop { get; set; } = new TreeDropConfig();
    }
}

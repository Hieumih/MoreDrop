using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Config.Model;

namespace Config
{
    public sealed class ModConfig
    {
        public MonsterDropConfig MonsterDrop { get; set; } = new MonsterDropConfig();
    }
}

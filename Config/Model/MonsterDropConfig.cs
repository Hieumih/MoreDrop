using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Config.Model
{
    public class MonsterDropConfig
    {
        public int TurnOnMoreMonsterDrops { get; set; } = 1;

        public int WithoutBurglarRing { get; set; } = 12;

        public int WithBurglarRing { get; set; } = 24;
    }
}

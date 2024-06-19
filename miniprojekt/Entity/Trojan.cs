using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProjekt.Enumarable;

namespace MiniProjekt
{
    public class Trojan: Entity
    {
        public Trojan(int level, int currentHp, int maxHp, double attackSpeed, Damage damageType, int damage, int physicalResistance, int rangeResistance) : base(1, 80, 80, 1, Enumarable.Damage.Physical, 0, 15, 15)
        {
        }
    }
}

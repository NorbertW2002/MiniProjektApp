using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProjekt.Enumarable;

namespace MiniProjekt
{
    public class Warrior: Entity
    {
        public Warrior(int level, int currentHp, int maxHp, double attackSpeed, Damage damageType, int damage, int physicalResistance, int rangeResistance) : base(1, 25, 25, 1, Enumarable.Damage.Physical, 8, 5, 3)
        {
        }
    }
}

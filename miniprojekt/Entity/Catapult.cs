using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProjekt.Enumarable;

namespace MiniProjekt
{
    public class Catapult:Entity
    {
        public Catapult(int level, int currentHp, int maxHp, double attackSpeed, Damage damageType, int damage, int physicalResistance, int rangeResistance) : base(1, 20, 20, 0.2, Enumarable.Damage.Range, 30, 1, 8)
        {
        }
    }
}

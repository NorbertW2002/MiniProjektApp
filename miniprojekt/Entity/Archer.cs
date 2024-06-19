using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProjekt.Enumarable;

namespace MiniProjekt
{
    public class Archer: Entity
    {
        public Archer(int level, int currentHp, int maxHp, double attackSpeed, Damage damageType, int damage, int physicalResistance, int rangeResistance) : base(1,10, 10, 1.3, Enumarable.Damage.Range, 5, 2, 2)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProjekt.Enumarable;

namespace MiniProjekt
{
    public class Kamikadze: Entity
    {
        public Kamikadze(int level, int currentHp, int maxHp, double attackSpeed, Damage damageType, int damage, int physicalResistance, int rangeResistance) : base(1, 10, 10, 0.5, Enumarable.Damage.Destruction, 50, 2, 8)
        {
        }
    }
}

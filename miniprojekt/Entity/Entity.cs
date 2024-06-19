using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProjekt.Enumarable;

namespace MiniProjekt
{
    public abstract class Entity
    {
        private int level;

        public int Level
        {
            get { return level;}
            set
            {
                if (level > 1)
                {
                    MaxHP = (int)(MaxHP * 1.15);
                    CurrentHP = MaxHP;
                    AttackSpeed = (int)(AttackSpeed * 1.3);
                    Damage = (int)(Damage * 1.2);
                    PhysicalResistance = (int)(PhysicalResistance * 1.25);
                    RangeResistance = (int)(RangeResistance * 1.25);
                }
            }
        }

        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public double AttackSpeed { get; set; }
        public Damage DamageType { get; set; }
        public int Damage { get; set; }
        public int PhysicalResistance { get; set; }
        public int RangeResistance { get; set; }

        protected Entity()
        {

        }
        protected Entity(int level, int currentHp, int maxHp, double attackSpeed, Damage damageType, int damage, int physicalResistance, int rangeResistance)
        {
            Level = level;
            CurrentHP = currentHp;
            MaxHP = maxHp;
            AttackSpeed = attackSpeed;
            DamageType = damageType;
            Damage = damage;
            PhysicalResistance = physicalResistance;
            RangeResistance = rangeResistance;
        }
    }
}

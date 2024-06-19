using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class HorseStable:Building
    {
        public int CurrentHorses { get; set; }

        public int MaxHorses { get; set; }

        public HorseStable(string Name, int Level):base(Name, Level) 
        {
            this.CurrentHorses = 0;
            this.MaxHorses = 2;
        }

        public HorseStable() : base()
        {
            this.CurrentHorses = 0;
            this.MaxHorses = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"CurrentHorses: {CurrentHorses}\n" +
                $"MaxHorses: {MaxHorses}\n";
        }
    }
}

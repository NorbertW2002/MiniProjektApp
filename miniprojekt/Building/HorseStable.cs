using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class HorseStable:Building
    {
        private int level = 1;
        public override int Level
        {
            get => level;
            set
            {
                if (value <= MaxBuildingLevel)
                {
                    level = value;
                    UpdateProperties();
                }
            }
        }
        public int CurrentHorses { get; set; }

        public int MaxHorses { get; set; }
        public int MaxBuildingLevel { get; set; }
        public HorseStable(string Name, int Level):base(Name, Level) 
        {
            CurrentHorses = 0;
            MaxHorses = 2;
        }


        private void UpdateProperties()
        {
            MaxHorses = 2 + (Level - 1) * 2;
        }

        public override string ToString()
        {
            return base.ToString() + $"CurrentHorses: {CurrentHorses}\n" +
                $"MaxHorses: {MaxHorses}\n";
        }
    }
}

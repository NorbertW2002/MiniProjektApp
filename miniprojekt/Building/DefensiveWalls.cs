using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class DefensiveWalls:Building
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
        public int DefensiveValue { get; set; }

        public int MaxDefensiveValue { get; set; }
        public int MaxBuildingLevel { get; set; }

        public DefensiveWalls(string Name, int Level, int DefensiveValue, int MaxDefensiveValue):base(Name, Level)
        {
            this.DefensiveValue = DefensiveValue;
            this.MaxDefensiveValue=MaxDefensiveValue;
            MaxBuildingLevel = 5;
        }
        public DefensiveWalls(string Name, int Level) : base(Name, Level)
        {
           DefensiveValue = 10;
           MaxDefensiveValue = 10;
            MaxBuildingLevel = 5;
        }
        private void UpdateProperties()
        {
            MaxDefensiveValue = 10 + (Level - 1) * 10;
        }
        public override string ToString()
        {
            return base.ToString() + $"DefensiveValue: {DefensiveValue}\n" +
                $"MaxDefensiveValue: {MaxDefensiveValue}";
        }
    }
}

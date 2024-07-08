using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Sawmill:Building
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
        public int GenerateWoodPerTime { get; set; }
        public int MaxWoodPerTime { get; set; }

        public int Time { get; set; }
        public int MaxBuildingLevel { get; set; }
        public Sawmill(string Name, int Level):base(Name, Level)
        {
            GenerateWoodPerTime = 10;
            MaxWoodPerTime = 500;
            Time = 30;
            MaxBuildingLevel = 5;
        }
        private void UpdateProperties()
        {
            GenerateWoodPerTime = 10 + (Level - 1) * 5;
            MaxWoodPerTime = 500 + (Level - 1) * 100;
            Time = 30 - (Level - 1) * 2;
        }
        public override string ToString()
        {
            return base.ToString() + $"GenerateWoodPerTime: {GenerateWoodPerTime}\n";
        }
    }
}

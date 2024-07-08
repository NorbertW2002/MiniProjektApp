using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class StoneMine:Building
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
        public int MaxBuildingLevel { get; set; }
        public int GenerateStonePerTime { get; set; }
        public int MaxStonePerTime { get; set; }

        public int Time { get; set; }

        public StoneMine(string Name, int Level): base(Name, Level)
        {
            GenerateStonePerTime = 10;
            MaxStonePerTime = 500;
            Time = 35;
            MaxBuildingLevel = 5;
        }

        private void UpdateProperties()
        {
            GenerateStonePerTime = 10 + (Level - 1) * 5;
            MaxStonePerTime = 500 + (Level - 1) * 100;
            Time = 35 - (Level - 1) * 2;
        }
        public override string ToString()
        {
            return base.ToString() + $"GenerateStonePerTime: {GenerateStonePerTime}\n";
        }
    }
}

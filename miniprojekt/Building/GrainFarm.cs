using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class GrainFarm:Building
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
        public int GenerateWheatPerTime { get; set; }
        public int MaxFarmPerTime { get; set; }
        public int MaxBuildingLevel { get; set; }
        public int Time { get; set; }

        public GrainFarm(string Name, int Level):base(Name, Level)
        {
            GenerateWheatPerTime = 10;
            Time = 40;
            MaxFarmPerTime = 500;
            MaxBuildingLevel = 5;
        }

        private void UpdateProperties()
        {
            GenerateWheatPerTime = 10 + (Level - 1) * 5;
            MaxFarmPerTime = 500 + (Level - 1) * 100;
            Time = 40 - (Level - 1) * 3;
        }
        public override string ToString()
        {
            return base.ToString() + $"GenerateWheatPerTime: {GenerateWheatPerTime}\n";
        }
    }
}

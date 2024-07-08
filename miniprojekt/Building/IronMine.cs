using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class IronMine:Building
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
        public int GenerateIronPerTime { get; set; }
        public int MaxIronPerTime { get; set; }
        public int MaxBuildingLevel { get; set; }
        public int Time { get; set; }

        public IronMine(string Name, int Level):base(Name, Level)
        {
            GenerateIronPerTime = 10;
            MaxIronPerTime = 300;
            Time = 55;
            MaxBuildingLevel = 5;
        }

        private void UpdateProperties()
        {
            GenerateIronPerTime = 10 + (Level - 1) * 5;
            MaxIronPerTime = 300 + (Level - 1) * 100;
            Time = 55 - (Level - 1) * 3;
        }
        public override string ToString()
        {
            return base.ToString() + $"GenerateIronPerTime: {GenerateIronPerTime}\n";
        }
    }
}

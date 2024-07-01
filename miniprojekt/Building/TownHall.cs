using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class TownHall:Building
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

        public int GenerateGoldPerTime { get; set; }

        public int MaxGoldPerTime { get; set; }

        public int Time {  get; set; }

        public TownHall(string Name, int Level, int MaxBuildingLevel, int GenerateGoldPerTime, int MaxGoldPerTime):base(Name, Level)
        {
            this.MaxBuildingLevel = MaxBuildingLevel;
            this.GenerateGoldPerTime = GenerateGoldPerTime;
            this.MaxGoldPerTime = MaxGoldPerTime;
            Time = 20;
            UpdateProperties();
        }
        public TownHall(string Name, int Level): base(Name, Level)
        {
            MaxBuildingLevel = 8;
            GenerateGoldPerTime = 10;
            MaxGoldPerTime = 1000;
            Time = 20;
            UpdateProperties();
        }

        public TownHall() : base()
        {
            MaxBuildingLevel = 8;
            GenerateGoldPerTime = 10;
            MaxGoldPerTime = 1000;
            Time = 20;
            UpdateProperties();
        }
        private void UpdateProperties()
        {
            GenerateGoldPerTime = 10 + (Level-1) * 5;
            MaxGoldPerTime = 1000 + (Level-1) * (100 * Level);
            Time = 20 - (Level - 1) * 2;
        }

        public override string ToString()
        {
            return base.ToString() + $"MaxBuildingLevel: {MaxBuildingLevel};" +
                $"GenerateGoldPerTime: {GenerateGoldPerTime};" +
                $"MaxGoldPerTime: {MaxGoldPerTime};";
        }
    }
}

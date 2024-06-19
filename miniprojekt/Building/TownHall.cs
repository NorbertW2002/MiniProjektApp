using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class TownHall:Building
    {
        public int MaxBuildingLevel { get; set; }

        public int GenerateGoldPerTime { get; set; }

        public int MaxGoldPerTime { get; set; }

        public int Time {  get; set; }

        public TownHall(string Name, int Level, int MaxBuildingLevel, int GenerateGoldPerTime, int MaxGoldPerTime):base(Name, Level)
        {
            this.MaxBuildingLevel = MaxBuildingLevel;
            this.GenerateGoldPerTime = GenerateGoldPerTime;
            this.MaxGoldPerTime = MaxGoldPerTime;
        }
        public TownHall(string Name, int Level): base(Name, Level)
        {
            this.MaxBuildingLevel = 10;
            this.GenerateGoldPerTime = 10;
            this.MaxGoldPerTime = 1000;
            this.Time = 20;
        }

        public TownHall() : base()
        {
            this.MaxBuildingLevel = 10;
            this.GenerateGoldPerTime = 10;
            this.MaxGoldPerTime = 1000;
        }

        public override string ToString()
        {
            return base.ToString() + $"MaxBuildingLevel: {MaxBuildingLevel};" +
                $"GenerateGoldPerTime: {GenerateGoldPerTime};" +
                $"MaxGoldPerTime: {MaxGoldPerTime};";
        }
    }
}

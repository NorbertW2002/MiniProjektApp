using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class GrainFarm:Building
    {
        public int GenerateWheatPerTime { get; set; }
        public int MaxFarmPerTime { get; set; }

        public int Time { get; set; }
        public GrainFarm(string Name, int Level):base(Name, Level)
        {
            this.GenerateWheatPerTime = 10;
            this.Time = 40;
            this.MaxFarmPerTime = 500;
        }

        public GrainFarm() : base()
        {
            this.GenerateWheatPerTime = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"GenerateWheatPerTime: {GenerateWheatPerTime}\n";
        }
    }
}

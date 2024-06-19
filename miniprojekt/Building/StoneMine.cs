using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class StoneMine:Building
    {
        public int GenerateStonePerTime { get; set; }
        public int MaxStonePerTime { get; set; }

        public int Time { get; set; }

        public StoneMine(string Name, int Level): base(Name, Level)
        {
            this.GenerateStonePerTime = 10;
            this.MaxStonePerTime = 500;
            this.Time = 35;
        }

        public StoneMine() : base()
        {
            this.GenerateStonePerTime = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"GenerateStonePerTime: {GenerateStonePerTime}\n";
        }
    }
}

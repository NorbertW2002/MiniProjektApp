using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class IronMine:Building
    {
        public int GenerateIronPerTime { get; set; }

        public IronMine(string Name, int Level):base(Name, Level)
        {
            this.GenerateIronPerTime = 10;
        }

        public IronMine() : base()
        {
            this.GenerateIronPerTime = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"GenerateIronPerTime: {GenerateIronPerTime}\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class DefensiveWalls:Building
    {
        public int DefensiveValue { get; set; }

        public int MaxDefensiveValue { get; set; }

        public DefensiveWalls(string Name, int Level, int DefensiveValue, int MaxDefensiveValue):base(Name, Level)
        {
            this.DefensiveValue = DefensiveValue;
            this.MaxDefensiveValue=MaxDefensiveValue;
        }
        public DefensiveWalls(string Name, int Level) : base(Name, Level)
        {
            this.DefensiveValue = 10;
            this.MaxDefensiveValue = 10;
        }
        public DefensiveWalls() : base() {
            this.DefensiveValue = 0;
            this.MaxDefensiveValue = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"DefensiveValue: {DefensiveValue}\n" +
                $"MaxDefensiveValue: {MaxDefensiveValue}";
        }
    }
}

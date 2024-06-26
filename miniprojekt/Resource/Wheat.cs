using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Wheat:Resource
    {
        [JsonConstructor]
        public Wheat(string name, int WheatNumber):base(name, WheatNumber)
        {
        }
        public override string ToString()
        {
            return " Number of " + base.ToString() + $" needed: {base.Amount}";
        }
    }
}

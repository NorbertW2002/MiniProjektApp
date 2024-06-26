using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Iron:Resource
    {
        [JsonConstructor]

        public Iron(string name, int IronNumber) : base(name, IronNumber) 
        {
        }

        public override string ToString()
        {
            return " Number of " + base.ToString() + $" needed: {base.Amount}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Wheat:Resource
    {

        public Wheat(string name, int WheatNumber):base(name, WheatNumber)
        {
        }
        public override string ToString()
        {
            return " Number of " + base.ToString() + $" needed: {base.Amount}";
        }
    }
}

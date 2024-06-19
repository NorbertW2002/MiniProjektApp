using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Stone:Resource
    {
        public Stone(string name, int StoneNumber) : base(name, StoneNumber)
        {
        }

        public override string ToString()
        {
            return " Number of " + base.ToString() + $" needed: {base.Amount}";
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Iron:Resource
    {

        public Iron(string name, int IronNumber) : base(name, IronNumber) 
        {
        }

        public override string ToString()
        {
            return " Number of " + base.ToString() + $" needed: {base.Amount}";
        }
    }
}

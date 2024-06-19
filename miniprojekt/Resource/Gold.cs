using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Gold:Resource
    {

        public Gold(string name, int goldNumber):base(name, goldNumber)
        {
        }

        public override string ToString()
        {
            return " Number of " + base.ToString() +$" needed: {base.Amount}";
        }
    }
}

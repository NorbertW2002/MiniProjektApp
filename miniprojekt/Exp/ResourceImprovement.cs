using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class ResourceImprovement
    {
        public int Level { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
        public int Wood { get; set; }

        public ResourceImprovement(int level, int stone, int iron, int wood)
        {
            Level = level;
            Stone = stone;
            Iron = iron;
            Wood = wood;
        }

        public override string ToString()
        {
            return $"Level of Fortification: {Level}\n" +
                $"Stone needed for improvement: {Stone}\n" +
                $"Iron needed for improvement: {Iron}\n" +
                $"Wood needed for improvement: {Wood}\n";
        }
    }
}

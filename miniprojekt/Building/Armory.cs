using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Armory:Building
    {
        List<Entity> EntitiesLevel;

        public Armory(string Name, int Level):base(Name, Level)
        {
            EntitiesLevel = new List<Entity>();
        }

        public Armory():base()
        {
            EntitiesLevel = new List<Entity>();
        }

        public override string ToString()
        {
            string temp = "";
            foreach (Entity entity in EntitiesLevel)
            {
                temp += entity.ToString() + '\n';
            }
            return base.ToString() + temp + '\n';
        }
    }
}

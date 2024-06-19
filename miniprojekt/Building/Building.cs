using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public abstract class Building
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Building(string Name, int Level)
        {
            this.Name = Name;
            this.Level = Level;
        }

        public Building()
        {
            this.Name = " ";
            this.Level = 1;
        }

        public override string ToString()
        {
            return $"Name: {Name};" +
                $"Level: {Level};";
        }
    }
}

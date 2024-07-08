using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public abstract class Building
    {
        public string Name { get; set; }
        public virtual int Level { get; set; }
        [JsonConstructor]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public abstract class Resource
    {
        public string Name { get; set; }
        public int Amount {  get; set; }
        [JsonConstructor]
        protected Resource(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

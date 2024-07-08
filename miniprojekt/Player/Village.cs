using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Village
    {
        public string Name { get; set; }
        public List<Building> Buildings = new List<Building>();
        public List<Entity> Entities = new List<Entity>();
        public static int Slots = 12;
        [JsonConstructor]
        public Village(string name, List<Building> buildings, List<Entity> entities)
        {
            Name = name;
            Buildings = buildings ?? new List<Building> { new TownHall("Ratusz", 1) };
            Entities = entities ?? new List<Entity>();
        }
        public Village(string name)
        {
            Name = name;
            Buildings.Add(new TownHall("Ratusz", 1));
        }

        public override string ToString()
        {
            string temp = "", temp2 = "";
            foreach (var building in Buildings)
            {
                temp += building.ToString() + '\n';
            }
            foreach(var entity in Entities)
            {
                temp2 += entity.ToString() + "\n";
            }
            return $"Name: {Name}\nBuilding: {temp}\nEntities: {temp2}\n";
        }

        public void AddBuilding(Building building)
        {
            Buildings.Add(building);
        }
        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }
    }
}

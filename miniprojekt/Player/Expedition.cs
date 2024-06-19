using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Expedition
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int ExperienceGained { get; set; }
        public DefensiveWalls DefensiveWalls { get; set;}
        public List<Entity> Entities { get; set; }
        public List<Resource> Resources { get; set; }

        public Expedition(string name, int level, int experienceGained, DefensiveWalls defensiveWalls, List<Entity> entities, List<Resource> resources)
        {
            Name = name;
            Level = level;
            ExperienceGained = experienceGained;
            DefensiveWalls = defensiveWalls;
            Entities = entities;
            Resources = resources;
        }

        public override string ToString()
        {
            string temp = "", temp2 = "";
            foreach (Entity entity in Entities)
            {
                temp += entity.ToString();
            }
            foreach (Resource resource in Resources)
            {
                temp2 += resource.ToString();
            }
            return $"Name: {Name}\nLevel: {Level}\nExperienceGained: {ExperienceGained}\nDefensiveWalls: {DefensiveWalls}\nEntities: {Entities}\nResources: {Resources}";
        }
    }
}

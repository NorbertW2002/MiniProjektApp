using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class ResourcesNeeded
    {
        public List<Resource> ResourcesForBuilding(string BuildingName)
        {
            var resources = new List<Resource>();
            switch(BuildingName)
            {
                case "Armory":
                    resources.Add(new Iron("Iron", 100));
                    resources.Add(new Stone("Stone", 200));
                    resources.Add(new Gold("Gold", 250));
                    break;
                case "Barracks":
                    resources.Add(new Wood("Wood", 80));
                    resources.Add(new Gold("Gold", 150));
                    resources.Add(new Wheat("Wheat", 100));
                    break;
                case "Defensive Walls":
                    resources.Add(new Iron("Iron", 100));
                    resources.Add(new Wood("Wood", 100));
                    resources.Add(new Stone("Stone", 100));
                    break;
                case "Grain Farm":
                    resources.Add(new Wood("Wood", 80));
                    resources.Add(new Gold("Gold", 200));
                    break;
                case "Horse Stable":
                    resources.Add(new Wheat("Wheat", 300));
                    resources.Add(new Gold("Gold", 200));
                    resources.Add(new Wood("Wood", 200));
                    break;
                case "Iron Mine":
                    resources.Add(new Stone("Stone", 100));
                    resources.Add(new Wheat("Gold", 150));
                    break;
                case "Sawmill":
                    resources.Add(new Gold("Gold", 100));
                    break;
                case "Silo":
                    resources.Add(new Gold("Gold", 250));
                    resources.Add(new Wood("Wood", 300));
                    break;
                case "Stone Mine":
                    resources.Add(new Gold("Gold", 150));
                    break;
            }
            return resources;
        }

        public List<Resource> ResourceForUpgrade(string BuildName, int level)
        {
            var resources = new List<Resource>();

            switch (BuildName)
            {
                case "Armory":
                    resources.Add(new Iron("Iron", 100*(level+1)));
                    resources.Add(new Stone("Stone", 200 * (level + 1)));
                    resources.Add(new Gold("Gold", 250 * (level + 1)));
                    break;
                case "Barracks":
                    resources.Add(new Wood("Wood", 80 * (level + 1)));
                    resources.Add(new Gold("Gold", 150 * (level + 1)));
                    resources.Add(new Wheat("Wheat", 100 * (level + 1)));
                    break;
                case "Defensive Walls":
                    resources.Add(new Iron("Iron", 100 * (level + 1)));
                    resources.Add(new Wood("Wood", 100 * (level + 1)));
                    resources.Add(new Stone("Stone", 100 * (level + 1)));
                    break;
                case "Grain Farm":
                    resources.Add(new Wood("Wood", 80 * (level + 1)));
                    resources.Add(new Gold("Gold", 200 * (level + 1)));
                    break;
                case "Horse Stable":
                    resources.Add(new Wheat("Wheat", 300 * (level + 1)));
                    resources.Add(new Gold("Gold", 200 * (level + 1)));
                    resources.Add(new Wood("Wood", 200 * (level + 1)));
                    break;
                case "Iron Mine":
                    resources.Add(new Stone("Stone", 100 * (level + 1)));
                    resources.Add(new Wheat("Gold", 150 * (level + 1)));
                    break;
                case "Sawmill":
                    resources.Add(new Gold("Gold", 100 * (level + 1)));
                    break;
                case "Silo":
                    resources.Add(new Gold("Gold", 250 * (level + 1)));
                    resources.Add(new Wood("Wood", 220 * (level + 1)));
                    break;
                case "Stone Mine":
                    resources.Add(new Gold("Gold", 150 * (level + 1)));
                    break;
                case "Ratusz":
                    resources.Add(new Gold("Gold", 200 * (level + 1)));
                    break;
            }

            return resources;
        }
        public List<Resource> ResourcesForEntities(string EntityName, int level, int amount)
        {
            var resources = new List<Resource>();
            switch(EntityName)
            {
                case "Archer":
                    resources.Add(new Gold("Gold", amount * (12 - (level-1))));
                    resources.Add(new Wheat("Wheat", amount * (15 - (level - 1))));
                    break;
                case "Catapult":
                    resources.Add(new Gold("Gold", amount * (20 - (level - 1))));
                    resources.Add(new Wood("Wood", amount * (15 - (level - 1))));
                    resources.Add(new Stone("Stone", amount * (25 - (level - 1))));
                    break;
                case "Hussar":
                    resources.Add(new Gold("Gold", amount * (70 - (level - 1))));
                    resources.Add(new Wheat("Wheat", amount * (60 - (level - 1))));
                    break;
                case "Kamikadze":
                    resources.Add(new Gold("Gold", amount * (40 - (level - 1))));
                    resources.Add(new Wheat("Wheat", amount * (20 - (level - 1))));
                    resources.Add(new Iron("Iron", amount * (30 - (level - 1))));
                    break;
                case "Trojan":
                    resources.Add(new Gold("Gold", amount * (50 - (level - 1))));
                    resources.Add(new Wood("Wood", amount * (35 - (level - 1))));
                    resources.Add(new Iron("Iron", amount * (30 - (level - 1))));
                    break;
                case "Warrior":
                    resources.Add(new Gold("Gold", amount * (8 - (level - 1))));
                    resources.Add(new Wheat("Wheat", amount * (10 - (level - 1))));
                    break;
            }
            return resources;
        }
        public List<Resource> ResourcesForEntityUpgrade(string entityName, int level)
        {
            var resources = new List<Resource>();
            switch (entityName)
            {
                case "Archer":
                    resources.Add(new Gold("Gold", 12 *level));
                    resources.Add(new Wheat("Wheat", 15 *level));
                    break;
                case "Catapult":
                    resources.Add(new Gold("Gold",  20* level));
                    break;
                case "Hussar":
                    resources.Add(new Gold("Gold",  50 * level));
                    resources.Add(new Wheat("Wheat",  50 * level));
                    break;
                case "Kamikadze":
                    resources.Add(new Gold("Gold", 40 * level));
                    resources.Add(new Wheat("Wheat", 20 * level));
                    break;
                case "Trojan":
                    resources.Add(new Gold("Gold", 30 * level));
                    break;
                case "Warrior":
                    resources.Add(new Gold("Gold", 8 * level ));
                    resources.Add(new Wheat("Wheat", 15 * level));
                    break;
            }
            return resources;
        }
            
    }
}

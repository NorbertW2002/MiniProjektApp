using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int CurrentExperience { get; set; }
        public List<Resource> Resources { get; set; }
        public Fraction? Fraction { get; set; }
        public List<Village> Villages { get; set; } 

        public Player(string Name, int Level, int CurrentExperience, List<Resource> resources, Fraction fraction, List<Village> villages)
        {
            this.Name = Name;
            this.Level = Level;
            this.CurrentExperience = CurrentExperience;
            this.Resources = resources;
            this.Fraction = fraction;
            this.Villages = villages;
        }

        public Player(string Name)
        {
            this.Name = Name;
            Level = 1;
            CurrentExperience = 0;
            Resources =
            [
                new Wood("Wood",0),
                new Iron("Iron", 0),
                new Stone("Stone", 0),
                new Wheat("Wheat", 0),
                new Gold("Gold", 100),
            ];
            Villages = new List<Village>();
            if(Name.EndsWith('a')|| Name.EndsWith('A'))
            {
                Villages.Add(new Village("Wioska " + Name.Substring(0, Name.Length - 1) + "y"));
            }
            else
            {
                Villages.Add(new Village("Wioska " + Name + "a"));

            }
            this.Fraction = null;
        }
        public void AddExp(int exp)
        {
            CurrentExperience += exp;
            CheckLevel();
        }

        private void CheckLevel()
        {
            int requiredExp = CalculateRequiredExperience(Level);
            while (CurrentExperience >= requiredExp)
            {
                CurrentExperience -= requiredExp;
                Level++;
                requiredExp = CalculateRequiredExperience(Level);
            }
        }

        public int CalculateRequiredExperience(int level)
        {
            return level * 20;
        }
        public bool HasEnoughResources(List<Resource> requiredResources)
        {
            foreach (var required in requiredResources)
            {
                var playerResource = Resources.FirstOrDefault(r => r.Name == required.Name);
                if (playerResource == null || playerResource.Amount < required.Amount)
                {
                    return false;
                }
            }
            return true;
        }
        public void afterBuildingBought(List<Resource> requiredResources)
        {
            foreach (var required in requiredResources)
            {
                var playerResource = Resources.FirstOrDefault(r => r.Name == required.Name);
                if (playerResource != null)
                {
                    playerResource.Amount -= required.Amount; 
                }
            }
        }
        public override string ToString()
        {
            string temp = "", temp2 = "";
            foreach (Resource resource in Resources)
            {
                temp += resource.ToString() + '\n';
            }
            foreach (Village village in Villages)
            {
                temp2 += village.ToString() + '\n';
            }
            return $"Name: {Name}\nLevel: {Level}\nCurrentExperience: {CurrentExperience}\nResource: {temp}\nFraction: {Fraction}\nVillages: {temp2}\n";
        }

    }
}

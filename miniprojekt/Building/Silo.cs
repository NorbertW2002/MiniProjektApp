using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Silo:Building
    {
        public List<Resource> CurrentResources { get; set; }

        public List<Resource> MaxResources { get; set; }

        public Silo(string Name, int Level):base(Name, Level)
        {
            this.CurrentResources = new List<Resource>();
            this.MaxResources = new List<Resource>();
        }

        public Silo() : base()
        {
            this.CurrentResources = new List<Resource>();
            this.MaxResources = new List<Resource>();
        }

        public override string ToString()
        {
            string temp = "", temp2 = "";
            foreach (var resource in CurrentResources)
            {
                temp += resource.ToString()+ '\n';
            }
            foreach(var resource in MaxResources)
            {
                temp2 += resource.ToString()+ '\n';
            }
            return base.ToString() + $"CurrentResources: \n {temp}" +
                $"MaxResources: \n" + temp2;
        }
    }
}

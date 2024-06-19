using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Barracks:Building
    {
        public int MaxEntity { get; set; }

        public Barracks(string Name, int Level): base(Name, Level)
        {
            this.MaxEntity = 40;
        }

        public Barracks() : base()
        {
            this.MaxEntity = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"MaxEntity: {MaxEntity}";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Barracks:Building
    {
        private int level = 1;
        public override int Level
        {
            get => level;
            set
            {
                if (value <= MaxBuildingLevel)
                {
                    level = value;
                    UpdateProperties();
                }
            }
        }
        public double Cost { get; set; }
        public int MaxBuildingLevel { get; set; }

        public Barracks(string Name, int Level): base(Name, Level)
        {
            Cost = 1;
            MaxBuildingLevel = 5;
        }
        private void UpdateProperties()
        {
            Cost = Math.Round((1 / Math.Sqrt(Level)),2);
        }

        public override string ToString()
        {
            return base.ToString() + $"Cost: {Cost}";
        }
    }
}

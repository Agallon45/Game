using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Enemy
    {
        public string name;
        public int healthPoints;
        public int strength;
        public int armor;
        public string[,] schematic;

        public Enemy(string name, string[,] schematic)
        {
            this.name = name;
            this.schematic = schematic;
            healthPoints = 50;
            strength = 5;
            armor = 5;
        }
    }
}

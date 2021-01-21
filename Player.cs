using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Player
    {
        public string name;
        public int healthPoints;
        public int strength;
        public int armor;


        public Player(string name)
        {
            this.name = name;
            healthPoints = 100;
            strength = 500;
            armor = 5;
        }
    }
}

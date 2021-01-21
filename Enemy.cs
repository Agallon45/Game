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
        public int agility;
        public int expAward;


        public string Attack(Player player)
        {
            Random rnd = new Random();
            if ((rnd.Next(1, 100)+agility) > player.agility)
            {
                int dmg = rnd.Next(1, strength) + strength;
                //dmg = dmg - player.armor;
                player.healthPoints = player.healthPoints - dmg;
                return $"{player.name} suffers {dmg} damage!";
            }
            else
            {
                return $"{name}s attack misses!";
            }
        }
    }
}

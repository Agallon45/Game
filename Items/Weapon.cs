using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Weapon: Item
    {

        public Weapon(string Name)
        {
            name = Name;

        }

        public Weapon(string Name, int Strength, int Agility, int Intellect)
        {
            name = Name;
            strength = Strength;
            agility = Agility;
            intellect = Intellect;
            cost = (Strength + Agility + Intellect) * 10;
            description = $"STR: {strength} AGI: {agility} INT: {intellect}";

            for (int i = description.Length; i < 23; i++)
            {
                description += " ";

            }

        }

        public override string ToString()
        {
            return name + "str:  " + strength + ", " + "agi: " + agility + ", int: " + intellect + ", cost: " + cost;  
        }
    }
}

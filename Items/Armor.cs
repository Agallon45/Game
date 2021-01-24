using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Armor: Item
    {
        public Armor(string Name, int Armor, int HealthPoints)
        {
            name = Name;
            armor = Armor;
            healthPoints = HealthPoints;

            cost = (Armor * 10)+ HealthPoints;
            description = $"+ARMOR: {armor} +HP: {healthPoints}";

            for (int i = description.Length; i < 23; i++)
            {
                description += " ";

            }

        }
    }
}

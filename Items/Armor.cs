using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Armor: Item
    {
        public Armor(string Name, int Armor, int HealthPoints)
        {
            double prel;
            name = Name;
            armor = Armor;
            healthPoints = HealthPoints;

            prel = (Armor * 1.3)+ (HealthPoints * 1.3);
            cost = Math.Round(prel);
            description = $"+ARMOR: {armor} +HP: {healthPoints}";

            for (int i = description.Length; i < 23; i++)
            {
                description += " ";

            }

        }
    }
}

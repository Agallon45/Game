using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Consumable: Item
    {

        public Consumable(string Name, int Health)
        {
            name = Name;
            healthPoints = Health;
            cost = (Health * 1.5) * 2;
            description = $"HEALS FOR: {healthPoints}";

            for (int i = description.Length; i < 23; i++)
            {
                description += " ";

            }

        }
    }
}

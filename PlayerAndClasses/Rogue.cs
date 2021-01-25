using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Rogue: Player
    {




        public Rogue(string name)
        {
            this.name = name;
            commands.Add(1,"FIGHT");
            commands.Add(2,"SWIFT THINKING");
            commands.Add(3,"DODGE");
            commands.Add(4,"ITEMS");
            maxHealthPoints = 60;
            currentHealthPoints = maxHealthPoints;
            strength = 10;
            armor = 10;
            agility = 30;
            intellect = 5;
            lvl = 1;
            experience = 0;
            playerClass = "Rogue";
            initiative = 5;
        }

        public override void StatGain()
        {
            maxHealthPoints += 5;
            currentHealthPoints = maxHealthPoints;
            strength += 1;
            agility += 1;
            intellect += 2;
        }

        public override string Dodge()
        {
            agility += 30;
            isDodging = true;
            return $"{name} is trying to dodge, while setting up a counter-attack!";
        }

        public override string SwiftThinking()
        {
            maxHealthPoints -= 10;
            return $"{name} acts with ease- and swiftness. {name} acts twice in a row! ";
        }

        public override string Heal() { return ""; }

        public override string Defend() { return ""; }

        public override string Bless() { return ""; }

        public override string RemoveBuff() { return ""; }

        public override string AgitatingShout(Enemy enemy) { return ""; }




    }
}

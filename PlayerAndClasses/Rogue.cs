using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Rogue: Player
    {
        private double currentHealthPoints;
        public override double CurrentHealthPoints

        {
            get { return currentHealthPoints; }
            set
            {
                if (value > maxHealthPoints)
                {
                    currentHealthPoints = maxHealthPoints;
                }
                else if (value < 0)
                {
                    currentHealthPoints = 0;
                }
                else
                {
                    currentHealthPoints = value;
                }
            }
        }

        public Rogue(string name)
        {
            this.name = name;
            commands.Add(1,"FIGHT");
            commands.Add(2,"SWIFT THINKING");
            commands.Add(3,"DODGE");
            commands.Add(4,"ITEMS");
            maxHealthPoints = 60;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 10;
            Armor = 10;
            Agility = 30;
            Intellect = 5;
            lvl = 1;
            experience = 0;
            playerClass = "Rogue";
            initiative = 5;
            strengthLoss = 0;
        }

        public override void StatGain()
        {
            maxHealthPoints += 5;
            CurrentHealthPoints = maxHealthPoints;
            Strength += 1;
            Agility += 1;
            Intellect += 2;
        }

        public override string Dodge()
        {
            Agility += 30;
            isDodging = true;
            return $"{name} is trying to dodge, while setting up a counter-attack!";
        }

        public override string SwiftThinking()
        {
            Strength -= 2;
            strengthLoss += 2;
            return $"{name} acts with ease- and swiftness. {name} acts twice in a row! ";
        }

        public override string Heal() { return ""; }

        public override string Defend() { return ""; }

        public override string Bless() { return ""; }

        //public override string RemoveBuff() { return ""; }

        public override string AgitatingShout(Enemy enemy) { return ""; }




    }
}

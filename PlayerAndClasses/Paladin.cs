using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Paladin: Player
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

        public Paladin(string name)
        {
            this.name = name;
            commands.Add(1,"FIGHT");
            commands.Add(2,"HEAL");
            commands.Add(3, "BLESS");
            commands.Add(4,"ITEMS");
            maxHealthPoints = 90;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 12;
            Armor = 30;
            Agility = 6;
            Intellect = 15;
            lvl = 1;
            experience = 0;
            playerClass = "Paladin";
            initiative = 2;
        }

        public override void StatGain()
        {
            maxHealthPoints += 7;
            CurrentHealthPoints = maxHealthPoints;
            Strength += 2;
            //agility += 0;
            Intellect += 2;
        }

        public override string Heal()
        {
            Random rnd = new Random();
            double amount = rnd.Next(((int)Intellect/2), ((int)Intellect));
            double healAmount = amount * 2;
            CurrentHealthPoints += healAmount;
            //double check = CurrentHealthPoints + healAmount;
            //if (check > maxHealthPoints)
            //{
                
            //    CurrentHealthPoints = maxHealthPoints;
            //}
            //else
            //{
            //    CurrentHealthPoints += healAmount;
            //}
            return $"{name} heals self for {healAmount}!";
        }

        public override string Bless()
        {
            blessed = true;
            roundNumRemove = roundNum + 2;
            Strength += 10;
            Intellect += 10;
            Agility += 10;
            Armor += 10;
            posStrength = 10;
            posIntellect = 10;
            posAgility = 10;
            posArmor = 10;


            return $"{name} has cast Bless on self.";
        }

        //public override string RemoveBuff()
        //{
        //    buffed = false;
        //    Strength -= 10;
        //    Agility -= 10;
        //    Intellect -= 10;
        //    Armor -= 10;

        //    return $"Bless fades from {name}...";
        //}


        public override string Defend() { return ""; }

        public override string Dodge() { return ""; }

        public override string AgitatingShout(Enemy enemy) { return ""; }

        public override string SwiftThinking() { return ""; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    
    class Warrior: Player
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


        public Warrior(string name)
        {
            this.name = name;
            commands.Add(1,"FIGHT");
            commands.Add(2,"AGITATING SHOUT");
            commands.Add(3,"DEFEND");
            commands.Add(4,"ITEMS");
            maxHealthPoints = 100;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 15;
            Armor = 50;
            Agility = 5;
            Intellect = 1;
            lvl = 1;
            experience = 0;
            playerClass = "Warrior";
            isDefending = false;
            initiative = 1;
        }

        public override void StatGain()
        {
            maxHealthPoints += 10;
            CurrentHealthPoints = maxHealthPoints;
            Strength += 2;
            //agility += 1;
            //intellect += 1;
        }

        public override string Defend()
        {
            isDefending = true;
            defended = true;
            Armor += 20;
            armorBuff += 20;
            return $"{name} is defending!";
        }

        public override string Heal() { return ""; }

        public override string Dodge() { return ""; }

        public override string Bless() { return ""; }
        public override string SwiftThinking() { return ""; }


        public override string AgitatingShout(Enemy enemy)
        {
            //buffed = true;
            agitated = true;
            enemy.debuffed = true;
            roundNumRemove = roundNum + 2;
            Strength += 3;
            posStrength = 3;
            enemy.Strength = enemy.Strength * 0.9;

            return $"{name} lets out a ferocious warcry! {enemy.name} trembles in fear...";
        }
    

    //public override string RemoveBuff() {
    //    buffed = false;
    //    Strength -= 3;
    //    return $"{name} is no longer agitated...";
    //}
    }
}

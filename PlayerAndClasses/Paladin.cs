using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Paladin: Player
    {

        public Paladin(string name)
        {
            this.name = name;
            commands.Add(1,"FIGHT");
            commands.Add(2,"HEAL");
            commands.Add(3, "BLESS");
            commands.Add(4,"ITEMS");
            maxHealthPoints = 90;
            currentHealthPoints = maxHealthPoints;
            strength = 12;
            armor = 30;
            agility = 6;
            intellect = 15;
            lvl = 1;
            experience = 0;
            playerClass = "Paladin";
            initiative = 2;
        }

        public override void StatGain()
        {
            maxHealthPoints += 7;
            currentHealthPoints = maxHealthPoints;
            strength += 2;
            //agility += 0;
            intellect += 2;
        }

        public override string Heal()
        {
            Random rnd = new Random();
            double amount = rnd.Next(((int)intellect/2), ((int)intellect));
            double healAmount = amount * 2;
            double check = currentHealthPoints + healAmount;
            if (check > maxHealthPoints)
            {
                
                currentHealthPoints = maxHealthPoints;
            }
            else
            {
                currentHealthPoints += healAmount;
            }
            return $"{name} heals him/herself for {healAmount}!";
        }

        public override string Bless()
        {
            buffed = true;
            roundNumRemove = roundNum + 2;
            strength += 10;
            intellect += 10;
            agility += 10;
            armor += 10;

            return $"{name} has cast Bless on self.";
        }

        public override string RemoveBuff()
        {
            buffed = false;
            strength -= 10;
            agility -= 10;
            intellect -= 10;
            armor -= 10;

            return $"Bless fades from {name}...";
        }


        public override string Defend() { return ""; }

        public override string Dodge() { return ""; }

        public override string AgitatingShout(Enemy enemy) { return ""; }

        public override string SwiftThinking() { return ""; }
    }
}

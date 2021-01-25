using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    
    class Warrior: Player
    {


        public Warrior(string name)
        {
            this.name = name;
            commands.Add(1,"FIGHT");
            commands.Add(2,"AGITATING SHOUT");
            commands.Add(3,"DEFEND");
            commands.Add(4,"ITEMS");
            maxHealthPoints = 100;
            currentHealthPoints = maxHealthPoints;
            strength = 15;
            armor = 50;
            agility = 5;
            intellect = 1;
            lvl = 1;
            experience = 0;
            playerClass = "Warrior";
            isDefending = false;
            initiative = 1;
        }

        public override void StatGain()
        {
            maxHealthPoints += 10;
            currentHealthPoints = maxHealthPoints;
            strength += 2;
            //agility += 1;
            //intellect += 1;
        }

        public override string Defend()
        {
            isDefending = true;
            defended = true;
            armor += 20;
            armorBuff += 20;
            return $"{name} is defending!";
        }

        public override string Heal() { return ""; }

        public override string Dodge() { return ""; }

        public override string Bless() { return ""; }
        public override string SwiftThinking() { return ""; }


        public override string AgitatingShout(Enemy enemy)
        {
            buffed = true;
            enemy.debuffed = true;
            roundNumRemove = roundNum + 2;
            strength += 3;
            enemy.strength = enemy.strength * 0.9;

            return $"{name} lets out a ferocious warcry! {enemy.name} trembles in fear...";
        }
    

    public override string RemoveBuff() {
        buffed = false;
        strength -= 3;
        return $"{name} is no longer agitated...";
    }
    }
}

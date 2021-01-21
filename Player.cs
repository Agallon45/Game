using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Player
    {
        public string name;

        public int healthPoints;
        public int strength;
        public int armor;
        public int agility;
        public int intellect;
        public int lvl;
        public int experience;

        public string playerClass;


        public Player(string name, string playerClass)
        {
            this.name = name;
            if (playerClass.ToLower().Equals("warrior"))
            {
                healthPoints = 100;
                strength = 20;
                armor = 20;
                agility = 5;
                intellect = 1;
                lvl = 1;
                experience = 0;
                this.playerClass = playerClass.ToUpper();
            }
            else if (playerClass.ToLower().Equals("thief"))
            {
                healthPoints = 80;
                strength = 10;
                armor = 10;
                agility = 20;
                intellect = 20;
                lvl = 1;
                experience = 0;
                this.playerClass = playerClass.ToUpper();
            }else if (playerClass.ToLower().Equals("mage"))
            {
                healthPoints = 50;
                strength = 5;
                armor = 5;
                agility = 5;
                intellect = 50;
                lvl = 1;
                experience = 0;
                this.playerClass = playerClass.ToUpper();
            }

        }

        public string Attack(Enemy enemy)
        {
            Random rnd = new Random();
            if ((rnd.Next(1, 100) + agility) > enemy.agility)
            {
                int dmg = rnd.Next(1, strength) + strength;
                dmg = dmg - enemy.armor;
                enemy.healthPoints = enemy.healthPoints - dmg;
                return $"{enemy.name} suffers {dmg} damage!";
            }
            else
            {
                return $"{name}s attack misses!";
            }
        }

        public string AddExperience(Enemy enemy)
        {
            experience += enemy.expAward;
            if(experience > (50*lvl))
            {
                return LevelUp();
            }
            else
            {
                return "";
            }


        }

        private string LevelUp()
        {
            lvl++;
            experience = 0;
            StatGain();
            return $"{name} has advanced to level {lvl}!";
            
        }

        private void StatGain()
        {
            if (playerClass.ToLower().Equals("warrior")){
                healthPoints += 10;
                strength += 5;
                agility += 1;
                intellect += 1;

            }else if (playerClass.ToLower().Equals("thief")){
                healthPoints += 5;
                strength += 2;
                agility += 3;
                intellect += 3;

            }
            else//Mage just nu
            {
                healthPoints += 5;
                strength += 1;
                agility += 1;
                intellect += 10;

            }
        }

    }
}

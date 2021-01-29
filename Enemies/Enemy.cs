using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    abstract class Enemy
    {
        public string name;
        public double maxHealthPoints;
        private double currentHealthPoints;
        public double CurrentHealthPoints
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
        private double strength;
        public double Strength
        {
            get { return strength; }
            set
            {
                if (value < 3)
                {
                    strength = 2;
                }
                else
                {
                    strength = value;
                }
            }
        }
        private double armor;
        public double Armor
        {
            get { return armor; }
            set
            {
                if (value < 3)
                {
                    armor = 2;
                }
                else
                {
                    armor = value;
                }
            }
        }
        private double agility;
        public double Agility
        {
            get { return agility; }
            set
            {
                if (value < 3)
                {
                    agility = 2;
                }
                else
                {
                    agility = value;
                }
            }
        }
        public string[,] schematic;
        public double expAward;
        public double coinReward;
        public int roundNum;
        public bool debuffed;
        public int initiative;
        public bool buffed;//för specialatk
        public double buffAmount;//för specialatk
        public int roundNumRemove;
        public double negStrength;
        public double negAgility;
        public bool isDotted;
        public double dot;

        public string EnemyTurn(Player player)
        {
            Random rnd = new Random();
            int atk = rnd.Next(0, 2);
            if (atk == 0)
            {
                return Attack(player);
            }
            else
            {
                return SpecialAtk(player);
            }
        }

        public abstract string RemoveBuffs();

        public abstract string SpecialAtk(Player player);

        public string Attack(Player player)
        {
            Random rnd = new Random();
            if (player is Warrior)
            {
                if (player.isDefending)
                {

                    if ((rnd.Next(1, 100) + agility) > player.Agility)
                    {
                        double dmg = rnd.Next(1, (int)strength) + (strength * 0.8);
                        dmg = dmg - (player.Armor * 0.1);
                        dmg = Math.Round(dmg);//ROUND
                        if (dmg < 1)
                            dmg = 1;

                        player.CurrentHealthPoints = player.CurrentHealthPoints - (dmg * 0.5);
                        player.isDefending = false;
                        return $"{player.name} suffers {dmg} damage! {dmg * 0.5} damage blocked!";

                    }
                    else
                    {
                        return $"{name}s attack misses!";
                    }
                }
                else
                {
                    if ((rnd.Next(1, 100) + agility) > player.Agility)
                    {
                        double dmg = rnd.Next(1, (int)strength) + (strength * 0.8);
                        dmg = dmg - (player.Armor * 0.1);
                        dmg = Math.Round(dmg);//ROUND
                        if (dmg < 1)
                            dmg = 1;
                        player.CurrentHealthPoints = player.CurrentHealthPoints - dmg;
                        return $"{player.name} suffers {dmg} damage!";
                    }
                    else
                    {
                        return $"{name}s attack misses!";
                    }
                }
            }
            else
            {
                if ((rnd.Next(1, 100) + agility) > player.Agility)
                {
                    double dmg = rnd.Next(1, (int)strength) + (strength * 0.8);
                    dmg = dmg - (player.Armor * 0.1);
                    dmg = Math.Round(dmg);//ROUND
                    if (dmg < 1)
                        dmg = 1;
                    player.CurrentHealthPoints = player.CurrentHealthPoints - dmg;
                    if (player is Rogue && player.isDodging)
                    {
                        currentHealthPoints -= player.Strength;
                        player.isDodging = false;
                        player.Agility -= 30;
                        return $"{player.name} suffers {dmg} damage! {player.name} counter-attacks for {player.Strength} damage!";
                    }
                    else
                    {
                        return $"{player.name} suffers {dmg} damage!";
                    }


                }
                else
                {
                    if (player is Rogue && player.isDodging)
                    {
                        currentHealthPoints -= player.Strength;
                        player.isDodging = false;
                        player.Agility -= 30;
                        return $"{name}s attack misses! {player.name} counter-attacks for {player.Strength} damage!";
                    }
                    else
                    {
                        return $"{name}s attack misses!";
                    }

                }
            }

        }
    }
}

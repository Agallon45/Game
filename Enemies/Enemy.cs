﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Enemy
    {
        public string name;
        public double maxHealthPoints;
        public double currentHealthPoints;
        public double strength;
        public double armor;
        public string[,] schematic;
        public double agility;
        public double expAward;
        public double coinReward;
        public int roundNum;
        public bool debuffed;


        public string Attack(Player player)
        {
            Random rnd = new Random();
            if (player is Warrior)
            {
                if (player.isDefending)
                {

                    if ((rnd.Next(1, 100) + agility) > player.agility)
                    {
                        double dmg = rnd.Next(1, (int)strength) + strength;
                        dmg = dmg - (player.armor * 0.1);
                        player.currentHealthPoints = player.currentHealthPoints - (dmg*0.5);
                        player.isDefending = false;
                        return $"{player.name} suffers {dmg} damage! {dmg*0.5} damage blocked!";
                        
                    }
                    else
                    {
                        return $"{name}s attack misses!";
                    }
                }
                else
                {
                    if ((rnd.Next(1, 100) + agility) > player.agility)
                    {
                        double dmg = rnd.Next(1, (int)strength) + strength;
                        dmg = dmg - (player.armor * 0.1);
                        player.currentHealthPoints = player.currentHealthPoints - dmg;
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
                if ((rnd.Next(1, 100) + agility) > player.agility)
                {
                    double dmg = rnd.Next(1, (int)strength) + strength;
                    dmg = dmg - (player.armor * 0.1);
                    player.currentHealthPoints = player.currentHealthPoints - dmg;
                    if(player is Rogue && player.isDodging)
                    {
                        player.isDodging = false;
                        player.agility -= 10;
                    }
                    
                    return $"{player.name} suffers {dmg} damage!";
                }
                else
                {
                    if (player is Rogue && player.isDodging)
                    {
                        player.isDodging = false;
                        player.agility -= 10;
                    }
                    return $"{name}s attack misses!";
                }
            }

        }
    }
}

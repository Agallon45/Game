﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Goblin: Enemy
    {
        public Goblin(string name)
        {
            string[,] goblinSchematic =
{               //25x11
            /*1*/{" "," "," "," "," "," "," ",","," "," "," "," "," "," ",","," "," "," "," "," "," "," "," "," "," "},
            /*2*/{" "," "," "," "," "," ","/","(",".","-","\"","\"","-",".",")","\\"," "," "," "," "," "," "," "," "," "},
            /*3*/{" "," ","|","\\"," "," ","\\","/"," "," "," "," "," "," ","\\","/"," "," ","/","|"," "," "," "," "," "},
            /*4*/{" "," ","|"," ","\\"," ","/"," ","=","."," "," ",".","="," ","\\"," ","/"," ","|"," "," "," "," "," "},
            /*5*/{" "," ","\\","("," ","\\"," "," "," ","o","\\","/","o"," "," "," ","/"," ",")","/"," "," "," "," "," "},
            /*6*/{" "," "," ","\\","_",","," ","'","-","/"," "," ","\\","-","'"," ",",","_","/"," "," "," "," "," "," "},
            /*7*/{" "," "," "," "," ","/"," "," "," ","\\","_","_","/"," "," "," ","\\"," "," "," "," "," "," "," "," "},
            /*8*/{" "," "," "," "," ","\\"," ","\\","_","_","/","\\","_","_","/"," ","/"," "," "," "," "," "," "," "," "},
            /*9*/{" "," "," ","_","_","_","\\"," ","\\","|","-","-","|","/"," ","/","_","_","_"," "," "," "," "," "," "},
            /*10*/{" ","/","`"," "," "," "," ","\\"," "," "," "," "," "," ","/"," "," "," "," ","`","\\"," "," "," "," "},
            /*11*/{"/"," "," "," "," "," "," "," ","'","-","-","-","-","'"," "," "," "," "," "," "," ","\\"," "," "," "},

        };
            //GOBLIN
            //1           ,      ,              
            //2          /(.-""-.)\                    
            //3      |\  \/      \/  /|   
            //4      | \ / =.  .= \ / |
            //5      \( \   o\/o   / )/
            //6       \_, '-/  \-' ,_/
            //7         /   \__/   \
            //8         \ \__/\__/ /
            //9       ___\ \|--|/ /___
            //10    /`    \      /    `\
            //11   /       '----'       \
            this.name = name;
            this.schematic = goblinSchematic;
            maxHealthPoints = 70;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 12;
            Armor = 60;
            Agility = 5;
            expAward = 35;
            coinReward = 25;
            initiative = 1;

        }

        public Goblin(string name, double modifier)
        {
            string[,] goblinSchematic =
{               //25x11
            /*1*/{" "," "," "," "," "," "," ",","," "," "," "," "," "," ",","," "," "," "," "," "," "," "," "," "," "},
            /*2*/{" "," "," "," "," "," ","/","(",".","-","\"","\"","-",".",")","\\"," "," "," "," "," "," "," "," "," "},
            /*3*/{" "," ","|","\\"," "," ","\\","/"," "," "," "," "," "," ","\\","/"," "," ","/","|"," "," "," "," "," "},
            /*4*/{" "," ","|"," ","\\"," ","/"," ","=","."," "," ",".","="," ","\\"," ","/"," ","|"," "," "," "," "," "},
            /*5*/{" "," ","\\","("," ","\\"," "," "," ","o","\\","/","o"," "," "," ","/"," ",")","/"," "," "," "," "," "},
            /*6*/{" "," "," ","\\","_",","," ","'","-","/"," "," ","\\","-","'"," ",",","_","/"," "," "," "," "," "," "},
            /*7*/{" "," "," "," "," ","/"," "," "," ","\\","_","_","/"," "," "," ","\\"," "," "," "," "," "," "," "," "},
            /*8*/{" "," "," "," "," ","\\"," ","\\","_","_","/","\\","_","_","/"," ","/"," "," "," "," "," "," "," "," "},
            /*9*/{" "," "," ","_","_","_","\\"," ","\\","|","-","-","|","/"," ","/","_","_","_"," "," "," "," "," "," "},
            /*10*/{" ","/","`"," "," "," "," ","\\"," "," "," "," "," "," ","/"," "," "," "," ","`","\\"," "," "," "," "},
            /*11*/{"/"," "," "," "," "," "," "," ","'","-","-","-","-","'"," "," "," "," "," "," "," ","\\"," "," "," "},

        };
            //GOBLIN
            //1           ,      ,              
            //2          /(.-""-.)\                    
            //3      |\  \/      \/  /|   
            //4      | \ / =.  .= \ / |
            //5      \( \   o\/o   / )/
            //6       \_, '-/  \-' ,_/
            //7         /   \__/   \
            //8         \ \__/\__/ /
            //9       ___\ \|--|/ /___
            //10    /`    \      /    `\
            //11   /       '----'       \
            this.name = name;
            this.schematic = goblinSchematic;
            maxHealthPoints = 70 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 12 * modifier;
            Armor = 60 * modifier;
            Agility = 6 * modifier;
            expAward = 35 * modifier;
            coinReward = 28 * modifier;
            initiative = 1;

        }

        public override string SpecialAtk(Player player)
        {
            player.CurrentHealthPoints -= Strength;
            Strength += 1;
            CurrentHealthPoints += Strength;

            return $"{name} sucks {player.name}s blood! {name} is revitalized!";
        }

        public override string RemoveBuffs()
        {
            if (debuffed)
            {
                if (roundNum == roundNumRemove)
                {
                    Strength += negStrength;
                    negStrength = 0;
                    Agility += negAgility;
                    negAgility = 0;
                    debuffed = false;
                    roundNumRemove = 0;
                    return $"{name} is no longer debuffed";
                }
            }

            if (isDotted)
            {
                if (roundNum == roundNumRemove)
                {
                    dot = 0;
                    isDotted = false;
                    return $"{name} is no longer suffering periodic damage.";
                }
                else
                {
                    CurrentHealthPoints -= dot;
                    return $"{name} suffers {dot} damage!";
                }
            }
            else
            {
                return "";
            }
        }
    }
}

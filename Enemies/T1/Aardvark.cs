using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Aardvark: Enemy
    {

        public Aardvark(string name)
        {
            
            string[,] aardvarkSchematic =
            {
                { " "," "," "," "," "," "," "," "," ","_",".","-","-","-",".","_"," "," "," "," ","/","\\","\\"," "," "," ",},
                { " "," "," "," "," "," ",".","/","'"," "," "," "," "," "," "," ","\"","-","-","`","\\","/","/"," "," "," ",},
                { " "," "," "," ",".","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","o"," ","\\"," "," "," ",},
                { " "," "," ","/",".","/","\\"," "," ",")","_","_","_","_","_","_"," "," "," ","\\","_","_"," ","\\"," "," ",},
                { " "," ",".","/"," "," ","/"," ","/","\\"," ","\\"," "," "," ","|"," ","\\"," ","\\"," "," ", "\\"," ","\\"," ",},
                { " "," "," "," "," ","/"," ","/"," "," ","\\"," ","\\"," "," ","|"," ","|","\\"," ","\\"," "," ","\\","7"," ",},
                { " "," "," "," "," "," ","\""," "," "," "," "," ","\""," "," "," "," ","\""," "," ","\""," "," "," ","V","K",}
            };
            this.name = name;
            this.schematic = aardvarkSchematic;
            maxHealthPoints = 40;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 6;
            Armor = 80;
            Agility = 5;
            expAward = 16;
            coinReward = 25;
            initiative = 1;
        }

        public Aardvark(string name, double modifier)
        {

            string[,] aardvarkSchematic =
            {
                { " "," "," "," "," "," "," "," "," ","_",".","-","-","-",".","_"," "," "," "," ","/","\\","\\"," "," "," ",},
                { " "," "," "," "," "," ",".","/","'"," "," "," "," "," "," "," ","\"","-","-","`","\\","/","/"," "," "," ",},
                { " "," "," "," ",".","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","o"," ","\\"," "," "," ",},
                { " "," "," ","/",".","/","\\"," "," ",")","_","_","_","_","_","_"," "," "," ","\\","_","_"," ","\\"," "," ",},
                { " "," ",".","/"," "," ","/"," ","/","\\"," ","\\"," "," "," ","|"," ","\\"," ","\\"," "," ", "\\"," ","\\"," ",},
                { " "," "," "," "," ","/"," ","/"," "," ","\\"," ","\\"," "," ","|"," ","|","\\"," ","\\"," "," ","\\","7"," ",},
                { " "," "," "," "," "," ","\""," "," "," "," "," ","\""," "," "," "," ","\""," "," ","\""," "," "," ","V","K",}
            };
            this.name = name;
            this.schematic = aardvarkSchematic;
            maxHealthPoints = 50 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 6 * modifier;
            Armor = 80 * modifier;
            Agility = 5 * modifier;
            expAward = 16 * modifier;
            coinReward = 25 * modifier;
            initiative = 1;
        }

        public override string SpecialAtk(Player player)
        {
            if (!buffed)
            {

            buffed = true;
            Armor += 50;
            buffAmount += 50;
                roundNumRemove = roundNum + 2;
            return $"{name} hardens!";
            }
            else
            {
                return Attack(player);
            }
        }

        public override string RemoveBuffs()
        {
            if (buffed)
            {
                if(roundNumRemove == roundNum)
                {
                    buffed = false;
                    Armor -= buffAmount;
                    buffAmount = 0;
                    roundNumRemove = 0;
                    return $"{name} is no longer very hard. Flaccid rather...";
                }
                else
                {
                    return "";
                }
            }
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



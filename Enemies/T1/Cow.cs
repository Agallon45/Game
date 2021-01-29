﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Cow : Enemy
    {
        public Cow(string name)
        {


            string[,] cowSchematic =
            {
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","/",")"," "," ","(","\\"," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," "," ",".","-",".","_","(","(",",","~","~",".",")",")","_",".","-",","," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," "," "," ","`","-","."," "," "," ","@","@"," "," "," ",",","-","'"," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","/"," ",",","n","-","-","n","."," ","\\"," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," ","(","`","'","\\"," "," "," ","("," ","("," ",".","_","_","."," ",")"," ",")"," "," ","/","`","'",")"},
                {" "," "," "," "," "," "," "," ","`",".","'","\"",".","_"," ",")"," ","`","-","-","-","-","'"," ","(","_",",","\"","`",".","'"," "},
                {" "," "," "," "," "," "," "," "," "," ","\"",".","_"," "," "," "," "," "," "," "," "," "," "," "," "," ","_",",","\""," "," "," "},
                { " "," "," "," "," "," "," "," "," "," "," "," "," ","/"," "," "," "," "," "," "," "," "," "," "," "," ","\\"," "," "," "," "," "},
                { " "," "," "," "," "," "," ","h","j","w"," "," ","("," "," "," "," "," "," "," "," "," "," "," "," "," "," ",")"," "," "," "," "},
                { " "," "," "," "," "," "," ","`","9","7"," "," ","(","`","-",".","_","_"," "," "," "," ","_","_",".","-","'",")"," "," "," "," "},
                { " "," "," "," "," "," "," "," "," "," "," "," "," ","\\"," "," "," ","/","`","-","-","'","\\"," "," "," ","/"," "," "," "," "," "},
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," ",")"," ","/"," "," "," "," "," "," ","\\"," ","("," "," "," "," "," "," "},
                { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", ".", "_", "\\"," "," "," "," "," "," ","/","_",",","\\"," "," "," "," "," "}
            };
            this.name = name;
            this.schematic = cowSchematic;
            maxHealthPoints = 40;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 13;
            Armor = 10;
            Agility = 9;
            expAward = 18;
            coinReward = 25;
            initiative = 2;
        }

        public Cow(string name, double modifier)
        {


            string[,] cowSchematic =
            {
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","/",")"," "," ","(","\\"," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," "," ",".","-",".","_","(","(",",","~","~",".",")",")","_",".","-",","," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," "," "," ","`","-","."," "," "," ","@","@"," "," "," ",",","-","'"," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","/"," ",",","n","-","-","n","."," ","\\"," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," ","(","`","'","\\"," "," "," ","("," ","("," ",".","_","_","."," ",")"," ",")"," "," ","/","`","'",")"},
                {" "," "," "," "," "," "," "," ","`",".","'","\"",".","_"," ",")"," ","`","-","-","-","-","'"," ","(","_",",","\"","`",".","'"," "},
                {" "," "," "," "," "," "," "," "," "," ","\"",".","_"," "," "," "," "," "," "," "," "," "," "," "," "," ","_",",","\""," "," "," "},
                { " "," "," "," "," "," "," "," "," "," "," "," "," ","/"," "," "," "," "," "," "," "," "," "," "," "," ","\\"," "," "," "," "," "},
                { " "," "," "," "," "," "," ","h","j","w"," "," ","("," "," "," "," "," "," "," "," "," "," "," "," "," "," ",")"," "," "," "," "},
                { " "," "," "," "," "," "," ","`","9","7"," "," ","(","`","-",".","_","_"," "," "," "," ","_","_",".","-","'",")"," "," "," "," "},
                { " "," "," "," "," "," "," "," "," "," "," "," "," ","\\"," "," "," ","/","`","-","-","'","\\"," "," "," ","/"," "," "," "," "," "},
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," ",")"," ","/"," "," "," "," "," "," ","\\"," ","("," "," "," "," "," "," "},
                { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "/", ".", "_", "\\"," "," "," "," "," "," ","/","_",",","\\"," "," "," "," "," "}
            };
            this.name = name;
            this.schematic = cowSchematic;
            maxHealthPoints = 40 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 13 * modifier;
            Armor = 10 * modifier;
            Agility = 9 * modifier;
            expAward = 18 * modifier;
            coinReward = 25 * modifier;
            initiative = 2;
        }

        public override string SpecialAtk(Player player)
        {
            if (!player.debuffed)
            {
                player.Intellect -= 30;
                player.negIntellect = 30;
                player.debuffed = true;
                return $"{name} says no! That's not going to happen!";
            }
            else
            {
                return Attack(player);
            }

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
                return "Zzzzzzzz...";
            }
        }
    }
}

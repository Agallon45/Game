using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Knight : Enemy
    {
        public Knight(string name)
        {


            string[,] knightSchematic =
            {
                { " "," ",",","^","."," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," ","|","|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," ","|","|","|"," "," "," "," "," "," "," ","_","T","_"," "," "," "," "," "," "},
                {" "," ","|","|","|"," "," "," ",".","-",".","[",":","|",":","]",".","-","."," "," "},
                {" "," ","=","=","=","_"," ","/","\\","|"," "," ","\"","'","\""," "," ","|","/"," "," "},
                {" "," "," ","E","]","_","|","\\","/"," ","\\","-","-","|","-","|","'","'","'","'","|"},
                {" "," "," ","O"," "," ","`","'"," "," ","'","=","[",":","]","|"," ","A"," "," ","|"},
                {" "," "," "," "," "," "," "," "," "," ","/","\"","\"","\"","\"","|"," "," ","P"," ","|"},
                {" "," "," "," "," "," "," "," "," ","/","\"","\"","\"","\"","\"","`",".","_","_",".","'"},
                {" "," "," "," "," "," "," "," ","[","]","\"","/","\"","\"","\"","\\","\"","[","]"," "," "},
                {" "," "," "," "," "," "," "," ","|"," ","\\"," "," "," "," "," ","/"," ","|"," "," "},
                {" "," "," "," "," "," "," "," ","|"," ","|"," "," "," "," "," ","|"," ","|"," "," "},
                {" "," "," "," "," "," ","<","\\","\\","\\",")"," "," "," "," "," ","(","/","/","/",">"},
            };
            this.name = name;
            this.schematic = knightSchematic;
            maxHealthPoints = 110;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 22;
            Armor = 50;
            Agility = 5;
            expAward = 80;
            coinReward = 70;
            initiative = 2;
        }

        public Knight(string name, double modifier)
        {


            string[,] knightSchematic =
            {
                { " "," ",",","^","."," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," ","|","|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," ","|","|","|"," "," "," "," "," "," "," ","_","T","_"," "," "," "," "," "," "},
                {" "," ","|","|","|"," "," "," ",".","-",".","[",":","|",":","]",".","-","."," "," "},
                {" "," ","=","=","=","_"," ","/","\\","|"," "," ","\"","'","\""," "," ","|","/"," "," "},
                {" "," "," ","E","]","_","|","\\","/"," ","\\","-","-","|","-","|","'","'","'","'","|"},
                {" "," "," ","O"," "," ","`","'"," "," ","'","=","[",":","]","|"," ","A"," "," ","|"},
                {" "," "," "," "," "," "," "," "," "," ","/","\"","\"","\"","\"","|"," "," ","P"," ","|"},
                {" "," "," "," "," "," "," "," "," ","/","\"","\"","\"","\"","\"","`",".","_","_",".","'"},
                {" "," "," "," "," "," "," "," ","[","]","\"","/","\"","\"","\"","\\","\"","[","]"," "," "},
                {" "," "," "," "," "," "," "," ","|"," ","\\"," "," "," "," "," ","/"," ","|"," "," "},
                {" "," "," "," "," "," "," "," ","|"," ","|"," "," "," "," "," ","|"," ","|"," "," "},
                {" "," "," "," "," "," ","<","\\","\\","\\",")"," "," "," "," "," ","(","/","/","/",">"},
            };
            this.name = name;
            this.schematic = knightSchematic;
            maxHealthPoints = 110 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 22 * modifier;
            Armor = 50 * modifier;
            Agility = 5 * modifier;
            expAward = 80 * modifier;
            coinReward = 70 * modifier;
            initiative = 2;
        }

        public override string SpecialAtk(Player player)
        {
            double dmg = (Armor);
            dmg = Math.Round(dmg);
            player.CurrentHealthPoints -= dmg;
            Armor += 10;
            return $"{name} throws his shield at {player.name}! {player.name} suffers {dmg} damage!";
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
                return $"{name} says: Only a fleshwound?";
            }

        }
    }
}

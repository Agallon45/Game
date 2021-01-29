using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Frog: Enemy
    {
        public Frog(string name)
        {

            string[,] frogSchematic =
            {
                /*1*/{" "," "," "," "," "," "," ","_"," "," "," "," "," ","_"," "," "," "," "," "," "," "," " },
                /*2*/{" "," "," "," "," "," ","(","'",")","-","=","-","(","'",")"," "," "," "," "," "," "," " },
                /*3*/{" "," "," "," "," ","_","_","("," "," ","\""," "," ",")","_","_"," "," "," "," "," "," " },
                /*4*/{" "," "," "," ","/","_","/","'","-","-","-","-","-","'","\\","_","\\"," "," "," "," "," " },
                /*5*/{" ","_","_","_","\\","\\"," ","\\","\\"," "," "," "," "," ","/","/"," ","/","/","_","_","_" },
                /*6*/{" ",">","_","_","_","_",")","/","_","\\","-","-","-","/","_","\\","(","_","_","_","_","<" }


            };
            //1       _     _        .
            //2      (')-=-(')       .
            //3     __(  "  )__      .
            //4    /_/'-----'\_\     .
            //5 ___\\ \\     // //___.
            //6 >____)/_\---/_\(____<.
            this.name = name;
            this.schematic = frogSchematic;
            maxHealthPoints = 30;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 10;
            Armor = 5;
            Agility = 20;
            expAward = 16;
            coinReward = 20;
            initiative = 1;
        }

        public Frog(string name, double modifier)
        {

            string[,] frogSchematic =
            {
                /*1*/{" "," "," "," "," "," "," ","_"," "," "," "," "," ","_"," "," "," "," "," "," "," "," " },
                /*2*/{" "," "," "," "," "," ","(","'",")","-","=","-","(","'",")"," "," "," "," "," "," "," " },
                /*3*/{" "," "," "," "," ","_","_","("," "," ","\""," "," ",")","_","_"," "," "," "," "," "," " },
                /*4*/{" "," "," "," ","/","_","/","'","-","-","-","-","-","'","\\","_","\\"," "," "," "," "," " },
                /*5*/{" ","_","_","_","\\","\\"," ","\\","\\"," "," "," "," "," ","/","/"," ","/","/","_","_","_" },
                /*6*/{" ",">","_","_","_","_",")","/","_","\\","-","-","-","/","_","\\","(","_","_","_","_","<" }


            };
            //1       _     _        .
            //2      (')-=-(')       .
            //3     __(  "  )__      .
            //4    /_/'-----'\_\     .
            //5 ___\\ \\     // //___.
            //6 >____)/_\---/_\(____<.
            this.name = name;
            this.schematic = frogSchematic;
            maxHealthPoints = 30 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 10 * modifier;
            Armor = 10 * modifier;
            Agility = 20 * modifier;
            expAward = 18 * modifier;
            coinReward = 23 * modifier;
            initiative = 1;
        }

        public override string SpecialAtk(Player player)
        {
            Random rnd = new Random();
            if(rnd.Next(0,8)>3)
            {

            
            if (!buffed)
            {
                buffed = true;
                Agility += 70;
                roundNumRemove = roundNum + 2;
                return $"{name} is very slippery! Attacks seems only to glance off of it!";
            }
            else
            {
                buffed = false;
                Agility = Agility -= 70;
                return Attack(player);
            }
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


                if (roundNum == roundNumRemove)
                {
                    buffed = false;
                    Agility -= 70;
                    roundNumRemove = 0;
                    return $"{name} is suddenly very dry. Attack {name} now!";
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
                return "Croak...";
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Phoenix: Enemy
    {

        public Phoenix(string name)
        {
            string[,] phoenixSchematic =
            {
                /*1*/{" ",".","\\","\\"," "," "," "," "," "," "," "," "," "," "," "," ","/","/","." },
                /*2*/{"."," ","\\"," ","\\"," "," "," "," "," "," "," "," "," "," ","/"," ","/","." },
                /*3*/{".","\\"," "," ",",","\\"," "," "," "," "," ","/","`"," ","/",",",".","-"," " },
                /*4*/{" ","-","."," "," "," ","\\"," "," ","/"," ","'","/"," ","/"," "," ","."," " },
                /*5*/{" ","`"," ","-"," "," "," ","`","-","'"," "," ","\\"," "," ","-"," "," "," " },
                /*6*/{" "," "," ","'","."," "," "," "," "," "," "," ","/",".","\\","`"," "," "," " },
                /*7*/{" "," "," "," "," "," ","-"," "," "," "," ",".","-"," "," "," "," "," "," " },
                /*8*/{" "," "," "," "," "," ",":","`","/","/",".","'"," "," "," "," "," "," "," " },
                /*9*/{" "," "," "," "," "," ",".","`",".","'"," "," "," "," "," "," "," "," "," " },
                /*10*/{" "," "," "," "," "," ",".","'"," ","B","P"," "," "," "," "," "," "," "," " }

            };
            //1 .\\            //..
            //2. \ \          / /..
            //3.\  ,\     /` /,.- .
            //4 -.   \  / '/ /  . .
            //5 ` -   `-'  \  -   .
            //6   '.       /.\`   .
            //7      -    .-      .
            //8      :`//.'       .
            //9      .`.'         .
            //1      .' BP        . 

            this.name = name;
            this.schematic = phoenixSchematic;
            maxHealthPoints = 450;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 95;
            Armor = 80;
            Agility = 40;
            expAward = 95;
            coinReward = 120;
            initiative = 4;
        }

        public Phoenix(string name, double modifier)
        {
            string[,] phoenixSchematic =
            {
                /*1*/{" ",".","\\","\\"," "," "," "," "," "," "," "," "," "," "," "," ","/","/","." },
                /*2*/{"."," ","\\"," ","\\"," "," "," "," "," "," "," "," "," "," ","/"," ","/","." },
                /*3*/{".","\\"," "," ",",","\\"," "," "," "," "," ","/","`"," ","/",",",".","-"," " },
                /*4*/{" ","-","."," "," "," ","\\"," "," ","/"," ","'","/"," ","/"," "," ","."," " },
                /*5*/{" ","`"," ","-"," "," "," ","`","-","'"," "," ","\\"," "," ","-"," "," "," " },
                /*6*/{" "," "," ","'","."," "," "," "," "," "," "," ","/",".","\\","`"," "," "," " },
                /*7*/{" "," "," "," "," "," ","-"," "," "," "," ",".","-"," "," "," "," "," "," " },
                /*8*/{" "," "," "," "," "," ",":","`","/","/",".","'"," "," "," "," "," "," "," " },
                /*9*/{" "," "," "," "," "," ",".","`",".","'"," "," "," "," "," "," "," "," "," " },
                /*10*/{" "," "," "," "," "," ",".","'"," ","B","P"," "," "," "," "," "," "," "," " }

            };
            //1 .\\            //..
            //2. \ \          / /..
            //3.\  ,\     /` /,.- .
            //4 -.   \  / '/ /  . .
            //5 ` -   `-'  \  -   .
            //6   '.       /.\`   .
            //7      -    .-      .
            //8      :`//.'       .
            //9      .`.'         .
            //1      .' BP        . 

            this.name = name;
            this.schematic = phoenixSchematic;
            maxHealthPoints = 450 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 95 * modifier;
            Armor = 80 * modifier;
            Agility = 40 * modifier;
            expAward = 95 * modifier;
            coinReward = 120 * modifier;
            initiative = 4;
        }

        public override string SpecialAtk(Player player)
        {
            if (!player.isDotted)
                {
                double dmg = Strength;
                maxHealthPoints = maxHealthPoints * 1.5;
                CurrentHealthPoints = maxHealthPoints;
                player.CurrentHealthPoints -= dmg;
                player.isDotted = true;
                player.dot = 10;
                player.roundNumRemove = roundNum + 2;
                return $"{name} decides to die and be reborn again. {player.name} gets caught in the fiery explosion and suffers {dmg} damage. Also you are on fire.";
            }
            else
            {
                double dmg = Strength;
                maxHealthPoints = maxHealthPoints * 1.5;
                CurrentHealthPoints = maxHealthPoints;
                return $"{name} decides to die and be reborn again. {player.name} gets caught in the fiery explosion and suffers {dmg} damage.";
            }
        }

        public override string RemoveBuffs()
        {
            if (debuffed)
            {
                if(roundNum == roundNumRemove)
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
                return "Everything is burning...";
            }
            
        }
    }
}

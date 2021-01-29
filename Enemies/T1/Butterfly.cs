using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Butterfly: Enemy
    {
        public Butterfly(string name)
        {
            string[,] butterflySchematic =
            {
                /*1*/{" ",".","'","."," "," "," "," "," "," "," "," "," ",".","'","."," " },
                /*2*/{" ","|"," "," ","\\"," "," "," "," "," "," "," "," ","/"," "," ","|" },
                /*3*/{" ","'","."," "," ","\\"," "," ","|"," "," ","/"," "," ",".","'"," " },
                /*4*/{" "," "," ","'","."," ","\\","\\","|","/","/"," ",".","'"," "," "," " },
                /*5*/{" "," "," "," "," ","'","-","-"," ","-","-","'"," "," "," "," "," " },
                /*6*/{" "," "," "," "," ",".","'","/","|","\\","'",".","."," "," "," "," " },
                /*7*/{" "," "," "," ","'",".",".","'","|"," ","'",".",".","'"," "," "," " }
            };
            this.name = name;
            this.schematic = butterflySchematic;
            maxHealthPoints = 35;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 10;
            Armor = 1;
            Agility = 5;
            expAward = 20;
            coinReward = 25;
            initiative = 3;

            //1 .'.         .'. .
            //2  |  \       /  |.
            //3 '.  \  |  /  .' .
            //4   '. \\|// .'   .
            //5     '-- --'     .
            //6     .'/|\'..    .
            //7    '..'| '..'   .
        }
        public Butterfly(string name, double modifier)
        {
            string[,] butterflySchematic =
            {
                /*1*/{" ",".","'","."," "," "," "," "," "," "," "," "," ",".","'","."," " },
                /*2*/{" "," ","|"," "," ","\\"," "," "," "," "," "," "," ","/"," "," ","|" },
                /*3*/{" ","'","."," "," ","\\"," "," ","|"," "," ","/"," "," ",".","'"," " },
                /*4*/{" "," "," ","'","."," ","\\","\\","|","/","/"," ",".","'"," "," "," " },
                /*5*/{" "," "," "," "," ","'","-","-"," ","-","-","'"," "," "," "," "," " },
                /*6*/{" "," "," "," "," ",".","'","/","|","\\","'",".","."," "," "," "," " },
                /*7*/{" "," "," "," ","'",".",".","'","|"," ","'",".",".","'"," "," "," " }
            };
            this.name = name;
            this.schematic = butterflySchematic;
            maxHealthPoints = 35 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 13 * modifier;
            Armor = 5 * modifier;
            Agility = 10 * modifier;
            expAward = 25 * modifier;
            coinReward = 25 * modifier;
            initiative = 3;

            //1 .'.         .'. .
            //2  |  \       /  |.
            //3 '.  \  |  /  .' .
            //4   '. \\|// .'   .
            //5     '-- --'     .
            //6     .'/|\'..    .
            //7    '..'| '..'   .
        }

        public override string SpecialAtk(Player player)
        {
            if (!player.debuffed)
            {
                player.debuffed = true;
                player.Strength -= 5;
                player.negStrength = 5;
                return $"{name} fills the air with pollen. Atchoo!";
            }
            else
            {
                player.debuffed = false;
                player.Strength += player.negStrength;
                player.negStrength = 0;
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
                return " ";
            }
        }


    }
}

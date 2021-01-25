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
                /*2*/{" "," ","|"," "," ","\\"," "," "," "," "," "," "," ","/"," "," ","|" },
                /*3*/{" ","'","."," "," ","\\"," "," ","|"," "," ","/"," "," ",".","'"," " },
                /*4*/{" "," "," ","'","."," ","\\","\\","|","/","/"," ",".","'"," "," "," " },
                /*5*/{" "," "," "," "," ","'","-","-"," ","-","-","'"," "," "," "," "," " },
                /*6*/{" "," "," "," "," ",".","'","/","|","\\","'",".","."," "," "," "," " },
                /*7*/{" "," "," "," ","'",".",".","'","|"," ","'",".",".","'"," "," "," " }
            };
            this.name = name;
            this.schematic = butterflySchematic;
            maxHealthPoints = 35;
            currentHealthPoints = maxHealthPoints;
            strength = 10;
            armor = 1;
            agility = 5;
            expAward = 20;
            coinReward = 15;
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
            currentHealthPoints = maxHealthPoints;
            strength = 13 * modifier;
            armor = 5 * modifier;
            agility = 10 * modifier;
            expAward = 25 * modifier;
            coinReward = 20 * modifier;
            initiative = 3;

            //1 .'.         .'. .
            //2  |  \       /  |.
            //3 '.  \  |  /  .' .
            //4   '. \\|// .'   .
            //5     '-- --'     .
            //6     .'/|\'..    .
            //7    '..'| '..'   .
        }

    }
}

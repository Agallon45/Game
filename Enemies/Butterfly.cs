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
            strength = 10 * modifier;
            armor = 1 * modifier;
            agility = 5 * modifier;
            expAward = 20 * modifier;
            coinReward = 15 * modifier;

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

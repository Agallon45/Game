﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Dragon: Enemy
    {

        public Dragon(string name)
        {
            string[,] dragonSchematic =
            {
                /*1*/{" "," ","<",">","=","=","=","=","=","=","=","(",")"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*2*/{" "," "," ","(","/","\\","_","_","_"," ","/","|","\\","\\"," "," "," "," "," "," "," "," "," ","(",")","=","=","=","=","=","=","=","=","=","=","<",">","_"," " },
                /*3*/{" "," "," "," "," "," "," ","\\","_","/"," ","|"," ","\\","\\"," "," "," "," "," "," "," ","/","/","|","\\"," "," "," ","_","_","_","_","_","_","/"," ","\\",")" },
                /*4*/{" "," "," "," "," "," "," "," "," ","\\","_","|"," "," ","\\","\\"," "," "," "," "," ","/","/"," ","|"," ","\\","_","/"," "," "," "," "," "," "," "," "," "," " },
                /*5*/{" "," "," "," "," "," "," "," "," "," ","\\","|","\\","/","|","\\","_"," "," "," ","/","/"," "," ","/","\\","/"," "," "," "," "," "," "," "," "," "," "," "," " },
                /*6*/{" "," "," "," "," "," "," "," "," "," ","(","o","o",")","\\"," "," ","\\","_","/","/"," "," ","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*7*/{" "," "," "," "," "," "," "," "," ","/","/","_","/","\\","_","\\","/"," "," ","/"," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*8*/{" "," "," "," "," "," "," "," ","@","@","/"," "," ","|","=","\\"," "," "," ","\\"," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*9*/{" "," "," "," "," "," "," "," "," "," "," "," "," ","\\","_"," ","=","\\","_"," ","\\"," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*10*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","\\","=","=","\\"," "," ","\\","|","\\","_"," ","s","n","d"," "," "," "," "," "," "," "," "," "," " },
                /*11*/{" "," "," "," "," "," "," "," "," "," "," "," "," ","_","_","(","\\","=","=","=","\\","("," "," ",")","\\"," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*12*/{" "," "," "," "," "," "," "," "," "," "," "," ","(","(","(","~",")"," ","_","_","(","_"," ","/"," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," " },
                /*13*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","(","(","(","~",")"," ","\\"," "," ","/"," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*14*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","_","_","_","_","_","_"," ","/"," ","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*15*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","'","-","-","-","-","-","-","'"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " }
            };

            //1  <>=======()                          .
            //2   (/\___ /|\\         ()==========<>_ .
            //3       \_/ | \\       //|\   ______/ \).
            //4         \_|  \\     // | \_/          .
            //5          \|\/|\_   //  /\/            .
            //6          (oo)\  \_//  /               .
            //7         //_/\_\/  /  |                .
            //8        @@/  |=\   \  |                .
            //9             \_ =\_ \ |                .
            //1               \==\  \|\_ snd          .
            //1             __(\===\(  )\             .
            //1            (((~) __(_ /  |            .
            //1                (((~) \  /             .
            //1               ______ / /              .
            //1               '------'                .
            this.name = name;
            this.schematic = dragonSchematic;
            maxHealthPoints = 550;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 70;
            Armor = 110;
            Agility = 25;
            expAward = 125;
            coinReward = 135;
            initiative = 6;





        }

        public Dragon(string name, double modifier)
        {
            string[,] dragonSchematic =
            {
                /*1*/{" "," "," ", " ","<",">","=","=","=","=","=","=","=","(",")"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*2*/{" "," "," ","(","/","\\","_","_","_"," ","/","|","\\","\\"," "," "," "," "," "," "," "," "," ","(",")","=","=","=","=","=","=","=","=","=","=","<",">","_"," " },
                /*3*/{" "," "," "," "," "," "," ","\\","_","/"," ","|"," ","\\","\\"," "," "," "," "," "," "," ","/","/","|","\\"," "," "," ","_","_","_","_","_","_","/"," ","\\",")" },
                /*4*/{" "," "," "," "," "," "," "," "," ","\\","_","|"," "," ","\\","\\"," "," "," "," "," ","/","/"," ","|"," ","\\","_","/"," "," "," "," "," "," "," "," "," "," " },
                /*5*/{" "," "," "," "," "," "," "," "," "," ","\\","|","\\","/","|","\\","_"," "," "," ","/","/"," "," ","/","\\","/"," "," "," "," "," "," "," "," "," "," "," "," " },
                /*6*/{" "," "," "," "," "," "," "," "," "," ","(","o","o",")","\\"," "," ","\\","_","/","/"," "," ","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*7*/{" "," "," "," "," "," "," "," "," ","/","/","_","/","\\","_","\\","/"," "," ","/"," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*8*/{" "," "," "," "," "," "," "," ","@","@","/"," "," ","|","=","\\"," "," "," ","\\"," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*9*/{" "," "," "," "," "," "," "," "," "," "," "," "," ","\\","_"," ","=","\\","_"," ","\\"," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*10*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","\\","=","=","\\"," "," ","\\","|","\\","_"," ","s","n","d"," "," "," "," "," "," "," "," "," "," " },
                /*11*/{" "," "," "," "," "," "," "," "," "," "," "," "," ","_","_","(","\\","=","=","=","\\","("," "," ",")","\\"," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*12*/{" "," "," "," "," "," "," "," "," "," "," "," ","(","(","(","~",")"," ","_","_","(","_"," ","/"," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," " },
                /*13*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","(","(","(","~",")"," ","\\"," "," ","/"," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*14*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","_","_","_","_","_","_"," ","/"," ","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                /*15*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","'","-","-","-","-","-","-","'"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " }
            };

            //1  <>=======()                          .
            //2   (/\___ /|\\         ()==========<>_ .
            //3       \_/ | \\       //|\   ______/ \).
            //4         \_|  \\     // | \_/          .
            //5          \|\/|\_   //  /\/            .
            //6          (oo)\  \_//  /               .
            //7         //_/\_\/  /  |                .
            //8        @@/  |=\   \  |                .
            //9             \_ =\_ \ |                .
            //1               \==\  \|\_ snd          .
            //1             __(\===\(  )\             .
            //1            (((~) __(_ /  |            .
            //1                (((~) \  /             .
            //1               ______ / /              .
            //1               '------'                .
            this.name = name;
            this.schematic = dragonSchematic;
            maxHealthPoints = 550 * modifier;
            CurrentHealthPoints = maxHealthPoints;
            Strength = 70 * modifier;
            Armor = 110 * modifier;
            Agility = 25 * modifier;
            expAward = 125 * modifier;
            coinReward = 135 * modifier;
            initiative = 6;

        }

        public override string SpecialAtk(Player player)
        {
            Armor += 50;
            Agility += 2;
            Strength += 2;
            CurrentHealthPoints += 10;
            maxHealthPoints += 10;
            player.Strength -= 2;
            player.maxHealthPoints -= 10;
            player.CurrentHealthPoints -= 10;
            return $"{name}s scaly skin shines as bright as the sun, blinding you as it takes to the skies!";
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
                return $"The majestic presence of the {name} is extremely captivating, making it hard to concentrate. Don't loose focus!";
            }

            
        }
    }
}

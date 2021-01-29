﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Castle : Enemy
    {
        public Castle(string name)
        {


            string[,] castleSchematic =
            {
                { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","-","|"," "," "," "," "," "," "," "," "," "," "," "," "," ","|","-"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" "," "," "," "," "," "," "," "," ","-","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","[","-","_","-","_","-","_","-","_","-","_","-","_","-","_","-","]"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","-"," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," ","[","-","_","-","_","-","_","-","_","-","]"," "," "," "," "," "," "," "," "," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," ","|"," "," "," "," "," "," "," "," "," "," ","[","-","_","-","_","-","_","-","_","-","]"," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," ","|"," ","o"," "," "," ","o"," ","|"," "," "," "," "," "," "," "," "," "," "," ","["," "," ","0"," "," "," ","0"," "," "," ","0"," "," ","]"," "," "," "," "," "," "," "," "," "," "," ","|"," ","o"," "," "," ","o"," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," ","|"," "," "," "," "," ","|"," "," "," "," ","-","|"," "," "," "," "," "," "," ","|"," "," "," "," "," "," "," "," "," "," "," ","|"," "," "," "," "," "," "," ","|","-"," "," "," "," ","|"," "," "," "," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," ","|"," "," "," "," "," ","|","_","-","_","_","_","-","_","_","_","-","_","_","_","-","|"," "," "," "," "," "," "," "," "," ","|","-","_","_","_","-","_","_","_","-","_","_","_","-","_","|"," "," "," "," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," ","|"," "," ","o"," "," ","]"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","["," "," "," "," ","0"," "," "," "," ","]"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","["," "," ","o"," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," ","|"," "," "," "," "," ","]"," "," "," ","o"," "," "," ","o"," "," "," ","o"," "," ","["," ","_","_","_","_","_","_","_"," ","]"," "," ","o"," "," "," ","o"," "," "," ","o"," "," "," ","["," "," "," "," "," ","|"," ","-","-","-","-","_","_","_","_","_","_","_","_","_","_"},
                {"_","_","_","_","_","-","-","-","-","-"," ","|"," "," "," "," "," ","]"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","["," ","|","|","|","|","|","|","|"," ","]"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","["," "," "," "," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," "," "," "," "," "," ","|"," "," "," "," "," ","]"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","["," ","|","|","|","|","|","|","|"," ","]"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","["," "," "," "," "," ","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
               {" "," "," "," "," "," "," ","_","-","_","-","|","_","_","_","_","_","]","-","-","-","-","-","-","-","-","-","-","-","-","-","-","[","_","|","|","|","|","|","|","|","_","]","-","-","-","-","-","-","-","-","-","-","-","-","-","-","[","_","_","_","_","_","|","-","_","-","_"," "," "," "," "," "," "," "," "," "," "," "},
                {" "," "," "," "," "," ","("," ","(","_","_","_","_","_","_","_","_","_","_","-","-","-","-","-","-","-","-","-","-","-","-","_","_","_","_","_","_","_","_","_","_","_","_","_","-","-","-","-","-","-","-","-","-","-","-","-","-","_","_","_","_","_","_","_","_","_",")"," ",")"," "," "," "," "," "," "," "," "," "," "}

            };
            this.name = name;
            this.schematic = castleSchematic;
        }

        public override string SpecialAtk(Player player)
        {
            throw new NotImplementedException();
        }

        public override string RemoveBuffs()
        {
            throw new NotImplementedException();
        }
    }
}

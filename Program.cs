using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        bool inBattle = false;
        string[,] ui =
{               //60x12
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }
            };

        string[,] goblinSchematic =
    {               //25x11
            /*1*/{" "," "," "," "," "," "," ",","," "," "," "," "," "," ",","," "," "," "," "," "," "," "," "," "," "},
            /*2*/{" "," "," "," "," "," ","/","(",".","-","\"","\"","-",".",")","\\"," "," "," "," "," "," "," "," "," "},
            /*3*/{" "," ","|","\\"," "," ","\\","/"," "," "," "," "," "," ","\\","/"," "," ","/","|"," "," "," "," "," "},
            /*4*/{" "," ","|"," ","\\"," ","/"," ","=","."," "," ",".","="," ","\\"," ","/"," ","|"," "," "," "," "," "},
            /*5*/{" "," ","\\","("," ","\\"," "," "," ","o","\\","/","o"," "," "," ","/"," ",")","/"," "," "," "," "," "},
            /*6*/{" "," "," ","\\","_",","," ","'","-","/"," "," ","\\","-","'"," ",",","_","/"," "," "," "," "," "," "},
            /*7*/{" "," "," "," "," ","/"," "," "," ","\\","_","_","/"," "," "," ","\\"," "," "," "," "," "," "," "," "},
            /*8*/{" "," "," "," "," ","\\"," ","\\","_","_","/","\\","_","_","/"," ","/"," "," "," "," "," "," "," "," "},
            /*9*/{" "," "," ","_","_","_","\\"," ","\\","|","-","-","|","/"," ","/","_","_","_"," "," "," "," "," "," "},
            /*10*/{" ","/","`"," "," "," "," ","\\"," "," "," "," "," "," ","/"," "," "," "," ","`","\\"," "," "," "," "},
            /*11*/{"/"," "," "," "," "," "," "," ","'","-","-","-","-","'"," "," "," "," "," "," "," ","\\"," "," "," "},

        };
        //GOBLIN
        //1           ,      ,              
        //2          /(.-""-.)\                    
        //3      |\  \/      \/  /|   
        //4      | \ / =.  .= \ / |
        //5      \( \   o\/o   / )/
        //6       \_, '-/  \-' ,_/
        //7         /   \__/   \
        //8         \ \__/\__/ /
        //9       ___\ \|--|/ /___
        //10    /`    \      /    `\
        //11   /       '----'       \

        string[,] victoryMsg =
                //49x6
        {
            /*1*/{"_","_","_","_"," "," "," ","_","_","_","_",".","_","_"," "," "," "," "," "," "," "," ","_","_"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",".","_","."},
            /*2*/{"\\"," "," "," ","\\"," ","/"," "," "," ","/","|","_","_","|"," ","_","_","_","_","_","/"," "," ","|","_"," ","_","_","_","_","_","_","_","_","_","_","_"," ","_","_","_",".","_","_",".","|"," ","|"},
            /*3*/{" ","\\"," "," "," ","Y"," "," "," ","/"," ","|"," "," ","|","/"," ","_","_","_","\\"," "," "," ","_","_","\\","/"," "," ","_"," ","\\","_"," ","_","_"," ","<"," "," "," ","|"," "," ","|","|"," ","|"},
            /*4*/{" "," ","\\"," "," "," "," "," ","/"," "," ","|"," "," ","\\"," "," ","\\","_","_","_","|"," "," ","|"," ","("," "," ","<","_",">"," ",")"," "," ","|"," ","\\","/","\\","_","_","_"," ","|"," ","\\","|" },
            /*5*/{" "," "," ","\\","_","_","_","/"," "," "," ","|","_","_","|","\\","_","_","_"," "," ",">","_","_","|"," "," ","\\","_","_","_","_","/","|","_","_","|"," "," "," ","/"," ","_","_","_","|"," ","_","_" },
            /*6*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","\\","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","\\","/"," "," "," "," "," ","\\","/"}
        };
        //VICTORY MESSAGE
        //1____   ____.__        __                      ._.
        //2\   \ /   /|__| _____/  |_ ___________ ___.__.| |
        //3 \   Y   / |  |/ ___\   __\/  _ \_ __ <   |  || |
        //4  \     /  |  \  \___|  | (  <_> )  | \/\___ | \|
        //5   \___/   |__|\___  >__|  \____/|__|   / ___| __
        //6                   \/                   \/     \/





        List<Enemy> enemyList = new List<Enemy>();
        Player player;

        static void Main(string[] args)
        {
            Program prog = new Program();
            //prog.StartGame();
            //prog.LoadMenu();
            prog.NewGame();
            prog.LoadFight();
        }

        private void StartGame()
        {
            Console.WriteLine("___________              __                           ________                       ");
            Console.WriteLine("\\_   _____/____    _____/  |______    _________.__.  /  _____/_____    _____   ____  ");
            Console.WriteLine(" |    __) \\__  \\  /    \\   __\\__  \\  /  ___<   |  | /   \\  ___\\__  \\  /     \\_/ __ \\ ");
            Console.WriteLine(" |     \\   / __ \\|   |  \\  |  / __ \\_\\___ \\ \\___  | \\    \\_\\  \\/ __ \\|  Y Y  \\  ___/ ");
            Console.WriteLine(" \\___  /  (____  /___|  /__| (____  /____  >/ ____|  \\______  (____  /__|_|  /\\___  >");
            Console.WriteLine("     \\/        \\/     \\/          \\/     \\/ \\/              \\/     \\/      \\/     \\/ ");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true);
            
        }

        private void LoadMenu()
        {
            string cmd;
            Console.Clear();
            Console.WriteLine("Enter a command");
            Console.WriteLine("NEW: New game");
            Console.WriteLine("LD: Load Game");
            Console.WriteLine("EXT: Exit Game");
            do
            {
                //Console.Write(">");
                cmd = Console.ReadLine();
            } while (!cmd.Equals("NEW") && !cmd.Equals("LD") && !cmd.Equals("EXT"));

            if (cmd.Equals("NEW"))
            {
                NewGame();
            }else if (cmd.Equals("LD"))
            {
                LoadGame();
            }
            else
            {
                ExitGame();
            }

        }

        private static void ExitGame()
        {
            Environment.Exit(0);
        }

        private void LoadGame()
        {
            Console.WriteLine("Spel laddas.");
            Console.ReadLine();
        }

        private void NewGame()
        {
            player = CreateNewPlayer();
            Console.Clear();
            LoadUserInterfaceOutOfBattle();
        }

        private void LoadScene()
        {
            Console.Clear();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < ui.GetLength(1) - 1; x++)
                {
                    Point currentPoint = new Point(x, y);
                    Console.Write(ui[y, x]);
                }
                Console.WriteLine();
            }
            if (!inBattle)
                LoadUserInterfaceOutOfBattle();

        }

        private void LoadUserInterfaceOutOfBattle()
        {
            Console.WriteLine($"                                                            ");
            Console.WriteLine($"____________________________________________________________");
            Console.WriteLine($"{player.name}");
            Console.WriteLine($"Health: {player.healthPoints}   Strength: {player.strength} ");
            Console.WriteLine($"Weapon: {player.healthPoints}   Armor: {player.strength}    ");
            //Console.WriteLine("Enter a chhar to begin battle!");
            // För utveckling: Console.WriteLine($"x = {goblin.GetLength(0)}, Y = {goblin.GetLength(1)}.");
            //Console.ReadLine();
            //LoadFight();
            //UpdateScene(GeneratePicture(victoryMsg));
        }

        private void LoadUserInterfaceInBattle(Enemy enemy)
        {
            Console.WriteLine($"                                                            ");
            Console.WriteLine($"____________________________________________________________");
            Console.WriteLine($"{player.name}");
            Console.WriteLine($"Health: {player.healthPoints}   Strength: {player.strength}   Enemyhealth: {enemy.healthPoints} ");
            Console.WriteLine($"Weapon: {player.healthPoints}   Armor: {player.strength}   Enemystrength: {enemy.strength}    ");
            //Console.WriteLine("Enter a chhar to begin battle!");
            // För utveckling: Console.WriteLine($"x = {goblin.GetLength(0)}, Y = {goblin.GetLength(1)}.");
            //Console.ReadLine();
            //LoadFight();
            //UpdateScene(GeneratePicture(victoryMsg));
        }


        private static Player CreateNewPlayer()
        {
            Console.WriteLine("Vad heter din karaktär?");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            return player;
        }

        private void UpdateScene(Dictionary<Point, string> schematic)
        {
            foreach (KeyValuePair<Point, string> item in schematic)
            {
                ui[item.Key.Y, item.Key.X] = item.Value;
            }
            LoadScene();
        }

        private Dictionary<Point,string> GeneratePicture(string[,] schematic)
        {
            int x2 = (((60 - schematic.GetLength(1)) / 2) + schematic.GetLength(1));
            Dictionary<Point, string> dictionarySchematic = new Dictionary<Point, string>();
            for (int y = 0; y < schematic.GetLength(0); y++)
            {
                for (int x = ((60 - schematic.GetLength(1)) / 2); x < x2; x++)
                {
                    Point point = new Point(x, y);
                    dictionarySchematic.Add(point, schematic[y, (x- ((60 - schematic.GetLength(1)) / 2))]);
                }
            }
            return dictionarySchematic;
        }

        private void LoadFight()
        {
            inBattle = true;
            Enemy enemy = new Enemy("Goblin", goblinSchematic);
            UpdateScene(GeneratePicture(enemy.schematic));
            LoadUserInterfaceInBattle(enemy);
            StartFight(enemy);

        }

        private void UpdateUserInterfaceInBattle(Enemy enemy)
        {
            UpdateScene(GeneratePicture(enemy.schematic));
            LoadUserInterfaceInBattle(enemy);
        }

        private void StartFight(Enemy enemy)
        {
            Random rnd = new Random();
            do
            {
                //Spelarens tur
                
                if (FightMenu().Equals("FIGHT"))
                {
                    int atk = rnd.Next(1, player.strength);
                    atk += player.strength;
                    enemy.healthPoints = enemy.healthPoints - atk;
                }
                else
                {
                    Environment.Exit(0);
                }
                //Enemys tur
                int enemyAtk = rnd.Next(1, enemy.strength);
                enemyAtk += enemy.strength;
                player.healthPoints = player.healthPoints - enemyAtk;
                UpdateUserInterfaceInBattle(enemy);
            } while (player.healthPoints > 1 || enemy.healthPoints > 1);
            if(enemy.healthPoints < 1)
            {
                UpdateScene(GeneratePicture(victoryMsg));
                inBattle = false;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private string FightMenu()
        {
            Console.WriteLine($"COMMANDS: FIGHT");
            string cmd;
            do
            {
                //Console.Write(">");
                cmd = Console.ReadLine();
            } while (!cmd.Equals("FIGHT"));
            return cmd;
            //if(cmd == "FIGHT")
            //{

            //    return "FIGHT";
                
            //}

        }

        //private Dictionary<Point, string> GenerateGoblin()
        //{
        //    List<Point> pointList = new List<Point>();
        //    for (int y = 0; y < 11; y++)
        //    {
        //        for (int x = 0; x < 22; x++)
        //        {
        //            Point point = new Point(x, y);
        //            pointList.Add(point);
        //        }
        //    }
        //    Dictionary<Point, string> goblin = new Dictionary<Point, string>();
        //    //First row
        //    for (int i = 0; i < 23; i++)
        //    {
        //        if(i == 9 || i == 16)
        //        {
        //            goblin.Add(pointList[i], ",");
        //        }
        //        else
        //        {
        //            goblin.Add(pointList[i], " ");
        //        }
        //    }
        //    //Second Row
        //    for (int i = 24; i < 45; i++)
        //    {
        //        if(i == 30)
        //        {
        //            goblin.Add(pointList[i], "/");
        //        }else if(i == 31)
        //        {
        //            goblin.Add(pointList[i], "(");
        //        }else if(i == 32)
        //        {
        //            goblin.Add(pointList[i], ".");
        //        }else if(i == 33)
        //        {
        //            goblin.Add(pointList[i], "-");
        //        }else if(i == 34)
        //        {
        //            goblin.Add(pointList[i], "\"");
        //        }else if(i == 35)
        //        {
        //            goblin.Add(pointList[i], "\"");
        //        }else if(i == 36)
        //        {
        //            goblin.Add(pointList[i], "-");
        //        }else if(i == 37)
        //        {
        //            goblin.Add(pointList[i], ".");
        //        }else if(i == 38)
        //        {
        //            goblin.Add(pointList[i], ")");
        //        }else if(i == 39)
        //        {
        //            goblin.Add(pointList[i], "\\");
        //        }
        //        else
        //        {
        //            goblin.Add(pointList[i], " ");
        //        }
        //    }

        //    return goblin;

        //}


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

// Sjyssta bilder på saker: https://www.asciiart.eu/animals/frogs
//Meddelandegenerator: https://www.patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20



namespace Game
{
    class Program
    {
        bool inBattle = false;
        string[,] scene =
{               //74x15
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " }
            };

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

        string[,] defeatMsg =
        {
            /*1*/{"_","_","_","_","_","_","_","_"," "," "," "," "," "," "," "," "," "," ","_","_","_","_","_"," "," "," "," "," "," "," "," "," "," "," "," "," "," ","_","_"," "," ",".","_","." },
            /*2*/{"\\","_","_","_","_","_","_"," ","\\"," "," "," ","_","_","_","_","_","/"," ","_","_","_","_","\\","_","_","_","_"," ","_","_","_","_","_"," ","_","/"," "," ","|","_","|"," ","|"},
            /*3*/{" ","|"," "," "," "," ","|"," "," ","\\","_","/"," ","_","_"," ","\\"," "," "," ","_","_","\\","/"," ","_","_"," ","\\","\\","_","_"," "," ","\\","\\"," "," "," ","_","_","\\"," ","|"},
            /*4*/{" ","|"," "," "," "," ","`"," "," "," ","\\"," "," ","_","_","_","/","|"," "," ","|"," ","\\"," "," ","_","_","_","/"," ","/"," ","_","_"," ","\\","|"," "," ","|"," "," ","\\","|" },
            /*5*/{"/","_","_","_","_","_","_","_"," "," ","/","\\","_","_","_"," "," ",">","_","_","|"," "," ","\\","_","_","_"," "," ",">","_","_","_","_"," "," ","/","_","_","|"," "," ","_","_" },
            /*6*/{" "," "," "," "," "," "," "," ","\\","/"," "," "," "," "," ","\\","/"," "," "," "," "," "," "," "," "," "," ","\\","/"," "," "," "," "," ","\\","/"," "," "," "," "," "," ","\\","/" }
        };

        //DEFEAT MESSAGE
        //1________          _____              __  ._.
        //2\______ \   _____/ ____\____ _____ _/  |_| |
        //3 |    |  \_/ __ \   __\/ __ \\__  \\   __\ |
        //4 |    `   \  ___/|  | \  ___/ / __ \|  |  \|
        //5/_______  /\___  >__|  \___  >____  /__|  __
        //6        \/     \/          \/     \/      \/


        string[,] gameOverMsg =
        {
            /*1*/{" "," "," "," "," "," "," "," "," ","_","_","_","_","_","_","_","_"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","_","_","_","_","_","_","_","_"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",".","_","." },
            /*2*/{" "," "," "," "," "," "," "," ","/"," "," ","_","_","_","_","_","/","_","_","_","_","_"," "," "," "," ","_","_","_","_","_"," "," "," ","_","_","_","_"," "," ","\\","_","_","_","_","_"," "," ","\\","_","_","_"," "," ","_","_"," ","_","_","_","_","_","_","_","_","_","_","_","|"," ","|"},
            /*3*/{" "," "," "," "," "," "," ","/"," "," "," ","\\"," "," ","_","_","_","\\","_","_"," "," ","\\"," "," ","/"," "," "," "," "," ","\\","_","/"," ","_","_"," ","\\"," "," ","/"," "," "," ","|"," "," "," ","\\"," "," ","\\","/"," ","/","/"," ","_","_"," ","\\","_"," "," ","_","_"," ","\\"," ","|" },
            /*4*/{" "," "," "," "," "," "," ","\\"," "," "," "," ","\\","_","\\"," "," ","\\","/"," ","_","_"," ","\\","|"," "," ","Y"," ","Y"," "," ","\\"," "," ","_","_","_","/"," ","/"," "," "," "," ","|"," "," "," "," ","\\"," "," "," ","/","\\"," "," ","_","_","_","/","|"," "," ","|"," ","\\","/","\\","|" },
            /*5*/{" "," "," "," "," "," "," "," ","\\","_","_","_","_","_","_"," "," ","(","_","_","_","_"," "," ","/","_","_","|","_","|"," "," ","/","\\","_","_","_"," "," ",">","\\","_","_","_","_","_","_","_"," "," ","/","\\","_","/"," "," ","\\","_","_","_"," "," ",">","_","_","|"," "," "," ","_","_" },
            /*6*/{" "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","\\","/"," "," "," "," "," ","\\","/"," "," "," "," "," "," ","\\","/"," "," "," "," "," ","\\","/"," "," "," "," "," "," "," "," "," ","\\","/"," "," "," "," "," "," "," "," "," "," ","\\","/"," "," "," "," "," "," "," ","\\","/" }
        };

        //GAME OVER MESSAGE
        //1         ________                       ________                    ._.
        //2        /  _____/_____    _____   ____  \_____  \___  __ ___________| |
        //3       /   \  ___\__  \  /     \_/ __ \  /   |   \  \/ // __ \_  __ \ |
        //4       \    \_\  \/ __ \|  Y Y  \  ___/ /    |    \   /\  ___/|  | \/\|
        //5        \______  (____  /__|_|  /\___  >\_______  /\_/  \___  >__|   __
        //6               \/     \/      \/     \/         \/          \/       \/




        
        Player player;

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.StartGame();
            prog.LoadMenu();
            //prog.NewGame();
            //prog.LoadFight();
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
            Console.WriteLine("FGT: Fight mode - survive as many battles as possible!");
            Console.WriteLine("LD: Load Game");
            Console.WriteLine("EXT: Exit Game");
            do
            {
                //Console.Write(">");
                cmd = Console.ReadLine();
            } while (!cmd.Equals("NEW") && !cmd.Equals("LD") && !cmd.Equals("EXT") && !cmd.Equals("FGT"));

            if (cmd.Equals("NEW"))
            {
                NewGame();
            }else if (cmd.Equals("LD"))
            {
                LoadGame();
            }else if (cmd.Equals("FGT"))
            {
                StartFightMode();
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

        private void LoadGame()//Ej implementerad ännu
        {
            Console.WriteLine("Spel laddas.");
            Console.ReadLine();
        }

        private void NewGame()
        {
            player = CreateNewPlayer();
            Console.Clear();
            LoadUserInterfaceOutOfBattle("");
        }

        private void PrintScene(string[,] newUi)//Tar en 2d-Array!
        {
            //Skriver ut den mottagna 2D-arrayen i konsolen.
            Console.Clear();
            for (int y = 0; y < newUi.GetLength(0); y++)
            {
                for (int x = 0; x < newUi.GetLength(1) - 1; x++)
                {
                    Point currentPoint = new Point(x, y);
                    Console.Write(newUi[y, x]);
                }
                Console.WriteLine();
            }
            //if (!inBattle)
            //    LoadUserInterfaceOutOfBattle("");
        }



        private void PrintScene(string[,] newUi, Enemy enemy)//Tar en 2d-Array!
        {
            //Skriver ut den mottagna 2D-arrayen i konsolen.
            Console.Clear();
            for (int y = 0; y < newUi.GetLength(0); y++)
            {
                for (int x = 0; x < newUi.GetLength(1) - 1; x++)
                {
                    Point currentPoint = new Point(x, y);
                    Console.Write(newUi[y, x]);
                }
                Console.WriteLine();
            }
            if(inBattle)
                LoadUserInterfaceInBattle(enemy);
        }

        private void PrintScene(string[,] newUi, Enemy enemy, string msg)//Tar en 2d-Array!
        {
            //Skriver ut den mottagna 2D-arrayen i konsolen.
            Console.Clear();
            for (int y = 0; y < newUi.GetLength(0); y++)
            {
                for (int x = 0; x < newUi.GetLength(1) - 1; x++)
                {
                    Point currentPoint = new Point(x, y);
                    Console.Write(newUi[y, x]);
                }
                Console.WriteLine();
            }
            if (inBattle)
                LoadUserInterfaceInBattle(enemy, msg);
        }

        private void ClearScene()//DONE! Skriver ut den tomma original-arrayen.
        {
            Console.Clear();
            for (int y = 0; y < scene.GetLength(0); y++)
            {
                for (int x = 0; x < scene.GetLength(1) - 1; x++)
                {
                    Point currentPoint = new Point(x, y);
                    Console.Write(scene[y, x]);
                }
                Console.WriteLine();
            }
            //if (!inBattle)
            //    LoadUserInterfaceOutOfBattle("");

        }

        private void LoadUserInterfaceOutOfBattle(string msg)
        {
            Console.WriteLine($" {msg}                                                           ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"{player.name}");
            Console.WriteLine($"Health: {player.healthPoints}   Strength: {player.strength} ");
            Console.WriteLine($"Weapon: {player.healthPoints}   Armor: {player.strength}    ");
        }

        private void LoadUserInterfaceInBattle(Enemy enemy)
        {
            Console.WriteLine($"                                                            ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"{player.name}                       Enemy: {enemy.name}");
            Console.WriteLine($"Health: {player.healthPoints}   Strength: {player.strength}   Enemyhealth: {enemy.healthPoints} ");
            Console.WriteLine($"Weapon: {player.healthPoints}   Armor: {player.strength}      Enemystrength: {enemy.strength}    ");
        }

        private void LoadUserInterfaceInBattle(Enemy enemy, string msg)
        {
            Console.WriteLine($"  {msg}                                                          ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"{player.name}                       Enemy: {enemy.name}");
            Console.WriteLine($"Health: {player.healthPoints}   Strength: {player.strength}   Enemyhealth: {enemy.healthPoints} ");
            Console.WriteLine($"Weapon: {player.healthPoints}   Armor: {player.strength}      Enemystrength: {enemy.strength}    ");
        }

        private void UpdateUserInterfaceInBattle(Enemy enemy, string msg)//UPDATE - LADDAR ÄVEN OM SCENE
        {
            PrintScene(CreateScene(GeneratePicture(enemy.schematic)), enemy, msg);
        }

        private static Player CreateNewPlayer()//Lägg in checkar som kollar namnet
        {
            Console.Clear();
            Console.WriteLine("Vad heter din karaktär?");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            return player;
        }

        private string[,] CreateScene(Dictionary<Point, string> schematic)
        {
            //Kopierar orig. arrayen.
            var newUi = new string[scene.GetLength(0), scene.GetLength(1)];
            newUi = scene.Clone() as string[,];

            //Skriver ut dictionaryn på en kopierad scene.
            foreach (KeyValuePair<Point, string> item in schematic)
            {
                newUi[item.Key.Y, item.Key.X] = item.Value;
            }
            //LoadScene(newUi);
            return newUi;
        }

        private Dictionary<Point,string> GeneratePicture(string[,] schematic)
        {
            int x2 = (((75 - schematic.GetLength(1)) / 2) + schematic.GetLength(1));
            Dictionary<Point, string> dictionarySchematic = new Dictionary<Point, string>();
            for (int y = 0; y < schematic.GetLength(0); y++)
            {
                for (int x = ((75 - schematic.GetLength(1)) / 2); x < x2; x++)
                {
                    Point point = new Point(x, y);
                    dictionarySchematic.Add(point, schematic[y, (x- ((75 - schematic.GetLength(1)) / 2))]);
                }
            }
            return dictionarySchematic;
        }

        private void LoadFight(Enemy enemy)
        {
            inBattle = true;
            //Goblin enemy = new Goblin("Goblin");
            //Frog enemy = new Frog("Frog");
            //SpiderSwarm enemy = new SpiderSwarm("Spider Swarm");
            PrintScene(CreateScene(GeneratePicture(enemy.schematic)), enemy);
            StartFight(enemy);

        }




        private void StartFight(Enemy enemy)
        {
            Random rnd = new Random();
            UpdateUserInterfaceInBattle(enemy, $"A wild {enemy.name} appears!");
            System.Threading.Thread.Sleep(2000);

            do
            {
                UpdateUserInterfaceInBattle(enemy, $"{player.name}s turn!");
                //Player turn
                if (FightMenu().Equals("FIGHT"))
                {
                    int atk = rnd.Next(1, player.strength);
                    atk += player.strength;
                    if(rnd.Next(1,100) < enemy.agility)
                    {
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        System.Threading.Thread.Sleep(1000);
                        UpdateUserInterfaceInBattle(enemy, $"{player.name}s attack misses!");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        enemy.healthPoints = enemy.healthPoints - atk;
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        System.Threading.Thread.Sleep(1000);
                        UpdateUserInterfaceInBattle(enemy, $"{enemy.name} suffers {atk} damage!");
                        System.Threading.Thread.Sleep(2000);
                    }


                }
                else
                {
                    Environment.Exit(0);
                }
                //Enemy turn
                if(enemy.healthPoints > 1)
                {
                    UpdateUserInterfaceInBattle(enemy, $"{enemy.name} strikes back!");
                    System.Threading.Thread.Sleep(2000);
                    int enemyAtk = rnd.Next(1, enemy.strength);
                    enemyAtk += enemy.strength;
                    player.healthPoints = player.healthPoints - enemyAtk;
                    UpdateUserInterfaceInBattle(enemy, $"{player.name} suffers {enemyAtk} damage!");
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    //inget görs.
                }

            } while (player.healthPoints > 1 && enemy.healthPoints > 1);

            if(enemy.healthPoints < 1)
            {
                PrintScene(CreateScene(GeneratePicture(victoryMsg)), enemy);
                System.Threading.Thread.Sleep(3000);
                inBattle = false;
            }
            else
            {
                PrintScene(CreateScene(GeneratePicture(defeatMsg)), enemy);
                System.Threading.Thread.Sleep(3000);
            }
        }

        private string FightMenu()
        {
            Console.WriteLine($"COMMANDS: FIGHT");
            string cmd;
            do
            {
                cmd = Console.ReadLine();
            } while (!cmd.Equals("FIGHT"));
            return cmd;
        }

        private void StartFightMode()
        {
            int victories = 0;
            player = CreateNewPlayer();
            Random rnd = new Random();
            
            do
            {
                LoadFight(GenerateFightModeEnemyList().ElementAt(rnd.Next(0,3)));
                victories++;
            } while (player.healthPoints > 0);
            ClearScene();
            PrintScene(CreateScene(GeneratePicture(gameOverMsg)));
            if (victories > 1)
            {
                LoadUserInterfaceOutOfBattle($"Du lyckades döda {victories} fiender!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
                LoadMenu();
            }

            else
            {
                LoadUserInterfaceOutOfBattle($"Du lyckades döda {victories} fiende!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
                LoadMenu();
            }
                
        }

        private List<Enemy> GenerateFightModeEnemyList()
        {
            Goblin goblin = new Goblin("Goblin");
            Frog frog = new Frog("Frog");
            SpiderSwarm spiderSwarm = new SpiderSwarm("Spider Swarm");
            List<Enemy> enemyList = new List<Enemy>();
            enemyList.Add(goblin);
            enemyList.Add(frog);
            enemyList.Add(spiderSwarm);
            return enemyList;
        }
    }
}

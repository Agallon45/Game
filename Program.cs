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
        public bool inBattle = false;

        Player player;
        public static Program prog;
        public static SceneHandler sceneHandler;
        public static MessageHandler msgHandler;
        public static bool isRunning = true;

        static void Main(string[] args)
        {
            do
            {

                prog = new Program();
                sceneHandler = new SceneHandler();
                msgHandler = new MessageHandler();
                prog.StartGame();
                //---------------------TESTAREA-------------------------------------------------------------
                //SAKER SOM BEHÖVS FÖR TEST AV DET MESTA:
                //Warrior player = new Warrior("Zav");
                //TESTA STORE:
                //StoreHandler storeHandler = new StoreHandler("store");
                //Store store = storeHandler.CreateStore();
                //player.coin = 200;
                //store.PrintStore(player);
                //player.OpenInventory();
                //TESTA BILDER:
                //Dragon dragon = new Dragon("Dragon");
                //Aardvark aardvark = new Aardvark("Aard");
                //Ant ant = new Ant("Ant");
                //Bear bear = new Bear("Bear");
                //Castle castle = new Castle("Castle");
                //Cow cow = new Cow("Cow");
                //Griffin griffin = new Griffin("Griffin");
                //Knight knight = new Knight("Knight");
                //Moose knight = new Moose("Moose");
                //Snake knight = new Snake("Snake");
                //Fight fight = new Fight(knight, player,sceneHandler, prog, msgHandler, true, 0);
                //fight.UpdateUserInterfaceInBattle(knight, $"A wild {knight.name} appears!");
                //Console.ReadKey();
                //---------------------------------------------------------------------------------------
                prog.LoadMenu();
            } while (isRunning);

        }

        private void StartGame()
        {
            sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(msgHandler.title), true));
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true);


        }

        public void LoadMenu()
        {
            string cmd;
            Console.Clear();
            sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(msgHandler.title), true));
            Console.WriteLine("Enter a command");
            Console.WriteLine("[NEW]: New game - Not yet implemented!");
            Console.WriteLine("[FGT]: Fight mode - survive as many battles as possible!");
            Console.WriteLine("[LD]: Load Game - Not yet Implemented!");
            Console.WriteLine("[EXT]: Exit Game");
            do
            {
                cmd = Console.ReadLine().ToLower();
            } while (!cmd.Equals("new") && !cmd.Equals("ld") && !cmd.Equals("ext") && !cmd.Equals("fgt"));

            if (cmd.Equals("new"))
            {
                NewGame();//Inte implementerat
            }else if (cmd.Equals("ld"))
            {
                LoadGame();//Inte implementerat
            }else if (cmd.Equals("fgt"))
            {
                FightMode fightMode = new FightMode();
                player = CreateNewPlayer();
                fightMode.StartFightMode(player, prog, msgHandler.gameOverMsg, sceneHandler, inBattle, msgHandler);
            }
            else
            {
                ExitGame();
            }

        }

        private static Player CreateNewPlayer()//Lägg in checkar som kollar namnet
        {
            Console.Clear();
            Console.WriteLine("Vad heter din karaktär?");
            string playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Välj klass");
            Console.WriteLine("[WARRIOR]");
            Console.WriteLine("[ROGUE]");
            Console.WriteLine("[PALADIN]");
            string classChoice;
            do
            {
                classChoice = Console.ReadLine().ToLower();
            } while (!classChoice.Equals("warrior") && !classChoice.Equals("rogue") && !classChoice.Equals("paladin"));

            if (classChoice.Equals("warrior"))
            {
                Warrior player = new Warrior(playerName);
                return player;
            }
            else if (classChoice.Equals("rogue"))
            {
                Rogue player = new Rogue(playerName);
                return player;
            }
            else//Paladin just nu
            {
                Paladin player = new Paladin(playerName);
                return player;
            }
        }

        private static void ExitGame()
        {
            isRunning = false;
            //Environment.Exit(0);
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

        public void LoadUserInterfaceOutOfBattle(string msg)
        {
            Console.WriteLine($" {msg}                                                           ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"***************************************************************************");
            Console.WriteLine($"***************************************************************************");
            Console.WriteLine($"PLAYER {player.name}");
            Console.WriteLine($"{player.playerClass} LVL: {player.lvl} Health: {player.CurrentHealthPoints}/{player.maxHealthPoints} Agility: {player.Agility} Strength: {player.Strength} Intellect: {player.Intellect} Armor: {player.Armor} ");
        }
    }
}

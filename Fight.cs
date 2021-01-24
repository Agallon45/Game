using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Fight
    {
        public int roundNum;
        public Enemy enemy;
        public Player player;
        public SceneHandler sceneHandler;
        public Program prog;
        public bool inBattle;
        public MessageHandler msgHandler;
        public int victories;

        public Fight(Enemy enemy, Player player, SceneHandler sceneHandler, Program prog, MessageHandler msgHandler, bool inBattle, int victories)
        {
            this.enemy = enemy;
            this.player = player;
            this.sceneHandler = sceneHandler;
            this.prog = prog;
            this.msgHandler = msgHandler;
            this.inBattle = inBattle;
            this.victories = victories;

        }

        public void UpdateUserInterfaceInBattle(Enemy enemy, string msg)//UPDATE - LADDAR ÄVEN OM SCENE
        {
            sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(enemy.schematic), false), enemy, msg);
            LoadUserInterfaceInBattle(enemy, msg);
        }

        public void LoadUserInterfaceInBattle(Enemy enemy, string msg)
        {
            Console.WriteLine($"  {msg}                                                          ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"ENEMY: {enemy.name}                                 NUMBER OF VICTORIES: {victories}");
            Console.WriteLine($"HP: {enemy.currentHealthPoints}/{enemy.maxHealthPoints}  ");
            Console.WriteLine($"PLAYER {player.name}");
            Console.WriteLine($"{player.playerClass} LVL: {player.lvl} Health: {player.currentHealthPoints}/{player.maxHealthPoints} Agility: {player.agility} Strength: {player.strength} Intellect: {player.intellect} Armor: {player.armor} ");
        }

        public void LoadUserInterfaceInBattle(Enemy enemy)
        {
            Console.WriteLine($"                                                            ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"ENEMY: {enemy.name}                                 NUMBER OF VICTORIES: {victories}");
            Console.WriteLine($"HP: {enemy.currentHealthPoints}/{enemy.maxHealthPoints}   ");
            Console.WriteLine($"PLAYER {player.name}");
            Console.WriteLine($"{player.playerClass} LVL: {player.lvl} Health: {player.currentHealthPoints}/{player.maxHealthPoints} Agility: {player.agility} Strength: {player.strength} Intellect: {player.intellect} Armor: {player.armor} ");
        }

        public void StartFight()
        {
            Random rnd = new Random();
            roundNum = 0;
            
            UpdateUserInterfaceInBattle(enemy, $"A wild {enemy.name} appears!");
            System.Threading.Thread.Sleep(2000);
            while (player.currentHealthPoints > 0 && enemy.currentHealthPoints > 0)
            {
                RemoveBuffs();
                roundNum++;
                player.roundNum = roundNum;
                enemy.roundNum = roundNum;
                if (player.agility > enemy.agility)
                {
                    PlayerTurn(roundNum);
                    if(enemy.currentHealthPoints > 0)
                        EnemyTurn(roundNum);
                }
                else
                {
                    EnemyTurn(roundNum);
                    if (player.currentHealthPoints > 0)
                        PlayerTurn(roundNum);
                }
            }
            RemoveBuffsAtEndOfRound();
            if(enemy.currentHealthPoints < 1)
            {
                UpdateUserInterfaceInBattle(enemy, player.AddExperienceAndCoin(enemy));
                System.Threading.Thread.Sleep(3000);
                sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(msgHandler.victoryMsg), false), enemy);
                System.Threading.Thread.Sleep(3000);
                inBattle = false;
            }
            else
            {
                sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(msgHandler.defeatMsg), false), enemy);
                System.Threading.Thread.Sleep(3000);
            }
        }

        private void RemoveBuffs()
        {
            if (player.buffed)
            {
                if(roundNum == player.roundNumRemove)
                {
                    UpdateUserInterfaceInBattle(enemy, player.RemoveBuff());
                    System.Threading.Thread.Sleep(2000);
                }
            }

        }

        private void RemoveBuffsAtEndOfRound()
        {
            if (player.buffed)
            {
                UpdateUserInterfaceInBattle(enemy, player.RemoveBuff());
                System.Threading.Thread.Sleep(2000);
            }
        }

        public void PlayerTurn(int roundNum)
        {
            UpdateUserInterfaceInBattle(enemy, $"{player.name}s turn!");
            string cmd = FightMenu();
            if(cmd == null)
                PlayerTurn(roundNum);

            switch (cmd)
            {
                case "FIGHT":
                    UpdateUserInterfaceInBattle(enemy, $"");
                    UpdateUserInterfaceInBattle(enemy, $"");
                    UpdateUserInterfaceInBattle(enemy, $"");
                    System.Threading.Thread.Sleep(1000);
                    UpdateUserInterfaceInBattle(enemy, player.Attack(enemy));
                    System.Threading.Thread.Sleep(2000);
                    break;
                case "ITEMS":
                    player.OpenInventory();
                    PlayerTurn(roundNum);
                    break;
                case "DEFEND":
                    UpdateUserInterfaceInBattle(enemy, player.Defend());
                    System.Threading.Thread.Sleep(2000);
                    break;
                case "DODGE":
                    UpdateUserInterfaceInBattle(enemy, player.Dodge());
                    System.Threading.Thread.Sleep(2000);
                    break;
                case "HEAL":
                    UpdateUserInterfaceInBattle(enemy, player.Heal());
                    System.Threading.Thread.Sleep(2000);
                    break;
                case "BLESS":
                    UpdateUserInterfaceInBattle(enemy, player.Bless());
                    System.Threading.Thread.Sleep(2000);
                    break;
                case "INTIMIDATING SHOUT":
                    UpdateUserInterfaceInBattle(enemy, player.IntimidatingShout(enemy));
                    System.Threading.Thread.Sleep(3000);
                    break;
                case "SWIFT THINKING":
                    UpdateUserInterfaceInBattle(enemy, player.SwiftThinking());
                    System.Threading.Thread.Sleep(3000);
                    PlayerTurn(roundNum);
                    PlayerTurn(roundNum);
                    
                    break;
            }

        }

        public void EnemyTurn(int roundNum)
        {
            UpdateUserInterfaceInBattle(enemy, $"{enemy.name} strikes!");
            System.Threading.Thread.Sleep(2000);
            UpdateUserInterfaceInBattle(enemy, enemy.Attack(player));
            System.Threading.Thread.Sleep(3000);

        }

        private string FightMenu()
        {
            bool isRunning = true;
            do
            {
                try
                {

                
                string cmd2;
                int cmd;
                do
                {
                    foreach (KeyValuePair<int, string> comm in player.commands)
                    {
                        Console.Write($"{comm.Key}.[{comm.Value}] ");
                    }
                    cmd2 = Console.ReadLine();
                } while (!int.TryParse(cmd2, out cmd) && !player.commands.ContainsKey(cmd));
                isRunning = false;
                return player.commands[cmd];
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Not a command. X");
                    Console.ReadKey(true);
                }
                return null;
            } while (isRunning);
        }










    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Fight
    {
        public int roundNum;
       static public Enemy enemy;
        static public Player player;
        public SceneHandler sceneHandler;
        public Program prog;
        public bool inBattle;
        public MessageHandler msgHandler;
       static public int victories;

        public Fight(Enemy Enemy, Player Player, SceneHandler sceneHandler, Program prog, MessageHandler msgHandler, bool inBattle, int Victories)
        {
            enemy = Enemy;
            player = Player;
            this.sceneHandler = sceneHandler;
            this.prog = prog;
            this.msgHandler = msgHandler;
            this.inBattle = inBattle;
            victories = Victories;

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
            Console.WriteLine($"HP: {enemy.CurrentHealthPoints}/{enemy.maxHealthPoints}  ");
            Console.WriteLine($"PLAYER {player.name}");
            Console.WriteLine($"{player.playerClass} LVL: {player.lvl} Health: {player.CurrentHealthPoints}/{player.maxHealthPoints} Agility: {player.Agility} Strength: {player.Strength} Intellect: {player.Intellect} Armor: {player.Armor} ");
        }

        public void LoadUserInterfaceInBattle(Enemy enemy)
        {
            Console.WriteLine($"                                                            ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"ENEMY: {enemy.name}                                 NUMBER OF VICTORIES: {victories}");
            Console.WriteLine($"HP: {enemy.CurrentHealthPoints}/{enemy.maxHealthPoints}   ");
            Console.WriteLine($"PLAYER {player.name}");
            Console.WriteLine($"{player.playerClass} LVL: {player.lvl} Health: {player.CurrentHealthPoints}/{player.maxHealthPoints} Agility: {player.Agility} Strength: {player.Strength} Intellect: {player.Intellect} Armor: {player.Armor} ");
        }

        public static void LoadUserInterfaceInBattle(string msg)
        {
            Console.WriteLine($"                                                            ");
            Console.WriteLine($"___________________________________________________________________________");
            Console.WriteLine($"ENEMY: {enemy.name}                                 NUMBER OF VICTORIES: {victories}");
            Console.WriteLine($"HP: {enemy.CurrentHealthPoints}/{enemy.maxHealthPoints}   ");
            Console.WriteLine($"PLAYER {player.name}");
            Console.WriteLine($"{player.playerClass} LVL: {player.lvl} Health: {player.CurrentHealthPoints}/{player.maxHealthPoints} Agility: {player.Agility} Strength: {player.Strength} Intellect: {player.Intellect} Armor: {player.Armor} ");
        }

        public void StartFight()
        {
            Random rnd = new Random();
            roundNum = 0;
            
            UpdateUserInterfaceInBattle(enemy, $"A wild {enemy.name} appears!");
            System.Threading.Thread.Sleep(2000);
            while (player.CurrentHealthPoints > 0 && enemy.CurrentHealthPoints > 0)
            {
                RemoveBuffs();
                roundNum++;
                player.roundNum = roundNum;
                enemy.roundNum = roundNum;
                if (enemy.CurrentHealthPoints < 1)
                {
                    UpdateUserInterfaceInBattle(enemy, player.AddExperienceAndCoin(enemy));
                    System.Threading.Thread.Sleep(3000);
                    sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(msgHandler.victoryMsg), false), enemy);
                    System.Threading.Thread.Sleep(3000);
                    inBattle = false;
                }
                if (player.initiative > enemy.initiative)
                {
                    PlayerTurn(roundNum);
                    if(enemy.CurrentHealthPoints > 0)
                        EnemyTurn(roundNum);
                }
                else
                {
                    EnemyTurn(roundNum);
                    if (player.CurrentHealthPoints > 0)
                        PlayerTurn(roundNum);
                }
            }
            RemoveBuffsAtEndOfRound();
            if(player is Warrior)
            {
                if (player.defended)
                {
                    player.Armor -= player.armorBuff;
                    player.defended = false;
                }
            }
            if(player is Rogue)
            {
                player.Strength += player.strengthLoss;
                player.strengthLoss = 0;
            }
            if(enemy.CurrentHealthPoints < 1)
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
            UpdateUserInterfaceInBattle(enemy, player.RemoveBuff());
            System.Threading.Thread.Sleep(2000);
            if (player.isDotted)
            {
                UpdateUserInterfaceInBattle(enemy, $"{player.name} suffers {player.dot} damage!");
                System.Threading.Thread.Sleep(2000);
                player.CurrentHealthPoints -= player.dot;
                
                if (roundNum == player.roundNumRemove)
                {

                    player.roundNumRemove = 0;
                    player.dot = 0;
                    player.Agility += player.negAgility;
                    player.isDotted = false;
                    UpdateUserInterfaceInBattle(enemy, $"{player.name} no longer suffers periodic damage.");
                    System.Threading.Thread.Sleep(2000);
                }

            }
            if (enemy.isDotted)
            {
                UpdateUserInterfaceInBattle(enemy, $"{enemy.name} suffers {enemy.dot} damage!");
                System.Threading.Thread.Sleep(2000);
                enemy.CurrentHealthPoints -= player.dot;
            }
            if (enemy.buffed || enemy.debuffed)
            {
                UpdateUserInterfaceInBattle(enemy, enemy.RemoveBuffs());
                System.Threading.Thread.Sleep(2000);
                if (roundNum == enemy.roundNumRemove)
                {

                    player.roundNumRemove = 0;
                    player.dot = 0;
                    player.Agility += player.negAgility;
                    player.isDotted = false;
                    UpdateUserInterfaceInBattle(enemy, $"{enemy.name} no longer suffers periodic damage.");
                    System.Threading.Thread.Sleep(2000);
                }
            }

            if (player.debuffed)
            {
                if(roundNum == player.roundNumRemove)
                {
                    player.Strength += player.negStrength;
                    player.negStrength = 0;
                    player.Agility += player.negAgility;
                    player.negAgility = 0;
                    player.Intellect += player.negIntellect;
                    player.negIntellect = 0;
                    player.maxHealthPoints += player.negHealth;
                    player.negHealth = 0;
                    player.Armor += player.negArmor;
                    player.negArmor = 0;
                    player.roundNumRemove = 0;
                    player.debuffed = false;
                }
            }
            if (player.buffed)
            {
                if (roundNum == player.roundNumRemove)
                {
                    player.Strength -= player.posStrength;
                    player.posStrength = 0;
                    player.Agility -= player.posAgility;
                    player.posAgility = 0;
                    player.Intellect -= player.posIntellect;
                    player.posIntellect = 0;
                    player.Armor -= player.posArmor;
                    player.posArmor = 0;
                    player.roundNumRemove = 0;
                    player.buffed = false;
                }
            }

            if (player.blessed)
            {
                if(roundNum == player.roundNumRemove)
                {
                    player.blessed = false;
                    player.Strength -= player.posStrength;
                    player.Intellect -= player.posIntellect;
                    player.Agility -= player.posAgility;
                    player.Armor -= player.posArmor;
                    player.posStrength = 0;
                    player.posIntellect = 0;
                    player.posAgility = 0;
                    player.posArmor = 0;
                }
            }
            

        }

        private void RemoveBuffsAtEndOfRound()
        {
            //if (player.buffed)
            //{
                UpdateUserInterfaceInBattle(enemy, player.RemoveBuff());
                System.Threading.Thread.Sleep(2000);
            //}
            player.Strength += player.negStrength;
            player.negStrength = 0;
            player.Agility += player.negAgility;
            player.negAgility = 0;
            player.Intellect += player.negIntellect;
            player.negIntellect = 0;
            player.maxHealthPoints += player.negHealth;
            player.negHealth = 0;
            player.Armor += player.negArmor;
            player.negArmor = 0;

            //player.Strength -= player.posStrength;
            //player.posStrength = 0;
            //player.Agility -= player.posAgility;
            //player.posAgility = 0;
            //player.Intellect -= player.posIntellect;
            //player.posIntellect = 0;
            //player.maxHealthPoints -= player.posHealth;
            //player.posHealth = 0;
            //player.Armor -= player.posArmor;
            //player.posArmor = 0;
            if (player.blessed)
            {
                player.blessed = false;
                player.Strength -= player.posStrength;
                player.Intellect -= player.posIntellect;
                player.Agility -= player.posAgility;
                player.Armor -= player.posArmor;
                player.posStrength = 0;
                player.posIntellect = 0;
                player.posAgility = 0;
                player.posArmor = 0;
            }
    }

        public void PlayerTurn(int roundNum)
        {
            if (player.hasJumped)
            {
                UpdateUserInterfaceInBattle(enemy, $"");
                UpdateUserInterfaceInBattle(enemy, $"");
                UpdateUserInterfaceInBattle(enemy, player.Jump(enemy));
                System.Threading.Thread.Sleep(3000);
            }
            else
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
                    if (player.buffed)
                    {
                        UpdateUserInterfaceInBattle(enemy, " You are already blessed!");
                        System.Threading.Thread.Sleep(2000);
                        PlayerTurn(roundNum);
                    }
                    else
                    {
                        UpdateUserInterfaceInBattle(enemy, player.Bless());
                        System.Threading.Thread.Sleep(2000);
                    }
                    break;
                case "AGITATING SHOUT":
                    UpdateUserInterfaceInBattle(enemy, player.AgitatingShout(enemy));
                    System.Threading.Thread.Sleep(3000);
                    break;
                case "SWIFT THINKING":
                    UpdateUserInterfaceInBattle(enemy, player.SwiftThinking());
                    System.Threading.Thread.Sleep(3000);
                    PlayerTurn(roundNum);
                    PlayerTurn(roundNum);
                    break;
                case "ARMORING DEFENSE":
                    UpdateUserInterfaceInBattle(enemy, player.ArmoringDefense());
                    System.Threading.Thread.Sleep(3000);
                    break;
                case "FLEX":
                    UpdateUserInterfaceInBattle(enemy, player.Flex());
                    System.Threading.Thread.Sleep(3000);
                    break;
                case "QUICK REFLEXES":
                    UpdateUserInterfaceInBattle(enemy, player.QuickReflexes());
                    System.Threading.Thread.Sleep(3000);
                    break;
                case "DAMNING GLARE":
                    UpdateUserInterfaceInBattle(enemy, player.DamningGlare(enemy));
                    System.Threading.Thread.Sleep(2000);
                    break;
                case "FLARE":
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, player.Flare(enemy));
                     System.Threading.Thread.Sleep(2000);
                     break;
                case "BOOKSMARTS":
                        UpdateUserInterfaceInBattle(enemy, player.BookSmarts());
                        System.Threading.Thread.Sleep(3000);
                        break;
                case "JUMP":
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, player.Jump(enemy));
                        System.Threading.Thread.Sleep(3000);
                        break;
                case "SCARE":
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, player.Scare(enemy));
                        System.Threading.Thread.Sleep(3000);
                        break;
                case "BAMBOOZLE":
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, $"");
                        UpdateUserInterfaceInBattle(enemy, player.Bamboozle(enemy));
                        System.Threading.Thread.Sleep(3000);
                        break;
            }
            }

        }

        public void EnemyTurn(int roundNum)
        {
            UpdateUserInterfaceInBattle(enemy, $"{enemy.name}s turn!");
            System.Threading.Thread.Sleep(2000);
            UpdateUserInterfaceInBattle(enemy, enemy.EnemyTurn(player));
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

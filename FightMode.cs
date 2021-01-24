using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    
    class FightMode
    {
        public int victories;
        StoreHandler storeHandler;
        public void StartFightMode(Player player, Program prog, string[,] sceneArt, SceneHandler sceneHandler, bool inBattle, MessageHandler msgHandler)
        {
            victories = 0;
            Random rnd = new Random();

            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("***\t\t\t                                                                 ***");
            Console.WriteLine($"*** Try to reach as many victories as possible.                                          ***");
            Console.WriteLine("***\tAt every 5th victory you have a chance to buy and use or equip items. X          ***");
            Console.WriteLine("***\t                                                                                 ***");
            Console.WriteLine("***                                                                                      ***");
            Console.WriteLine("***                                                                                      ***");
            Console.WriteLine("***                                                                                      ***");
            Console.WriteLine("***                                                                                      ***");
            Console.WriteLine("***                                                                                      ***");
            Console.WriteLine("***                                                                                      ***");
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey(true);

            do
            {
                if(victories%5 == 0 && !(victories == 0))
                {
                    Console.Clear();
                    Console.WriteLine("********************************************************************************************");
                    Console.WriteLine("***\t\t\t                                                                 ***");
                    Console.WriteLine($"***\tYou have reached {victories} victories.                                                    ***");
                    Console.WriteLine("***\tYou now have a chance to access the store before you continue the slaughter.     ***");
                    Console.WriteLine("***\t                                                                                 ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("********************************************************************************************");
                    Console.WriteLine($"Press any key to continue...");
                    Console.ReadKey(true);
                    storeHandler = new StoreHandler("Store");
                    Store store = storeHandler.CreateStore();
                    store.PrintStore(player);
                    player.OpenInventory();
                    Console.Clear();
                    Console.WriteLine("********************************************************************************************");
                    Console.WriteLine("***\t\t\t                                                                 ***");
                    Console.WriteLine($"***\t                                                                                ***");
                    Console.WriteLine("***\tThe slaughter continues...X                                                      ***");
                    Console.WriteLine("***\t                                                                                 ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("***                                                                                      ***");
                    Console.WriteLine("********************************************************************************************");
                    Console.ReadKey(true);

                }
                Console.Clear();
                Console.WriteLine("********************************************************************************************");
                Console.WriteLine("***\t\t\t                                                                 ***");
                Console.WriteLine($"***                                                                                      ***");
                Console.WriteLine("***\tPrepare yourself... X                                                            ***");
                Console.WriteLine("***\t                                                                                 ***");
                Console.WriteLine("***                                                                                      ***");
                Console.WriteLine("***                                                                                      ***");
                Console.WriteLine("***                                                                                      ***");
                Console.WriteLine("***                                                                                      ***");
                Console.WriteLine("***                                                                                      ***");
                Console.WriteLine("***                                                                                      ***");
                Console.WriteLine("********************************************************************************************");
                Console.WriteLine($"Press any key to continue...");
                Console.ReadKey(true);
                double modified = victories;
                if (victories < 3)
                {
                    List<Enemy> fightList = GenerateFightModeEnemyList();
                    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                }
                else if(victories < 10)
                {
                    
                    List<Enemy> fightList = GenerateHarderFightModeEnemyList(modified);
                    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                }else if(victories < 15)
                {

                    List<Enemy> fightList = GenerateEvenHarderFightModeEnemyList(modified);
                    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                }
                else
                {
                    List<Enemy> fightList = GenerateTheHardestFightModeEnemyList(modified);
                    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                }
                    if (player.currentHealthPoints > 1)
                    victories++;

            } while (player.currentHealthPoints > 0);
            sceneHandler.ClearScene();
            sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(sceneArt), false));
            if (victories > 1)
            {
                prog.LoadUserInterfaceOutOfBattle($"Du lyckades döda {victories} fiender!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
                prog.LoadMenu();
            }

            else
            {
                prog.LoadUserInterfaceOutOfBattle($"Du lyckades döda {victories} fiende!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
                prog.LoadMenu();
            }

        }

        private List<Enemy> GenerateFightModeEnemyList()
        {
            Goblin goblin = new Goblin("Goblin");
            Frog frog = new Frog("Frog");
            Butterfly butterfly = new Butterfly("Butterfly");
            List<Enemy> enemyList = new List<Enemy>();
            enemyList.Add(goblin);
            enemyList.Add(frog);
            enemyList.Add(butterfly);
            return enemyList;
        }

        private List<Enemy> GenerateHarderFightModeEnemyList(double modifier)
        {
            double modified = (modifier * 0.1) + 1;
            Goblin goblin = new Goblin("Goblin - Tougher", modified);
            Frog frog = new Frog("Frog - Tougher", modified);
            Butterfly butterfly = new Butterfly("Butterfly - Tougher", modified);
            List<Enemy> enemyList = new List<Enemy>();
            enemyList.Add(goblin);
            enemyList.Add(frog);
            enemyList.Add(butterfly);
            return enemyList;
        }

        private List<Enemy> GenerateEvenHarderFightModeEnemyList(double modifier)
        {
            double modified = (modifier * 0.1) + 1;
            Goblin goblin = new Goblin("Goblin - Tougher", modified);
            Frog frog = new Frog("Frog - Tougher", modified);
            Butterfly butterfly = new Butterfly("Butterfly - Tougher", modified);
            SpiderSwarm spiderSwarm = new SpiderSwarm("Spider Swarm");
            Dragon dragon = new Dragon("Dragon");
            Phoenix phoenix = new Phoenix("Phoenix");
            List<Enemy> enemyList = new List<Enemy>();
            enemyList.Add(goblin);
            enemyList.Add(frog);
            enemyList.Add(butterfly);
            enemyList.Add(spiderSwarm);
            enemyList.Add(dragon);
            enemyList.Add(phoenix);
            return enemyList;
        }

        private List<Enemy> GenerateTheHardestFightModeEnemyList(double modifier)
        {
            double modified = (modifier * 0.1) + 1;
            Goblin goblin = new Goblin("Goblin - Tougher", modified);
            Frog frog = new Frog("Frog - Tougher", modified);
            Butterfly butterfly = new Butterfly("Butterfly - Tougher", modified);
            SpiderSwarm spiderSwarm = new SpiderSwarm("Spider Swarm - Tougher", modified);
            Dragon dragon = new Dragon("Dragon - Tougher", modified);
            Phoenix phoenix = new Phoenix("Phoenix - Tougher", modified);
            List<Enemy> enemyList = new List<Enemy>();
            enemyList.Add(goblin);
            enemyList.Add(frog);
            enemyList.Add(butterfly);
            enemyList.Add(spiderSwarm);
            enemyList.Add(dragon);
            enemyList.Add(phoenix);
            return enemyList;
        }

        private void LoadFight(Enemy enemy, Program prog, SceneHandler sceneHandler, bool inBattle, Player player, MessageHandler msgHandler)
        {
            Fight fight = new Fight(enemy, player, sceneHandler, prog, msgHandler, inBattle, victories);
            sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(enemy.schematic), false), enemy);
            //prog.StartFight(enemy, sceneHandler);
            fight.StartFight();


        }



    }
}

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
            Console.WriteLine("***\tAt every 5th victory you have a chance to buy and use or equip items.            ***");
            Console.WriteLine("***\tAt every 5th victory you get to pick a new skill from 3 randomly selected ones. X***");
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
                double modified = (victories * 0.1)+1;
                //if (victories < 3)
                //{
                    List<Enemy> fightList = GenerateFightModeEnemyList(modified);
                    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                //}
                //else if(victories < 10)
                //{
                    
                //    List<Enemy> fightList = GenerateHarderFightModeEnemyList(modified);
                //    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                //    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                //}else if(victories < 15)
                //{

                //    List<Enemy> fightList = GenerateEvenHarderFightModeEnemyList(modified);
                //    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                //    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                //}
                //else
                //{
                //    List<Enemy> fightList = GenerateTheHardestFightModeEnemyList(modified);
                //    Enemy enemy = fightList.ElementAt(rnd.Next(0, fightList.Count));
                //    LoadFight(enemy, prog, sceneHandler, inBattle, player, msgHandler);
                //}
                    if (player.CurrentHealthPoints > 1)
                    victories++;
                if(victories%6 == 0)
                    GetNewSkill(player, GenerateSkillList());

            } while (player.CurrentHealthPoints > 0);
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

        private void GetNewSkill(Player player, Dictionary<int, Skill> skillList)
        {
            //Dictionary<string, string> skillList = new Dictionary<string, string>();
            Random rnd = new Random();
            Dictionary<int, Skill> finalSkillList = new Dictionary<int, Skill>();
            int rnd1 = rnd.Next(1, skillList.Count);
            finalSkillList.Add(finalSkillList.Count + 1, skillList[rnd1]);
            skillList.Remove(rnd1);
            int rnd2 = rnd.Next(1, skillList.Count);
            while(rnd2 == rnd1)
            {
                rnd2 = rnd.Next(1, skillList.Count);
            }
            finalSkillList.Add(finalSkillList.Count + 1, skillList[rnd2]);
            skillList.Remove(rnd2);
            int rnd3 = rnd.Next(1, skillList.Count);
            while(rnd3 == rnd2||rnd3 == rnd2)
            {
                rnd3 = rnd.Next(1, skillList.Count);
            }
            finalSkillList.Add(finalSkillList.Count + 1, skillList[rnd3]);


            //skillList.Add("ARMORING DEFENSE","- A skill that boosts your armor for the duration of the battle.");
            //skillList.Add("FLEX", "- Show off your toned muscles! Increases strength for the duration of the battle.");
            //skillList.Add("QUICK REFLEXES","- Hightens your reflexes, allowing you to get the initiative on your enemies!");

            Console.Clear();
            Console.WriteLine($"***************************Welcome to the Skillstore!**********************************************");
            Console.WriteLine("**\t");
            Console.WriteLine("**\t");
            foreach (var skill in finalSkillList)
            {
                Console.WriteLine($"**\t ID: {skill.Key}\t NAME: [{skill.Value.name}]");
                Console.WriteLine($"**\t DESCRIPTION: {skill.Value.description}");
                Console.WriteLine("**\t");
                Console.WriteLine("**\t");
            }
                
            string choice;
            int choice2;
            do
            {
                Console.WriteLine($"**Choose a skill to add to your characters skill list! (Enter the ID of the skill you want to choose.)**");
                choice = Console.ReadLine();
            } while (!((int.TryParse(choice, out choice2))) && finalSkillList.ContainsKey(choice2));
            player.commands.Add(player.commands.Count+1, finalSkillList[choice2].name);
            Console.WriteLine($"You chose to add [{finalSkillList[choice2].name}] to your skill list. X");
            Console.ReadKey(true);

        }

        private Dictionary<int,Skill> GenerateSkillList()
        {
            Dictionary<int, Skill> skillList = new Dictionary<int, Skill>();
            Skill def = new Skill("ARMORING DEFENSE", "- A skill that boosts your armor for the duration of the battle.");
            Skill flex = new Skill("FLEX", "- Show off your toned muscles! Increases strength for the duration of the battle.");
            Skill quick = new Skill("QUICK REFLEXES", "- Heightens your reflexes, allowing you to get the initiative on your enemies!");
            Skill glare = new Skill("DAMNING GLARE", "- Stare your opponents to death!");
            Skill flare = new Skill("FLARE", "- Burn your opponents to ashes. Kinda...");
            Skill smarts = new Skill("BOOKSMARTS","- You become pretty smart, with intelligence to match!");
            Skill jump = new Skill("JUMP","- Jump high in the sky, avoiding the enemies attacks, while preparing your own.");
            Skill scare = new Skill("SCARE","- Frighten yur enemies with a loud \"Boo!\"");
            Skill bambooz = new Skill("BAMBOOZLE","- Confuse your enemies with a series of quick and senseless movements.");
            skillList.Add(skillList.Count + 1, def);
            skillList.Add(skillList.Count + 1, flex);
            skillList.Add(skillList.Count + 1, quick);
            skillList.Add(skillList.Count + 1, glare);
            skillList.Add(skillList.Count + 1, flare);
            skillList.Add(skillList.Count + 1, smarts);
            skillList.Add(skillList.Count + 1, jump);
            skillList.Add(skillList.Count + 1, scare);
            skillList.Add(skillList.Count + 1, bambooz);
            return skillList;
        }



        private List<Enemy> GenerateFightModeEnemyList(double victories)
        {
            List<Enemy> enemyList = new List<Enemy>();
            if (victories < 3)
            {
                Cow cow = new Cow("Cow");
                Frog frog = new Frog("Frog");
                Butterfly butterfly = new Butterfly("Butterfly");
                Aardvark aardvark = new Aardvark("Aardvark");
                enemyList.Add(aardvark);
                enemyList.Add(frog);
                enemyList.Add(butterfly);
                enemyList.Add(cow);

                return enemyList;
            }else if(victories < 7)
            {
                Cow cow = new Cow("Cow", victories);
                Frog frog = new Frog("Frog", victories);
                Butterfly butterfly = new Butterfly("Butterfly", victories);
                Aardvark aardvark = new Aardvark("Aardvark", victories);
                enemyList.Add(aardvark);
                enemyList.Add(frog);
                enemyList.Add(butterfly);
                enemyList.Add(cow);

                return enemyList;
            }else if (victories < 12)
            {
                Ant ant = new Ant("Ant");
                Bear bear = new Bear("Bear");
                Goblin goblin = new Goblin("Goblin");
                Moose moose = new Moose("Moose");
                enemyList.Add(ant);
                enemyList.Add(bear);
                enemyList.Add(goblin);
                enemyList.Add(moose);

                return enemyList;
            }else if(victories < 16)
            {
                Ant ant = new Ant("Ant", victories);
                Bear bear = new Bear("Bear", victories);
                Goblin goblin = new Goblin("Goblin", victories);
                Moose moose = new Moose("Moose", victories);
                enemyList.Add(ant);
                enemyList.Add(bear);
                enemyList.Add(goblin);
                enemyList.Add(moose);

                return enemyList;
            }else if (victories < 22)
            {
                Griffin griffin = new Griffin("Griffin");
                Knight knight = new Knight("Knight");
                Snake snake = new Snake("Snake");
                SpiderSwarm spiderSwarm = new SpiderSwarm("Spider Swarm");
                enemyList.Add(griffin);
                enemyList.Add(knight);
                enemyList.Add(snake);
                enemyList.Add(spiderSwarm);

                return enemyList;
            }else if (victories < 27)
            {
                Griffin griffin = new Griffin("Griffin", victories);
                Knight knight = new Knight("Knight", victories);
                Snake snake = new Snake("Snake", victories);
                SpiderSwarm spiderSwarm = new SpiderSwarm("Spider Swarm", victories);
                enemyList.Add(griffin);
                enemyList.Add(knight);
                enemyList.Add(snake);
                enemyList.Add(spiderSwarm);

                return enemyList;
            }
            else
            {
                Dragon dragon = new Dragon("Dragon");
                Phoenix phoenix = new Phoenix("Phoenix");
                enemyList.Add(dragon);
                enemyList.Add(phoenix);

                return enemyList;
            }



        }

        //private List<Enemy> GenerateHarderFightModeEnemyList(double modifier)
        //{
        //    double modified = (modifier * 0.1) + 1;
        //    //Goblin goblin = new Goblin("Goblin - Tougher", modified);
        //    //Frog frog = new Frog("Frog - Tougher", modified);
        //    //Butterfly butterfly = new Butterfly("Butterfly - Tougher", modified);
        //    List<Enemy> enemyList = new List<Enemy>();
        //    //enemyList.Add(goblin);
        //    //enemyList.Add(frog);
        //    //enemyList.Add(butterfly);
        //    //TEST PURPOSES--------------------------------------------
        //    Goblin goblin = new Goblin("Goblin");
        //    Ant ant = new Ant("Ant");
        //    Bear bear = new Bear("Bear");
        //    enemyList.Add(ant);
        //    enemyList.Add(bear);
        //    enemyList.Add(goblin);
        //    return enemyList;
        //}

        //private List<Enemy> GenerateEvenHarderFightModeEnemyList(double modifier)
        //{
        //    double modified = (modifier * 0.1) + 1;
        //    Goblin goblin = new Goblin("Goblin - Tougher", modified);
        //    Frog frog = new Frog("Frog - Tougher", modified);
        //    Butterfly butterfly = new Butterfly("Butterfly - Tougher", modified);
        //    SpiderSwarm spiderSwarm = new SpiderSwarm("Spider Swarm");
        //    Dragon dragon = new Dragon("Dragon");
        //    Phoenix phoenix = new Phoenix("Phoenix");
        //    List<Enemy> enemyList = new List<Enemy>();
        //    enemyList.Add(goblin);
        //    enemyList.Add(frog);
        //    enemyList.Add(butterfly);
        //    enemyList.Add(spiderSwarm);
        //    enemyList.Add(dragon);
        //    enemyList.Add(phoenix);
        //    return enemyList;
        //}

        //private List<Enemy> GenerateTheHardestFightModeEnemyList(double modifier)
        //{
        //    double modified = (modifier * 0.1) + 1;
        //    Goblin goblin = new Goblin("Goblin - Tougher", modified);
        //    Frog frog = new Frog("Frog - Tougher", modified);
        //    Butterfly butterfly = new Butterfly("Butterfly - Tougher", modified);
        //    SpiderSwarm spiderSwarm = new SpiderSwarm("Spider Swarm - Tougher", modified);
        //    Dragon dragon = new Dragon("Dragon - Tougher", modified);
        //    Phoenix phoenix = new Phoenix("Phoenix - Tougher", modified);
        //    List<Enemy> enemyList = new List<Enemy>();
        //    enemyList.Add(goblin);
        //    enemyList.Add(frog);
        //    enemyList.Add(butterfly);
        //    enemyList.Add(spiderSwarm);
        //    enemyList.Add(dragon);
        //    enemyList.Add(phoenix);
        //    return enemyList;
        //}

        private void LoadFight(Enemy enemy, Program prog, SceneHandler sceneHandler, bool inBattle, Player player, MessageHandler msgHandler)
        {
            Fight fight = new Fight(enemy, player, sceneHandler, prog, msgHandler, inBattle, victories);
            sceneHandler.PrintScene(sceneHandler.CreateScene(sceneHandler.GeneratePicture(enemy.schematic), false), enemy);
            //prog.StartFight(enemy, sceneHandler);
            fight.StartFight();


        }



    }
}

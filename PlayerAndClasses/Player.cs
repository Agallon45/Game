using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    abstract class Player
    {
        public string name;

        public double maxHealthPoints;
        public double currentHealthPoints;
        public double CurrentHealthPoints
        {
            get { return currentHealthPoints; }
            set
            {
                if (currentHealthPoints + value > maxHealthPoints)
                {
                    currentHealthPoints = maxHealthPoints;
                }
                if(currentHealthPoints + value < 0)
                {
                    currentHealthPoints = 0;
                }
            }
        }

        public double strength;
        public double armor;
        public double agility;
        public double intellect;
        public double lvl;
        public double experience;
        public Dictionary<int, string> commands = new Dictionary<int, string>();
        public Dictionary<int, Item> items = new Dictionary<int, Item>();
        public bool isDefending;//Det här kan inte vara det bästa sättet att lösa det här på?
        public bool isDodging;//Det här kan inte vara det bästa sättet att lösa det här på?
        public double coin;
        public List<Item> equippedGear = new List<Item>();
        public int roundNum;
        public bool buffed;
        public int roundNumRemove;
        public int armorBuff;
        public bool defended;
        public int initiative;

        public string playerClass;

        public string Attack(Enemy enemy)
        {
            Random rnd = new Random();
            if ((rnd.Next(1, 100) + agility) > enemy.agility)
            {
                double dmg = rnd.Next(1, (int)strength) + strength;
                dmg = dmg - (enemy.armor * 0.1);
                if (playerClass.ToLower().Equals("rogue"))
                {
                    int crit = rnd.Next(0, 3);
                    if (crit == 1)
                    {
                        dmg = dmg * 2;
                        enemy.currentHealthPoints = enemy.currentHealthPoints - dmg;
                        return $"{name} is concentrating. {enemy.name} suffers a critical hit for {dmg} damage!";
                    }

                }
                enemy.currentHealthPoints = enemy.currentHealthPoints - dmg;
                return $"{enemy.name} suffers {dmg} damage!";
            }
            else
            {
                return $"{name}s attack misses!";
            }
        }

        public string AddExperienceAndCoin(Enemy enemy)
        {
            coin += enemy.coinReward;
            experience += enemy.expAward;
            if (experience > (50 * lvl))
            {
                return LevelUp();
            }
            else
            {
                return "";
            }
        }

        private string LevelUp()
        {
            lvl++;
            experience = 0;
            StatGain();
            return $"{name} has advanced to level {lvl}!";

        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine($"***************************{name}s inventory**********************************************");
            Console.WriteLine("**\tID\t NAME\t\t\t  DESCRIPTION\t\t WORTH\t EQUIPPED\t**");
            foreach (var item in items)
                Console.WriteLine($"**\t{item.Key}\t {item.Value.name} {item.Value.description} {item.Value.cost}\t {item.Value.equipped}\t\t**");
            Console.WriteLine($"**You have {coin}\t coin**");
            Console.WriteLine($"LVL: {lvl} Health: {currentHealthPoints}/{maxHealthPoints} Agility: {agility} Strength: {strength} Intellect: {intellect} Armor: {armor} ");
        }

        public void EquipItem()
        {
            string cmd;
            int cmd2;
            try
            {

            
            do
            {
                Console.WriteLine("Enter the ID of the item you wish to equip/unequip. [B]ACK");
                cmd = Console.ReadLine();
            } while (!((int.TryParse(cmd, out cmd2))) && items.ContainsKey(cmd2) && !cmd.Equals("b"));

            if (cmd.Equals("b"))
                OpenInventory();
            else if (items[cmd2] is Weapon || items[cmd2] is Armor)
            {
                ConsoleKey choice;
                if (items[cmd2].equipped == true)
                {
                    do
                    {
                        Console.WriteLine("Do you want to unequip this item? [Y]/[N]");
                        choice = Console.ReadKey(true).Key;
                    } while (choice != ConsoleKey.Y && choice != ConsoleKey.N);
                    if (choice == ConsoleKey.Y)
                    {
                        items[cmd2].equipped = false;
                        ItemStatChange(items[cmd2]);
                        OpenInventory();
                    }
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Do you want to equip this item? [Y]/[N]");
                        choice = Console.ReadKey(true).Key;
                    } while (choice != ConsoleKey.Y && choice != ConsoleKey.N);
                    if (choice == ConsoleKey.Y)
                    {
                        items[cmd2].equipped = true;
                        ItemStatChange(items[cmd2]);
                        OpenInventory();

                    }

                }
            }
            else if (items[cmd2] is Consumable)
            {
                Console.WriteLine("That is not something you can equip. X");
                Console.ReadKey(true);
                OpenInventory();
            }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("You don't have an item with that ID. X");
                Console.ReadKey(true);
                OpenInventory();
            }
        }

        private void ItemStatChange(Item item)
        {
            ChangeStats(item.healthPoints, item.strength, item.armor, item.agility, item.intellect, item.equipped);
        }

        private void ChangeStats(int hp, int str, int arm, int agi, int inte, bool upStats)
        {
            if (upStats)
            {
                maxHealthPoints += hp;
                strength += str;
                armor += arm;
                agility += agi;
                intellect += inte;
            }
            else
            {
                maxHealthPoints -= hp;
                strength -= str;
                armor -= arm;
                agility -= agi;
                intellect -= inte;
            }

        }

        public void ConsumeItem()
        {
            string cmd;
            int cmd2;
            do
            {
                Console.WriteLine("Enter the ID of the item you wish you wish to consume. [B]ACK");
                cmd = Console.ReadLine();
            } while (!((int.TryParse(cmd, out cmd2))) && items.ContainsKey(cmd2) && cmd.Equals("b"));

            if (cmd.Equals("b"))
                OpenInventory();
            else if (items[cmd2] is Consumable)
            {
                if ((currentHealthPoints += items[cmd2].healthPoints) < maxHealthPoints)
                {
                    currentHealthPoints += items[cmd2].healthPoints;
                }
                else
                {
                    currentHealthPoints = maxHealthPoints;
                }

                items.Remove(cmd2);
                OpenInventory();
            }
            else if (items[cmd2] is Weapon || items[cmd2] is Armor)
            {
                Console.WriteLine("That is not a consumable.");
                Console.ReadKey(true);
                OpenInventory();
            }
        }

        public void OpenInventory()
        {
            Console.Clear();
            ShowInventory();
            ConsoleKey choice;
            do
            {
                Console.WriteLine("[C]ONSUME ITEM \t E[Q]UIP/UNE[Q]UIP ITEM \t [E]XIT");
                choice = Console.ReadKey(true).Key;
            } while (choice != ConsoleKey.C && choice != ConsoleKey.Q && choice != ConsoleKey.E);
            if (choice == ConsoleKey.Q)
            {
                EquipItem();
            }
            else if (choice == ConsoleKey.C)
            {
                ConsumeItem();
            }
        }


        public Item SellItemFromInventory()
        {
            bool isRunning = true;
            do
            {
                try
                {
                    string cmd;
                    int cmd2;
                    do
                    {
                        Console.WriteLine("Enter the ID of the item you wish you wish to sell. Enter <b> to CANCEL.");
                        cmd = Console.ReadLine();
                    } while (!((int.TryParse(cmd, out cmd2))) && !items.ContainsKey(cmd2) && !cmd.Equals("b"));

                    if (cmd.Equals("b"))
                    {
                        isRunning = false;
                        return null;
                    }
                    else
                    {
                        Item item = items[cmd2];
                        items.Remove(cmd2);

                        return item;
                    }


                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("ID not present. X");
                    Console.ReadKey();
                    return null;
                }
            } while (isRunning);
        }



        public abstract void StatGain();

        public abstract string Defend();

        public abstract string Heal();

        public abstract string Dodge();

        public abstract string Bless();

        public abstract string RemoveBuff();

        public abstract string AgitatingShout(Enemy enemy);

        public abstract string SwiftThinking();

    }
}

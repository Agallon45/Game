using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    abstract class Player
    {
        public string name;
        public double strengthLoss;
        public double maxHealthPoints;
        private double currentHealthPoints;
        public abstract double CurrentHealthPoints
        {
            get;
            set;
        }

        private double strength;
        public double Strength
        {
            get { return strength; }
            set
            {
                if (value < 0)
                {
                    strength = 0;
                }
                else
                {
                    strength = value;
                }
            }
        }
        private double armor;
        public double Armor
        {
            get { return armor; }
            set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }
        private double agility;
        public double Agility
        {
            get { return agility; }
            set
            {
                if (value < 0)
                {
                    agility = 0;
                }
                else
                {
                    agility = value;
                }
            }
        }
        private double intellect;
        public double Intellect
        {
            get { return intellect; }
            set
            {
                if (value < 0)
                {
                    intellect = 0;
                }
                else
                {
                    intellect = value;
                }
            }
        }
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
        public bool debuffed;
        public double negStrength;
        public double negAgility;
        public double negIntellect;
        public double negHealth;
        public double negArmor;
        public double dot;
        public bool isDotted;
        public double posStrength;
        public double posAgility;
        public double posIntellect;
        public double posHealth;
        public double posArmor;
        public int posInitiative;
        public bool blessed;
        public bool agitated;
        public bool hasJumped;


        public string playerClass;

        public string Attack(Enemy enemy)
        {
            Random rnd = new Random();
            if ((rnd.Next(1, 100) + agility) > enemy.Agility)
            {
                double dmg = rnd.Next(1, (int)strength) + strength;
                dmg = dmg - (enemy.Armor * 0.1);
                if (playerClass.ToLower().Equals("rogue"))
                {
                    int crit = rnd.Next(0, 3);
                    if (crit == 1)
                    {
                        dmg = dmg * 2;
                        dmg = Math.Round(dmg);//ROUND
                        if(dmg < 0)
                            dmg = dmg * (-1);
                        enemy.CurrentHealthPoints = enemy.CurrentHealthPoints - dmg;
                        return $"{name} is concentrating. {enemy.name} suffers a critical hit for {dmg} damage!";
                    }

                }
                dmg = Math.Round(dmg);//ROUND
                enemy.CurrentHealthPoints = enemy.CurrentHealthPoints - dmg;
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

        public string ArmoringDefense()
        {
            if (!buffed)
            {
                buffed = true;
                Armor += 100;
                posArmor = 100;
                roundNumRemove = roundNum + 2;
            
            return $"{name}s armor is shining bright in the sun.";
            }
            else
            {
                Armor += 5;
                posArmor += 5;
                return $"{name} is trying to armor up further, but it doesn't have much effect...";
            }

        }

        public string Flex()
        {
            if (!buffed)
            {
                buffed = true;
                Strength += 10;
                posStrength = 10;
                roundNumRemove = roundNum + 2;
                return $"{name} shows off a fine body, seemingly sculpted by Michelangelo himself!";
            }
            else
            {
                Strength += 1;
                posStrength += 1;
                return $"{name} tries to flex further, but no one is very much impressed...";
            }
        }

        public string QuickReflexes()
        {
            if (!buffed)
            {
                buffed = true;
                initiative += 6;
                posInitiative = 6;
                roundNumRemove = roundNum + 2;
                return $"{name} suddenly has very quick feet!";
            }
            else
            {
                return $"{name} can't get very much faster than this...";
            }
        }

        public string DamningGlare(Enemy enemy)
        {
            if (!enemy.debuffed)
            {
                enemy.Strength -= 10;
                enemy.negStrength = 10;
                enemy.debuffed = true;
                enemy.roundNumRemove = roundNum + 2;
                return $"{name} is staring directly into {enemy.name}s eyes. {enemy.name} brakes contact first!";
            }
            else
            {
                enemy.Strength -= 1;
                enemy.negStrength += 1;
                return $"{name} is staring into {enemy.name}s eyes again. It's not very effective this time...";
            }

        }

        public string Flare(Enemy enemy)
        {
            enemy.isDotted = true;
            enemy.dot = strength;
            enemy.roundNumRemove = roundNum + 2;
            enemy.CurrentHealthPoints -= strength;
            return $"{enemy.name} suffers {strength} damage! {enemy.name} is on fire!";
        }

        public string BookSmarts()
        {
            buffed = true;
            intellect += 15;
            posIntellect = 15;
            roundNumRemove = roundNum + 2;
            return $"{name} can feel the smarts from the books pouring over the mind!";
        }

        public string Jump(Enemy enemy)
        {
            if (!hasJumped)
            {
                hasJumped = true;
                agility += 90;
                return $"{name} takes to the skies and is nowhere to be seen!";
            }
            else
            {
                hasJumped = false;
                agility -= 90;
                enemy.CurrentHealthPoints -= strength * 2;
                return $"{name} swoops down, inflicting {strength * 2} damage on {enemy.name}";
                
                
            }
        }

        public string Scare(Enemy enemy)
        {
            if (!enemy.debuffed)
            {
                enemy.debuffed = true;
            enemy.Strength -= 30;
            enemy.negStrength = 30;
            return $"{name} utters a loud 'Boo!', which scares the bejeezuz out of{enemy.name}!";

            }
            else
            {
                enemy.Strength -= 1;
                enemy.negStrength += 1;
                return $"{name} tries to scare {enemy.name} again, buts its not very effective...";
            }
        }

        public string Bamboozle(Enemy enemy)
        {
            
            Random rnd = new Random();
            if(rnd.Next(1,4) > 1)
            {
                if (!enemy.debuffed)
                {
                    
            double str = (rnd.Next(1, 11) * 0.1)+1;
            double agi = (rnd.Next(1, 11)*0.1)+1;
            enemy.Strength -= str;
            enemy.Agility -= agi;
            enemy.negStrength = str;
            enemy.negAgility = agi;
            double dmg = rnd.Next(1, 99);
            enemy.CurrentHealthPoints -= dmg;
            enemy.debuffed = true;
            enemy.roundNumRemove = roundNum + (rnd.Next(1, 5));
            return $"{name} busts out som sweet but not very cognizable dansmoves, while flailing their arms up and around. {enemy.name} suffers {dmg} damage and stares with blank eyes into the air.";
                }
                else
                {
                    return $"{name} tries to moonwalk across the ground, but stumbles about in an embarrasing fashion. Nothing much gets done. ";
                }
            }
            else
            {
                return $"{name} tries to moonwalk across the ground, but stumbles about in an embarrasing fashion. Nothing much gets done. ";
            }
        }

        public abstract void StatGain();

        public abstract string Defend();

        public abstract string Heal();

        public abstract string Dodge();

        public abstract string Bless();

        public string RemoveBuff()
        {


            if (blessed)
            {
                if (roundNum == roundNumRemove)
                {


                    Strength -= posStrength;
                    Agility -= posAgility;
                    Intellect -= posIntellect;
                    Armor -= posArmor;
                    roundNumRemove = 0;
                    posStrength = 0;
                    posAgility = 0;
                    posIntellect = 0;
                    posArmor = 0;
                    blessed = false;
                    return $"Bless fades from {name}...";
                }
            }

            else if (agitated)
            {
                if (roundNum == roundNumRemove)
                {
                    agitated = false;
                    Strength -= posStrength;
                    Agility -= posAgility;
                    Intellect -= posIntellect;
                    Armor -= posArmor;
                    roundNumRemove = 0;
                    posStrength = 0;
                    posAgility = 0;
                    posIntellect = 0;
                    posArmor = 0;

                    return $"{name} is no longer agitated...";
                }
            }
            else if (buffed)
            {
                if (roundNum == roundNumRemove)
                {
                    Strength -= posStrength;
                    Agility -= posAgility;
                    Intellect -= posIntellect;
                    Armor -= posArmor;
                    initiative -= posInitiative;
                    posInitiative = 0;
                    roundNumRemove = 0;
                    posStrength = 0;
                    posAgility = 0;
                    posIntellect = 0;
                    posArmor = 0;
                    buffed = false;
                    return "Buff fades...";
                }
            }

            return "";
}
    

        public abstract string AgitatingShout(Enemy enemy);

        public abstract string SwiftThinking();

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Store
    {
        public string name;
        public Dictionary<int, Item> storeInventory = new Dictionary<int, Item>();

        public Store(string Name, Dictionary<int, Item> StoreInventory)
        {
            name = Name;
            storeInventory = StoreInventory;
        }

        public void PrintStore(Player player)
        {
            Console.Clear();
            Console.WriteLine($"***************************Welcome to the {name}!**********************************");
            Console.WriteLine("**\tID\t NAME\t\t\t  DESCRIPTION\t\t\t PRICE\t**");
            foreach (var item in storeInventory)
                Console.WriteLine($"**\t{item.Key}\t {item.Value.name} {item.Value.description}\t {item.Value.cost}\t**");
            Console.WriteLine($"**You have {player.coin} coin**");
            StoreMenu(player);
            
        }

        private void StoreMenu(Player player)
        {

                try
                {
                    int cmd2;
                    string cmd;
                    ConsoleKey choice;
                    do
                    {
                        Console.WriteLine("[B]UY [S]ELL [E]XIT ");
                        choice = Console.ReadKey(true).Key;
                    } while (choice != ConsoleKey.B && choice != ConsoleKey.S && choice != ConsoleKey.E);

                    if (choice == ConsoleKey.B)
                    {


                        do
                        {
                            Console.WriteLine("Enter the ID of the item you wish you wish to buy. Enter <b> to CANCEL.");
                            cmd = Console.ReadLine();
                        } while (!((int.TryParse(cmd, out cmd2))) && !storeInventory.ContainsKey(cmd2) && !cmd.Equals("b"));
                        if (cmd.Equals("b"))
                        {
                            //isRunning = false;
                        }
                        else if (storeInventory[cmd2].cost < player.coin)
                        {

                            player.items.Add(player.items.Count+1, storeInventory[cmd2]);
                            player.coin -= storeInventory[cmd2].cost;
                            storeInventory[cmd2].cost = (storeInventory[cmd2].cost / 2);
                            Console.WriteLine($"{storeInventory[cmd2].name}");
                            Console.WriteLine("has been added to your inventory. X");
                            Console.ReadKey(true);
                            storeInventory.Remove(cmd2);
                            //isRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough coin! X");
                            Console.ReadKey(true);
                        }

                        Console.Clear();
                        PrintStore(player);
                    }
                    else if (choice == ConsoleKey.S)
                    {
                        player.ShowInventory();
                        Item soldItem = player.SellItemFromInventory();
                        if (soldItem != null)
                        {
                            player.coin += soldItem.cost;
                            Console.WriteLine($"You sold {soldItem.name} to the store for {soldItem.cost / 2} coins. X");
                            Console.ReadKey(true);
                        }
                        PrintStore(player);

                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("ID not present. X");
                    Console.ReadKey();
                }
            

        }

    }
}

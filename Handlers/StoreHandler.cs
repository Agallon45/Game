using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class StoreHandler
    {
        string[] armorTypes = new string[] {"Helm", "Boots","Chestpiece","Bracers","Gloves","Pants", "Leggings" };
        string[] armorNouns = new string[] 
        {"Defense", "Stamina", "Glory", "Health", "Stability","Reverence", "Protection" };

        string[] weaponNouns = new string[] {"Axe", "Sword", "Knife","Dagger","Staff","Mace","Pistol","Gun" };
        string[] weaponTypes = new string[] {"Slaughter","Blood","Evil","Death","Destruction","Doom  ","Pain","Sickness","Constipation","Dullness","Crushing" };




        public string name;
        //public Store store;

        public StoreHandler(string Name)
        {
            name = Name;
        }



        public Store CreateStore()
        {
            Store store = new Store("Store", GenerateStoreStock());
            return store;

        }

        private Dictionary<int, Item> GenerateStoreStock()
        {
            Random rnd = new Random();
            Dictionary<int, Item> itemsForSale = new Dictionary<int, Item>();
            int amountOfItems = rnd.Next(1, 10);
            int whatToMake;

            for (int i = 0; i < amountOfItems; i++)
            {
                whatToMake = rnd.Next(0, 3);
                if(whatToMake == 0)
                {
                    Consumable cons = GenerateConsumable();
                    itemsForSale.Add(i+1, cons);
                }else if(whatToMake == 1)
                {
                    Weapon weapon = GenerateWeapon();
                    itemsForSale.Add(i+1, weapon);
                }
                else
                {
                    Armor armor = GenerateArmor();
                    itemsForSale.Add(i+1, armor);
                }
            }

            return itemsForSale;



        }

        private Consumable GenerateConsumable()
        {

            Random rnd = new Random();
            int healAmount = rnd.Next(2, 5);
            string name = $"Potion {healAmount * 10}";

            for (int i = name.Length; i < 24; i++)
            {
                name += " ";
            }

            Consumable cons = new Consumable(name, healAmount * 10);

            return cons;

        }

        private Weapon GenerateWeapon()
        {
            Random rnd = new Random();
            int nounInd = rnd.Next(1, (weaponNouns.Length-1));
            int typeInd = rnd.Next(1, (weaponTypes.Length - 1));
            int totalStr = rnd.Next(1, 10);
            int totalAgi = rnd.Next(1, 10);
            int totalInt = rnd.Next(1, 10);

            string name = $"{weaponNouns[nounInd]} of {weaponTypes[typeInd]}";
            for (int i = name.Length; i < 24; i++)
            {
                name += " ";
            }

            Weapon weapon = new Weapon(name, rnd.Next(0, totalStr), rnd.Next(0, totalAgi), rnd.Next(0, totalInt));
            return weapon;
        }

        private Armor GenerateArmor()
        {
            Random rnd = new Random();
            int nounInd = rnd.Next(0, (armorNouns.Length - 1));
            int typeInd = rnd.Next(0, (armorTypes.Length - 1));
            int amountOfArmor = rnd.Next(1, 10) * 10;
            int amountOfHealth = rnd.Next(1, 10) * 10;

            string name = $"{armorTypes[typeInd]} of {armorNouns[nounInd]}";

            for (int i = name.Length; i < 24; i++)
            {
                name += " ";
            }

            Armor armor = new Armor(name, rnd.Next(0, amountOfArmor), rnd.Next(0, amountOfHealth));
            return armor;
        }
    
    }
}

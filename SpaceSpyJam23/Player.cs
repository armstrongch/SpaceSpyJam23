using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSpyJam23
{
    public enum SKILLS
    {
        HUNGER,
    }

    public class Player
    {
        public Location CurrentLocation { get; private set; }
        public string Name { get; private set; }
        public List<Item> Inventory { get; private set; }

        public Dictionary<SKILLS, int> SkillValues { get; private set; }

        public Player(Location startingLocation, string name)
        {
            CurrentLocation = startingLocation;
            Name = name;
            SkillValues = new Dictionary<SKILLS, int>()
            {
                { SKILLS.HUNGER, 0 },
            };
            Inventory = new List<Item>();
        }

        public void TravelToLocation(Location newLocation)
        {
            Console.WriteLine("Travelling to: " + newLocation.Name);
            CurrentLocation = newLocation;
            IncrementSkillValue(SKILLS.HUNGER, 5);
        }

        public void UpdateSkillValue(string attributeName, int value)
        {
            SKILLS skill = SKILLS.HUNGER;
            switch(attributeName.ToUpper())
            {
                case "HUNGER": skill = SKILLS.HUNGER; break;
                default: throw new NotImplementedException();
            }
            UpdateSkillValue(skill, value);
        }

        public void UpdateSkillValue(SKILLS skill, int value)
        {
            SkillValues[skill] = value;
        }

        public void IncrementSkillValue(SKILLS skill, int value)
        {
            SkillValues[skill] += value;
        }

        public void PickUpItem(Item item)
        {
            Inventory.Add(item);
        }

        public string[] GetItemNames()
        {
            List<string> itemList = new List<string>();
            Inventory = Inventory.OrderBy(i => i.Name).ToList();

            foreach (Item i in Inventory)
            {
                itemList.Add(i.Name);
            }

            return itemList.ToArray();
        }

        public string[] GetItemActionNames(string itemName, bool includeDescriptions)
        {
            Item item = Inventory.First(x => x.Name.ToUpper() == itemName);
            return item.GetItemActionNames(ACTION_TYPE.INVENTORY, includeDescriptions);
        }

        public void DoItemAction(string itemName, string itemActionName)
        {
            Item item = Inventory.First(i => i.Name == itemName);
            item.DoItemAction(itemActionName, CurrentLocation, this);
        }

        public bool InventoryContainsItem(ITEMS item)
        {
            throw new NotImplementedException("This doesn't work!");
            //Item generatedItem = ItemFactory.GenerateItem(item);
            //return Inventory.Contains(generatedItem);
        }

        public void RemoveItem(ITEMS item)
        {
            throw new NotImplementedException("This doesn't work!");
            //Item generatedItem = ItemFactory.GenerateItem(item);
            //Inventory.Remove(generatedItem);
        }

        public void RemoveItem(string itemName)
        {
            foreach (Item item in Inventory)
            {
                if (item.Name == itemName)
                {
                    Inventory.Remove(item);
                    break;
                }
            }
        }
    }
}

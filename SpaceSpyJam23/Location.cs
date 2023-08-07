using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpaceSpyJam23
{
    public class Location
    {
        private List<Item> Items = new List<Item>();
        private Dictionary<string, string> Exits = new Dictionary<string, string>();

        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public Location(string name, string description, List<Item> items, Dictionary<string, string> exits)
        {
            Name = name;
            Description = description;
            Items = items;
            for (int i = 0; i < exits.Count; i++)
            {
                string exitName = exits.Keys.ElementAt(i);
                string locationName = exits[exitName];
                AddExit(exitName, locationName);
            }
        }

        public void AddExit(string exitName, string locationName)
        {
            Exits.Add(exitName.ToUpper(), locationName.ToUpper());
        }

        public string[] GetItemNames()
        {
            List<string> itemList = new List<string>();
            Items = Items.OrderBy(i => i.Name).ToList();
            
            foreach (Item i in Items)
            {
                itemList.Add(i.Name);
            }

            return itemList.ToArray();
        }

        public string[] GetExitNames()
        {
            List<string> exitNames = new List<string>();
            for (int i = 0; i < Exits.Count; i += 1)
            {
                exitNames.Add(Exits.Keys.ElementAt(i));
            }

            return exitNames.ToArray();
        }

        public string[] GetItemActionNames(string itemName, bool includeDescriptions)
        {
            Item item = Items.First(x => x.Name.ToUpper() == itemName);
            return item.GetItemActionNames(ACTION_TYPE.WORLD, includeDescriptions);
        }

        public void DoItemAction(string itemName, string itemActionName, Player player)
        {
            Item item = Items.First(i => i.Name == itemName);
            item.DoItemAction(itemActionName, this, player);
            if (player.CurrentLocation.Name != "HOME")
            {
                player.IncrementSkillValue(SKILLS.WARMTH, -3);
            }
        }

        public string GetLocationNameFromExitName(string exitName)
        {
            return Exits[exitName];
        }

        public void RemoveOrReplaceItem(string oldItemName, ITEMS? newItem)
        {
            for (int i = 0; i < Items.Count; i ++)
            {
                if (Items[i].Name == oldItemName)
                {
                    Items.RemoveAt(i);
                    if (newItem != null)
                    {
                        Items.Add(ItemFactory.GenerateItem((ITEMS)newItem));
                    }
                    break;
                }
            }
        }
    }
}

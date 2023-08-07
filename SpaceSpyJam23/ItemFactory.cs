using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSpyJam23
{   
    public enum ITEMS
    {
        BED,
        WOOD_STOVE,
        WINDOW
    }
    
    public class ItemFactory
    {

        private static ITEMS stringToItemsEnum(string itemName)
        {
            return (ITEMS)Enum.Parse(typeof(ITEMS), itemName);
        }
        
        public static Item GenerateItem(string itemName)
        {
            ITEMS itemFromName = stringToItemsEnum(itemName);
            return GenerateItem(itemFromName);
        }
        
        public static Item GenerateItem(ITEMS item)
        {
            switch (item)
            {
                case ITEMS.BED:
                    return new Item(item.ToString(), new List<ItemAction>() {
                        new ItemAction("examine", "Look at the bed.", ACTION_TYPE.WORLD, examine),
                        new ItemAction("sleep", "Sleep in the bed.", ACTION_TYPE.WORLD, sleep),
                        new ItemAction("nap", "Nap in the bed.", ACTION_TYPE.WORLD, nap)
                    }) ;
                case ITEMS.WOOD_STOVE:
                    return new Item(item.ToString(), new List<ItemAction>() {
                        new ItemAction("examine", "Look at the wood stove.", ACTION_TYPE.WORLD, examine),
                    });
                case ITEMS.WINDOW:
                    return new Item(item.ToString(), new List<ItemAction>() {
                        new ItemAction("examine", "Look out the window.", ACTION_TYPE.WORLD, examine),
                    });
                default:
                    throw new NotImplementedException();
            }
        }

        static string examine(string itemName)
        {
            switch (itemName)
            {
                case "BED":
                    return "A king-sized mattress atop a sturdy wooden frame, draped with a thick patchwork quilt.";
                case "WOOD STOVE":
                    return "A wrought-iron strove, large enough to keep the cabin warm and toasty on the coldest winter days.";
                case "WINDOW":
                    return "It is a beautiful autumn day outside. The sky is blue, and the auburn-colored leaves littering the ground are occasionally lifted by the breeze to dance across the yard.";
                default:
                    return $"{itemName} is not very exciting";
            }
        }
        static string nap(string itemName)
        {
            return $"You take a quick nap in the {itemName}.";
        }
        static string sleep(string itemName)
        {
            return $"You take a long snooze in the {itemName}.";
        }
    }
}

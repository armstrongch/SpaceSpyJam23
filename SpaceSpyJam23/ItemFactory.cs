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
        WINDOW,
        TV,
        BLINKING_ANSWERING_MACHINE,
        ANSWERING_MACHINE
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
                case ITEMS.TV:
                    return new Item(item.ToString(), new List<ItemAction>() {
                        new ItemAction("examine", "Watch television.", ACTION_TYPE.WORLD, examine),
                    });
                case ITEMS.BLINKING_ANSWERING_MACHINE:
                    return new Item(item.ToString(), new List<ItemAction>() {
                        new ItemAction("examine", "Check your voicemail.", ACTION_TYPE.WORLD, examine),
                    });
                case ITEMS.ANSWERING_MACHINE:
                    return new Item(item.ToString(), new List<ItemAction>() {
                        new ItemAction("examine", "Check your voicemail.", ACTION_TYPE.WORLD, examine),
                    });
                default:
                    throw new NotImplementedException();
            }
        }

        static string examine(string itemName, Location location)
        {
            switch (itemName)
            {
                case "BED":
                    return "A king-sized mattress atop a sturdy wooden frame, draped with a thick patchwork quilt.";
                case "WOOD STOVE":
                    return "A wrought-iron strove, large enough to keep the cabin warm and toasty on the coldest winter days.";
                case "WINDOW":
                    return "It is a beautiful autumn day outside. The sky is blue, and the auburn-colored leaves littering the ground are occasionally lifted by the breeze to dance across the yard.";
                case "TV":
                    return "When you turn on the television, there is nothing but static. The cable must be out again.";
                case "BLINKING ANSWERING MACHINE":
                    location.ReplaceItem(itemName, ITEMS.ANSWERING_MACHINE);
                    return "You have two new voice messages. First message:\n"
                        + "\"Hello, this is an automated message from the Salem Community Cable Company. There have been reports of a downed line in your area. We are sending a crew out to evaluate shortly, and you can expect an outage of 48-72 hours. Thank you.\"\n"
                        + "Second message:\n"
                        + "\"Hey, this is Lara from next door. I think the storm knocked down another tree last night, and the TV is on the fritz again. Can you try to fix it? Those goons from the cable company always take ages to drive out here from the city, and I don't want to miss the big game tonight! Talk to you later.\"";
                case "ANSWERING MACHINE":
                    return "There are no new messages.";
                default:
                    return $"{itemName} is not very exciting";
            }
        }
        static string nap(string itemName, Location location)
        {
            return $"You take a quick nap in the {itemName}.";
        }
        static string sleep(string itemName, Location location)
        {
            return $"You take a long snooze in the {itemName}.";
        }
    }
}

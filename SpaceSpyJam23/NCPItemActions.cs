using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSpyJam23
{
    public partial class ItemFactory
    {
        static string throwRocks(string itemName, Location location, Player player)
        {
            if (!player.InventoryContainsItem(ITEMS.ROCKS))
            {
                return "You don't have any rocks to throw.";
            }
            else
            {
                player.RemoveItem(ITEMS.ROCKS);
                switch(itemName)
                {
                    case "SQUIRREL":
                        player.IncrementSkillValue(SKILLS.SQUIRREL_KARMA, -1);
                        location.RemoveOrReplaceItem(itemName, ITEMS.ANGRY_SQUIRREL);
                        return $"You throw a handful of rocks at the {itemName}. The {itemName} becomes angry!";
                    case "ANGRY SQUIRREL":
                        player.IncrementSkillValue(SKILLS.SQUIRREL_KARMA, -1);
                        location.RemoveOrReplaceItem(itemName, null);
                        return $"You throw a handful of rocks at the {itemName}. The {itemName} scampers away.";
                    default:
                        throw new NotImplementedException();
                }
            }
            
        }

        static string giveAcorn(string itemName, Location location, Player player)
        {
            if (!player.InventoryContainsItem(ITEMS.ACORN))
            {
                return "You don't have an acorn to give.";
            }
            else
            {
                player.RemoveItem(ITEMS.ACORN);
                player.IncrementSkillValue(SKILLS.SQUIRREL_KARMA, 1);
                switch (itemName)
                {
                    case "SQUIRREL":
                        if (player.SkillValues[SKILLS.SQUIRREL_KARMA] > 0)
                        {
                            player.PickUpItem(ItemFactory.GenerateItem(ITEMS.APPLE));
                            return $"The {itemName} is delighted by your gift. In return, it offers you an apple.";
                        }
                        else
                        {
                            return $"The {itemName} cautiously accepts your gift.";
                        }
                        
                    case "ANGRY SQUIRREL":
                        location.RemoveOrReplaceItem(itemName, ITEMS.SQUIRREL);
                        return $"The {itemName} cautiously accepts your gift.";
                    default:
                        throw new NotImplementedException();
                }
            }

        }
    }
}

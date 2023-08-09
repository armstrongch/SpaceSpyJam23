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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Timers;

namespace SpaceSpyJam23
{
    public partial class Game
    {
        //Returns the player's starting location.
        private Location BuildWorld()
        {
            Item bed = ItemFactory.GenerateItem(ITEMS.BED);
            Item woodstove = ItemFactory.GenerateItem(ITEMS.WOOD_STOVE);
            Item window = ItemFactory.GenerateItem(ITEMS.WINDOW);

            Location home = new Location(
                "HOME", "A cozy log cabin.",
                new List<Item>() { bed, woodstove, window },
                new Dictionary<string, string>()
                {
                    { "DOOR", "FRONT YARD" }
                });

            Location frontYard = new Location(
                "FRONT YARD", "A rectangular patch of leaf-strewn grass, surrounded by dense forest on three sides.",
                new List<Item>() { },
                new Dictionary<string, string>()
                {
                    { "YOUR HOUSE", "HOME" }
                });



            Locations.Add(home);
            Locations.Add(frontYard);

            return home;
        }

        private void SetupPlayerInventory()
        {
            //Player.PickUpItem(ItemFactory.GenerateItem(ITEMS.WALLET));
        }
    }
}
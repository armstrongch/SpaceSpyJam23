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
            Item tv = ItemFactory.GenerateItem(ITEMS.TV);
            Item answeringMachine = ItemFactory.GenerateItem(ITEMS.BLINKING_ANSWERING_MACHINE);

            Location home = new Location(
                "HOME", "A cozy log cabin.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>()
                {
                    { "DOOR", "FRONT YARD" }
                });

            Location frontYard = new Location(
                "FRONT YARD", "A rectangular patch of leaf-strewn grass, surrounded by dense forest on three sides.",
                new List<Item>()
                {
                    ItemFactory.GenerateItem(ITEMS.DEBRIS),
                    ItemFactory.GenerateItem(ITEMS.DEBRIS),
                    ItemFactory.GenerateItem(ITEMS.SQUIRREL),
                },
                new Dictionary<string, string>()
                {
                    { "YOUR HOUSE", "HOME" },
                });

            Location dogPark = new Location(
                "DOG PARK", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>() { });

            Location playground = new Location(
                "PLAYGROUND", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>() { });

            Location cornfield = new Location(
                "CORNFIELD", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>() { });

            Location pumpkinPatch = new Location(
                "PUMPKIN PATCH", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>() { });

            Location orchard = new Location(
                "ORCHARD", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>() { });

            Location graveyard = new Location(
                "GRAVEYARD", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>() { });

            Location fireRoad = new Location(
                "FIRE ROAD", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>() { });

            Location hilltop = new Location(
                "HILLTOP", "Desc goes here.",
                new List<Item>() { bed, woodstove, window, tv, answeringMachine },
                new Dictionary<string, string>()
                {
                    { "ZIPLINE", "FRONT YARD" },
                });

            ConnectLocations(frontYard, dogPark);
            ConnectLocations(frontYard, playground);
            ConnectLocations(dogPark, playground);

            ConnectLocations(dogPark, cornfield);
            ConnectLocations(playground, pumpkinPatch);
            ConnectLocations(cornfield, pumpkinPatch);

            ConnectLocations(cornfield, orchard);
            ConnectLocations(pumpkinPatch, graveyard);
            ConnectLocations(orchard, graveyard);

            ConnectLocations(orchard, fireRoad);
            ConnectLocations(fireRoad, hilltop);

            Locations.Add(home);
            Locations.Add(frontYard);
            Locations.Add(dogPark);
            Locations.Add(playground);
            Locations.Add(cornfield);
            Locations.Add(pumpkinPatch);
            Locations.Add(orchard);
            Locations.Add(graveyard);
            Locations.Add(fireRoad);
            Locations.Add(hilltop);
            
            return home;
        }

        private void SetupPlayerInventory()
        {
            //Player.PickUpItem(ItemFactory.GenerateItem(ITEMS.WALLET));
        }

        private void ConnectLocations(Location loc1, Location loc2)
        {
            loc1.AddExit(loc2.Name, loc2.Name);
            loc2.AddExit(loc1.Name, loc1.Name);
        }
    }
}
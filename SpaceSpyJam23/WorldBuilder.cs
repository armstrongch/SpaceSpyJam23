using System.Collections.Generic;

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
            Item axe = ItemFactory.GenerateItem(ITEMS.AXE);
            Item fallenTree = ItemFactory.GenerateItem(ITEMS.FALLEN_TREE);

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
                    axe,
                    ItemFactory.GenerateItem(ITEMS.DEBRIS),
                    ItemFactory.GenerateItem(ITEMS.DEBRIS),
                    ItemFactory.GenerateItem(ITEMS.SQUIRREL),
                },
                new Dictionary<string, string>()
                {
                    { "YOUR HOUSE", "HOME" },
                });

            Location orchard = new Location(
                "ORCHARD", "A few rows of trees, branches heavy with ripe apples.",
                new List<Item>() { },
                new Dictionary<string, string>() { });

            Location graveyard = new Location(
               "GRAVEYARD", "A small field of irregularly shaped tombstones, slightly overgrown and scattered with wildflowers.",
               new List<Item>() { },
               new Dictionary<string, string>() { });

            Location fireRoad = new Location(
                "FIRE ROAD", "A narrow gravel trail, cutting a steep path upwards into the forest.",
                new List<Item>() { },
                new Dictionary<string, string>() { });

            Location hilltop = new Location(
                "HILLTOP", "A wooded clearing several hundred feet above the road, offering a birds-eye view of the fiery Fall colors.",
                new List<Item>() { fallenTree },
                new Dictionary<string, string>()
                {
                    { "ZIPLINE", "FRONT YARD" },
                });

            ConnectLocations(frontYard, orchard);
            ConnectLocations(orchard, graveyard);
            ConnectLocations(graveyard, fireRoad);
            ConnectLocations(fireRoad, hilltop);

            
            Locations.Add(home);
            Locations.Add(frontYard);
            Locations.Add(orchard);
            Locations.Add(graveyard);
            Locations.Add(fireRoad);
            Locations.Add(hilltop);
            
            return home;
        }

        private void SetupPlayerInventory()
        {

        }

        private void ConnectLocations(Location loc1, Location loc2)
        {
            loc1.AddExit(loc2.Name, loc2.Name);
            loc2.AddExit(loc1.Name, loc1.Name);
        }
    }
}
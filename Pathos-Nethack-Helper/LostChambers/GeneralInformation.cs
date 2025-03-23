using System.Collections.Generic;

namespace Pathos_Nethack_Helper.LostChambers
{
    /**
     * Information that isn't critical to the function of this program. Stuff like what the rooms
     * look like, 
     */
    public class GeneralInformation
    {
        private static Dictionary<LostChamber.RoomName, string> roomDescriptions = new Dictionary<LostChamber.RoomName, string>()
        {
            {LostChamber.RoomName.Mindflayers, "The only room containing more than one mindflayer. Also the boss room"},
            {LostChamber.RoomName.Succubi, "Contains primarily succubus and incubus creatures. May spawn a few other demon types, but they should be rare and few"},
            {LostChamber.RoomName.Boulders, "Filled with boulders all around and spread out. There are gold ones at the room's edges"},
            {LostChamber.RoomName.Entrance, "The exit to the dungeon. Has three fake walls with nothing, more nothing, and a mindflayer behind them. Not in that order"},
            {LostChamber.RoomName.Graveyard, "Lots of graves. Only undead spawn here"},
            {LostChamber.RoomName.Bugs, "Not to be confused with spiders. These are fleas and their exterminators are on the job!"},
            {LostChamber.RoomName.Zoo, "Four hidden walls, four different biomes. Lava, grass, honeycomb, and ice. May contain Sasquatch!"},
            {LostChamber.RoomName.Lava, "Filled with lava and the giants to go with it"},
            {LostChamber.RoomName.Corpses, "Everything is already dead. Weird... Nothing in here to do except eat I guess"},
            {LostChamber.RoomName.Boons, "Four people willing to trade karma for useful acts like enchantment, blessing, etc. Beware though, they are currently insane and may attack if you stay too long"},
            {LostChamber.RoomName.Water, "Filled with water. One side has a fountain trapped with amnesia"},
            {LostChamber.RoomName.Merchants, "Four shopkeeps. Buy and sell whatever you want, but they are currently insane and may attack if you stay too long"},
            {LostChamber.RoomName.Ice, "The floor is all ice and the enemies are too"},
            {LostChamber.RoomName.Rocks, "Every spot has a pile of rocks. Maybe it was once a boulder before the native giants got ahold of them"},
            {LostChamber.RoomName.Grove, "A lush green pasture with some trees and a bunch of elves. Enemies spawn here but not many"},
            {LostChamber.RoomName.Mimics, "Doppelgangers by the entrance, and treasure abounds! Or does it?"},
            {LostChamber.RoomName.Traps, "You arrive surrounded by trapped boulders only to find many more traps beyond. Nothing here worth that danger"},
            {LostChamber.RoomName.Yeoman, "It's just a room full of Yeoman... Orcs wil eventually kill them but for now it's just them"},
            {LostChamber.RoomName.Labyrinth, "Tight dark hallways and not much else. The center portal doesn't seem to be working here..."},
            {LostChamber.RoomName.Nurses, "A good place to get hurt. Filled with nurses and for some reason those quantum weirdos"},
            {LostChamber.RoomName.Spiders, "Not to be confused with 'Bugs', this room contains only spiders, but MANY of those"},
        };

        public static Dictionary<LostChamber.RoomName, string> RoomDescriptions()
        {
            return roomDescriptions ?? (roomDescriptions = new Dictionary<LostChamber.RoomName, string>());
        }

        public static string getRoomDescription(LostChamber.RoomName roomName)
        {
            return RoomDescriptions()[roomName];
        }
    }
}
using System;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class LostChamber
    {
        public RoomName CurrentRoomName { get; }
        // Each room can rotate. This tracks clockwise 90 deg intervals
        public int RotationFromOriginalMap { get; set; } = -99;

        public RoomName NorthWest { get; set; }
        public RoomName SouthEast { get; set; }
        public RoomName NorthEast { get; set; }
        public RoomName SouthWest { get; set; }
        public RoomName Center { get; set; }
        public RotationQuestion OrientationQuestion { get; set; }

        public LostChamber(RoomName currentRoomName)
        {
            CurrentRoomName = currentRoomName;
        }

        public LostChamber(RoomName currentRoomName, RoomName northWest, RoomName southEast, RoomName northEast,
            RoomName southWest, RoomName center)
        {
            CurrentRoomName = currentRoomName;
            NorthWest = northWest;
            SouthEast = southEast;
            NorthEast = northEast;
            SouthWest = southWest;
            Center = center;
        }

        public bool OrientationIsDetermined()
        {
            return OrientationQuestion != null && RotationFromOriginalMap != -99;
        }

        /**
         * An easy way to remember each room by a moniker
         */
        public enum RoomName
        {
            Mindflayers,
            Succubi,
            Boulders,
            Entrance,
            Graveyard,
            Bugs,
            Zoo,
            Lava,
            Corpses,
            Boons,
            Water,
            Merchants,
            Ice,
            Rocks,
            Grove,
            Mimics,
            Traps,
            Yeoman,
            Labyrinth,
            Nurses,
            Spiders,
            Unknown
        }
    }
}
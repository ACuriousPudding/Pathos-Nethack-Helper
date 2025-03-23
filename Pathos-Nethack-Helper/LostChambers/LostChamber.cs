using System;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class LostChamber
    {
        RoomName roomName;
        // Each room can rotate. This tracks clockwise 90 deg intervals
        private int rotationFromOriginalMap;

        private LostChamber northWest = null;
        private LostChamber southEast = null;
        private LostChamber northEast = null;
        private LostChamber southWest = null;
        private LostChamber center = null;
        
        private bool orientationDetermined = false;
        private String orientationQuestion = null;

        public LostChamber(RoomName roomName, LostChamber northWest, LostChamber southEast, LostChamber northEast,
            LostChamber southWest, LostChamber center)
        {
            this.roomName = roomName;
            this.northWest = northWest ?? throw new ArgumentNullException(nameof(northWest));
            this.southEast = southEast ?? throw new ArgumentNullException(nameof(southEast));
            this.northEast = northEast ?? throw new ArgumentNullException(nameof(northEast));
            this.southWest = southWest ?? throw new ArgumentNullException(nameof(southWest));
            this.center = center ?? throw new ArgumentNullException(nameof(center));
        }

        public LostChamber(RoomName roomName)
        {
            this.roomName = roomName;
        }

        public RoomName GetRoomName
        {
            get => roomName;
            set => roomName = value;
        }

        public int GetRotationFromOriginalMap
        {
            get => rotationFromOriginalMap;
            set => rotationFromOriginalMap = value;
        }

        public LostChamber GetNorthWest
        {
            get => northWest;
            set => northWest = value;
        }

        public LostChamber GetSouthEast
        {
            get => southEast;
            set => southEast = value;
        }

        public LostChamber GetNorthEast
        {
            get => northEast;
            set => northEast = value;
        }

        public LostChamber GetSouthWest
        {
            get => southWest;
            set => southWest = value;
        }

        public LostChamber GetCenter
        {
            get => center;
            set => center = value;
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
            Spiders
        }
    }
}
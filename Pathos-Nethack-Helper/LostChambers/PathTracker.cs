using System;
using System.Collections;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class PathTracker
    {
        private ArrayList _visitedRooms = new ArrayList();
        private LostChamber _currentRoom = null;
        public bool DeadPath = false;
        private PortalData _portalData;

        public PathTracker(PortalData portalData)
        {
            _portalData = portalData;
        }

        public void Visit(int portalNum)
        {
            LostChamber.RoomName nextRoom;
            switch (portalNum)
            {
                case 0:
                    nextRoom = _currentRoom.Center;
                    break;
                case 1:
                    nextRoom = _currentRoom.NorthWest;
                    break;
                case 2:
                    nextRoom = _currentRoom.NorthEast;
                    break;
                case 3:
                    nextRoom = _currentRoom.SouthWest;
                    break;
                case 4:
                    nextRoom = _currentRoom.SouthEast;
                    break;
                default:
                    throw new ArgumentException("Invalid portal number.");
            }

            if (_visitedRooms.Contains(nextRoom))
            {
                this.DeadPath = true;
                return;
            }
            else
            {
                _visitedRooms.Add(nextRoom);
                _currentRoom = _portalData.GetChamber(nextRoom);
            }
        }
        
    }
}
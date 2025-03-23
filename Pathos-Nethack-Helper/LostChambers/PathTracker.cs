using System;
using System.Collections;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class PathTracker
    {
        private ArrayList _visitedRooms = new ArrayList();
        private LostChamber _currentRoom = null;
        public bool DeadPath = false;

        public void Visit(int portalNum)
        {
            LostChamber nextRoom = null;
            switch (portalNum)
            {
                case 0:
                    nextRoom = _currentRoom.GetCenter;
                    break;
                case 1:
                    nextRoom = _currentRoom.GetNorthWest;
                    break;
                case 2:
                    nextRoom = _currentRoom.GetNorthEast;
                    break;
                case 3:
                    nextRoom = _currentRoom.GetSouthWest;
                    break;
                case 4:
                    nextRoom = _currentRoom.GetSouthEast;
                    break;
                default:
                    throw new ArgumentException("Invalid portal number.");
            }

            if (_visitedRooms.Contains(nextRoom.GetRoomName))
            {
                this.DeadPath = true;
                return;
            }
            else
            {
                _visitedRooms.Add(nextRoom.GetRoomName);
                _currentRoom = nextRoom;
            }
        }
        
    }
}
using System.Collections.Generic;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class PortalData
    {
        private static Dictionary<LostChamber.RoomName, RotationQuestion> _rotationQuestions = null;

        private static Dictionary<LostChamber.RoomName, LostChamber> RoomsByName { get; } =
            new Dictionary<LostChamber.RoomName, LostChamber>();
        
        private static Dictionary<LostChamber.RoomName, LostChamber.RoomName[]> _originalPortalData = new Dictionary<LostChamber.RoomName, LostChamber.RoomName[]>()
        {
            { LostChamber.RoomName.Mindflayers, new [] { LostChamber.RoomName.Entrance } },
            { LostChamber.RoomName.Succubi, new [] { LostChamber.RoomName.Nurses, LostChamber.RoomName.Boulders, LostChamber.RoomName.Nurses, LostChamber.RoomName.Succubi, LostChamber.RoomName.Entrance } },
            { LostChamber.RoomName.Boulders, new [] { LostChamber.RoomName.Succubi, LostChamber.RoomName.Yeoman, LostChamber.RoomName.Graveyard, LostChamber.RoomName.Ice, LostChamber.RoomName.Bugs } },
            { LostChamber.RoomName.Entrance, new [] { LostChamber.RoomName.Entrance, LostChamber.RoomName.Water, LostChamber.RoomName.Ice, LostChamber.RoomName.Boulders, LostChamber.RoomName.Corpses } },
            { LostChamber.RoomName.Graveyard, new [] { LostChamber.RoomName.Boons, LostChamber.RoomName.Labyrinth, LostChamber.RoomName.Rocks, LostChamber.RoomName.Spiders, LostChamber.RoomName.Merchants } },
            { LostChamber.RoomName.Bugs, new [] { LostChamber.RoomName.Merchants, LostChamber.RoomName.Corpses, LostChamber.RoomName.Succubi, LostChamber.RoomName.Lava, LostChamber.RoomName.Yeoman } },
            { LostChamber.RoomName.Zoo, new [] { LostChamber.RoomName.Entrance, LostChamber.RoomName.Spiders, LostChamber.RoomName.Graveyard, LostChamber.RoomName.Boons, LostChamber.RoomName.Boulders } },
            { LostChamber.RoomName.Lava, new [] { LostChamber.RoomName.Ice, LostChamber.RoomName.Succubi, LostChamber.RoomName.Mindflayers, LostChamber.RoomName.Succubi, LostChamber.RoomName.Nurses } },
            { LostChamber.RoomName.Corpses, new [] { LostChamber.RoomName.Labyrinth, LostChamber.RoomName.Corpses, LostChamber.RoomName.Corpses, LostChamber.RoomName.Corpses, LostChamber.RoomName.Corpses } },
            { LostChamber.RoomName.Boons, new [] { LostChamber.RoomName.Grove, LostChamber.RoomName.Succubi, LostChamber.RoomName.Grove, LostChamber.RoomName.Boulders, LostChamber.RoomName.Entrance } },
            { LostChamber.RoomName.Water, new [] { LostChamber.RoomName.Zoo, LostChamber.RoomName.Labyrinth, LostChamber.RoomName.Yeoman, LostChamber.RoomName.Lava, LostChamber.RoomName.Nurses } },
            { LostChamber.RoomName.Merchants, new [] { LostChamber.RoomName.Graveyard, LostChamber.RoomName.Lava, LostChamber.RoomName.Ice, LostChamber.RoomName.Water, LostChamber.RoomName.Boons } },
            { LostChamber.RoomName.Ice, new [] { LostChamber.RoomName.Lava, LostChamber.RoomName.Mimics, LostChamber.RoomName.Boons, LostChamber.RoomName.Bugs, LostChamber.RoomName.Grove } },
            { LostChamber.RoomName.Rocks, new [] { LostChamber.RoomName.Ice, LostChamber.RoomName.Rocks, LostChamber.RoomName.Rocks, LostChamber.RoomName.Traps, LostChamber.RoomName.Nurses } },
            { LostChamber.RoomName.Grove, new [] { LostChamber.RoomName.Mimics, LostChamber.RoomName.Entrance, LostChamber.RoomName.Boons, LostChamber.RoomName.Traps, LostChamber.RoomName.Merchants } },
            { LostChamber.RoomName.Mimics, new [] { LostChamber.RoomName.Zoo, LostChamber.RoomName.Succubi, LostChamber.RoomName.Water, LostChamber.RoomName.Labyrinth, LostChamber.RoomName.Merchants } },
            { LostChamber.RoomName.Traps, new [] { LostChamber.RoomName.Yeoman, LostChamber.RoomName.Graveyard, LostChamber.RoomName.Succubi, LostChamber.RoomName.Traps, LostChamber.RoomName.Corpses } },
            { LostChamber.RoomName.Yeoman, new [] { LostChamber.RoomName.Zoo, LostChamber.RoomName.Corpses, LostChamber.RoomName.Bugs, LostChamber.RoomName.Entrance, LostChamber.RoomName.Boulders } },
            { LostChamber.RoomName.Labyrinth, new [] { LostChamber.RoomName.Labyrinth, LostChamber.RoomName.Corpses, LostChamber.RoomName.Grove, LostChamber.RoomName.Merchants, LostChamber.RoomName.Bugs } },
            { LostChamber.RoomName.Nurses, new [] { LostChamber.RoomName.Succubi, LostChamber.RoomName.Corpses, LostChamber.RoomName.Boulders, LostChamber.RoomName.Grove, LostChamber.RoomName.Bugs } },
            { LostChamber.RoomName.Spiders, new [] { LostChamber.RoomName.Succubi, LostChamber.RoomName.Boulders, LostChamber.RoomName.Mimics, LostChamber.RoomName.Traps, LostChamber.RoomName.Grove } },
        };
        private static Dictionary<LostChamber.RoomName, LostChamber> _chambers = new Dictionary<LostChamber.RoomName, LostChamber>();

        public Dictionary<LostChamber.RoomName, RotationQuestion> GetRotationQuestions()
        {
            if (_rotationQuestions == null)
            {
                InitRotationQuestions();
            }
            return _rotationQuestions;
        }

        public RotationQuestion getRotationQuestion(LostChamber.RoomName roomName)
        {
            if (_rotationQuestions == null)
            {
                InitRotationQuestions();
            }

            if (_rotationQuestions.ContainsKey(roomName))
            {
                return _rotationQuestions[roomName];
            }
            return null;
        }

        public bool hasRotationQuestion(LostChamber.RoomName roomName)
        {
            return _rotationQuestions.ContainsKey(roomName);
        }

        public LostChamber GetChamber(LostChamber.RoomName roomName)
        {
            if (_chambers == null || _chambers.Count == 0)
            {
                CreatePortalMap();
            }
            return _chambers[roomName];
        }

        public Dictionary<LostChamber.RoomName, LostChamber> CreatePortalMap()
        {
            return CreatePortalMap(_originalPortalData);
        }

        public Dictionary<LostChamber.RoomName, LostChamber> CreatePortalMap(Dictionary<LostChamber.RoomName, LostChamber.RoomName[]> inputPortalData)
        {
            Dictionary<LostChamber.RoomName, LostChamber.RoomName[]> portalData = inputPortalData == null ? _originalPortalData : inputPortalData;
            Dictionary<LostChamber.RoomName, LostChamber> results = new Dictionary<LostChamber.RoomName, LostChamber>();
            
            var keyEnum = portalData.Keys.GetEnumerator();
            while (keyEnum.MoveNext())
            {
                var thisChamber = new LostChamber(keyEnum.Current);
                var thisChamberData = portalData[keyEnum.Current];
                thisChamber.Center = thisChamberData[0];
                thisChamber.NorthWest = thisChamberData[1];
                thisChamber.NorthEast = thisChamberData[2];
                thisChamber.SouthWest = thisChamberData[3];
                thisChamber.SouthEast = thisChamberData[4];
                thisChamber.OrientationQuestion = getRotationQuestion(thisChamber.CurrentRoomName);
                results.Add(keyEnum.Current, thisChamber);
            }

            return results;
        }

        /*
         * The rotation questions are based on the original map. The rotation is clockwise, so the first
         * value in the string array indicates a 0 degrees rotation, the second is 90 degrees, etc. The
         * questions are based on the original map data recorded manually. The first answer is the value
         * matching that rotation data. The other answers represent a rotation of that "default" case.
         */
        private void InitRotationQuestions()
        {
            _rotationQuestions = new Dictionary<LostChamber.RoomName, RotationQuestion>();
            RotationQuestion entranceQuestion = new RotationQuestion(LostChamber.RoomName.Entrance, 
                // The entrance room has four fake walls. Two have mindflayers, and two have open/empty chests.
                // The Mindflayers are accross from each other, and the chests are across from each other.
                // The chest on one wall is centered, and the other is offset. This relative orientation is consistent.
                "Of the four fake walls, in which direction is the centered chest hidden?",
                new string[]{"East", "South", "West", "North"});
            _rotationQuestions.Add(entranceQuestion.RoomForQuestion, entranceQuestion);
            
            RotationQuestion waterQuestion = new RotationQuestion(LostChamber.RoomName.Water,
                // The water room has a single fountain out of sight from the entrance portal and centered on one wall.
                "Which direction is the fountain?",
                new string[]{"West", "North", "East", "South"});
            _rotationQuestions.Add(waterQuestion.RoomForQuestion, waterQuestion);
            
            RotationQuestion zooQuestion = new RotationQuestion(LostChamber.RoomName.Zoo,
                "Of the four biomes in this room, which direction is the grass?",
                new string[]{"North-East", "South-East", "South-West", "North-West"});
            _rotationQuestions.Add(zooQuestion.RoomForQuestion, zooQuestion);

            RotationQuestion graveyardQuestion = new RotationQuestion(LostChamber.RoomName.Graveyard,
                "There are two graves touching the blue portal that can be used to make a line to a nearby wall segment. Which direction on that line has a wall segment with two graves touching it?",
                new string[]{"South", "West", "North", "East"});
            _rotationQuestions.Add(graveyardQuestion.RoomForQuestion, graveyardQuestion);
            
            RotationQuestion labyrinthQuestion = new RotationQuestion(LostChamber.RoomName.Labyrinth,
                "There are four paths from the blue portal. One of them is only one square. Which direction is that one-square path?",
                new string[]{"West", "North", "East", "South"});
            _rotationQuestions.Add(labyrinthQuestion.RoomForQuestion, labyrinthQuestion);
            
            RotationQuestion groveQuestion = new RotationQuestion(LostChamber.RoomName.Grove,
                "Which direction from the blue portal has a tree within two spaces?",
                new string[]{"East", "South", "West", "North"});
            _rotationQuestions.Add(groveQuestion.RoomForQuestion, groveQuestion);
        }
            
        
        
    }
}
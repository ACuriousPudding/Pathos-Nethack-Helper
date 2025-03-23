using System.Collections.Generic;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class PortalData
    {
        private static Dictionary<LostChamber.RoomName, RotationQuestion> _rotationQuestions = null;
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
                initRotationQuestions();
            }
            return _rotationQuestions;
        }

        public RotationQuestion getRotationQuestion(LostChamber.RoomName roomName)
        {
            if (_rotationQuestions == null)
            {
                initRotationQuestions();
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
        
        public Dictionary<LostChamber.RoomName, LostChamber> FillPortalMap(Dictionary<LostChamber.RoomName, LostChamber.RoomName[]> portalData)
        {
            
        }

        private void initRotationQuestions()
        {
            _rotationQuestions = new Dictionary<LostChamber.RoomName, RotationQuestion>();
            RotationQuestion entranceQuestion = new RotationQuestion(LostChamber.RoomName.Entrance, 
                "Of the three fake walls, in which direction is the mind flayer hidden?",
                new string[]{"North", "East", "South", "West"});
            _rotationQuestions.Add(entranceQuestion.RoomName, entranceQuestion);
            
            RotationQuestion waterQuestion = new RotationQuestion(LostChamber.RoomName.Water,
                "Which direction is the fountain?",
                new string[]{"West", "North", "East", "South"});
            _rotationQuestions.Add(waterQuestion.RoomName, waterQuestion);
            
            RotationQuestion zooQuestion = new RotationQuestion(LostChamber.RoomName.Zoo,
                "Of the four biomes in this room, which direction is the grass?",
                new string[]{"North-East", "South-East", "South-West", "North-West"});
            _rotationQuestions.Add(zooQuestion.RoomName, zooQuestion);

            RotationQuestion graveyardQuestion = new RotationQuestion(LostChamber.RoomName.Graveyard,
                "There are two graves touching the blue portal that can be used to make a line to a nearby wall segment. Which direction on that line has a wall segment with two graves touching it?",
                new string[]{"South", "West", "North", "East"});
            _rotationQuestions.Add(graveyardQuestion.RoomName, graveyardQuestion);
            
            RotationQuestion labyrinthQuestion = new RotationQuestion(LostChamber.RoomName.Labyrinth,
                "There are four paths from the blue portal. One of them is only one square. Which direction is that one-square path?",
                new string[]{"West", "North", "East", "South"});
            _rotationQuestions.Add(labyrinthQuestion.RoomName, labyrinthQuestion);
            
            RotationQuestion groveQuestion = new RotationQuestion(LostChamber.RoomName.Grove,
                "Which direction from the blue portal has a tree within two spaces?",
                new string[]{"East", "South", "West", "North"});
            _rotationQuestions.Add(groveQuestion.RoomName, groveQuestion);
        }
            
        
        
    }
}
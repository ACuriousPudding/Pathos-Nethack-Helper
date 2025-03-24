using System;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class RotationQuestion
    {
        public RotationQuestion(LostChamber.RoomName roomForQuestion, string questionText, string[] answers)
        {
            RoomForQuestion = roomForQuestion;
            QuestionText = questionText;
            Answers = answers;
        }

        public LostChamber.RoomName RoomForQuestion { get; set; }
        public string QuestionText { get; set; }
        
        /** Any answers must be listed in ascending order of rotation distance. The first answer will
         * be 0 degrees, second will be 90 degrees, etc.
         */
        public string[] Answers { get; set; }
    }
}
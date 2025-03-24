using System;

namespace Pathos_Nethack_Helper.LostChambers
{
    /**
     * A question that can be asked to determine the orientation of a room. The index of the answer value
     * indicates the number of 90 degree rotations clockwise from the original map, with 0 being the original
     * map, 1 being 90 degrees clockwise, 2 being 180 degrees, and 3 being 270 degrees clockwise.
     */
    public class RotationQuestion
    {

        /**
         * Constructor for the RotationQuestion class.
         * <p>
         * The answers must be listed in ascending order of rotation distance. The first answer will
         * be 0 degrees, the second will be 90 degrees, etc.
         * <p>
         * @param roomForQuestion The room for which the question applies.
         * @param questionText The text of the question. This is the text that is displayed to the user.
         * @param answers A string array of the possible answers to the question. Array must be of length 4.
         * @return A RotationQuestion object.
         */
        public RotationQuestion(LostChamber.RoomName roomForQuestion, string questionText, string[] answers)
        {
            RoomForQuestion = roomForQuestion;
            QuestionText = questionText;
            Answers = answers;
        }

        // TODO: Add validation to check if room is a valid LostChamber.RoomName value
        public LostChamber.RoomName RoomForQuestion { get; set; }
        public string QuestionText { get; set; }
        
        // TODO: Add validation to the setter to ensure the array length is 4.
        /** Any answers must be listed in ascending order of rotation distance. The first answer will
         * be 0 degrees, second will be 90 degrees, etc.
         */
        public string[] Answers { get; set; }
    }
}
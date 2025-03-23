using System;

namespace Pathos_Nethack_Helper.LostChambers
{
    public class RotationQuestion
    {
        LostChamber.RoomName roomName;
        string rotationQuestion = null;
        /** Any answers must be listed in ascending order of rotation distance. The first answer will
         * be 0 degrees, second will be 90 degrees, etc.
         */
        string[] answers = null;

        public LostChamber.RoomName RoomName
        {
            get => roomName;
            set => roomName = value;
        }

        public string RotationQuestion1
        {
            get => rotationQuestion;
            set => rotationQuestion = value;
        }

        public string[] Answers
        {
            get => answers;
            set => answers = value;
        }

        public RotationQuestion(LostChamber.RoomName roomName, string rotationQuestion, string[] answers)
        {
            this.roomName = roomName;
            this.rotationQuestion = rotationQuestion ?? throw new ArgumentNullException(nameof(rotationQuestion));
            this.answers = answers ?? throw new ArgumentNullException(nameof(answers));
        }
    }
}
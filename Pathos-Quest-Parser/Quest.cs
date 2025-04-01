namespace Pathos_Nethack_Helper.PathosQuestParser
{
    public class Quest
    {
        public string Name { get; set; }
        public string FilePath { get; set; }

        public Quest(string name, string filepath)
        {
            Name = name;
            FilePath = filepath;
        }

        public override string ToString()
        {
            return $"Quest: {Name}\n" +
                   $"FilePath: {FilePath}";
        }
    }
}
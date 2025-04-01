namespace Pathos_Nethack_Helper.PathosQuestParser
{
    public class Quest
    {
        public string? Name { get; set; }
        public string FilePath { get; set; }

        public Quest(string filepath)
        {
            FilePath = filepath;
            // DEBUG: Go ahead and create the tokenizer here for testing
            Tokenizer tokenizer = new Tokenizer(FilePath);
            tokenizer.Parse();
        }

        public override string ToString()
        {
            return $"FilePath: {FilePath}";
        }

        public void Query()
        {
            // TODO: Determine return type
            // TODO: Query quest data based on type
            Console.WriteLine("Quest.Query() not implemented");
        }
    }
}
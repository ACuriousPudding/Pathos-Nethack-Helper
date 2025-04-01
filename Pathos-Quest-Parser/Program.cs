using System;
using Pathos_Nethack_Helper.PathosQuestParser;

Console.WriteLine("DEBUG: Starting Program.cs");
// TODO: Take commandline arguments
// TODO: Add interactive CLI menu for querying Quest data
// DEBUG: Hard-coded test file
string testFilePath = "./prototype/Chambers.Quest";
// chambers = new Quest(testFilePath);

Console.WriteLine($"Creating Tokenizer with filepath {testFilePath}");
Tokenizer tokenizer = new Tokenizer(testFilePath);

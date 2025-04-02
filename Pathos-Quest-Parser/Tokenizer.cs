using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Pathos_Nethack_Helper.PathosQuestParser
{
    public class Tokenizer
    {
        private string FilePath = "";

        // Constructor
        public Tokenizer(string filePath)
        {
            this.FilePath = filePath;
        }
        
        public void Parse()
        {
            Console.WriteLine("Tokenizer.Parse() not fully implemented.");
            // Read the file and tokenize the lines
            this.ParseFile();

            // Create TokenGroups from the tokenized lines
        }

        public List<List<string>> ParseFile()
        {
            Console.WriteLine("Tokenizer.ParseFile() called");
            // Initialize a nested list of token lists. Each list models a line of the .Quest file.
            List<List<string>> tokenizedLines = new List<List<string>>();
            // Read the file line by line, tokenizing each line and inserting it into the list
            foreach (string line in File.ReadLines(this.FilePath))
            {
                Console.WriteLine($"Reading line: {line}");
                List<string> tokenizedLine = this.ParseLine(line);
                Console.WriteLine($"Number of Tokens found: {tokenizedLine.Count}");
                // Add the tokenized line to the list. It's fine if the list is empty; that's used as a flag later.
                tokenizedLines.Add(tokenizedLine);
            }

            return tokenizedLines;
        }

        private List<string> ParseLine(string line)
        {
            Console.WriteLine("Tokenizer.ParseLine() called.");
            List<string> tokens = new List<string>();

            string currentToken = "";
            bool inBrackets = false;
            foreach (char c in line)
            {
                // Case: Open Brackets
                // When the character is an opening bracket, we want to escape any whitespace inside it
                if (c == '[' && !inBrackets)
                {
                    inBrackets = true;
                    // If a current token exists, finalize it and start a new one
                    if (!string.IsNullOrEmpty(currentToken) && currentToken != "@")
                    {
                        tokens.Add(currentToken);
                        currentToken = c.ToString();
                    } else {
                        // Start a new token with the '[' character
                        currentToken += c.ToString();
                    }
                    continue;
                }
                // Case: Close Brackets
                if (c == ']' && inBrackets)
                {
                    inBrackets = false;
                    // When the character is a closing bracket AND we're inside brackets, finalize the token
                    currentToken += c.ToString();
                    tokens.Add(currentToken);
                    currentToken = "";
                    continue;
                }
                // Case: Whitespace or Semicolon delimiter
                // TODO: determine what to do if the semi-colon isn't at the end of the line and is used inside a line as a legit character
                if ((c == ' ' || c == ';') && !inBrackets)
                {
                    // If we encounter a space or semicolon and we're not in brackets, finalize the current token
                    if (!string.IsNullOrEmpty(currentToken) && currentToken != "@")
                    {
                        tokens.Add(currentToken);
                        currentToken = "";
                    }
                    continue;
                }
                // Otherwise, keep building the current token
                currentToken += c.ToString();
            }
            // Finalize the last token if it exists
            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }

        private Dictionary<string, TokenGroup> ProcessTokens()
        {
            Console.WriteLine("Tokenizer.ProcessTokens() not implemented.");
            return new Dictionary<string, TokenGroup>();
        }
    }
}